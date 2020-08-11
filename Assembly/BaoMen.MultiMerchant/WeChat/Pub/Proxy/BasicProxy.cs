using BaoMen.MultiMerchant.Util;
using BaoMen.MultiMerchant.WeChat.Pub.BusinessLogic;
using BaoMen.WeChat.Pub.Provider;
using Microsoft.Extensions.DependencyInjection;
using System;
using BaoMen.WeChat.Pub.Client;
using BaoMen.WeChat.Pub.Client.Sns;

namespace BaoMen.MultiMerchant.WeChat.Pub.Proxy
{
    /// <summary>
    /// 基础代理
    /// </summary>
    public class BasicProxy : BaseProxy
    {
        private readonly IAppAccessTokenManager appAccessTokenManager;
        private readonly IAuthAccessTokenManager authAccessTokenManager;

        private readonly BasicProvider basicProvider;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="serviceProvider">服务提供程序</param>
        public BasicProxy(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            appAccessTokenManager = serviceProvider.GetRequiredService<IAppAccessTokenManager>();
            authAccessTokenManager = serviceProvider.GetRequiredService<IAuthAccessTokenManager>();
            basicProvider = serviceProvider.GetRequiredService<BasicProvider>();
        }

        /// <summary>
        /// 取得公众号的全局唯一票据
        /// </summary>
        /// <param name="merchantId">商户ID</param>
        /// <param name="config">配置</param>
        /// <returns>access_token</returns>
        public string Token(string merchantId, Config config = null)
        {
            config ??= configBuilder.BuildPubConifg(merchantId);
            //查表
            Entity.AppAccessToken appAccessToken = appAccessTokenManager.Get(config.AppId);
            if (appAccessToken == null || appAccessToken.ExpiresTime < DateTime.Now.AddMinutes(3)) //微信刷新后保留5分钟旧的access_token，此处提前3分钟过期
            {
                TokenRequest request = new TokenRequest
                {
                    ApiDomain = config.ApiDomain,
                    AppId = config.AppId,
                    AppSecret = config.AppSecret
                };
                DateTime now = DateTime.Now;
                TokenResponse response = basicProvider.Token(request);
                if (response.ErrorCode == 0)
                {
                    appAccessToken = new Entity.AppAccessToken
                    {
                        AccessToken = response.AccessToken,
                        AppId = config.AppId,
                        CreateTime = now,
                        ExpiresIn = response.ExpiresIn,
                        ExpiresTime = now.AddSeconds(response.ExpiresIn),
                        MerchantId = merchantId
                    };
                    appAccessTokenManager.InserOrUpdate(appAccessToken);
                }
                else
                {
                    throw new Exception("获取accessToken失败");
                }
            }
            return appAccessToken.AccessToken;
        }

        /// <summary>
        /// 取得网页授权的access_token
        /// </summary>
        /// <param name="merchantId">商户ID</param>
        /// <param name="code">网页授权第一步获取的code参数</param>
        /// <returns></returns>
        public AccessTokenResponse AccessToken(string merchantId, string code)
        {
            Config config = configBuilder.BuildPubConifg(merchantId);
            AccessTokenRequest request = new AccessTokenRequest
            {
                ApiDomain = config.ApiDomain,
                AppId = config.AppId,
                AppSecret = config.AppSecret,
                Code = code
            };
            DateTime now = DateTime.Now;
            AccessTokenResponse response = basicProvider.AccessToken(request);
            if (response.ErrorCode == 0)
            {
                Entity.AuthAccessToken authAccessToken = new Entity.AuthAccessToken
                {
                    AccessToken = response.AccessToken,
                    AppId = config.AppId,
                    CreateTime = now,
                    ExpiresIn = response.ExpiresIn,
                    ExpiresTime = now.AddSeconds(response.ExpiresIn),
                    MerchantId = merchantId,
                    OpenId = response.OpenId,
                    Scope = response.Scope,
                    RefreshToken = response.RefreshToken
                };
                authAccessTokenManager.InserOrUpdate(authAccessToken);
            }
            return response;
        }

        /// <summary>
        /// 拉取用户信息(需scope为 snsapi_userinfo)
        /// </summary>
        /// <param name="merchantId">商户ID</param>
        /// <param name="openId">用户微信OpenId</param>
        /// <param name="accessToken">网页授权接口调用凭证</param>
        /// <returns></returns>
        /// <remarks>
        /// 如果网页授权作用域为snsapi_userinfo，则此时开发者可以通过access_token和openid拉取用户信息了。
        /// </remarks>
        public UserInfoResponse UserInfo(string merchantId, string openId, string accessToken = null)
        {
            Config config = configBuilder.BuildPubConifg(merchantId);
            string token = accessToken;
            if (string.IsNullOrEmpty(token))
            {
                Entity.AuthAccessToken authAccessToken = authAccessTokenManager.Get(new Tuple<string, string>(config.AppId, openId));
                if (authAccessToken != null && authAccessToken.ExpiresTime > DateTime.Now.AddMinutes(3))
                {
                    token = authAccessToken.AccessToken;
                }
            }
            if (token == null) throw new ArgumentNullException("accessToken");
            UserInfoRequest request = new UserInfoRequest
            {
                ApiDomain = config.ApiDomain,
                AccessToken = token,
                OpenId = openId
            };
            return basicProvider.UserInfo(request);
        }
    }
}
