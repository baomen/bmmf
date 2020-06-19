/*
Author: WangXinBin
CreateTime: 2019/10/23 11:52:57
*/

using System;
using System.ComponentModel.DataAnnotations;

namespace BaoMen.MultiMerchant.Web.Merchant.Model
{
    #region class CreateUserToken (generated)
    /// <summary>
    /// 商户用户令牌模型
    /// </summary>
    public partial class CreateUserToken
    {	
		/// <summary>
        /// 令牌
        /// </summary>
        [Required]
        [StringLength(32, MinimumLength = 32)]
		public string Token { get; set; }
        
		/// <summary>
        /// 到期时间
        /// </summary>
		public DateTime Expires { get; set; }
        
    }
	#endregion
}