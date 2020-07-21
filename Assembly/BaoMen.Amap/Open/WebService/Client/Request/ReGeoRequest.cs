using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaoMen.Amap.Open.WebService.Client.Request
{
    /// <summary>
    /// 逆地理编码
    /// </summary>
    public class ReGeoRequest: BaseRequest
    {
        /// <summary>
        /// 经纬度坐标 必填
        /// </summary>
        /// <remarks>
        /// 传入内容规则：经度在前，纬度在后，经纬度间以“,”分割，经纬度小数点后不要超过 6 位。如果需要解析多个经纬度的话，请用"|"进行间隔，并且将 batch 参数设置为 true，最多支持传入 20 对坐标点。每对点坐标之间用"|"分割。
        /// </remarks>
        [JsonProperty("location")]
        public string Location { get; set; }

        /// <summary>
        /// 返回附近POI类型
        /// </summary>
        [JsonProperty("poitype")]
        public string PoiType { get; set; }
    }
}
