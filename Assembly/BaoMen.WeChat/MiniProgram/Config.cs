using System;
using System.Collections.Generic;
using System.Text;

namespace BaoMen.WeChat.MiniProgram
{
    /// <summary>
    /// 微信公众号配置
    /// </summary>
    public class Config : Util.Config
    {
        /// <summary>
        /// 开发者ID
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// 开发者密码
        /// </summary>
        public string AppSecret { get; set; }

    }
}
