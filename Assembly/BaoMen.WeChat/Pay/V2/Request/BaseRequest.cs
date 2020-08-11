using BaoMen.WeChat.Pay.Util;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace BaoMen.WeChat.Pay.V2.Request
{
    /// <summary>
    /// 请求参数的基类
    /// </summary>
    public abstract class BaseRequest : WxPayData
    {

        /// <summary>
        /// 验证数据
        /// </summary>
        /// <returns></returns>
        public virtual void Validate()
        {
            ValidationContext validationContext = new ValidationContext(this);
            ICollection<ValidationResult> validationResults = new List<ValidationResult>();
            if (!System.ComponentModel.DataAnnotations.Validator.TryValidateObject(this, validationContext, validationResults))
            {
                throw new ArgumentException();
            }
        }

        /// <summary>
        /// 转为XML字符串
        /// </summary>
        /// <returns></returns>
        public string ToXml()
        {
            //数据为空时不能转化为xml格式
            if (0 == m_values.Count)
            {
                logger.Error("Request数据为空!");
                throw new WxPayException("Request数据为空!");
            }

            string xml = "<xml>";
            foreach (KeyValuePair<string, object> pair in m_values)
            {
                //字段值不能为null，会影响后续流程
                if (pair.Value == null)
                {
                    logger.Error("Request内部含有值为null的字段!");
                    throw new WxPayException("Request内部含有值为null的字段!");
                }
                Type valueType = pair.Value.GetType();
                if (valueType == typeof(int))
                {
                    xml += "<" + pair.Key + ">" + pair.Value + "</" + pair.Key + ">";
                }
                else if (valueType == typeof(string))
                {
                    xml += "<" + pair.Key + ">" + "<![CDATA[" + pair.Value + "]]></" + pair.Key + ">";
                }
                else//除了string和int类型不能含有其他数据类型
                {
                    logger.Error("Request字段数据类型错误!");
                    throw new WxPayException("Request字段数据类型错误!");
                }
            }
            if (!string.IsNullOrEmpty(Sign))
            {
                xml += $"<sign><![CDATA[{Sign}]]></sign>";
            }
            xml += "</xml>";
            return xml;
        }

        #region 公共字段

        /// <summary>
        /// 签名
        /// </summary>
        public string Sign { get; internal set; }

        /// <summary>
        /// 接口超时时长（秒）
        /// </summary>
        public int Timeout { get; set; } = 10;

        /// <summary>
        /// 随机字符串
        /// </summary>
        [Required]
        [StringLength(32)]
        public string NonceStr
        {
            get => m_values.ContainsKey("nonce_str") ? (string)m_values["nonce_str"] : null;
            internal set => m_values["nonce_str"] = value;
        }

        #endregion

    }
}
