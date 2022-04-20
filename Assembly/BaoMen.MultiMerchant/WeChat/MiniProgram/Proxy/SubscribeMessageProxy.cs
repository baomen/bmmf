using BaoMen.WeChat.MiniProgram.Client.SubscribeMessage;
using BaoMen.WeChat.MiniProgram.Provider;
using Microsoft.Extensions.DependencyInjection;
using NLog;
using System;

namespace BaoMen.MultiMerchant.WeChat.MiniProgram.Proxy
{
    /// <summary>
    /// 订阅消息代理
    /// </summary>
    public class SubscribeMessageProxy : BaseProxy
    {
        /// <summary>
        /// 基础代理
        /// </summary>

        private readonly BasicProxy basicProxy;

        /// <summary>
        /// 订阅消息提供程序
        /// </summary>
        private readonly SubscribeMessageProvider subscribeMessageProvider;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="serviceProvider">服务提供程序</param>
        public SubscribeMessageProxy(IServiceProvider serviceProvider) : base(serviceProvider, LogManager.GetCurrentClassLogger())
        {
            basicProxy = serviceProvider.GetRequiredService<BasicProxy>();
            subscribeMessageProvider = serviceProvider.GetRequiredService<SubscribeMessageProvider>();
        }

        /// <summary>
        /// 发送订阅消息
        /// </summary>
        /// <param name="request">发送请求</param>
        /// <param name="merchantId">商户ID</param>
        /// <returns></returns>
        public SendResponse Send(SendRequest request, string merchantId = null)
        {
            Config config = configBuilder.BuildMiniPorgramConifg(merchantId);
            request.ApiDomain = config.ApiDomain;
            request.AccessToken = basicProxy.GetAccessToken(merchantId, config);
            return subscribeMessageProvider.Send(request);
        }
    }
}
