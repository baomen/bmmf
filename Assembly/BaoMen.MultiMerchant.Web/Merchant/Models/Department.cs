/*
Author: WangXinBin
CreateTime: 2019/10/30 11:40:25
*/

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BaoMen.MultiMerchant.Web.Merchant.Models
{
    #region class Department (generated)
    /// <summary>
    /// 商户部门模型
    /// </summary>
    public partial class Department
    {
        /// <summary>
        /// ID
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 上级ID
        /// </summary>
        public string ParentId { get; set; }

        /// <summary>
        /// 商户ID
        /// </summary>
        public string MerchantId { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 显示顺序
        /// </summary>
        public int VisibleIndex { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

    }
    #endregion

    #region class CreateDepartment (generated)
    /// <summary>
    /// 商户部门模型
    /// </summary>
    public partial class CreateDepartment
    {
        /// <summary>
        /// 名称
        /// </summary>
        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        /// <summary>
        /// 显示顺序
        /// </summary>
        [Required]
        public int VisibleIndex { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [Range(0, 1)]
        public int Status { get; set; }

        /// <summary>
        /// 描述
        /// </summary>

        [StringLength(500)]
        public string Description { get; set; }

    }
    #endregion

    #region class UpdateDepartment (generated)
    /// <summary>
    /// 商户部门模型
    /// </summary>
    public partial class UpdateDepartment
    {
        /// <summary>
        /// ID
        /// </summary>
        [Required]
        [StringLength(32, MinimumLength = 32)]
        public string Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        /// <summary>
        /// 显示顺序
        /// </summary>
        [Required]
        public int VisibleIndex { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [Range(0, 1)]
        public int Status { get; set; }

        /// <summary>
        /// 描述
        /// </summary>

        [StringLength(500)]
        public string Description { get; set; }

    }
    #endregion

    #region class DeleteDepartment (generated)
    /// <summary>
    /// 商户部门模型
    /// </summary>
    public partial class DeleteDepartment
    {
        /// <summary>
        /// ID
        /// </summary>
        [Required]
        [StringLength(32, MinimumLength = 32)]
        public string Id { get; set; }
    }
    #endregion

    public partial class Department
    {

    }

    public partial class CreateDepartment
    {
        /// <summary>
        /// 上级ID
        /// </summary>
        //[Required]
        //[StringLength(32, MinimumLength = 32)]
        public string ParentId { get; set; }
    }

    public partial class UpdateDepartment
    {
        /// <summary>
        /// 上级ID
        /// </summary>
        //[Required]
        //[StringLength(32, MinimumLength = 32)]
        public string ParentId { get; set; }
    }
}