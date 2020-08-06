using System;
using System.Collections.Generic;
using System.Text;

namespace BaoMen.WeChat.Pay.V2.Response.General
{
    /// <summary>
    /// 企业付款响应数据
    /// </summary>
    public class TransferResponse : BaseResponse
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="xml">XML</param>
        public TransferResponse(string xml) : base(xml, checkSign: false)
        {

        }

        /// <summary>
        /// 商户appid
        /// </summary>
        public string MchAppId
        {
            get { return m_values.ContainsKey("mch_appid") ? (string)m_values["mch_appid"] : null; }
        }

        /// <summary>
        /// 商户号
        /// </summary>
        public string MchId
        {
            get { return m_values.ContainsKey("mchid") ? (string)m_values["mchid"] : null; }
        }

        /// <summary>
        /// 商户号
        /// </summary>
        public string DeviceInfo
        {
            get { return m_values.ContainsKey("device_info") ? (string)m_values["device_info"] : null; }
        }

        /// <summary>
        /// 随机字符串
        /// </summary>
        public string NonceStr
        {
            get { return m_values.ContainsKey("nonce_str") ? (string)m_values["nonce_str"] : null; }
        }

        /// <summary>
        /// 商户订单号
        /// </summary>
        public string ParterTradeNo
        {
            get => m_values.ContainsKey("partner_trade_no") ? (string)m_values["partner_trade_no"] : null;
        }

        /// <summary>
        /// 微信付款单号
        /// </summary>
        public string PaymentNo
        {
            get => m_values.ContainsKey("payment_no") ? (string)m_values["payment_no"] : null;
        }

        /// <summary>
        /// 付款成功时间
        /// </summary>
        public string PaymentTime
        {
            get => m_values.ContainsKey("payment_time") ? (string)m_values["payment_time"] : null;
        }
    }
}
