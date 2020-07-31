using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaoMen.WeChat.Pay.V2.Request.General
{
    /// <summary>
    /// 普通商户请求数据基类
    /// </summary>
    public class BaseRequest : Request.BaseRequest
    {
        /// <summary>
        /// 配置信息
        /// </summary>
        [Required]
        public GeneralConfig Config { get; set; }
    }
}
