using System;
using System.Collections.Generic;
using System.Text;

namespace BaoMen.AliYun
{
    /// <summary>
    /// 配置
    /// </summary>
    public interface IConfig
    {
        /// <summary>
        /// 身份验证凭据
        /// </summary>
        string AccessKeyId { get; }

        /// <summary>
        /// 身份验证凭据密钥
        /// </summary>
        string AccessKeySecret { get; }
    }
}
