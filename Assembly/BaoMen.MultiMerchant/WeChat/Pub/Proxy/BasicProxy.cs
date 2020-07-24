using BaoMen.MultiMerchant.Util;
using BaoMen.MultiMerchant.WeChat.Pub.BusinessLogic;
using BaoMen.WeChat.Pub.Provider;
using Microsoft.Extensions.DependencyInjection;
using System;
using Request = BaoMen.WeChat.Pub.Client.Request;
using Response = BaoMen.WeChat.Pub.Client.Response;

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
        /// <returns>access_token</returns>
        public string QueryAccessToken(string merchantId)
        {
            Config config = configBuilder.BuildPubConifg(merchantId);
            //查表
            Entity.AppAccessToken appAccessToken = appAccessTokenManager.Get(config.AppId);
            if (appAccessToken == null || appAccessToken.ExpiresTime < DateTime.Now.AddMinutes(3)) //微信刷新后保留5分钟旧的access_token，此处提前3分钟过期
            {
                Request.QueryAccessToken request = new Request.QueryAccessToken
                {
                    ApiDomain = config.ApiDomain,
                    AppId = config.AppId,
                    AppSecret = config.AppSecret
                };
                DateTime now = DateTime.Now;
                Response.QueryAccessToken response = basicProvider.QueryAccessToken(request);
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
        public Response.QueryAuthAccessToken QueryAuthAccessToken(string merchantId, string code)
        {
            Config config = configBuilder.BuildPubConifg(merchantId);
            Request.QueryAuthAccessToken request = new Request.QueryAuthAccessToken
            {
                ApiDomain = config.ApiDomain,
                AppId = config.AppId,
                AppSecret = config.AppSecret,
                Code = code
            };
            return basicProvider.QueryAuthAccessToken(request);
        }
    }
}
