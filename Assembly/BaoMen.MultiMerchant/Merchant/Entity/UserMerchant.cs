/*
Author: WangXinBin
CreateTime: 2022-04-14 12:41:09
*/

using BaoMen.Common.Data.Attribute;
using BaoMen.Common.Model;
using System;
using System.Collections.Generic;

namespace BaoMen.MultiMerchant.Merchant.Entity
{
    #region class UserMerchant (generated)
    /// <summary>
    /// 商户用户对应关系表实体
    /// </summary>
	[Serializable]
    [DatabaseEntity(TableName = "mch_user_merchant")]
    public partial class UserMerchant :MultiMerchant.Util.IMerchantData
    {	
        private Tuple<string,string> complexKey;
        /// <summary>
        /// 复合主键Item1:UserId  Item2:MerchantId  
        /// </summary>
        public Tuple<string,string> ComplexKey
        {
            get
            {
                if (complexKey == null)
                {
                    complexKey = Tuple.Create(UserId, MerchantId);
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
        /// 商户ID
        /// </summary>
		/// <remarks>
		/// ColumnName: MerchantId (Primary Key)
		/// ColumnType: CHAR(32)
		/// AllowDBNull: False
		/// Unique: False
        /// Size: 32
		/// </remarks>
		public string MerchantId { get; set; }
        
    }
	#endregion
    
	#region class UserMerchantFilter (generated)
    /// <summary>
    /// 商户用户对应关系表实体过滤器
    /// </summary>
	[Serializable]
    [DatabaseEntityFilter(EntityType = typeof(UserMerchant))]
	public partial class UserMerchantFilter : MultiMerchant.Util.IMerchantFilter
	{		
		/// <summary>
        /// 用户ID
        /// </summary>
        [DatabaseEntityFilterProperty(EntityPropertyName = "UserId")]
        public FilterProperty<string> UserId { get; set; }
        
		/// <summary>
        /// 商户ID
        /// </summary>
        [DatabaseEntityFilterProperty(EntityPropertyName = "MerchantId")]
        public FilterProperty<string> MerchantId { get; set; }
        
	}
	#endregion
}