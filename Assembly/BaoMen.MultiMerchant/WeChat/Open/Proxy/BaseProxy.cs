using Microsoft.Extensions.DependencyInjection;
using System;

namespace BaoMen.MultiMerchant.WeChat.Open.Proxy
{
    /// <summary>
    /// 代理基类
    /// </summary>
    public class BaseProxy
    {
        /// <summary>
        /// 服务提供程序
        /// </summary>
        protected readonly IServiceProvider serviceProvider;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="serviceProvider">服务提供程序</param>
        public BaseProxy(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }
    }
}
