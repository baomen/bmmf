using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using Response = BaoMen.WeChat.Open.Client.Response;
using BaoMen.WeChat.Open;
using System.Security.Permissions;
using Microsoft.Extensions.DependencyInjection;
using BaoMen.WeChat.Open.Provider;

namespace BaoMen.MultiMerchant.Web.WeChat.Open
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
        /// 通过code获取access_token
        /// </summary>
        /// <param name="codeToAccessToken">请求包</param>
        /// <returns></returns>
        public Response.CodeToAccessToken CodeToAccessToken(string code)
        {
            try
            {
                Config config = configBuilder.BuildOpenConifg();
                BasicProvider provider = new BasicProvider(config);
                BaoMen.WeChat.Open.Client.Request.CodeToAccessToken codeToAccessToken = new BaoMen.WeChat.Open.Client.Request.CodeToAccessToken
                {
                    Code = code
                };
                return provider.CodeToAccessToken(codeToAccessToken);
            }
            catch (Exception exception)
            {
                return new Response.CodeToAccessToken
                {
                    ErrorCode = 1,
                    ErrorMessage = exception.Message
                };
            }
        }
    }
}
