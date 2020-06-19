/*
Author: WangXinBin
CreateTime: 2019/10/23 11:51:54
*/

using BaoMen.Common.Data.Attribute;
using BaoMen.Common.Model;
using BaoMen.MultiMerchant.System.Entity;
using System;
using System.Collections.Generic;

namespace BaoMen.MultiMerchant.Merchant.Entity
{
    #region class Role (generated)
    /// <summary>
    /// 商户角色实体
    /// </summary>
	[Serializable]
    [DatabaseEntity(TableName = "mch_role")]
    public partial class Role
    {
        /// <summary>
        /// ID
        /// </summary>
        /// <remarks>
        /// ColumnName: Id (Primary Key)
        /// ColumnType: CHAR(32)
        /// AllowDBNull: False
        /// Unique: True
        /// Size: 32
        /// </remarks>
        public string Id { get; set; }

        /// <summary>
        /// 商户ID
        /// </summary>
        /// <remarks>
        /// ColumnName: MerchantId 
        /// ColumnType: CHAR(32)
        /// AllowDBNull: False
        /// Unique: False
        /// Size: 32
        /// </remarks>
        public string MerchantId { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        /// <remarks>
        /// ColumnName: Name 
        /// ColumnType: VARCHAR(100)
        /// AllowDBNull: False
        /// Unique: False
        /// Size: 100
        /// </remarks>
        public string Name { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        /// <remarks>
        /// ColumnName: Status 
        /// ColumnType: INT(11)
        /// AllowDBNull: False
        /// Unique: False
        /// Size: 0
        /// </remarks>
        public int Status { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        /// <remarks>
        /// ColumnName: Description 
        /// ColumnType: VARCHAR(500)
        /// AllowDBNull: True
        /// Unique: False
        /// Size: 500
        /// </remarks>
        public string Description { get; set; }

    }
    #endregion

    #region class RoleFilter (generated)
    /// <summary>
    /// 商户角色实体过滤器
    /// </summary>
    [Serializable]
    [DatabaseEntityFilter(EntityType = typeof(Role))]
    public partial class RoleFilter : Util.IMerchantFilter
    {
        /// <summary>
        /// ID
        /// </summary>
        [DatabaseEntityFilterProperty(EntityPropertyName = "Id")]
        public FilterProperty<string> Id { get; set; }

        /// <summary>
        /// 商户ID
        /// </summary>
        [DatabaseEntityFilterProperty(EntityPropertyName = "MerchantId")]
        public FilterProperty<string> MerchantId { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [DatabaseEntityFilterProperty(EntityPropertyName = "Name")]
        public FilterProperty<string> Name { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [DatabaseEntityFilterProperty(EntityPropertyName = "Status")]
        public FilterProperty<int> Status { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [DatabaseEntityFilterProperty(EntityPropertyName = "Description")]
        public FilterProperty<string> Description { get; set; }

    }
    #endregion

    public partial class Role : Util.IMerchantData
    {
        /// <summary>
        /// 商户
        /// </summary>
        public Merchant Merchant { get; set; }

        /// <summary>
        /// 拥有的模块
        /// </summary>
        //[SourceMember(nameof(Model.Role.ModuleIds))]
        //[ValueConverter(typeof(Model.ModuleToIdValueConverter))]
        public ICollection<Module> Modules { get; set; }
    }
}