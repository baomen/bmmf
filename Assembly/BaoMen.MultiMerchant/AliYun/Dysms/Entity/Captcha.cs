using BaoMen.Common.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaoMen.MultiMerchant.AliYun.Dysms.Entity
{
    /// <summary>
    /// 验证码
    /// </summary>
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class Captcha : ResponseData
    {
        /// <summary>
        /// 验证码类型
        /// </summary>
        public CaptchaType Type { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// 验证码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 发送时间
        /// </summary>
        public DateTime SendTime { get; set; }

        /// <summary>
        /// 过期时间
        /// </summary>
        public DateTime ExpirationTime { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public CaptchaStatus Status { get; set; }
    }

    /// <summary>
    /// 验证码类型
    /// </summary>
    public enum CaptchaType
    {
        /// <summary>
        /// 用户注册
        /// </summary>
        Regist = 1,

        /// <summary>
        /// 用户登录
        /// </summary>
        Login = 2
    }

    /// <summary>
    /// 验证码状态
    /// </summary>
    public enum CaptchaStatus
    {
        /// <summary>
        /// 有效的
        /// </summary>
        Valid = 1,

        /// <summary>
        /// 无效的
        /// </summary>
        Invalid = 2
    }
}
