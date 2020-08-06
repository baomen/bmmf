using BaoMen.MultiMerchant.System.BusinessLogic;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BaoMen.MultiMerchant.AliYun
{
    /// <summary>
    /// 配置构建器
    /// </summary>
    public class ConfigBuilder
    {
        private IParameterManager parameterManager;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="serviceProvider">服务提供程序</param>
        public ConfigBuilder(IServiceProvider serviceProvider)
        {
            parameterManager = serviceProvider.GetRequiredService<IParameterManager>();
        }

        /// <summary>
        /// 构建默认配置
        /// </summary>
        /// <returns></returns>
        private Dysms.Config CreateDefaultDysmsConfig()
        {
            return new Dysms.Config
            {
                AccessKeyId = parameterManager.Get("0302020101")?.Value,
                AccessKeySecret = parameterManager.Get("0302020102")?.Value,
                SignName = parameterManager.Get("0302020201")?.Value
            };
        }

        /// <summary>
        /// 构建配置
        /// </summary>
        /// <param name="merchantId">商户ID</param>
        /// <returns></returns>
        public Dysms.Config BuildDysmsConfig(string merchantId = null)
        {
            if (string.IsNullOrEmpty(merchantId)) return CreateDefaultDysmsConfig();
            throw new NotImplementedException();
        }
    }
}
