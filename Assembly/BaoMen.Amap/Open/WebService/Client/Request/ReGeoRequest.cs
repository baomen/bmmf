using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaoMen.Amap.Open.WebService.Client.Request
{
    /// <summary>
    /// 逆地理编码
    /// </summary>
    public class ReGeoRequest : BaseRequest
    {
        /// <summary>
        /// 经纬度坐标 必填
        /// </summary>
        /// <remarks>
        /// 传入内容规则：经度在前，纬度在后，经纬度间以“,”分割，经纬度小数点后不要超过 6 位。如果需要解析多个经纬度的话，请用"|"进行间隔，并且将 batch 参数设置为 true，最多支持传入 20 对坐标点。每对点坐标之间用"|"分割。
        /// </remarks>
        //[JsonProperty("location")]
        public Location Location
        {
            get
            {
                return values.ContainsKey("location") ? (Location)values["location"] : default;
            }
            set
            {
                values["location"] = value;
            }
        }

        /// <summary>
        /// 返回附近POI类型
        /// </summary>
        //[JsonProperty("poitype")]
        public string PoiType
        {
            get
            {
                return values.ContainsKey("poitype") ? (string)values["poitype"] : default;
            }
            set
            {
                values["poitype"] = value;
            }
        }

        /// <summary>
        /// 搜索半径    默认值1000
        /// </summary>
        /// <remarks>
        /// radius取值范围在0~3000，默认是1000。单位：米
        /// </remarks>
        //[JsonProperty("radius")]
        public decimal? Radius
        {
            get
            {
                return values.ContainsKey("radius") ? (decimal)values["radius"] : default;
            }
            set
            {
                values["radius"] = value;
            }
        }

        /// <summary>
        /// 返回结果控制  默认值base
        /// </summary>
        /// <remarks>
        /// extensions 参数默认取值是 base，也就是返回基本地址信息；
        /// extensions 参数取值为 all 时会返回基本地址信息、附近 POI 内容、道路信息以及道路交叉口信息。
        /// </remarks>
        //[JsonProperty("extensions")]
        public string Extensions
        {
            get
            {
                return values.ContainsKey("extensions") ? (string)values["extensions"] : default;
            }
            set
            {
                values["extensions"] = value;
            }
        }

        /// <summary>
        /// 批量查询控制    默认值false
        /// </summary>
        /// <remarks>
        /// batch 参数设置为 true 时进行批量查询操作，最多支持 20 个经纬度点进行批量地址查询操作。
        /// batch 参数设置为 false 时进行单点查询，此时即使传入多个经纬度也只返回第一个经纬度的地址解析查询结果。
        /// </remarks>
        //[JsonProperty("batch")]
        public bool? Batch
        {
            get
            {
                return values.ContainsKey("batch") ? (bool)values["batch"] : default;
            }
            set
            {
                values["batch"] = value;
            }
        }

        /// <summary>
        /// 道路等级
        /// </summary>
        /// <remarks>
        /// 以下内容需要 extensions 参数为 all 时才生效。
        /// 可选值：0，1
        /// 当roadlevel=0时，显示所有道路
        /// 当roadlevel = 1时，过滤非主干道路，仅输出主干道路数据
        /// </remarks>
        //[JsonProperty("roadlevel")]
        public int? RoadLevel
        {
            get
            {
                return values.ContainsKey("roadlevel") ? (int)values["roadlevel"] : default;
            }
            set
            {
                values["roadlevel"] = value;
            }
        }


        /// <summary>
        /// 返回数据格式类型    默认值 JSON
        /// </summary>
        /// <remarks>
        /// 可选输入内容包括：JSON，XML。设置 JSON 返回结果数据将会以JSON结构构成；如果设置 XML 返回结果数据将以 XML 结构构成。
        /// </remarks>
        //[JsonProperty("output")]
        public string Output
        {
            get
            {
                return values.ContainsKey("output") ? (string)values["output"] : default;
            }
            set
            {
                values["output"] = value;
            }
        }

        /// <summary>
        /// 回调函数
        /// </summary>
        /// <remarks>
        /// callback 值是用户定义的函数名称，此参数只在 output 参数设置为 JSON 时有效。
        /// </remarks>
        //[JsonProperty("callback")]
        public string Callback
        {
            get
            {
                return values.ContainsKey("callback") ? (string)values["callback"] : default;
            }
            set
            {
                values["callback"] = value;
            }
        }

        /// <summary>
        /// 数字签名    默认值 0
        /// </summary>
        /// <remarks>
        /// 以下内容需要 extensions 参数为 all 时才生效。
        /// homeorcorp 参数的设置可以影响召回 POI 内容的排序策略，目前提供三个可选参数：
        /// 0：不对召回的排序策略进行干扰。
        /// 1：综合大数据分析将居家相关的 POI 内容优先返回，即优化返回结果中 pois 字段的poi顺序。
        /// 2：综合大数据分析将公司相关的 POI 内容优先返回，即优化返回结果中 pois 字段的poi顺序。
        /// </remarks>
        //[JsonProperty("homeorcorp")]
        public int? HomeOrCorp
        {
            get
            {
                return values.ContainsKey("homeorcorp") ? (int)values["homeorcorp"] : default;
            }
            set
            {
                values["homeorcorp"] = value;
            }
        }
    }
}
