using Newtonsoft.Json;
using System;

namespace BaoMen.WeChat.MiniProgram.Client.Basic
{
    /// <summary>
    /// 公众号的全局唯一票据
    /// </summary>
    /// <remarks>
    /// access_token	string	获取到的凭证
    /// expires_in number  凭证有效时间，单位：秒。目前是7200秒之内的值。
    /// errcode number  错误码
    /// errmsg string 错误信息
    /// </remarks>
    [Serializable]
    [JsonObject(MemberSerialization.OptIn)]
    public class GetAccessTokenResponse : BaseResponse
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
