using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaoMen.Amap.Open.WebService.Client.Response
{
    /// <summary>
    /// 地址元素
    /// </summary>
    [Serializable]
    [JsonObject(MemberSerialization.OptIn)]
    public class AddressComponent
    {
        /// <summary>
        /// 坐标点所在国家名称
        /// </summary>
        [JsonProperty("country")]
        //[JsonConverter(typeof(Utils.StringConverter))]
        public string Country { get; set; }

        /// <summary>
        /// 坐标点所在省名称
        /// </summary>
        [JsonProperty("province")]
        //[JsonConverter(typeof(Utils.StringConverter))]
        public string Province { get; set; }

        /// <summary>
        /// 坐标点所在城市名称
        /// </summary>
        [JsonProperty("city")]
        //[JsonConverter(typeof(Utils.StringConverter))]
        public string City { get; set; }

        /// <summary>
        /// 城市编码
        /// </summary>
        [JsonProperty("citycode")]
        //[JsonConverter(typeof(Utils.StringConverter))]
        public string CityCode { get; set; }

        /// <summary>
        /// 坐标点所在区
        /// </summary>
        [JsonProperty("district")]
        //[JsonConverter(typeof(Utils.StringConverter))]
        public string District { get; set; }

        /// <summary>
        /// 行政区编码
        /// </summary>
        [JsonProperty("adcode")]
        //[JsonConverter(typeof(Utils.StringConverter))]
        public string AdCode { get; set; }

        /// <summary>
        /// 坐标点所在乡镇/街道（此街道为社区街道，不是道路信息）
        /// </summary>
        [JsonProperty("township")]
        //[JsonConverter(typeof(Utils.StringConverter))]
        public string Township { get; set; }

        /// <summary>
        /// 坐标点所在乡镇/街道编码
        /// </summary>
        [JsonProperty("towncode")]
        //[JsonConverter(typeof(Utils.StringConverter))]
        public string Towncode { get; set; }

        /// <summary>
        /// 社区信息列表
        /// </summary>
        [JsonProperty("neighborhood")]
        public Neighborhood Neighborhood { get; set; }

        /// <summary>
        /// 楼信息列表
        /// </summary>
        [JsonProperty("building")]
        public Building Building { get; set; }

        /// <summary>
        /// 门牌信息列表
        /// </summary>
        [JsonProperty("streetNumber")]
        public StreetNumber StreetNumber { get; set; }

        /// <summary>
        /// 所属海域信息
        /// </summary>
        [JsonProperty("seaArea")]
        public string SeaArea { get; set; }

        /// <summary>
        /// 经纬度所属商圈列表
        /// </summary>
        [JsonProperty("businessAreas")]
        public IList<BusinessArea> BusinessAreas { get; set; }
    }
}
