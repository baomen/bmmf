/*
Author: WangXinBin
CreateTime: 2019/10/23 9:48:20
*/

using BaoMen.Common.Data.Attribute;
using BaoMen.Common.Model;
using System;
using System.Collections.Generic;

namespace BaoMen.MultiMerchant.Merchant.Entity
{
    #region class Parameter (generated)
    /// <summary>
    /// 商户参数实体
    /// </summary>
	[Serializable]
    [DatabaseEntity(TableName = "mch_parameter")]
    public partial class Parameter : IHierarchicalData<string>
    {
        private Tuple<string, string> complexKey;
        /// <summary>
        /// 复合主键Item1:Id  Item3:MerchantId  
        /// </summary>
        public Tuple<string, string> ComplexKey
        {
            get
            {
                if (complexKey == null)
                {
                    complexKey = Tuple.Create(Id, MerchantId);
                }
                return complexKey;
            }
        }
        /// <summary>
        /// ID
        /// </summary>
        /// <remarks>
        /// ColumnName: Id (Primary Key)
        /// ColumnType: VARCHAR(100)
        /// AllowDBNull: False
        /// Unique: False
        /// Size: 100
        /// </remarks>
        public string Id { get; set; }

        /// <summary>
        /// 父标识
        /// </summary>
        /// <remarks>
        /// ColumnName: ParentId 
        /// ColumnType: VARCHAR(100)
        /// AllowDBNull: False
        /// Unique: False
        /// Size: 100
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
        /// ColumnType: VARCHAR(255)
        /// AllowDBNull: False
        /// Unique: False
        /// Size: 255
        /// </remarks>
        public string Name { get; set; }

        /// <summary>
        /// 参数值
        /// </summary>
        /// <remarks>
        /// ColumnName: Value 
        /// ColumnType: VARCHAR(2048)
        /// AllowDBNull: True
        /// Unique: False
        /// Size: 2048
        /// </remarks>
        public string Value { get; set; }

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

    #region class ParameterFilter (generated)
    /// <summary>
    /// 商户参数实体过滤器
    /// </summary>
    [Serializable]
    [DatabaseEntityFilter(EntityType = typeof(Parameter))]
    public partial class ParameterFilter : Util.IMerchantFilter
    {
        /// <summary>
        /// ID
        /// </summary>
        [DatabaseEntityFilterProperty(EntityPropertyName = "Id")]
        public FilterProperty<string> Id { get; set; }

        /// <summary>
        /// 父标识
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
        /// 参数值
        /// </summary>
        [DatabaseEntityFilterProperty(EntityPropertyName = "Value")]
        public FilterProperty<string> Value { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [DatabaseEntityFilterProperty(EntityPropertyName = "Description")]
        public FilterProperty<string> Description { get; set; }

    }
    #endregion

    public partial class Parameter : Util.IMerchantData
    {

    }
}