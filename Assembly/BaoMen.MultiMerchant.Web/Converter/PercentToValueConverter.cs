using AutoMapper;
using System;

namespace BaoMen.MultiMerchant.Web.Converter
{
    /// <summary>
    /// 百分比 --> 值
    /// </summary>
    public class PercentToValueConverter : IValueConverter<decimal, decimal>
    {
        /// <summary>
        /// 转换
        /// </summary>
        /// <param name="sourceMember">源</param>
        /// <param name="context">上下文</param>
        /// <returns></returns>
        public decimal Convert(decimal sourceMember, ResolutionContext context)
        {
            return sourceMember / 100;
        }
    }
}
