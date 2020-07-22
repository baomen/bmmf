using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaoMen.Amap.Open.WebService.Client.Response
{
    /// <summary>
    /// 道路信息
    /// </summary>
    [Serializable]
    [JsonObject(MemberSerialization.OptIn)]
    public class Road
    {
        /// <summary>
        /// 道路id 
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// 道路到请求坐标的距离
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// 道路名称
        /// </summary>
        [JsonProperty("distance")]
        public string Distance { get; set; }

        /// <summary>
        /// 方位
        /// </summary>
        [JsonProperty("direction")]
        public string Direction { get; set; }

        /// <summary>
        /// 商圈中心点经纬度
        /// </summary>
        [JsonProperty("location")]
        public Location Location { get; set; }
    }
}
