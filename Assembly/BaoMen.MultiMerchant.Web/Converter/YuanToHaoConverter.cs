using AutoMapper;
using System;

namespace BaoMen.MultiMerchant.Web.Converter
{
    /// <summary>
    /// 元 --> 豪
    /// </summary>
    public class YuanToHaoConverter : IValueConverter<decimal, long>, IValueConverter<decimal?, long?>
    {
        /// <summary>
        /// 转换
        /// </summary>
        /// <param name="sourceMember">源</param>
        /// <param name="context">上下文</param>
        /// <returns></returns>
        public long Convert(decimal sourceMember, ResolutionContext context)
        {
            return MultiMerchant.Util.Helper.YuanToHao(sourceMember);
        }

        /// <summary>
        /// 转换
        /// </summary>
        /// <param name="sourceMember">源</param>
        /// <param name="context">上下文</param>
        /// <returns></returns>
        public long? Convert(decimal? sourceMember, ResolutionContext context)
        {
            if (sourceMember.HasValue) return Convert(sourceMember.Value, context);
            return null;
        }
    }
}
