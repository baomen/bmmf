using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaoMen.MultiMerchant.Util
{
    /// <summary>
    /// 帮助类
    /// </summary>
    public class Helper
    {
        /// <summary>
        /// 将JObject转换为具体的类型
        /// </summary>
        /// <typeparam name="T">具体的类型</typeparam>
        /// <param name="value">objec包装过的JObject对象</param>
        /// <returns></returns>
        public static T Parse<T>(object value)
            where T : class
        {
            if (value == null) return null;
            JObject jObject = value as JObject;
            if (jObject == null)
            {
                return null;
            }
            return jObject.ToObject<T>();
        }

        /// <summary>
        /// 从百分比的值转换为decimal
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static decimal FromPercent(decimal value)
        {
            return Math.Round(value / 100, 4);
        }

        /// <summary>
        /// 四舍六入五成双算法计算费用
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int GetFee(decimal value)
        {
            return (int)Math.Round(value, 0);
        }

        /// <summary>
        /// 计算不含税费用
        /// </summary>
        /// <param name="fee"></param>
        /// <param name="taxRate"></param>
        /// <returns></returns>
        public static int GetFeeWithoutTax(int fee, decimal taxRate)
        {
            if (taxRate == 0) return fee;
            decimal tax = Util.Helper.FromPercent(taxRate);
            return GetFee(fee / (1 + tax));
        }
    }
}
