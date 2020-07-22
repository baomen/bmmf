using System;
using System.Collections.Generic;
using System.Text;

namespace BaoMen.Amap.Utils
{
    /// <summary>
    /// 配置构建器
    /// </summary>
    public interface IConfigBuilder
    {
        /// <summary>
        /// 创建开放平台配置
        /// </summary>
        /// <returns></returns>
        Open.WebService.Config BuildOpenConfig();
    }
}
