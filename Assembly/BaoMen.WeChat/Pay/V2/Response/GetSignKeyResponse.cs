using System;
using System.Collections.Generic;
using System.Text;

namespace BaoMen.WeChat.Pay.V2.Response
{
    /// <summary>
    /// 获取沙箱验签秘钥响应参数
    /// </summary>
    public class GetSignKeyResponse : BaseResponse
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="xml">XML</param>
        public GetSignKeyResponse(string xml) : base(xml, checkSign: false)
        {

        }

        /// <summary>
        /// 商户号
        /// </summary>
        public string MchId
        {
            get { return m_values.ContainsKey("mch_id") ? (string)m_values["mch_id"] : null; }
        }

        /// <summary>
        /// 沙箱密钥
        /// </summary>
        public string SandboxSignKey
        {
            get { return m_values.ContainsKey("sandbox_signkey") ? (string)m_values["sandbox_signkey"] : null; }
        }
    }
}
