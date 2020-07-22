using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaoMen.MultiMerchant.Amap
{
    /// <summary>
    /// 配置构建器
    /// </summary>
    public class ConfigBuilder : BaoMen.Amap.Utils.IConfigBuilder
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
        /// 创建开放平台配置
        /// </summary>
        /// <returns></returns>
        public BaoMen.Amap.Open.WebService.Config BuildOpenConfig()
        {
            BaoMen.Amap.Open.WebService.Config config = new BaoMen.Amap.Open.WebService.Config
            {
                Key = parameterManager.Get("0303010101").Value,
                SignKey = parameterManager.Get("0303010102").Value
            };
            return config;
        }
    }
}
