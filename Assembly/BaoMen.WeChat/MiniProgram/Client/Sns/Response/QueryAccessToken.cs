using Newtonsoft.Json;
using System;

namespace BaoMen.WeChat.MiniProgram.Client.Response
{
    /// <summary>
    /// 公众号的全局唯一票据
    /// </summary>
    [Serializable]
    [JsonObject(MemberSerialization.OptIn)]
    public class QueryAccessToken : BaseResponse
    {
        /// <summary>
        ///  access_token	 获取到的凭证
        /// </summary>
        [JsonProperty("access_token")]
        public string AccessTokenValue { get; set; }

        /// <summary>
        /// expires_in	 凭证有效时间，单位：秒
        /// </summary>
        [JsonProperty("expires_in")]
        public string ExpiresIn { get; set; }
    }
}
