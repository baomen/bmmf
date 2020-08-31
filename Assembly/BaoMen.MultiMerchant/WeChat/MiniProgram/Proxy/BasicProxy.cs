using BaoMen.MultiMerchant.WeChat.MiniProgram.BusinessLogic;
using BaoMen.WeChat.MiniProgram.Client;
using BaoMen.WeChat.MiniProgram.Client.Basic;
using BaoMen.WeChat.MiniProgram.Provider;
using Microsoft.Extensions.DependencyInjection;
using NLog;
using System;
using System.Collections.Generic;
using System.Text;
using Client = BaoMen.WeChat.MiniProgram.Client;

namespace BaoMen.MultiMerchant.WeChat.MiniProgram.Proxy
{
    /// <summary>
    /// 基础代理
    /// </summary>
    public class BasicProxy : BaseProxy
    {
        /// <summary>
        /// 基础提供程序
        /// </summary>

        private readonly BasicProvider basicProvider;

        private readonly IAppAccessTokenManager appAccessTokenManager;
        private readonly ISessionManager sessionManager;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="serviceProvider">服务提供程序</param>
        public BasicProxy(IServiceProvider serviceProvider) : base(serviceProvider, LogManager.GetCurrentClassLogger())
        {
            basicProvider = serviceProvider.GetRequiredService<BasicProvider>();
            appAccessTokenManager = serviceProvider.GetRequiredService<IAppAccessTokenManager>();
            sessionManager = serviceProvider.GetRequiredService<ISessionManager>();
        }

        /// <summary>
        /// 获取小程序全局唯一后台接口调用凭据（access_token）。
        /// </summary>
        /// <remarks>
        /// 调用绝大多数后台接口时都需使用 access_token，开发者需要进行妥善保存。
        /// </remarks>
        /// <param name="merchantId">商户ID</param>
        /// <param name="config">配置</param>
        /// <returns></returns>
        public string GetAccessToken(string merchantId = null, Config config = null)
        {
            config ??= configBuilder.BuildMiniPorgramConifg(merchantId);
            //查表
            Entity.AppAccessToken appAccessToken = appAccessTokenManager.Get(config.AppId);
            if (appAccessToken == null || appAccessToken.ExpiresTime < DateTime.Now.AddMinutes(3)) //微信刷新后保留5分钟旧的access_token，此处提前3分钟过期
            {
                GetAccessTokenRequest request = new GetAccessTokenRequest
                {
                    ApiDomain = config.ApiDomain,
                    AppId = config.AppId,
                    AppSecret = config.AppSecret
                };
                DateTime now = DateTime.Now;
                GetAccessTokenResponse response = basicProvider.GetAccessToken(request);
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
        /// 登录凭证校验
        /// </summary>
        /// <param name="jsCode">登录时获取的 code</param>
        /// <param name="merchantId">商户ID</param>
        /// <returns></returns>
        /// <remarks>
        /// 通过 wx.login 接口获得临时登录凭证 code 后传到开发者服务器调用此接口完成登录流程。更多使用方法详见 小程序登录。
        /// </remarks>
        public CodeToSessionResponse CodeToSession(string jsCode, string merchantId = null)
        {
            Config config = configBuilder.BuildMiniPorgramConifg(merchantId);
            CodeToSessionRequest codeToSessionRequest = new CodeToSessionRequest
            {
                ApiDomain = config.ApiDomain,
                AppId = config.AppId,
                AppSecret = config.AppSecret,
                JsCode = jsCode
            };
            CodeToSessionResponse response = basicProvider.CodeToSession(codeToSessionRequest);
            if (response.ErrorCode == 0)
            {
                Entity.Session session = new Entity.Session
                {
                    AppId = config.AppId,
                    CreateTime = DateTime.Now,
                    MerchantId = merchantId,
                    OpenId = response.OpenId,
                    SessionKey = response.SessionKey,
                    UnionId = response.UnionId
                };
                sessionManager.InserOrUpdate(session);
            }
            return response;
        }

        /// <summary>
        /// 用户支付完成后，获取该用户的 UnionId，无需用户授权。本接口支持第三方平台代理查询。
        /// </summary>
        /// <param name="openId">微信小程序OpenId</param>
        /// <param name="merchantId">商户ID</param>
        /// <returns></returns>
        /// <remarks>
        /// 注意：调用前需要用户完成支付，且在支付后的五分钟内有效。
        /// </remarks>
        public GetPaidUnionIdReponse GetPaidUnionId(string openId, string merchantId = null)
        {
            Config config = configBuilder.BuildMiniPorgramConifg(merchantId);
            GetPaidUnionIdRequest request = new GetPaidUnionIdRequest
            {
                ApiDomain = config.ApiDomain,
                AccessToken = GetAccessToken(merchantId, config),
                OpenId = openId
            };
            return basicProvider.GetPaidUnionId(request);
        }

        /// <summary>
        /// 解密数据
        /// </summary>
        /// <param name="openId">微信小程序OpenId</param>
        /// <param name="encryptedData">加密的数据</param>
        /// <param name="iv">向量</param>
        /// <param name="merchantId">商户ID</param>
        /// <returns></returns>
        public DecryptDataResponse DecryptData(string openId, string encryptedData, string iv, string merchantId = null)
        {
            Config config = configBuilder.BuildMiniPorgramConifg(merchantId);
            Entity.Session session = sessionManager.Get(Tuple.Create(config.AppId, openId));
            if (session == null)
            {
                throw new ArgumentNullException("session key");
            }
            DecryptDataRequest request = new DecryptDataRequest
            {
                AppId = config.AppId,
                EncryptedData = encryptedData,
                IV = iv,
                SessionKey = session.SessionKey
            };
            return basicProvider.DecryptData(request);
        }
    }
}
