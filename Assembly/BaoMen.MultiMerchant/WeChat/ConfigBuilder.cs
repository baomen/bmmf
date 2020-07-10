using BaoMen.WeChat.Open;
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
        private readonly Merchant.BusinessLogic.IParameterManager merchantParameterManager;

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
        /// 创建小程序配置
        /// </summary>
        /// <returns></returns>
        protected override BaoMen.WeChat.MiniProgram.Config CreateMiniProgramConfig()
        {
            return new BaoMen.WeChat.MiniProgram.Config
            {
                AppId = parameterManager.Get("03010201").Value,
                AppSecret = parameterManager.Get("03010202").Value,
                ApiDomain = parameterManager.Get("03010203").Value
            };
        }

        /// <summary>
        /// 创建公众号配置
        /// </summary>
        /// <returns></returns>
        protected override BaoMen.WeChat.Pub.Config CreatePubConfig()
        {
            return new BaoMen.WeChat.Pub.Config
            {
                AppId = parameterManager.Get("03010101").Value,
                AppSecret = parameterManager.Get("03010102").Value,
                ApiDomain = parameterManager.Get("03010103").Value
            };
        }

        /// <summary>
        /// 构建微信公众号的配置
        /// </summary>
        /// <returns></returns>
        public BaoMen.WeChat.Pub.Config BuildPubConifg(string merchantId)
        {
            BaoMen.WeChat.Pub.Config config = new BaoMen.WeChat.Pub.Config
            {
                AppId = merchantParameterManager.Get("01010101").Value,
                AppSecret = merchantParameterManager.Get("01010102").Value,
                ApiDomain = parameterManager.Get("03010103").Value
            };
            CheckPubConfig(config);
            logger.Trace("build wechat pub config {config}", config);
            return config;
        }

        /// <summary>
        /// 构建微信小程序的配置
        /// </summary>
        /// <returns></returns>
        public BaoMen.WeChat.MiniProgram.Config BuildMiniPorgramConifg(string merchantId)
        {
            BaoMen.WeChat.MiniProgram.Config config = new BaoMen.WeChat.MiniProgram.Config
            {
                AppId = merchantParameterManager.Get("01010201").Value,
                AppSecret = merchantParameterManager.Get("01010202").Value,
                ApiDomain = parameterManager.Get("03010103").Value
            };
            CheckMiniProgramConfig(config);
            logger.Trace("build wechat mini program config {config}", config);
            return config;
        }

        /// <summary>
        /// 创建微信开放平台应用
        /// </summary>
        /// <returns></returns>
        protected override Config CreateOpenConfig()
        {
            throw new NotImplementedException();
        }
    }
}
