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

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="serviceProvider">服务提供程序</param>
        public BasicProxy(IServiceProvider serviceProvider) : base(serviceProvider, LogManager.GetCurrentClassLogger())
        {
            basicProvider = serviceProvider.GetRequiredService<BasicProvider>();
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
        public Client.Sns.CodeToSessionResponse CodeToSession(string jsCode, string merchantId = null)
        {
            Config config = configBuilder.BuildMiniPorgramConifg(merchantId);
            Client.Sns.CodeToSessionRequest codeToSessionRequest = new Client.Sns.CodeToSessionRequest
            {
                ApiDomain = config.ApiDomain,
                AppId = config.AppId,
                AppSecret = config.AppSecret,
                JsCode = jsCode
            };
            return basicProvider.CodeToSession(codeToSessionRequest);
        }
    }
}
