using System;
using System.Collections.Generic;
using System.Text;

namespace BaoMen.WeChat.Pay.V2
{
    /// <summary>
    /// 普通商户配置
    /// </summary>
    public class GeneralConfig
    {
        /// <summary>
        /// 商户号
        /// </summary>
        public string MchId { get; set; }

        /// <summary>
        /// 商户密钥
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// 证书路径（包含文件名）
        /// </summary>
        public string SslCertPath { get; set; }

        /// <summary>
        /// 证书密码
        /// </summary>
        public string SslCertPassword { get; set; }

        /// <summary>
        /// 交易保障等级
        /// </summary>
        public int ReportLevel { get; set; }

        /// <summary>
        /// 接口地址
        /// </summary>
        public string ApiUrl { get; set; }
    }
}
