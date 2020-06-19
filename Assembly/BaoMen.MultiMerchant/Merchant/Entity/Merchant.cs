/*
Author: WangXinBin
CreateTime: 2019/10/24 10:03:07
*/

using BaoMen.Common.Data.Attribute;
using BaoMen.Common.Model;
using System;
using System.Collections.Generic;

namespace BaoMen.MultiMerchant.Merchant.Entity
{
    #region class Merchant (generated)
    /// <summary>
    /// 商户实体
    /// </summary>
	[Serializable]
    [DatabaseEntity(TableName = "mch_merchant")]
    public partial class Merchant
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
        /// 编码
        /// </summary>
        /// <remarks>
        /// ColumnName: Code 
        /// ColumnType: VARCHAR(100)
        /// AllowDBNull: False
        /// Unique: True
        /// Size: 100
        /// </remarks>
        public string Code { get; set; }

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
        /// 版本ID
        /// </summary>
        /// <remarks>
        /// ColumnName: VersionId 
        /// ColumnType: CHAR(32)
        /// AllowDBNull: False
        /// Unique: False
        /// Size: 32
        /// </remarks>
        public string VersionId { get; set; }

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
        /// 描述信息
        /// </summary>
        /// <remarks>
        /// ColumnName: Description 
        /// ColumnType: VARCHAR(1000)
        /// AllowDBNull: True
        /// Unique: False
        /// Size: 1000
        /// </remarks>
        public string Description { get; set; }

    }
    #endregion

    #region class MerchantFilter (generated)
    /// <summary>
    /// 商户实体过滤器
    /// </summary>
    [Serializable]
    [DatabaseEntityFilter(EntityType = typeof(Merchant))]
    public partial class MerchantFilter
    {
        /// <summary>
        /// ID
        /// </summary>
        [DatabaseEntityFilterProperty(EntityPropertyName = "Id")]
        public FilterProperty<string> Id { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        [DatabaseEntityFilterProperty(EntityPropertyName = "Code")]
        public FilterProperty<string> Code { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [DatabaseEntityFilterProperty(EntityPropertyName = "Name")]
        public FilterProperty<string> Name { get; set; }

        /// <summary>
        /// 版本ID
        /// </summary>
        [DatabaseEntityFilterProperty(EntityPropertyName = "VersionId")]
        public FilterProperty<string> VersionId { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [DatabaseEntityFilterProperty(EntityPropertyName = "Status")]
        public FilterProperty<int> Status { get; set; }

        /// <summary>
        /// 描述信息
        /// </summary>
        [DatabaseEntityFilterProperty(EntityPropertyName = "Description")]
        public FilterProperty<string> Description { get; set; }

    }
    #endregion

    public partial class Merchant
    {
        /// <summary>
        /// 版本
        /// </summary>
        public System.Entity.Version Version { get; set; }
    }
}