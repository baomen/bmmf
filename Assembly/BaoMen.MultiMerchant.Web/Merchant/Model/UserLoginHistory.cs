/*
Author: WangXinBin
CreateTime: 2020-04-07 17:36:11
*/

using System;
using System.ComponentModel.DataAnnotations;

namespace BaoMen.MultiMerchant.Web.Merchant.Model
{
    #region class UserLoginHistory (generated)
    /// <summary>
    /// 商户用户登录历史模型
    /// </summary>
    public partial class UserLoginHistory
    {	
		/// <summary>
        /// ID
        /// </summary>
		public int Id { get; set; }
        
		/// <summary>
        /// 商户ID
        /// </summary>
		public string MerchantId { get; set; }
        
		/// <summary>
        /// 手机号
        /// </summary>
		public string Mobile { get; set; }
        
		/// <summary>
        /// 登录时间
        /// </summary>
		public DateTime LoginTime { get; set; }
        
		/// <summary>
        /// 类型
        /// </summary>
		public int Type { get; set; }
        
		/// <summary>
        /// 结果
        /// </summary>
		public int Result { get; set; }
        
		/// <summary>
        /// 客户端
        /// </summary>
		public string UserAgent { get; set; }
        
		/// <summary>
        /// 客户端IP
        /// </summary>
		public string ClientIp { get; set; }
        
		/// <summary>
        /// 服务端IP
        /// </summary>
		public string ServerIp { get; set; }
        
		/// <summary>
        /// 描述
        /// </summary>
		public string Description { get; set; }
        
    }
    #endregion


    public partial class UserLoginHistory
    {
        /// <summary>
        /// 类型名称
        /// </summary>
        public string TypeName { get; set; }

        /// <summary>
        /// 结果名称
        /// </summary>
        public string ResultName { get; set; }

        /// <summary>
        /// 商户名称
        /// </summary>
        public string MerchantName { get; set; }
    }
}