//using System;
//using System.Collections.Generic;
//using System.Net;
//using System.Text;

//namespace BaoMen.WeChat.Util
//{
//    /// <summary>
//    /// 配置构建器
//    /// </summary>
//    public abstract class ConfigBuilder : IConfigBuilder
//    {
//        protected static readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

//        /// <summary>
//        /// 内网IP
//        /// </summary>
//        private static readonly string intranetIP = GetIntranetIP();

//        /// <summary>
//        /// 构建微信公众号的配置
//        /// </summary>
//        /// <returns></returns>
//        public Pub.Config BuildPubConifg()
//        {
//            Pub.Config config = CreatePubConfig();
//            CheckPubConfig(config);
//            logger.Trace("build wechat pub config {config}", config);
//            return config;
//        }

//        /// <summary>
//        /// 检查微信公众号配置
//        /// </summary>
//        /// <param name="config">微信公众号配置</param>
//        protected void CheckPubConfig(Pub.Config config)
//        {
//            if (string.IsNullOrEmpty(config.AppId))
//            {
//                throw new ArgumentNullException("AppId", "参数为空");
//            }
//            if (string.IsNullOrEmpty(config.AppSecret))
//            {
//                throw new ArgumentNullException("AppSecret", "参数为空");
//            }
//            if (string.IsNullOrEmpty(config.ApiDomain))
//            {
//                throw new ArgumentNullException("ApiDomain", "参数为空");
//            }
//        }

//        /// <summary>
//        /// 创建微信公众号配置
//        /// </summary>
//        protected abstract Pub.Config CreatePubConfig();

//        /// <summary>
//        /// 构建微信小程序的配置
//        /// </summary>
//        /// <returns></returns>
//        public MiniProgram.Config BuildMiniProgramConifg()
//        {
//            MiniProgram.Config config = CreateMiniProgramConfig();
//            logger.Trace("build wechat mini program config {config}", config);
//            return config;
//        }

//        /// <summary>
//        /// 检查小程序配置
//        /// </summary>
//        /// <param name="config">微信小程序的配置</param>
//        protected void CheckMiniProgramConfig(MiniProgram.Config config)
//        {
//            if (string.IsNullOrEmpty(config.AppId))
//            {
//                throw new ArgumentNullException("AppId", "参数为空");
//            }
//            if (string.IsNullOrEmpty(config.AppSecret))
//            {
//                throw new ArgumentNullException("AppSecret", "参数为空");
//            }
//            if (string.IsNullOrEmpty(config.ApiDomain))
//            {
//                throw new ArgumentNullException("ApiDomain", "参数为空");
//            }
//        }

//        /// <summary>
//        /// 创建微信小程序配置
//        /// </summary>
//        protected abstract MiniProgram.Config CreateMiniProgramConfig();

//        /// <summary>
//        /// 构建微信开放平台的配置
//        /// </summary>
//        /// <returns></returns>
//        public Open.Config BuildOpenConifg()
//        {
//            Open.Config config = CreateOpenConfig();
//            CheckOpenConfig(config);
//            logger.Trace("build wechat open config {config}", config);
//            return config;
//        }

//        /// <summary>
//        /// 检查微信开放平台配置
//        /// </summary>
//        /// <param name="config">微信公众号配置</param>
//        protected void CheckOpenConfig(Open.Config config)
//        {
//            if (string.IsNullOrEmpty(config.AppId))
//            {
//                throw new ArgumentNullException("AppId", "参数为空");
//            }
//            if (string.IsNullOrEmpty(config.ApiDomain))
//            {
//                throw new ArgumentNullException("ApiDomain", "参数为空");
//            }
//        }

//        /// <summary>
//        /// 创建微信开放平台配置
//        /// </summary>
//        protected abstract Open.Config CreateOpenConfig();

//        /// <summary>
//        /// 获取内网IP
//        /// </summary>
//        /// <returns></returns>
//        protected static string GetIntranetIP()
//        {
//            IPHostEntry host;
//            string localIP = "?";
//            host = Dns.GetHostEntry(Dns.GetHostName());
//            foreach (IPAddress ip in host.AddressList)
//            {
//                if (ip.AddressFamily.ToString() == "InterNetwork")
//                {
//                    localIP = ip.ToString();
//                    break;
//                }
//            }
//            return localIP;
//        }
//    }
//}
