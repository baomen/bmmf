using AutoMapper;
using BaoMen.MultiMerchant.Merchant.BusinessLogic;

namespace BaoMen.MultiMerchant.Web.Merchant.Mapper
{
    /// <summary>
    /// 商户参数ID转为名称
    /// </summary>
    public class ParameterIdToNameConverter : IValueConverter<string, string>
    {
        private readonly IParameterManager parameterManager;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="parameterManager">商户参数业务逻辑</param>
        public ParameterIdToNameConverter(IParameterManager parameterManager)
        {
            this.parameterManager = parameterManager;
        }

        /// <summary>
        /// 转换
        /// </summary>
        /// <param name="sourceMember"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public string Convert(string sourceMember, ResolutionContext context)
        {
            return parameterManager.Get(sourceMember)?.Name;
        }
    }

    /// <summary>
    /// 商户参数值-->名称转换器
    /// </summary>
    public class ParameterValueToNameConverter : IValueConverter<System.Mapper.ParameterSourceMember, string>
    {
        private readonly IParameterManager parameterManager;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="parameterManager">商户参数业务逻辑</param>
        public ParameterValueToNameConverter(IParameterManager parameterManager)
        {
            this.parameterManager = parameterManager;
        }

        /// <summary>
        /// 转换
        /// </summary>
        /// <param name="sourceMember"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public string Convert(System.Mapper.ParameterSourceMember sourceMember, ResolutionContext context)
        {
            return parameterManager.Get(sourceMember.ParentId, sourceMember.Value)?.Name;
        }
    }
}
