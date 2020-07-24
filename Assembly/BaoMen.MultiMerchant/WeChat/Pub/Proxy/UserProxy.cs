using BaoMen.MultiMerchant.Util;
using BaoMen.MultiMerchant.WeChat.Pub.BusinessLogic;
using BaoMen.WeChat.MiniProgram.Client.Response;
using BaoMen.WeChat.Pub.Provider;
using Microsoft.Extensions.DependencyInjection;
using System;
using Request = BaoMen.WeChat.Pub.Client.Request;
using Response = BaoMen.WeChat.Pub.Client.Response;

namespace BaoMen.MultiMerchant.WeChat.Pub.Proxy
{
    /// <summary>
    /// 用户代理
    /// </summary>
    public class UserProxy : BaseProxy
    {
        private readonly IAppAccessTokenManager appAccessTokenManager;

        private readonly UserProvider userProvider;
        private readonly BasicProxy basicProxy;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="serviceProvider">服务提供程序</param>
        public UserProxy(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            appAccessTokenManager = serviceProvider.GetRequiredService<IAppAccessTokenManager>();
            userProvider = serviceProvider.GetRequiredService<UserProvider>();
            basicProxy = serviceProvider.GetRequiredService<BasicProxy>();
        }

        /// <summary>
        /// 获取用户基本信息
        /// </summary>
        /// <param name="merchantId">商户ID</param>
        /// <param name="openId">用户的OpenId</param>
        /// <returns></returns>
        public Response.QueryUserInfo QueryUserInfo(string merchantId, string openId)
        {
            Config config = configBuilder.BuildPubConifg(merchantId);
            Request.QueryUserInfo request = new Request.QueryUserInfo
            {
                AccessToken = basicProxy.QueryAccessToken(merchantId),
                ApiDomain = config.ApiDomain,
                Language = "zh_CN",
                OpenId = openId
            };
            return userProvider.QueryUserInfo(request);
        }
    }
}
