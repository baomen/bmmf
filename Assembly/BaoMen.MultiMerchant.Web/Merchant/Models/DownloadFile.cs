/*
Author: WangXinBin
CreateTime: 2020/1/13 10:58:04
*/

using System;
using System.ComponentModel.DataAnnotations;

namespace BaoMen.MultiMerchant.Web.Merchant.Models
{
    #region class DownloadFile (generated)
    /// <summary>
    /// 商户下载文件模型
    /// </summary>
    public partial class DownloadFile
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
        /// 文件类型
        /// </summary>
		public int Type { get; set; }
        /// <summary>
        /// 文件类型名称
        /// </summary>
        public string TypeName { get; set; }
        /// <summary>
        /// 原始文件名
        /// </summary>
        public string OriginalFileName { get; set; }
        
		/// <summary>
        /// 文件名
        /// </summary>
		public string FileName { get; set; }
        
		/// <summary>
        /// 扩展名
        /// </summary>
		public string ExtentionName { get; set; }
        
		/// <summary>
        /// 相对路径
        /// </summary>
		public string RelativePath { get; set; }
        
		/// <summary>
        /// 创建时间
        /// </summary>
		public DateTime CreateTime { get; set; }
        
		/// <summary>
        /// 关联ID
        /// </summary>
		public string RelatedId { get; set; }
        
    }
	#endregion
        
}