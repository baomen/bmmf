namespace BaoMen.MultiMerchant.WeChat.Pay
{
    /// <summary>
    /// 微信支付配置信息
    /// </summary>
    public class Config
    {
        /// <summary>
        /// 公众号ID
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// 商户号
        /// </summary>
        public string MchId { get; set; }

        /// <summary>
        /// 商户密钥
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// 公众号密钥
        /// </summary>
        public string AppSecret { get; set; }

        /// <summary>
        /// 证书路径（包含文件名）
        /// </summary>
        public string SslCertPath { get; set; }

        /// <summary>
        /// 证书密码
        /// </summary>
        public string SslCertPassword { get; set; }

        /// <summary>
        /// 通知地址
        /// </summary>
        public string NotifyUrl { get; set; }

        /// <summary>
        /// IP地址
        /// </summary>
        public string Ip { get; set; }

        /// <summary>
        /// 代理服务器
        /// </summary>
        public string ProxyUrl { get; set; }

        /// <summary>
        /// 子商户公众账号ID
        /// </summary>
        public string SubAppId { get; set; }

        /// <summary>
        /// 子商户号
        /// </summary>
        public string SubMchId { get; set; }

        /// <summary>
        /// 子商户小程序ID
        /// </summary>
        public string SubMiniProgramAppId { get; set; }

        /// <summary>
        /// 是否是子商户模式
        /// </summary>
        public bool IsSubMch { get; set; }

        /// <summary>
        /// 统一下单接口详情
        /// </summary>
        public UnifyOrderInterfaceDetail UnifyOrder { get; set; }

        /// <summary>
        /// 退款接口详情
        /// </summary>
        public InterfaceDetail Refund { get; set; }

        /// <summary>
        /// 退款查询接口详情
        /// </summary>
        public InterfaceDetail RefundQuery { get; set; }
    }

    /// <summary>
    /// 接口详情
    /// </summary>
    public class InterfaceDetail
    {
        /// <summary>
        /// 接口地址
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 超时时长
        /// </summary>
        public int TimeOut { get; set; }

        /// <summary>
        /// 上报等级
        /// </summary>
        public int ReportLevel { get; set; }
    }

    /// <summary>
    /// 统一下单接口详情
    /// </summary>
    public class UnifyOrderInterfaceDetail : InterfaceDetail
    {

        /// <summary>
        /// 交易有效期
        /// </summary>
        public int TransactionValidity { get; set; }
    }
}