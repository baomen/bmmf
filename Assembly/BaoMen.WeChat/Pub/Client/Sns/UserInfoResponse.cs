using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaoMen.WeChat.Pub.Client.Sns
{
    /// <summary>
    /// 获取用户基本信息
    /// </summary>
    [Serializable]
    [JsonObject(MemberSerialization.OptIn)]
    public class UserInfoResponse : BaseResponse
    {
        /// <summary>
        /// 用户的标识，对当前公众号唯一
        /// </summary>
        [JsonProperty("openid")]
        public string OpenId { get; set; }

        /// <summary>
        /// 用户的昵称
        /// </summary>
        [JsonProperty("nickname")]
        public string NickName { get; set; }

        /// <summary>
        /// 用户的性别，值为1时是男性，值为2时是女性，值为0时是未知
        /// </summary>
        [JsonProperty("sex")]
        public string Sex { get; set; }

        /// <summary>
        /// 用户所在城市
        /// </summary>
        [JsonProperty("city")]
        public string City { get; set; }

        /// <summary>
        /// 用户所在国家
        /// </summary>
        [JsonProperty("country")]
        public string Country { get; set; }

        /// <summary>
        /// 用户所在省份
        /// </summary>
        [JsonProperty("province")]
        public string Province { get; set; }

        /// <summary>
        /// 用户头像，最后一个数值代表正方形头像大小（有0、46、64、96、132数值可选，0代表640*640正方形头像），用户没有头像时该项为空
        /// </summary>
        [JsonProperty("headimgurl")]
        public string HeadImgUrl { get; set; }

        /// <summary>
        /// 只有在用户将公众号绑定到微信开放平台帐号后，才会出现该字段。
        /// </summary>
        [JsonProperty("unionid")]
        public string UnionId { get; set; }

        /// <summary>
        /// 用户特权信息，json 数组，如微信沃卡用户为（chinaunicom）
        /// </summary>
        [JsonProperty("privilege")]
        public List<string> Privilege { get; set; }
    }
}
