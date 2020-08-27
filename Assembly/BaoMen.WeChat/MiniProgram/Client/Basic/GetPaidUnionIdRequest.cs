using System;

namespace BaoMen.WeChat.MiniProgram.Client.Basic
{
    /// <summary>
    /// 用户支付完成后，获取该用户的 UnionId
    /// </summary>
    /// <remarks>
    /// access_token	string		是	接口调用凭证
    /// openid string 是   支付用户唯一标识
    /// transaction_id string 否   微信支付订单号
    /// mch_id string 否   微信支付分配的商户号，和商户订单号配合使用
    /// out_trade_no string 否   微信支付商户订单号，和商户号配合使用
    /// </remarks>
    [Serializable]
    public class GetPaidUnionIdRequest : BaseAccessTokenRequest
    {
        /// <summary>
        /// openid string 是   支付用户唯一标识
        /// </summary>
        public string OpenId { get; set; }

        /// <summary>
        /// transaction_id string 否   微信支付订单号
        /// </summary>
        public string TransactionId { get; set; }

        /// <summary>
        /// mch_id string 否   微信支付分配的商户号，和商户订单号配合使用
        /// </summary>
        public string MchId { get; set; }

        /// <summary>
        /// out_trade_no string 否   微信支付商户订单号，和商户号配合使用
        /// </summary>
        public string OutTradeNo { get; set; }
    }
}
