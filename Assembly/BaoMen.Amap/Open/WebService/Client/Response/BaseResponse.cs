using Newtonsoft.Json;
using System;

namespace BaoMen.Amap.Open.WebService.Client.Response
{
    /// <summary>
    /// 相应信息
    /// </summary>
    [Serializable]
    [JsonObject(MemberSerialization.OptIn)]
    public class BaseResponse
    {
        /// <summary>
        /// 返回结果状态值
        /// </summary>
        /// <remarks>
        /// 返回值为 0 或 1，0 表示请求失败；1 表示请求成功。
        /// </remarks>
        [JsonProperty("status")]
        public int Status { get; set; }

        /// <summary>
        /// 返回状态说明
        /// </summary>
        /// <remarks>
        /// 当 status 为 0 时，info 会返回具体错误原因，否则返回“OK”。详情可以参考info状态表
        /// </remarks>
        [JsonProperty("info")]
        public string Info { get; set; }

        /// <summary>
        /// 返回状态编码
        /// </summary>
        /// <remarks>
        /// 10000 OK 请求正常表
        /// </remarks>
        [JsonProperty("infocode")]
        public string InfoCode { get; set; }
    }
}
