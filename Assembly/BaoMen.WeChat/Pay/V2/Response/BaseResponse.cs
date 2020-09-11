using BaoMen.WeChat.Pay.Util;
using BaoMen.WeChat.Pay.WxPay.Util;
using System.Collections.Generic;
using System.Xml;

namespace BaoMen.WeChat.Pay.V2.Response
{
    /// <summary>
    /// 响应数据
    /// </summary>
    public abstract class BaseResponse : WxPayData
    {

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="xml">待转换的xml串</param>
        /// <param name="checkSign">是否检查签名</param>
        /// <param name="signType">签名方式</param>
        /// <param name="key">签名密钥</param>
        public BaseResponse(string xml , bool checkSign = true, string signType = Constant.SignType.HMACSHA256, string key = null)
        {
            FromXml(xml, checkSign, signType, key);
        }

        /// <summary>
        /// 将xml转为WxPayData对象并返回对象内部的数据
        /// </summary>
        /// <param name="xml">待转换的xml串</param>
        /// <param name="checkSign">是否检查签名</param>
        /// <param name="signType">签名方式</param>
        /// <param name="key">签名密钥</param>
        /// <returns></returns>
        protected SortedDictionary<string, object> FromXml(string xml, bool checkSign = true, string signType = Constant.SignType.HMACSHA256, string key = null)
        {
            if (string.IsNullOrEmpty(xml))
            {
                logger.Error("将空的xml串转换为WxPayData不合法!");
                throw new WxPayException("将空的xml串转换为WxPayData不合法!");
            }
            SafeXmlDocument xmlDoc = new SafeXmlDocument();
            xmlDoc.LoadXml(xml);
            XmlNode xmlNode = xmlDoc.FirstChild;//获取到根节点<xml>
            XmlNodeList nodes = xmlNode.ChildNodes;
            foreach (XmlNode xn in nodes)
            {
                XmlElement xe = (XmlElement)xn;
                m_values[xe.Name] = xe.InnerText;//获取xml的键值对到WxPayData内部的数据中
            }

            try
            {
                //2015-06-29 错误是没有签名
                if (m_values.ContainsKey("return_code") && m_values["return_code"]?.ToString() != "SUCCESS")
                {
                    return m_values;
                }
                if (checkSign)
                {
                    CheckSign(signType, key);//验证签名,不通过会抛异常
                }
            }
            catch (WxPayException ex)
            {
                throw new WxPayException(ex.Message);
            }
            return m_values;
        }

        /// <summary>
        /// 返回状态码
        /// </summary>
        public string ReturnCode
        {
            get { return m_values.ContainsKey("return_code") ? (string)m_values["return_code"] : null; }
        }

        /// <summary>
        /// 返回信息
        /// </summary>
        public string ReturnMsg
        {
            get {
                string message = null;
                if (m_values.ContainsKey("return_msg"))
                {
                    message = (string)m_values["return_msg"];
                }
                if(string.IsNullOrEmpty(message) && m_values.ContainsKey("retmsg"))
                {
                    message = (string)m_values["retmsg"];
                }
                return message;
            }
        }

        /// <summary>
        /// 业务结果
        /// </summary>
        public string ResultCode
        {
            get { return m_values.ContainsKey("result_code") ? (string)m_values["result_code"] : null; }
        }

        /// <summary>
        /// 错误代码
        /// </summary>
        public string ErrorCode
        {
            get { return m_values.ContainsKey("err_code") ? (string)m_values["err_code"] : null; }
        }

        /// <summary>
        /// 错误代码描述
        /// </summary>
        public string ErrorCodeDes
        {
            get { return m_values.ContainsKey("err_code_des") ? (string)m_values["err_code_des"] : null; }
        }
    }
}
