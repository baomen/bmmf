/*
Author: WangXinBin
CreateTime: 2019/10/23 11:52:25
*/

using Microsoft.Extensions.Configuration;
using System;
using BaoMen.MultiMerchant.Merchant.Entity;
using BaoMen.Common.Data;

namespace BaoMen.MultiMerchant.Merchant.BusinessLogic
{
    #region class UserRoleManager (generated)
    /// <summary>
    /// 商户用户角色业务逻辑
    /// </summary>
    public partial class UserRoleManager : Util.MerchantCacheableBusinessLogicBase<Tuple<string, string>, UserRole, UserRoleFilter, DataAccess.UserRole>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="configuration">配置实例</param>
        /// <param name="serviceProvider">服务提供程序</param>
        public UserRoleManager(IConfiguration configuration, IServiceProvider serviceProvider) : base(configuration, serviceProvider)
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
        /// 内部使用的数据访问实体
        /// </summary>
        internal DataAccess.UserRole Dal => dal;
    }
    #endregion
}