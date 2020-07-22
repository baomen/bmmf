using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaoMen.Amap.Open.WebService.Client.Response
{
    /// <summary>
    /// 社区信息列表
    /// </summary>
    [Serializable]
    [JsonObject(MemberSerialization.OptIn)]
    public class Neighborhood
    {
        /// <summary>
        /// 社区名称
        /// </summary>
        [JsonProperty("name")]
        [JsonConverter(typeof(Utils.StringConverter))]
        public string Name { get; set; }

        /// <summary>
        /// POI类型
        /// </summary>
        [JsonProperty("type")]
        [JsonConverter(typeof(Utils.StringConverter))]
        public string Type { get; set; }
    }
}
