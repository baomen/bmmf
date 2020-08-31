﻿using System;

namespace BaoMen.MultiMerchant.Web.WeChat.MiniProgram.Models
{
    /// <summary>
    /// 登录凭证校验
    /// </summary>
    /// <remarks>
    /// openid	string	用户唯一标识
    /// session_key string 会话密钥
    /// unionid string 用户在开放平台的唯一标识符，在满足 UnionID 下发条件的情况下会返回，详见 UnionID 机制说明。
    /// errcode number  错误码
    /// errmsg string 错误信息
    /// </remarks>
    [Serializable]
    public class CodeToSessionResponse : BaseResponse
    {
        /// <summary>
        /// openid	 用户唯一标识，请注意，在未关注公众号时，用户访问公众号的网页，也会产生一个用户和公众号唯一的OpenID
        /// </summary>
        public string OpenId { get; set; }

        ///// <summary>
        ///// session_key	string	会话密钥
        ///// </summary>
        //public string SessionKey { get; set; }

        /// <summary>
        /// unionid	string	用户在开放平台的唯一标识符，在满足 UnionID 下发条件的情况下会返回，详见 UnionID 机制说明。。
        /// </summary>
        public string UnionId { get; set; }
    }
}
