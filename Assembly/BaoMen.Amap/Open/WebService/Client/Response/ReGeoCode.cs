using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaoMen.Amap.Open.WebService.Client.Response
{
    /// <summary>
    /// 逆地理编码
    /// </summary>
    [Serializable]
    [JsonObject(MemberSerialization.OptIn)]
    public class ReGeoCode
    {
        /// <summary>
        /// 结构化地址信息
        /// </summary>
        /// <remarks>
        /// 结构化地址信息包括：省份＋城市＋区县＋城镇＋乡村＋街道＋门牌号码
        /// 如果坐标点处于海域范围内，则结构化地址信息为：省份＋城市＋区县＋海域信息
        /// </remarks>
        [JsonProperty("formatted_address")]
        [JsonConverter(typeof(Utils.StringConverter))]
        public string FormattedAddress { get; set; }

        /// <summary>
        /// 地址元素列表
        /// </summary>
        [JsonProperty("addressComponent")]
        public AddressComponent AddressComponent { get; set; }

        /// <summary>
        /// 道路信息列表
        /// </summary>
        [JsonProperty("roads")]
        public List<Road> Roads { get; set; }
    }
}
