using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using BaoMen.WeChat.MiniProgram.Client.Response;
using BaoMen.WeChat.MiniProgram;
using System.Security.Permissions;
using Microsoft.Extensions.DependencyInjection;
using BaoMen.WeChat.MiniProgram.Provider;

namespace BaoMen.MultiMerchant.Web.WeChat.MiniProgram
{
    /// <summary>
    /// 基础控制器
    /// </summary>
    public abstract class BasicController : ControllerBase
    {
        protected readonly BaoMen.WeChat.Util.IConfigBuilder configBuilder;

        public BasicController(IServiceProvider serviceProvider)
        {
            configBuilder = serviceProvider.GetRequiredService<BaoMen.WeChat.Util.IConfigBuilder>();
        }

        /// <summary>
        /// 获取小程序全局唯一后台接口调用凭据
        /// </summary>
        /// <returns></returns>
        public QueryAccessToken QueryAccessToken()
        {
            try
            {
                Config config = configBuilder.BuildMiniPorgramConifg();
                BasicProvider provider = new BasicProvider(config);
                return provider.QueryAccessToken();
            }
            catch (Exception exception)
            {
                return new QueryAccessToken
                {
                    ErrorCode = 1,
                    ErrorMessage = exception.Message
                };
            }
        }
    }
}
