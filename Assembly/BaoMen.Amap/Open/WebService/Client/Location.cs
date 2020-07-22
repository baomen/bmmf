using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaoMen.Amap.Open.WebService.Client
{
    /// <summary>
    /// 坐标
    /// </summary>
    [Serializable]
    //[JsonObject(MemberSerialization.OptIn)]
    public class Location
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="location">坐标字符串</param>
        public Location(string location)
        {
            if (!string.IsNullOrEmpty(location))
            {
                string[] temp = location.Split(',');
                if (temp.Length == 2)
                {
                    if (decimal.TryParse(temp[0], out decimal longitude))
                    {
                        Longitude = longitude;
                    }
                    if (decimal.TryParse(temp[1], out decimal latitude))
                    {
                        Latitude = latitude;
                    }
                }
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="longitude">经度</param>
        /// <param name="latitude">纬度</param>
        public Location(decimal longitude, decimal latitude)
        {
            Longitude = longitude;
            Latitude = latitude;
        }

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

        /// <summary>
        /// 隐式转换
        /// </summary>
        /// <param name="value">字符串值</param>
        public static implicit operator Location(string value)
        {
            return new Location(value);
        }
    }
}
