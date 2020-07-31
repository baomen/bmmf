using System;
using System.Xml;

namespace BaoMen.WeChat.Pay.WxPay.Util
{
    /// <summary>
    /// 安全的XML文档
    /// </summary>
    public class SafeXmlDocument:XmlDocument
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public SafeXmlDocument()
        {
            this.XmlResolver = null;
        }
    }
}
