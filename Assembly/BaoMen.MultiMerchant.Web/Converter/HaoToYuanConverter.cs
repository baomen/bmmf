using AutoMapper;
using System;

namespace BaoMen.MultiMerchant.Web.Converter
{
    /// <summary>
    /// 豪 --> 元
    /// </summary>
    public class HaoToYuanConverter : IValueConverter<long, decimal>, IValueConverter<long?, decimal?>
    {
        /// <summary>
        /// 转换
        /// </summary>
        /// <param name="sourceMember">源</param>
        /// <param name="context">上下文</param>
        /// <returns></returns>
        public decimal Convert(long sourceMember, ResolutionContext context)
        {
            return Math.Round(((decimal)sourceMember) / 10000, 4);
        }

        /// <summary>
        /// 转换
        /// </summary>
        /// <param name="sourceMember">源</param>
        /// <param name="context">上下文</param>
        /// <returns></returns>
        public decimal? Convert(long? sourceMember, ResolutionContext context)
        {
            if (sourceMember.HasValue) return Convert(sourceMember.Value, context);
            return null;
        }
    }
}
