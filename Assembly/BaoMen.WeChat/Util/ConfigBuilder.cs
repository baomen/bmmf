using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace BaoMen.WeChat.Util
{
    /// <summary>
    /// 配置构建器
    /// </summary>
    public abstract class ConfigBuilder
    {
        private static readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        /// <summary>
        /// 内网IP
        /// </summary>
        private static readonly string intranetIP = GetIntranetIP();

        /// <summary>
        /// 构建微信支付的配置
        /// </summary>
        /// <returns></returns>
        public Pub.Config BuildPubConifg()
        {
            Pub.Config config = CreatePubConfig();
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
            logger.Trace("build wechat pub config {config}", config);
            return config;
        }

        /// <summary>
        /// 创建微信支付配置
        /// </summary>
        protected abstract Pub.Config CreatePubConfig();

        /// <summary>
        /// 获取内网IP
        /// </summary>
        /// <returns></returns>
        protected static string GetIntranetIP()
        {
            IPHostEntry host;
            string localIP = "?";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    localIP = ip.ToString();
                    break;
                }
            }
            return localIP;
        }
    }
}
