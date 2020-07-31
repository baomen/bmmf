using System;

namespace BaoMen.WeChat.Pay.Util
{
    /// <summary>
    /// 微信支付异常
    /// </summary>
    public class WxPayException : Exception
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="message">错误消息</param>
        public WxPayException(string message = null) : base(message)
        {

        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="message">错误消息</param>
        /// <param name="innerException">内部异常</param>
        public WxPayException(string message = null, Exception innerException = null) : base(message, innerException)
        {

        }
    }
}