using BaoMen.WeChat.Pub;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaoMen.MultiMerchant.WeChat
{
    /// <summary>
    /// 配置构建器
    /// </summary>
    public class ConfigBuilder : BaoMen.WeChat.Util.ConfigBuilder
    {
        private readonly System.BusinessLogic.IParameterManager parameterManager;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="serviceProvider">服务提供程序</param>
        public ConfigBuilder(IServiceProvider serviceProvider)
        {
            parameterManager = serviceProvider.GetRequiredService<System.BusinessLogic.IParameterManager>();
        }

        /// <summary>
        /// 创建配置
        /// </summary>
        /// <returns></returns>
        protected override Config CreatePubConfig()
        {
            return new Config
            {
                AppId = parameterManager.Get("03010101").Value,
                AppSecret = parameterManager.Get("03010102").Value,
                ApiDomain = parameterManager.Get("03010103").Value
            };
        }
    }
}
