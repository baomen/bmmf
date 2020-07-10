using System;
using System.Collections.Generic;
using System.Text;

namespace BaoMen.WeChat.Util
{
    /// <summary>
    /// 配置构建器接口
    /// </summary>
    public interface IConfigBuilder
    {
        /// <summary>
        /// 构建微信公众号的配置
        /// </summary>
        /// <returns></returns>
        Pub.Config BuildPubConifg();

        /// <summary>
        /// 构建微信小程序的配置
        /// </summary>
        /// <returns></returns>
        MiniProgram.Config BuildMiniPorgramConifg();
    }
}
