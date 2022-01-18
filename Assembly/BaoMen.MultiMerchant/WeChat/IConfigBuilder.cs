using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace BaoMen.MultiMerchant.WeChat
{
    /// <summary>
    /// 配置构建器
    /// </summary>
    public interface IConfigBuilder
    {
        /// <summary>
        /// 构建微信公众号的配置
        /// </summary>
        /// <returns></returns>
        Pub.Config BuildPubConifg(string merchantId = null);


        /// <summary>
        /// 构建微信支付的配置
        /// </summary>
        /// <returns></returns>
        BaoMen.WeChat.Pay.V2.GeneralConfig BuildGeneralPayConfig(string merchantId = null);

        /// <summary>
        /// 构建微信小程序的配置
        /// </summary>
        /// <returns></returns>
        MiniProgram.Config BuildMiniPorgramConifg(string merchantId = null);
    }
}
