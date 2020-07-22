using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaoMen.Amap.Open.WebService.Client.Response
{
    /// <summary>
    /// 楼信息列表
    /// </summary>
    [Serializable]
    [JsonObject(MemberSerialization.OptIn)]
    public class Building
    {
        /// <summary>
        /// 建筑名称
        /// </summary>
        [JsonProperty("name")]
        [JsonConverter(typeof(Utils.StringConverter))]
        public string Name { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        [JsonProperty("type")]
        [JsonConverter(typeof(Utils.StringConverter))]
        public string Type { get; set; }
    }
}
