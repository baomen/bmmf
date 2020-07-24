﻿using NLog;
using System;

namespace BaoMen.MultiMerchant.WeChat.Pub.Proxy
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
        /// 日志记录
        /// </summary>
        protected readonly ILogger logger;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="serviceProvider">服务提供程序</param>
        public BaseProxy(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
            logger = LogManager.GetCurrentClassLogger();
        }
    }
}
