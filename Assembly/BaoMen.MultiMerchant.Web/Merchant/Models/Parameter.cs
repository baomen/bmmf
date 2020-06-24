/*
Author: WangXinBin
CreateTime: 2019/10/23 9:48:21
*/

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BaoMen.MultiMerchant.Web.Merchant.Models
{
    #region class Parameter (generated)
    /// <summary>
    /// 商户参数模型
    /// </summary>
    public partial class Parameter
    {
        /// <summary>
        /// ID
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 父标识
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
        /// 参数值
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

    }
    #endregion

    #region class CreateParameter (generated)
    /// <summary>
    /// 商户参数模型
    /// </summary>
    public partial class CreateParameter
    {
        /// <summary>
        /// 父标识
        /// </summary>
        [Required]
        [StringLength(100)]
        public string ParentId { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        /// <summary>
        /// 参数值
        /// </summary>

        [StringLength(2048)]
        public string Value { get; set; }

        /// <summary>
        /// 描述
        /// </summary>

        [StringLength(500)]
        public string Description { get; set; }

    }
    #endregion

    #region class UpdateParameter (generated)
    /// <summary>
    /// 商户参数模型
    /// </summary>
    public partial class UpdateParameter
    {
        /// <summary>
        /// ID
        /// </summary>
        [Required]
        [StringLength(100)]
        public string Id { get; set; }

        /// <summary>
        /// 父标识
        /// </summary>
        [Required]
        [StringLength(100)]
        public string ParentId { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        /// <summary>
        /// 参数值
        /// </summary>

        [StringLength(2048)]
        public string Value { get; set; }

        /// <summary>
        /// 描述
        /// </summary>

        [StringLength(500)]
        public string Description { get; set; }

    }
    #endregion

    #region class DeleteParameter (generated)
    /// <summary>
    /// 商户参数模型
    /// </summary>
    public partial class DeleteParameter
    {
        /// <summary>
        /// ID
        /// </summary>
        [Required]
        [StringLength(100)]
        public string Id { get; set; }
    }
    #endregion

    public partial class Parameter
    {
        /// <summary>
        /// 子参数
        /// </summary>
        public ICollection<Parameter> Children { get; set; }
    }
}