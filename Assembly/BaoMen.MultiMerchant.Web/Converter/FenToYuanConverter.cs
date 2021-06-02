using AutoMapper;
using System;

namespace BaoMen.MultiMerchant.Web.Converter
{
    /// <summary>
    /// 分 --> 元
    /// </summary>
    public class FenToYuanConverter : IValueConverter<int, decimal>, IValueConverter<long, decimal>
    {
        /// <summary>
        /// 转换
        /// </summary>
        /// <param name="sourceMember">源</param>
        /// <param name="context">上下文</param>
        /// <returns></returns>
        public decimal Convert(int sourceMember, ResolutionContext context)
        {
            return Math.Round(((decimal)sourceMember) / 100, 2);
        }

        /// <summary>
        /// 转换
        /// </summary>
        /// <param name="sourceMember">源</param>
        /// <param name="context">上下文</param>
        /// <returns></returns>
        public decimal Convert(long sourceMember, ResolutionContext context)
        {
            return Math.Round(((decimal)sourceMember) / 100, 2);
        }
    }
}
