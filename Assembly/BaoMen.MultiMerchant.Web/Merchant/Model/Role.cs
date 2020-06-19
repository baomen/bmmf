/*
Author: WangXinBin
CreateTime: 2019/10/23 11:51:56
*/

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BaoMen.MultiMerchant.Web.Merchant.Model
{
    #region class Role (generated)
    /// <summary>
    /// 商户角色模型
    /// </summary>
    public partial class Role
    {
        /// <summary>
        /// ID
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 商户ID
        /// </summary>
        public string MerchantId { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

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

    #region class CreateRole (generated)
    /// <summary>
    /// 商户角色模型
    /// </summary>
    public partial class CreateRole
    {
        /// <summary>
        /// 名称
        /// </summary>
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

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

    #region class UpdateRole (generated)
    /// <summary>
    /// 商户角色模型
    /// </summary>
    public partial class UpdateRole
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
        [StringLength(100)]
        public string Name { get; set; }

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

    #region class DeleteRole (generated)
    /// <summary>
    /// 商户角色模型
    /// </summary>
    public partial class DeleteRole
    {
        /// <summary>
        /// ID
        /// </summary>
        [Required]
        [StringLength(32, MinimumLength = 32)]
        public string Id { get; set; }

    }
    #endregion

    /// <summary>
    /// 角色详细信息
    /// </summary>
    public partial class RoleDetail
    {
        /// <summary>
        /// 拥有的模块ID
        /// </summary>
        public ICollection<string> ModuleIds { get; set; }
    }

    public partial class CreateRole
    {
        /// <summary>
        /// 拥有的模块ID
        /// </summary>
        [Required]
        public ICollection<string> ModuleIds { get; set; }
    }

    public partial class UpdateRole
    {
        /// <summary>
        /// 拥有的模块ID
        /// </summary>
        [Required]
        public ICollection<string> ModuleIds { get; set; }
    }
}