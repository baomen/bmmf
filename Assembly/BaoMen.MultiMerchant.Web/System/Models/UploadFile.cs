/*
Author: WangXinBin
CreateTime: 2020/1/10 14:14:24
*/

using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace BaoMen.MultiMerchant.Web.System.Models
{
    #region class UploadFile (generated)
    /// <summary>
    /// 系统上传文件模型
    /// </summary>
    public partial class UploadFile
    {	
		/// <summary>
        /// ID
        /// </summary>
		public int Id { get; set; }
        
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
        /// 创建人
        /// </summary>
		public string CreateUserId { get; set; }
        /// <summary>
        /// 创建人名称
        /// </summary>
        public string CreateUserName { get; set; }
        /// <summary>
        /// 关联ID
        /// </summary>
        public string RelatedId { get; set; }
        
    }
	#endregion
    
    #region class CreateUploadFile (generated)
    /// <summary>
    /// 系统上传文件模型
    /// </summary>
    public partial class CreateUploadFile
    {
        /// <summary>
        /// 文件类型
        /// </summary>
        [Required]
        public int Type { get; set; }
               
		/// <summary>
        /// 创建人
        /// </summary>
        [Required]
        [StringLength(32, MinimumLength = 32)]
		public string CreateUserId { get; set; }

        /// <summary>
        /// 关联ID
        /// </summary>

        [StringLength(100)]
        public string RelatedId { get; set; }
    }
	#endregion
    
    #region class UpdateUploadFile (generated)
    /// <summary>
    /// 系统上传文件模型
    /// </summary>
    public partial class UpdateUploadFile
    {	
		/// <summary>
        /// ID
        /// </summary>
        
		public int Id { get; set; }
        
		/// <summary>
        /// 文件类型
        /// </summary>
        
		public int Type { get; set; }
        
		/// <summary>
        /// 原始文件名
        /// </summary>
        [Required]
        [StringLength(200)]
		public string OriginalFileName { get; set; }
        
		/// <summary>
        /// 文件名
        /// </summary>
        [Required]
        [StringLength(32, MinimumLength = 32)]
		public string FileName { get; set; }
        
		/// <summary>
        /// 扩展名
        /// </summary>
        [Required]
        [StringLength(20)]
		public string ExtentionName { get; set; }
        
		/// <summary>
        /// 相对路径
        /// </summary>
        [Required]
        [StringLength(200)]
		public string RelativePath { get; set; }
        
		/// <summary>
        /// 创建人
        /// </summary>
        [Required]
        [StringLength(32, MinimumLength = 32)]
		public string CreateUserId { get; set; }
        
		/// <summary>
        /// 关联ID
        /// </summary>
        
        [StringLength(100)]
		public string RelatedId { get; set; }
        
    }
	#endregion
    
    #region class DeleteUploadFile (generated)
    /// <summary>
    /// 系统上传文件模型
    /// </summary>
    public partial class DeleteUploadFile
    {	
		/// <summary>
        /// ID
        /// </summary>
        
		public int Id { get; set; }
        
    }
    #endregion

    public partial class CreateUploadFile
    {
        /// <summary>
        /// 文件
        /// </summary>
        public IFormFile File { get; set; }
    }
}