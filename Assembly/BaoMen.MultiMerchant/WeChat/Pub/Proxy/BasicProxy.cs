using BaoMen.MultiMerchant.WeChat.Pub.BusinessLogic;
using BaoMen.WeChat.Pub.Provider;
using BaoMen.WeChat.Util;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaoMen.MultiMerchant.WeChat.Pub.Proxy
{
    /// <summary>
    /// 基础代理
    /// </summary>
    public class BasicProxy : BaseProxy
    {
        private readonly IAppAccessTokenManager appAccessTokenManager;
        private readonly IAuthAccessTokenManager authAccessTokenManager;

        private readonly IConfigBuilder configBuilder;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="serviceProvider">服务提供程序</param>
        public BasicProxy(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            appAccessTokenManager = serviceProvider.GetRequiredService<IAppAccessTokenManager>();
            authAccessTokenManager = serviceProvider.GetRequiredService<IAuthAccessTokenManager>();
            configBuilder = serviceProvider.GetRequiredService<ConfigBuilder>();
        }

        public Entity.AuthAccessToken GetAuthAccessToken(string code)
        {
            throw new NotImplementedException();
            //Entity.AuthAccessToken authAccessToken = authAccessTokenManager.Get(new Tuple<string, string>(appId, openId));
            //if (authAccessToken == null || authAccessToken.ExpiresTime < DateTime.Now)
            //{
            //    BasicProvider basicProvider = new BasicProvider
            //}
        }
    }
}
