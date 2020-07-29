using System;

namespace BaoMen.WeChat.Pay.WxPay
{
    /// <summary>
    /// 微信支付异常
    /// </summary>
    public class WxPayException : Exception
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="msg"></param>
        public WxPayException(string msg) : base(msg)
        {

        }
    }
}