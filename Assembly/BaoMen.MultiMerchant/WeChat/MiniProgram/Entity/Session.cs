/*
Author: WangXinBin
CreateTime: 2020-08-31 19:01:29
*/

using BaoMen.Common.Data.Attribute;
using BaoMen.Common.Model;
using System;
using System.Collections.Generic;

namespace BaoMen.MultiMerchant.WeChat.MiniProgram.Entity
{
    #region class Session (generated)
    /// <summary>
    /// 微信小程序登录凭证校验实体
    /// </summary>
	[Serializable]
    [DatabaseEntity(TableName = "wx_mp_session")]
    public partial class Session : MultiMerchant.Util.IMerchantData
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
        /// 小程序ID
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
        /// 微信小程序用户ID
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
        /// 会话密钥
        /// </summary>
		/// <remarks>
		/// ColumnName: SessionKey 
		/// ColumnType: VARCHAR(255)
		/// AllowDBNull: False
		/// Unique: False
        /// Size: 255
		/// </remarks>
		public string SessionKey { get; set; }
        
		/// <summary>
        /// 用户在开放平台的唯一标识符
        /// </summary>
		/// <remarks>
		/// ColumnName: UnionId 
		/// ColumnType: VARCHAR(255)
		/// AllowDBNull: True
		/// Unique: False
        /// Size: 255
		/// </remarks>
		public string UnionId { get; set; }
        
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
        
    }
	#endregion
    
	#region class SessionFilter (generated)
    /// <summary>
    /// 微信小程序登录凭证校验实体过滤器
    /// </summary>
	[Serializable]
    [DatabaseEntityFilter(EntityType = typeof(Session))]
	public partial class SessionFilter : MultiMerchant.Util.IMerchantFilter
	{		
		/// <summary>
        /// 小程序ID
        /// </summary>
        [DatabaseEntityFilterProperty(EntityPropertyName = "AppId")]
        public FilterProperty<string> AppId { get; set; }
        
		/// <summary>
        /// 微信小程序用户ID
        /// </summary>
        [DatabaseEntityFilterProperty(EntityPropertyName = "OpenId")]
        public FilterProperty<string> OpenId { get; set; }
        
		/// <summary>
        /// 商户ID
        /// </summary>
        [DatabaseEntityFilterProperty(EntityPropertyName = "MerchantId")]
        public FilterProperty<string> MerchantId { get; set; }
        
		/// <summary>
        /// 会话密钥
        /// </summary>
        [DatabaseEntityFilterProperty(EntityPropertyName = "SessionKey")]
        public FilterProperty<string> SessionKey { get; set; }
        
		/// <summary>
        /// 用户在开放平台的唯一标识符
        /// </summary>
        [DatabaseEntityFilterProperty(EntityPropertyName = "UnionId")]
        public FilterProperty<string> UnionId { get; set; }
        
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
		
	}
	#endregion
}