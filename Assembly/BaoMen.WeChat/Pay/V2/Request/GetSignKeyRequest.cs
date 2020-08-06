using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaoMen.WeChat.Pay.V2.Request
{
    /// <summary>
    /// 获取沙箱验签秘钥请求参数
    /// </summary>
    public class GetSignKeyRequest : BaseRequest
    {
        /// <summary>
        /// 商户号
        /// </summary>
        [Required]
        [StringLength(32)]
        public string MchId
        {
            get => m_values.ContainsKey("mch_id") ? (string)m_values["mch_id"] : null;
            internal set => m_values["mch_id"] = value;
        }
    }
}
