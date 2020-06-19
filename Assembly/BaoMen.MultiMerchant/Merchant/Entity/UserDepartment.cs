/*
Author: WangXinBin
CreateTime: 2020-04-08 16:05:51
*/

using BaoMen.Common.Data.Attribute;
using BaoMen.Common.Model;
using System;
using System.Collections.Generic;

namespace BaoMen.MultiMerchant.Merchant.Entity
{
    #region class UserDepartment (generated)
    /// <summary>
    /// 商户用户部门实体
    /// </summary>
	[Serializable]
    [DatabaseEntity(TableName = "mch_user_department")]
    public partial class UserDepartment
    {
        private Tuple<string, string> complexKey;
        /// <summary>
        /// 复合主键Item1:UserId  Item2:DepartmentId  
        /// </summary>
        public Tuple<string, string> ComplexKey
        {
            get
            {
                if (complexKey == null)
                {
                    complexKey = Tuple.Create(UserId, DepartmentId);
                }
                return complexKey;
            }
        }
        /// <summary>
        /// 用户ID
        /// </summary>
        /// <remarks>
        /// ColumnName: UserId (Primary Key)
        /// ColumnType: CHAR(32)
        /// AllowDBNull: False
        /// Unique: False
        /// Size: 32
        /// </remarks>
        public string UserId { get; set; }

        /// <summary>
        /// 部门ID
        /// </summary>
        /// <remarks>
        /// ColumnName: DepartmentId (Primary Key)
        /// ColumnType: CHAR(32)
        /// AllowDBNull: False
        /// Unique: False
        /// Size: 32
        /// </remarks>
        public string DepartmentId { get; set; }

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

    }
    #endregion

    #region class UserDepartmentFilter (generated)
    /// <summary>
    /// 商户用户部门实体过滤器
    /// </summary>
    [Serializable]
    [DatabaseEntityFilter(EntityType = typeof(UserDepartment))]
    public partial class UserDepartmentFilter
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        [DatabaseEntityFilterProperty(EntityPropertyName = "UserId")]
        public FilterProperty<string> UserId { get; set; }

        /// <summary>
        /// 部门ID
        /// </summary>
        [DatabaseEntityFilterProperty(EntityPropertyName = "DepartmentId")]
        public FilterProperty<string> DepartmentId { get; set; }

        /// <summary>
        /// 商户ID
        /// </summary>
        [DatabaseEntityFilterProperty(EntityPropertyName = "MerchantId")]
        public FilterProperty<string> MerchantId { get; set; }

    }
    #endregion

    public partial class UserDepartmentFilter : Util.IMerchantFilter
    {

    }
}