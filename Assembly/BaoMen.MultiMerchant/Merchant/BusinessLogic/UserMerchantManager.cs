
/*
Author: WangXinBin
CreateTime: 2022-04-14 12:41:10
*/

using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using BaoMen.MultiMerchant.Merchant.Entity;
using BaoMen.Common.Data;

namespace BaoMen.MultiMerchant.Merchant.BusinessLogic
{
    #region class UserMerchantManager (generated)
    /// <summary>
    /// 商户用户对应关系表业务逻辑
    /// </summary>
    public partial class UserMerchantManager : CacheableBusinessLogicBase<Tuple<string,string>,UserMerchant,UserMerchantFilter,DataAccess.UserMerchant>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="configuration">配置实例</param>
        /// <param name="serviceProvider">服务提供程序</param>
        public UserMerchantManager(IConfiguration configuration, IServiceProvider serviceProvider) : base(configuration)
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
        /// 数据访问实例
        /// </summary>
        internal DataAccess.UserMerchant Dal => dal;
    }
    #endregion
}