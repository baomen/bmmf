using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
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

        /// <summary>
        /// 获取证书文件的地址
        /// </summary>
        /// <param name="mchId">商户号</param>
        /// <param name="fileName">文件名</param>
        /// <returns></returns>
        public string GetSslFilePath(string mchId, string fileName)
        {
            string path;
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                path = parameterManager.Get("01020301").Value;
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                path = parameterManager.Get("01020302").Value;
            }
            else
            {
                throw new NotImplementedException();
            }
            return Path.Combine(path, "wxpay", mchId, fileName);
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

        #region 微信支付
        /// <summary>
        /// 创建默认的支付配置
        /// </summary>
        /// <returns></returns>
        private BaoMen.WeChat.Pay.V2.GeneralConfig CreateDefaultGeneralPayConfig()
        {
            return new BaoMen.WeChat.Pay.V2.GeneralConfig
            {
                AppId = parameterManager.Get("03010101")?.Value,
                MchId = parameterManager.Get("0301030101")?.Value,
                ApiUrl = parameterManager.Get("0301030301")?.Value,
                Key = parameterManager.Get("0301030102")?.Value,
                SslCertPath = GetSslFilePath(parameterManager.Get("0301030101")?.Value, parameterManager.Get("0301030103")?.Value),
                SslCertPassword = parameterManager.Get("0301030104").Value
            };
        }

        /// <summary>
        /// 构建微信支付的配置
        /// </summary>
        /// <returns></returns>
        public BaoMen.WeChat.Pay.V2.GeneralConfig BuildGeneralPayConfig(string merchantId = null)
        {
            return CreateDefaultGeneralPayConfig();
            //Pay.Config config;
            //if (string.IsNullOrEmpty(merchantId))
            //{
            //    config = CreateDefaultPayConfig();
            //}
            //return config;
        }
        #endregion

        #region 小程序
        /// <summary>
        /// 构建微信小程序的配置
        /// </summary>
        /// <returns></returns>
        public MiniProgram.Config BuildMiniPorgramConifg(string merchantId = null)
        {
            MiniProgram.Config config;
            if (string.IsNullOrEmpty(merchantId))
            {
                config = CreateDefaultMiniProgramConfig();
            }
            else
            {
                config = CreateMerchantMiniProgramConfig(merchantId);
                //没配置使用默认
                if (string.IsNullOrEmpty(config.AppId) || string.IsNullOrEmpty(config.AppSecret))
                {
                    config = CreateDefaultMiniProgramConfig();
                }
            }
            CheckMiniProgramConfig(config);
            logger.Trace("build wechat mini program config {config}", config);
            return config;
        }

        /// <summary>
        /// 创建默认的小程序配置
        /// </summary>
        /// <returns></returns>
        private MiniProgram.Config CreateDefaultMiniProgramConfig()
        {
            return new MiniProgram.Config
            {
                AppId = parameterManager.Get("03010201").Value,
                AppSecret = parameterManager.Get("03010202").Value,
                ApiDomain = parameterManager.Get("03010203").Value
            };
        }

        private MiniProgram.Config CreateMerchantMiniProgramConfig(string merchantId)
        {
            return new MiniProgram.Config
            {
                AppId = merchantParameterManager.Get("02010201").Value,
                AppSecret = merchantParameterManager.Get("02010202").Value,
                ApiDomain = parameterManager.Get("03010203").Value
            };
        }

        /// <summary>
        /// 检查微信小程序配置
        /// </summary>
        /// <param name="config">微信小程序配置</param>
        private void CheckMiniProgramConfig(MiniProgram.Config config)
        {
            if (string.IsNullOrEmpty(config.AppId))
            {
                logger.Warn("create mini-program config error.AppId is null or empty");
                throw new ArgumentNullException("AppId", "参数为空");
            }
            if (string.IsNullOrEmpty(config.AppSecret))
            {
                logger.Warn("create mini-program config error.AppSecret is null or empty");
                throw new ArgumentNullException("AppSecret", "参数为空");
            }
            if (string.IsNullOrEmpty(config.ApiDomain))
            {
                logger.Warn("create mini-program config error.ApiDomain is null or empty");
                throw new ArgumentNullException("ApiDomain", "参数为空");
            }
        }
        #endregion

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
