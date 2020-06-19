/*
Author: WangXinBin
CreateTime: 2019/10/23 11:51:32
*/

using Microsoft.Extensions.Configuration;
using System;
using BaoMen.MultiMerchant.Merchant.Entity;
using BaoMen.Common.Data;

namespace BaoMen.MultiMerchant.Merchant.BusinessLogic
{
    #region class UserDepartmentManager (generated)
    /// <summary>
    /// 商户用户部门业务逻辑
    /// </summary>
    public partial class UserDepartmentManager : Util.MerchantCacheableBusinessLogicBase<Tuple<string, string>, UserDepartment, UserDepartmentFilter, DataAccess.UserDepartment>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="configuration">配置实例</param>
        /// <param name="serviceProvider">服务提供程序</param>
        public UserDepartmentManager(IConfiguration configuration, IServiceProvider serviceProvider) : base(configuration, serviceProvider)
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
        internal DataAccess.UserDepartment Dal => dal;
    }
    #endregion
}