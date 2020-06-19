/*
Author: WangXinBin
CreateTime: 2019/10/30 11:40:23
*/

using BaoMen.Common.Data.Attribute;
using BaoMen.Common.Model;
using System;
using System.Collections.Generic;

namespace BaoMen.MultiMerchant.Merchant.Entity
{
    #region class Department (generated)
    /// <summary>
    /// 商户部门实体
    /// </summary>
	[Serializable]
    [DatabaseEntity(TableName = "mch_department")]
    public partial class Department : IHierarchicalData<string>
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
        /// 上级ID
        /// </summary>
        /// <remarks>
        /// ColumnName: ParentId 
        /// ColumnType: CHAR(32)
        /// AllowDBNull: False
        /// Unique: False
        /// Size: 32
        /// </remarks>
        public string ParentId { get; set; }

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
        /// ColumnType: VARCHAR(200)
        /// AllowDBNull: False
        /// Unique: False
        /// Size: 200
        /// </remarks>
        public string Name { get; set; }

        /// <summary>
        /// 显示顺序
        /// </summary>
        /// <remarks>
        /// ColumnName: VisibleIndex 
        /// ColumnType: INT(11)
        /// AllowDBNull: False
        /// Unique: False
        /// Size: 0
        /// </remarks>
        public int VisibleIndex { get; set; }

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

    #region class DepartmentFilter (generated)
    /// <summary>
    /// 商户部门实体过滤器
    /// </summary>
    [Serializable]
    [DatabaseEntityFilter(EntityType = typeof(Department))]
    public partial class DepartmentFilter : Util.IMerchantFilter
    {
        /// <summary>
        /// ID
        /// </summary>
        [DatabaseEntityFilterProperty(EntityPropertyName = "Id")]
        public FilterProperty<string> Id { get; set; }

        /// <summary>
        /// 上级ID
        /// </summary>
        [DatabaseEntityFilterProperty(EntityPropertyName = "ParentId")]
        public FilterProperty<string> ParentId { get; set; }

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
        /// 显示顺序
        /// </summary>
        [DatabaseEntityFilterProperty(EntityPropertyName = "VisibleIndex")]
        public FilterProperty<int> VisibleIndex { get; set; }

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

    public partial class Department : Util.IMerchantData
    {

    }
}