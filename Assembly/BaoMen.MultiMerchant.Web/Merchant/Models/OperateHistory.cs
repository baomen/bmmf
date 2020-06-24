/*
Author: WangXinBin
CreateTime: 2019/10/23 11:49:41
*/

using System;
using System.ComponentModel.DataAnnotations;

namespace BaoMen.MultiMerchant.Web.Merchant.Models
{
    #region class OperateHistory (generated)
    /// <summary>
    /// 商户操作日志模型
    /// </summary>
    public partial class OperateHistory
    {
        /// <summary>
        /// 流水号
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 商户ID
        /// </summary>
        public string MerchantId { get; set; }

        /// <summary>
        /// 系统用户ID
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>

        public string UserName { get; set; }

        /// <summary>
        /// 操作类型
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime OperateTime { get; set; }

        /// <summary>
        /// 程序集
        /// </summary>
        public string AssemblyName { get; set; }

        /// <summary>
        /// 实体类型
        /// </summary>
        public string EntityType { get; set; }

        /// <summary>
        /// 相关ID
        /// </summary>
        public string RelatedId { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

    }
    #endregion
}