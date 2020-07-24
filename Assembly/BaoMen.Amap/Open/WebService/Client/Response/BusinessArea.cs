using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaoMen.Amap.Open.WebService.Client.Response
{
    /// <summary>
    /// 经纬度所属商圈
    /// </summary>
    [Serializable]
    [JsonObject(MemberSerialization.OptIn)]
    [JsonArray(AllowNullItems = false)]
    public class BusinessArea
    {
        /// <summary>
        /// 商圈中心点经纬度
        /// </summary>
        [JsonProperty("location")]
        public Location Location { get; set; }

        /// <summary>
        /// 商圈名称
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// 商圈所在区域的adcode 
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
