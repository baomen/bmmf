using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaoMen.MultiMerchant.Web.WeChat.MiniProgram.Models
{
    /// <summary>
    /// 解密数据请求
    /// </summary>
    public class DecryptDataRequest
    {
        /// <summary>
        /// 商户ID
        /// </summary>
        [Required]
        [StringLength(32, MinimumLength = 32)]
        public string MerchantId { get; set; }

        /// <summary>
        /// 微信小程序OpenId
        /// </summary>
        [Required]
        public string OpenId { get; set; }

        /// <summary>
        /// 加密的数据
        /// </summary>
        [Required]
        public string EncryptedData { get; set; }

        /// <summary>
        /// 向量
        /// </summary>
        [Required]
        public string IV { get; set; }
    }
}
