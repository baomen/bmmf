using BaoMen.WeChat.Pay.V2.Validator;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaoMen.WeChat.Pay.V2.Request.General
{
    /// <summary>
    /// 企业付款请求数据
    /// </summary>
    public class TransferRequest : BaseRequest
    {
        /// <summary>
        /// 商户账号appid
        /// </summary>
        [Required]
        [StringLength(32)]
        public string MchAppId
        {
            get => m_values.ContainsKey("mch_appid") ? (string)m_values["mch_appid"] : null;
            internal set => m_values["mch_appid"] = value;
        }

        /// <summary>
        /// 商户号
        /// </summary>
        [Required]
        [StringLength(32)]
        public string MchId
        {
            get => m_values.ContainsKey("mchid") ? (string)m_values["mchid"] : null;
            internal set => m_values["mchid"] = value;
        }

        /// <summary>
        /// 设备号
        /// </summary>
        [StringLength(32)]
        public string DeviceInfo
        {
            get => m_values.ContainsKey("device_info") ? (string)m_values["device_info"] : null;
            set => m_values["device_info"] = value;
        }

        /// <summary>
        /// 商户订单号
        /// </summary>
        [Required]
        [StringLength(32)]
        public string ParterTradeNo
        {
            get => m_values.ContainsKey("partner_trade_no") ? (string)m_values["partner_trade_no"] : null;
            set => m_values["partner_trade_no"] = value;
        }

        /// <summary>
        /// 用户openid
        /// </summary>
        [Required]
        [StringLength(64)]
        public string OpenId
        {
            get => m_values.ContainsKey("openid") ? (string)m_values["openid"] : null;
            set => m_values["openid"] = value;
        }

        /// <summary>
        /// 校验用户姓名选项
        /// </summary>
        [Required]
        [StringLength(16)]
        public string CheckName
        {
            get => m_values.ContainsKey("check_name") ? (string)m_values["check_name"] : null;
            internal set => m_values["check_name"] = value;
        }

        /// <summary>
        /// 收款用户姓名
        /// </summary>
        [StringLength(64)]
        [CustomValidation(typeof(RequestValidator), "ValidateReUserName")]
        public string ReUserName
        {
            get => m_values.ContainsKey("re_user_name") ? (string)m_values["re_user_name"] : null;
            set => m_values["re_user_name"] = value;
        }

        /// <summary>
        /// 金额
        /// </summary>
        [Required]
        public int Amount
        {
            get => !m_values.ContainsKey("amount") || m_values["amount"] == null ? 0 : (int)m_values["amount"];
            set => m_values["amount"] = value;
        }

        /// <summary>
        /// 企业付款备注
        /// </summary>
        [Required]
        [StringLength(100)]
        public string Desc
        {
            get => m_values.ContainsKey("desc") ? (string)m_values["desc"] : null;
            set => m_values["desc"] = value;
        }

        /// <summary>
        /// Ip地址
        /// </summary>
        [Required]
        [StringLength(32)]
        public string SpBillCreateIp
        {
            get => m_values.ContainsKey("spbill_create_ip") ? (string)m_values["spbill_create_ip"] : null;
            internal set => m_values["spbill_create_ip"] = value;
        }
    }
}
