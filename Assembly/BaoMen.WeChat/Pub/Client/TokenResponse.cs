﻿using Newtonsoft.Json;
using System;

namespace BaoMen.WeChat.Pub.Client
{
    /// <summary>
    /// 公众号的全局唯一票据
    /// </summary>
    [Serializable]
    [JsonObject(MemberSerialization.OptIn)]
    public class TokenResponse : BaseResponse
    {
        /// <summary>
        ///  access_token	 获取到的凭证
        /// </summary>
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        /// expires_in	 凭证有效时间，单位：秒
        /// </summary>
        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }
    }
}