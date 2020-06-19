/*
Author: WangXinBin
CreateTime: 2019/10/23 11:52:23
*/

using Microsoft.Extensions.Configuration;
using System;
using BaoMen.MultiMerchant.Merchant.Entity;
using BaoMen.Common.Data;

namespace BaoMen.MultiMerchant.Merchant.BusinessLogic
{
    #region class RoleModuleManager (generated)
    /// <summary>
    /// 商户角色模块业务逻辑
    /// </summary>
    public partial class RoleModuleManager : Util.MerchantCacheableBusinessLogicBase<Tuple<string, string>, RoleModule, RoleModuleFilter, DataAccess.RoleModule>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="configuration">配置实例</param>
        /// <param name="serviceProvider">服务提供程序</param>
        public RoleModuleManager(IConfiguration configuration, IServiceProvider serviceProvider) : base(configuration, serviceProvider)
        {

        }

        /// <summary>
        /// 获取实体标识字段名称
        /// </summary>
        /// <remarks>
        /// <para>默认标识字段不为Id。覆盖此属性</para>
        /// </remarks>
        protected override string IdentityPropertyName
        {
            get { return "ComplexKey"; }
        }

        /// <summary>
        /// 角色模块数据访问实例
        /// </summary>
        internal DataAccess.RoleModule Dal => dal;
    }
    #endregion
}