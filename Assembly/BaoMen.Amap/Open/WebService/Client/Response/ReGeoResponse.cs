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

        ///// <summary>
        ///// 逆地理编码列表
        ///// </summary>
        ///// <remarks>
        ///// batch 字段设置为 true 时为批量请求，此时 regeocodes 标签返回，标签下为 regeocode 对象列表；batch 为false 时为单个请求，会返回 regeocode 对象；
        ///// </remarks>
        //[JsonProperty("regeocodes")]
        //public IList<ReGeoCode> ReGeoCodes { get; set; }
    }
}
