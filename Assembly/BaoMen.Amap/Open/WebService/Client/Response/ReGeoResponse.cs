using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaoMen.Amap.Open.WebService.Client.Response
{
    /// <summary>
    /// 逆地理编码
    /// </summary>
    public class ReGeoResponse : BaseResponse
    {
        /// <summary>
        /// 逆地理编码列表
        /// </summary>
        /// <remarks>
        /// batch 字段设置为 true 时为批量请求，此时 regeocodes 标签返回，标签下为 regeocode 对象列表；batch 为false 时为单个请求，会返回 regeocode 对象；
        /// </remarks>
        [JsonProperty("regeocode")]
        public ReGeoCode ReGeoCode { get; set; }

        /// <summary>
        /// 逆地理编码列表
        /// </summary>
        /// <remarks>
        /// batch 字段设置为 true 时为批量请求，此时 regeocodes 标签返回，标签下为 regeocode 对象列表；batch 为false 时为单个请求，会返回 regeocode 对象；
        /// </remarks>
        [JsonProperty("regeocodes")]
        public IList<ReGeoCode> ReGeoCodes { get; set; }
    }

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
        public IList<Road> Roads { get; set; }
    }

    /// <summary>
    /// 坐标点
    /// </summary>
    public class Location
    {
        /// <summary>
        /// 经度
        /// </summary>
        public decimal Longitude { get; set; }

        /// <summary>
        /// 纬度
        /// </summary>
        public decimal Latitude { get; set; }

        /// <summary>
        /// 重写基类方法
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0},{1}", Longitude.ToString("0.000000"), Latitude.ToString("0.000000"));
        }
    }

    /// <summary>
    /// 地址元素
    /// </summary>
    [Serializable]
    [JsonObject(MemberSerialization.OptIn)]
    public class AddressComponent
    {
        /// <summary>
        /// 坐标点所在省名称
        /// </summary>
        [JsonProperty("province")]
        public string Province { get; set; }

        /// <summary>
        /// 坐标点所在城市名称
        /// </summary>
        [JsonProperty("city")]
        [JsonConverter(typeof(Utils.StringConverter))]
        public string City { get; set; }

        /// <summary>
        /// 城市编码
        /// </summary>
        [JsonProperty("citycode")]
        public string CityCode { get; set; }

        /// <summary>
        /// 坐标点所在区
        /// </summary>
        [JsonProperty("district")]
        public string District { get; set; }

        /// <summary>
        /// 行政区编码
        /// </summary>
        [JsonProperty("adcode")]
        public string AdCode { get; set; }

        /// <summary>
        /// 坐标点所在乡镇/街道（此街道为社区街道，不是道路信息）
        /// </summary>
        [JsonProperty("township")]
        public string Township { get; set; }

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
        public string Name { get; set; }

        /// <summary>
        /// POI类型
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }
    }

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
        public string Name { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }
    }

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

    /// <summary>
    /// 经纬度所属商圈
    /// </summary>
    [Serializable]
    [JsonObject(MemberSerialization.OptIn)]
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
