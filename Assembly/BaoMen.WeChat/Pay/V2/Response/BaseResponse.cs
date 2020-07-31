using BaoMen.Common.Model;
using BaoMen.WeChat.Pay.Util;
using BaoMen.WeChat.Pay.WxPay.Util;
using NLog;
using System;
using System.Collections.Generic;
using System.Text;
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
        /// <param name="xml"></param>
        public BaseResponse(string xml = null)
        {
            FromXml(xml);
        }

        /// <summary>
        /// 将xml转为WxPayData对象并返回对象内部的数据
        /// </summary>
        /// <param name="xml">待转换的xml串</param>
        /// <returns></returns>
        public SortedDictionary<string, object> FromXml(string xml)
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
                //CheckSign();//验证签名,不通过会抛异常
            }
            catch (WxPayException ex)
            {
                throw new WxPayException(ex.Message);
            }
            return m_values;
        }
    }
}
