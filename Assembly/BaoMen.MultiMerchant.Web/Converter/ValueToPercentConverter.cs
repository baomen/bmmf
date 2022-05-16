using AutoMapper;
using System;

namespace BaoMen.MultiMerchant.Web.Converter
{
    /// <summary>
    /// 值 --> 百分比
    /// </summary>
    public class ValueToPercentConverter : IValueConverter<decimal, decimal>, IValueConverter<double, double>
    {
        /// <summary>
        /// 转换
        /// </summary>
        /// <param name="sourceMember">源</param>
        /// <param name="context">上下文</param>
        /// <returns></returns>
        public decimal Convert(decimal sourceMember, ResolutionContext context)
        {
            return (decimal)(double)(sourceMember * 100);
        }

        /// <summary>
        /// 转换
        /// </summary>
        /// <param name="sourceMember">源</param>
        /// <param name="context">上下文</param>
        /// <returns></returns>
        public double Convert(double sourceMember, ResolutionContext context)
        {
            return sourceMember * 100;
        }
    }
}
