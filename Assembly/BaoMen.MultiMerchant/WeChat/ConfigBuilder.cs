using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaoMen.MultiMerchant.WeChat
{
    /// <summary>
    /// 配置构建器
    /// </summary>
    public class ConfigBuilder
    {
        private readonly System.BusinessLogic.IParameterManager parameterManager;
        private readonly Merchant.BusinessLogic.IParameterManager merchantParameterManager;

        private static readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="serviceProvider">服务提供程序</param>
        public ConfigBuilder(IServiceProvider serviceProvider)
        {
            parameterManager = serviceProvider.GetRequiredService<System.BusinessLogic.IParameterManager>();
            merchantParameterManager = serviceProvider.GetRequiredService<Merchant.BusinessLogic.IParameterManager>();
        }

        #region 公众号
        /// <summary>
        /// 创建默认的公众号配置
        /// </summary>
        /// <returns></returns>
        private Pub.Config CreateDefaultPubConfig()
        {
            return new Pub.Config
            {
                AppId = parameterManager.Get("03010101")?.Value,
                AppSecret = parameterManager.Get("03010102")?.Value,
                ApiDomain = parameterManager.Get("03010103")?.Value
            };
        }

        /// <summary>
        /// 创建商户的公众号配置
        /// </summary>
        /// <param name="merchantId"></param>
        /// <returns></returns>
        private Pub.Config CreateMerchantPubConfig(string merchantId)
        {
            Pub.Config config = new Pub.Config
            {
                AppId = merchantParameterManager.Get("02010101")?.Value,
                AppSecret = merchantParameterManager.Get("02010102")?.Value,
                ApiDomain = parameterManager.Get("02010103")?.Value
            };
            if (string.IsNullOrEmpty(config.ApiDomain))
            {
                config.ApiDomain = parameterManager.Get("03010103")?.Value;
            }
            return config;
        }

        /// <summary>
        /// 检查微信公众号配置
        /// </summary>
        /// <param name="config">微信公众号配置</param>
        private void CheckPubConfig(Pub.Config config)
        {
            if (string.IsNullOrEmpty(config.AppId))
            {
                throw new ArgumentNullException("AppId", "参数为空");
            }
            if (string.IsNullOrEmpty(config.AppSecret))
            {
                throw new ArgumentNullException("AppSecret", "参数为空");
            }
            if (string.IsNullOrEmpty(config.ApiDomain))
            {
                throw new ArgumentNullException("ApiDomain", "参数为空");
            }
        }

        /// <summary>
        /// 构建微信公众号的配置
        /// </summary>
        /// <returns></returns>
        public Pub.Config BuildPubConifg(string merchantId = null)
        {
            Pub.Config config;
            if (string.IsNullOrEmpty(merchantId))
            {
                config = CreateDefaultPubConfig();
            }
            else
            {
                config = CreateMerchantPubConfig(merchantId);
                if (string.IsNullOrEmpty(config.AppId) || string.IsNullOrEmpty(config.AppSecret))
                {
                    config = CreateDefaultPubConfig();
                }
            }
            try
            {
                CheckPubConfig(config);
                logger.Trace($"build wechat pub config {config}.merchantId={merchantId}", config);
                return config;
            }
            catch (ArgumentNullException)
            {
                logger.Warn($"build wechat pub config {config} error.use default config.merchantId={merchantId}", config);
                throw;
            }
        }
        #endregion

        ///// <summary>
        ///// 构建微信小程序的配置
        ///// </summary>
        ///// <returns></returns>
        //public BaoMen.WeChat.MiniProgram.Config BuildMiniPorgramConifg(string merchantId)
        //{
        //    BaoMen.WeChat.MiniProgram.Config config = new BaoMen.WeChat.MiniProgram.Config
        //    {
        //        AppId = merchantParameterManager.Get("01010201").Value,
        //        AppSecret = merchantParameterManager.Get("01010202").Value,
        //        ApiDomain = parameterManager.Get("03010103").Value
        //    };
        //    CheckMiniProgramConfig(config);
        //    logger.Trace("build wechat mini program config {config}", config);
        //    return config;
        //}

        ///// <summary>
        ///// 创建小程序配置
        ///// </summary>
        ///// <returns></returns>
        //protected override BaoMen.WeChat.MiniProgram.Config CreateMiniProgramConfig()
        //{
        //    return new BaoMen.WeChat.MiniProgram.Config
        //    {
        //        AppId = parameterManager.Get("03010201").Value,
        //        AppSecret = parameterManager.Get("03010202").Value,
        //        ApiDomain = parameterManager.Get("03010203").Value
        //    };
        //}

        ///// <summary>
        ///// 创建微信开放平台应用
        ///// </summary>
        ///// <returns></returns>
        //protected override Config CreateOpenConfig()
        //{
        //    Config config = new BaoMen.WeChat.Open.Config
        //    {
        //        AppId = merchantParameterManager.Get("03010401").Value,
        //        ApiDomain = parameterManager.Get("03010402").Value
        //    };
        //    CheckOpenConfig(config);
        //    logger.Trace("build wechat open config {config}", config);
        //    return config;
        //}
    }
}
