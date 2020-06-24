/*
Author: WangXinBin
CreateTime: 2019/10/24 10:03:09
*/

using System;
using System.ComponentModel.DataAnnotations;

namespace BaoMen.MultiMerchant.Web.Merchant.Models
{
    #region class Merchant (generated)
    /// <summary>
    /// 商户模型
    /// </summary>
    public partial class Merchant
    {
        /// <summary>
        /// ID
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 版本ID
        /// </summary>
        public string VersionId { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 描述信息
        /// </summary>
        public string Description { get; set; }

    }
    #endregion

    #region class CreateMerchant (generated)
    /// <summary>
    /// 商户模型
    /// </summary>
    public partial class CreateMerchant
    {
        /// <summary>
        /// 编码
        /// </summary>
        [Required]
        [StringLength(100)]
        public string Code { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        /// <summary>
        /// 版本ID
        /// </summary>
        [Required]
        [StringLength(32, MinimumLength = 32)]
        public string VersionId { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [Range(0, 1)]
        public int Status { get; set; }

        /// <summary>
        /// 描述信息
        /// </summary>

        [StringLength(1000)]
        public string Description { get; set; }

    }
    #endregion

    #region class UpdateMerchant (generated)
    /// <summary>
    /// 商户模型
    /// </summary>
    public partial class UpdateMerchant
    {
        /// <summary>
        /// ID
        /// </summary>
        [Required]
        [StringLength(32, MinimumLength = 32)]
        public string Id { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        [Required]
        [StringLength(100)]
        public string Code { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        /// <summary>
        /// 版本ID
        /// </summary>
        [Required]
        [StringLength(32, MinimumLength = 32)]
        public string VersionId { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [Range(0, 1)]
        public int Status { get; set; }

        /// <summary>
        /// 描述信息
        /// </summary>

        [StringLength(1000)]
        public string Description { get; set; }

    }
    #endregion

    #region class DeleteMerchant (generated)
    /// <summary>
    /// 商户模型
    /// </summary>
    public partial class DeleteMerchant
    {
        /// <summary>
        /// ID
        /// </summary>
        [Required]
        [StringLength(32, MinimumLength = 32)]
        public string Id { get; set; }

    }
    #endregion

    public partial class Merchant
    {
        /// <summary>
        /// 版本名称
        /// </summary>
        public string VersionName { get; set; }
    }
}