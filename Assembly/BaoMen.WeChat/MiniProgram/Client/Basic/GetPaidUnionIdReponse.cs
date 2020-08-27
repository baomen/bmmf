using Newtonsoft.Json;
using System;

namespace BaoMen.WeChat.MiniProgram.Client.Basic
{
    /// <summary>
    /// 用户支付完成后，获取该用户的 UnionId
    /// </summary>
    /// <remarks>
    /// unionid string 用户唯一标识，调用成功后返回
    /// errcode number  错误码
    /// errmsg string 错误信息
    /// </remarks>
    [Serializable]
    [JsonObject(MemberSerialization.OptIn)]
    public class GetPaidUnionIdReponse : BaseResponse
    {
        /// <summary>
        /// unionid	string	用户在开放平台的唯一标识符，在满足 UnionID 下发条件的情况下会返回，详见 UnionID 机制说明。。
        /// </summary>
        [JsonProperty("unionid")]
        public string UnionId { get; set; }
    }
}
