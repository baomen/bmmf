/*
Author: WangXinBin
CreateTime: 2020-07-23 11:07:30
*/

using BaoMen.Common.Data.Attribute;
using BaoMen.Common.Model;
using System;
using System.Collections.Generic;

namespace BaoMen.MultiMerchant.WeChat.Pub.Entity
{
    #region class AuthAccessToken (generated)
    /// <summary>
    /// 微信公众号网页授权凭据实体
    /// </summary>
	[Serializable]
    [DatabaseEntity(TableName = "wx_pub_auth_access_token")]
    public partial class AuthAccessToken : MultiMerchant.Util.IMerchantData
    {	
        private Tuple<string,string> complexKey;
        /// <summary>
        /// 复合主键Item1:AppId  Item2:OpenId  
        /// </summary>
        public Tuple<string,string> ComplexKey
        {
            get
            {
                if (complexKey == null)
                {
                    complexKey = Tuple.Create(AppId, OpenId);
                }
                return complexKey;
            }
        }
		/// <summary>
        /// 公众号ID
        /// </summary>
		/// <remarks>
		/// ColumnName: AppId (Primary Key)
		/// ColumnType: VARCHAR(32)
		/// AllowDBNull: False
		/// Unique: False
        /// Size: 32
		/// </remarks>
		public string AppId { get; set; }
        
		/// <summary>
        /// 微信用户ID
        /// </summary>
		/// <remarks>
		/// ColumnName: OpenId (Primary Key)
		/// ColumnType: VARCHAR(255)
		/// AllowDBNull: False
		/// Unique: False
        /// Size: 255
		/// </remarks>
		public string OpenId { get; set; }
        
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
        /// 访问凭据
        /// </summary>
		/// <remarks>
		/// ColumnName: AccessToken 
		/// ColumnType: VARCHAR(512)
		/// AllowDBNull: False
		/// Unique: False
        /// Size: 512
		/// </remarks>
		public string AccessToken { get; set; }
        
		/// <summary>
        /// 刷新凭据
        /// </summary>
		/// <remarks>
		/// ColumnName: RefreshToken 
		/// ColumnType: VARCHAR(512)
		/// AllowDBNull: False
		/// Unique: False
        /// Size: 512
		/// </remarks>
		public string RefreshToken { get; set; }
        
		/// <summary>
        /// 超时时间
        /// </summary>
		/// <remarks>
		/// ColumnName: ExpiresIn 
		/// ColumnType: INT(11)
		/// AllowDBNull: False
		/// Unique: False
        /// Size: 0
		/// </remarks>
		public int ExpiresIn { get; set; }
        
		/// <summary>
        /// 作用域
        /// </summary>
		/// <remarks>
		/// ColumnName: Scope 
		/// ColumnType: VARCHAR(255)
		/// AllowDBNull: False
		/// Unique: False
        /// Size: 255
		/// </remarks>
		public string Scope { get; set; }
        
		/// <summary>
        /// 创建时间
        /// </summary>
		/// <remarks>
		/// ColumnName: CreateTime 
		/// ColumnType: DATETIME
		/// AllowDBNull: False
		/// Unique: False
        /// Size: 0
		/// </remarks>
		public DateTime CreateTime { get; set; }
        
		/// <summary>
        /// 到期时间
        /// </summary>
		/// <remarks>
		/// ColumnName: ExpiresTime 
		/// ColumnType: DATETIME
		/// AllowDBNull: False
		/// Unique: False
        /// Size: 0
		/// </remarks>
		public DateTime ExpiresTime { get; set; }
        
    }
	#endregion
    
	#region class AuthAccessTokenFilter (generated)
    /// <summary>
    /// 微信公众号网页授权凭据实体过滤器
    /// </summary>
	[Serializable]
    [DatabaseEntityFilter(EntityType = typeof(AuthAccessToken))]
	public partial class AuthAccessTokenFilter : MultiMerchant.Util.IMerchantFilter
	{		
		/// <summary>
        /// 公众号ID
        /// </summary>
        [DatabaseEntityFilterProperty(EntityPropertyName = "AppId")]
        public FilterProperty<string> AppId { get; set; }
        
		/// <summary>
        /// 微信用户ID
        /// </summary>
        [DatabaseEntityFilterProperty(EntityPropertyName = "OpenId")]
        public FilterProperty<string> OpenId { get; set; }
        
		/// <summary>
        /// 商户ID
        /// </summary>
        [DatabaseEntityFilterProperty(EntityPropertyName = "MerchantId")]
        public FilterProperty<string> MerchantId { get; set; }
        
		/// <summary>
        /// 访问凭据
        /// </summary>
        [DatabaseEntityFilterProperty(EntityPropertyName = "AccessToken")]
        public FilterProperty<string> AccessToken { get; set; }
        
		/// <summary>
        /// 刷新凭据
        /// </summary>
        [DatabaseEntityFilterProperty(EntityPropertyName = "RefreshToken")]
        public FilterProperty<string> RefreshToken { get; set; }
        
		/// <summary>
        /// 超时时间
        /// </summary>
        [DatabaseEntityFilterProperty(EntityPropertyName = "ExpiresIn")]
        public FilterProperty<int> ExpiresIn { get; set; }
        
		/// <summary>
        /// 作用域
        /// </summary>
        [DatabaseEntityFilterProperty(EntityPropertyName = "Scope")]
        public FilterProperty<string> Scope { get; set; }
        
		/// <summary>
        /// 创建时间
        /// </summary>
        [DatabaseEntityFilterProperty(EntityPropertyName = "CreateTime")]
		public FilterProperty<DateTime> CreateTime { get; set; }

		/// <summary>
        /// 创建时间最小值
        /// </summary>
        [DatabaseEntityFilterProperty(EntityPropertyName = "CreateTime")]
		public FilterProperty<DateTime> CreateTimeMin { get; set; }
        
		/// <summary>
        /// 创建时间最大值
        /// </summary>
        [DatabaseEntityFilterProperty(EntityPropertyName = "CreateTime")]
        public FilterProperty<DateTime> CreateTimeMax { get; set; }
		
		/// <summary>
        /// 到期时间
        /// </summary>
        [DatabaseEntityFilterProperty(EntityPropertyName = "ExpiresTime")]
		public FilterProperty<DateTime> ExpiresTime { get; set; }

		/// <summary>
        /// 到期时间最小值
        /// </summary>
        [DatabaseEntityFilterProperty(EntityPropertyName = "ExpiresTime")]
		public FilterProperty<DateTime> ExpiresTimeMin { get; set; }
        
		/// <summary>
        /// 到期时间最大值
        /// </summary>
        [DatabaseEntityFilterProperty(EntityPropertyName = "ExpiresTime")]
        public FilterProperty<DateTime> ExpiresTimeMax { get; set; }
		
	}
	#endregion
}