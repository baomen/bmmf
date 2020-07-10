using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace BaoMen.WeChat.MiniProgram.Client.Response
{
    /// <summary>
    /// 登录凭证校验
    /// </summary>
    [Serializable]
    [JsonObject(MemberSerialization.OptIn)]
    public class CodeToSession : BaseResponse
    {
        /// <summary>
        /// openid	 用户唯一标识，请注意，在未关注公众号时，用户访问公众号的网页，也会产生一个用户和公众号唯一的OpenID
        /// </summary>
        [JsonProperty("openid")]
        public string OpenId { get; set; }

        /// <summary>
        /// session_key	string	会话密钥
        /// </summary>
        [JsonProperty("session_key")]
        public string SessionKey { get; set; }

        /// <summary>
        /// unionid	string	用户在开放平台的唯一标识符，在满足 UnionID 下发条件的情况下会返回，详见 UnionID 机制说明。。
        /// </summary>
        [JsonProperty("unionid")]
        public string UnionId { get; set; }
    }
}
