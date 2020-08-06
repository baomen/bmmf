using System;
using System.Collections.Generic;
using System.Text;

namespace BaoMen.MultiMerchant.AliYun.Dysms
{
    /// <summary>
    /// 配置
    /// </summary>
    public class Config : AliYun.Config
    {
        /// <summary>
        /// 签名名称
        /// </summary>
        public string SignName { get; set; }
    }
}
