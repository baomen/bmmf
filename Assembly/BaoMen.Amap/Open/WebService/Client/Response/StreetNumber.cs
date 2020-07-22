using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaoMen.Amap.Open.WebService.Client.Response
{
    /// <summary>
    /// 门牌信息列表
    /// </summary>
    [Serializable]
    [JsonObject(MemberSerialization.OptIn)]
    public class StreetNumber
    {
        /// <summary>
        /// 街道名称
        /// </summary>
        [JsonProperty("street")]
        public string Street { get; set; }

        /// <summary>
        /// 门牌号
        /// </summary>
        [JsonProperty("number")]
        public string Number { get; set; }

        /// <summary>
        /// 坐标点
        /// </summary>
        [JsonProperty("location")]
        public Location Location { get; set; }

        /// <summary>
        /// 方向
        /// </summary>
        [JsonProperty("direction")]
        public string Direction { get; set; }

        /// <summary>
        /// 门牌地址到请求坐标的距离 单位：米
        /// </summary>
        [JsonProperty("distance")]
        public string Distance { get; set; }
    }
}
