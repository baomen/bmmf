/*
Author: WangXinBin
CreateTime: 2019/10/23 12:04:04
*/

using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using BaoMen.MultiMerchant.System.Entity;
using BaoMen.Common.Data;

namespace BaoMen.MultiMerchant.System.BusinessLogic
{
    #region class VersionModuleManager (generated)
    /// <summary>
    /// 系统版本模块业务逻辑
    /// </summary>
    public partial class VersionModuleManager : CacheableBusinessLogicBase<Tuple<string,string>,VersionModule,VersionModuleFilter,DataAccess.VersionModule>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="configuration">配置实例</param>
        public VersionModuleManager(IConfiguration configuration) : base(configuration)
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
        /// 版本模块数据访问实例
        /// </summary>
        internal DataAccess.VersionModule Dal => dal;
    }
    #endregion
}