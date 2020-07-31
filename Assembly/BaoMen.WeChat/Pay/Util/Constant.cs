using System;
using System.Collections.Generic;
using System.Text;

namespace BaoMen.WeChat.Pay.Util
{
    /// <summary>
    /// 微信支付常量
    /// </summary>
    public class Constant
    {
        /// <summary>
        /// 签名类型
        /// </summary>
        public class SignType
        {
            /// <summary>
            /// MD5
            /// </summary>
            public const string MD5 = "MD5";

            /// <summary>
            /// HMAC-SHA256
            /// </summary>
            public const string HMACSHA256 = "HMAC-SHA256";
        }
    }
}
