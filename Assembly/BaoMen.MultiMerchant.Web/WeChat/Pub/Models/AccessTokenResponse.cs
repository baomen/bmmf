﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BaoMen.MultiMerchant.Web.WeChat.Pub.Models
{
    /// <summary>
    /// 用户票据
    /// </summary>
    [Serializable]
    public class AccessTokenResponse : BaseResponse
    {
        /// <summary>
        /// access_token	 网页授权接口调用凭证,注意：此access_token与基础支持的access_token不同
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// expires_in	 access_token接口调用凭证超时时间，单位（秒）
        /// </summary>
        public int ExpiresIn { get; set; }

        /// <summary>
        /// refresh_token	 用户刷新access_token
        /// </summary>
        public string RefreshToken { get; set; }

        /// <summary>
        /// openid	 用户唯一标识，请注意，在未关注公众号时，用户访问公众号的网页，也会产生一个用户和公众号唯一的OpenID
        /// </summary>
        public string OpenId { get; set; }

        /// <summary>
        /// scope	 用户授权的作用域，使用逗号（,）分隔
        /// </summary>
        public string Scope { get; set; }

        /// <summary>
        /// unionid	 当且仅当该网站应用已获得该用户的userinfo授权时，才会出现该字段。
        /// </summary>
        public string UnionId { get; set; }
    }
}
