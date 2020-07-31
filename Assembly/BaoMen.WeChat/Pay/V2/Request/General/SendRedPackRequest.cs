using BaoMen.WeChat.Pay.V2.Request;
using BaoMen.WeChat.Pay.V2.Validator;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaoMen.WeChat.Pay.V2.Request.General
{
    /// <summary>
    /// 发放红包请求数据
    /// </summary>
    public class SendRedPackRequest : BaseRequest
    {
        /// <summary>
        /// 商户订单号
        /// </summary>
        [Required]
        [StringLength(28)]
        public string MchBillNo
        {
            get
            {
                return m_values.ContainsKey("mch_billno") ? (string)m_values["mch_billno"] : null;
            }
            set
            {
                m_values["mch_billno"] = value;
            }
        }

        /// <summary>
        /// 公众账号appid
        /// </summary>
        [Required]
        [StringLength(32)]
        public string WxAppId
        {
            get
            {
                return m_values.ContainsKey("wxappid") ? (string)m_values["wxappid"] : null;
            }
            set
            {
                m_values["wxappid"] = value;
            }
        }

        /// <summary>
        /// 商户名称
        /// </summary>
        [Required]
        [StringLength(32)]
        public string SendName
        {
            get
            {
                return m_values.ContainsKey("send_name") ? (string)m_values["send_name"] : null;
            }
            set
            {
                m_values["send_name"] = value;
            }
        }

        /// <summary>
        /// 用户openid
        /// </summary>
        [Required]
        [StringLength(32)]
        public string ReOpenId
        {
            get
            {
                return m_values.ContainsKey("re_openid") ? (string)m_values["re_openid"] : null;
            }
            set
            {
                m_values["re_openid"] = value;
            }
        }

        /// <summary>
        /// 付款金额
        /// </summary>
        [Required]
        public int TotalAmount
        {
            get
            {
                return !m_values.ContainsKey("total_amount") || m_values["total_amount"] == null ? 0 : (int)m_values["total_amount"];
            }
            set
            {
                m_values["total_amount"] = value;
            }
        }

        /// <summary>
        /// 红包发放总人数
        /// </summary>
        [Required]
        public int TotalNum
        {
            get
            {
                return !m_values.ContainsKey("total_num") || m_values["total_num"] == null ? 0 : (int)m_values["total_num"];
            }
            set
            {
                m_values["total_num"] = value;
            }
        }

        /// <summary>
        /// 红包祝福语
        /// </summary>
        [Required]
        [StringLength(128)]
        public string Wishing
        {
            get
            {
                return m_values.ContainsKey("wishing") ? (string)m_values["wishing"] : null;
            }
            set
            {
                m_values["wishing"] = value;
            }
        }

        /// <summary>
        /// Ip地址
        /// </summary>
        [Required]
        [StringLength(15)]
        public string ClientIp
        {
            get
            {
                return m_values.ContainsKey("client_ip") ? (string)m_values["client_ip"] : null;
            }
            set
            {
                m_values["client_ip"] = value;
            }
        }

        /// <summary>
        /// 活动名称
        /// </summary>
        [Required]
        [StringLength(32)]
        public string ActName
        {
            get
            {
                return m_values.ContainsKey("act_name") ? (string)m_values["act_name"] : null;
            }
            set
            {
                m_values["act_name"] = value;
            }
        }

        /// <summary>
        /// 备注
        /// </summary>
        [Required]
        [StringLength(256)]
        public string Remark
        {
            get
            {
                return m_values.ContainsKey("remark") ? (string)m_values["remark"] : null;
            }
            set
            {
                m_values["remark"] = value;
            }
        }

        /// <summary>
        /// 场景id
        /// </summary>
        [CustomValidation(typeof(RequestValidator), "ValidateSceneId")]
        public string SceneId
        {
            get
            {
                return m_values.ContainsKey("scene_id") ? (string)m_values["scene_id"] : null;
            }
            set
            {
                m_values["scene_id"] = value;
            }
        }

        /// <summary>
        /// 活动信息
        /// </summary>
        public string RiskInfo
        {
            get
            {
                return m_values.ContainsKey("risk_info") ? (string)m_values["risk_info"] : null;
            }
            set
            {
                m_values["risk_info"] = value;
            }
        }

    }
}
