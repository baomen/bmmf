using AutoMapper;
using BaoMen.MultiMerchant.System.BusinessLogic;
using BaoMen.MultiMerchant.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaoMen.MultiMerchant.Web.Converter
{
    /// <summary>
    /// ID 到 名称 转换器
    /// </summary>
    public class KeyToNameConverter<TSourceMember, TManager> : IValueConverter<TSourceMember, string>, IValueConverter<ICollection<TSourceMember>, string>
        where TManager : IGetNameManager<TSourceMember>
    {
        private readonly TManager manager;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="manager">业务逻辑</param>
        public KeyToNameConverter(TManager manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// 转换
        /// </summary>
        /// <param name="sourceMember"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public string Convert(TSourceMember sourceMember, ResolutionContext context)
        {
            return manager.GetName(sourceMember);
        }

        /// <summary>
        /// 转换
        /// </summary>
        /// <param name="sourceMember"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public string Convert(ICollection<TSourceMember> sourceMember, ResolutionContext context)
        {
            if (sourceMember?.Count > 0)
            {
                return string.Join('/', sourceMember.Select(p => Convert(p, context)).ToArray());
            }
            return null;
        }
    }
}
