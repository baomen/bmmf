using Microsoft.Extensions.DependencyInjection;
using NLog;
using System;

namespace BaoMen.MultiMerchant.WeChat.MiniProgram.Proxy
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
        /// 配置构建器
        /// </summary>
        protected readonly ConfigBuilder configBuilder;

        /// <summary>
        /// 日志记录
        /// </summary>
        protected readonly ILogger logger;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="serviceProvider">服务提供程序</param>
        /// <param name="logger">日志</param>
        public BaseProxy(IServiceProvider serviceProvider, ILogger logger)
        {
            this.serviceProvider = serviceProvider;
            configBuilder = serviceProvider.GetRequiredService<ConfigBuilder>();
        }
    }
}
