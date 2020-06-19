/*
Author: WangXinBin
CreateTime: 2019/10/23 11:52:22
*/

using BaoMen.Common.Data.Attribute;
using BaoMen.Common.Model;
using System;
using System.Collections.Generic;

namespace BaoMen.MultiMerchant.Merchant.Entity
{
    #region class RoleModule (generated)
    /// <summary>
    /// 商户角色模块实体
    /// </summary>
	[Serializable]
    [DatabaseEntity(TableName = "mch_role_module")]
    public partial class RoleModule
    {
        private Tuple<string, string> complexKey;
        /// <summary>
        /// 复合主键Item1:RoleId  Item2:ModuleId  
        /// </summary>
        public Tuple<string, string> ComplexKey
        {
            get
            {
                if (complexKey == null)
                {
                    complexKey = Tuple.Create(RoleId, ModuleId);
                }
                return complexKey;
            }
        }
        /// <summary>
        /// 角色ID
        /// </summary>
        /// <remarks>
        /// ColumnName: RoleId (Primary Key)
        /// ColumnType: CHAR(32)
        /// AllowDBNull: False
        /// Unique: False
        /// Size: 32
        /// </remarks>
        public string RoleId { get; set; }

        /// <summary>
        /// 模块ID
        /// </summary>
        /// <remarks>
        /// ColumnName: ModuleId (Primary Key)
        /// ColumnType: CHAR(32)
        /// AllowDBNull: False
        /// Unique: False
        /// Size: 32
        /// </remarks>
        public string ModuleId { get; set; }

    }
    #endregion

    #region class RoleModuleFilter (generated)
    /// <summary>
    /// 商户角色模块实体过滤器
    /// </summary>
    [Serializable]
    [DatabaseEntityFilter(EntityType = typeof(RoleModule))]
    public partial class RoleModuleFilter
    {
        /// <summary>
        /// 角色ID
        /// </summary>
        [DatabaseEntityFilterProperty(EntityPropertyName = "RoleId")]
        public FilterProperty<string> RoleId { get; set; }

        /// <summary>
        /// 模块ID
        /// </summary>
        [DatabaseEntityFilterProperty(EntityPropertyName = "ModuleId")]
        public FilterProperty<string> ModuleId { get; set; }

    }
    #endregion

    public partial class RoleModuleFilter : Util.IMerchantFilter
    {
        /// <summary>
        /// 商户ID
        /// </summary>
        public FilterProperty<string> MerchantId { get; set; }
    }
}