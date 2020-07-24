using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using Response = BaoMen.WeChat.Open.Client.Response;
using BaoMen.WeChat.Open;
using System.Security.Permissions;
using Microsoft.Extensions.DependencyInjection;
using BaoMen.WeChat.Open.Provider;

namespace BaoMen.MultiMerchant.Web.WeChat.Pub
{
    /// <summary>
    /// 基础控制器
    /// </summary>
    [ApiController]
    public abstract class BasicController : ControllerBase
    {
        /// <summary>
        /// 配置构建器
        /// </summary>
        protected readonly BaoMen.WeChat.Util.IConfigBuilder configBuilder;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="serviceProvider">服务提供程序</param>
        public BasicController(IServiceProvider serviceProvider)
        {
            configBuilder = serviceProvider.GetRequiredService<BaoMen.WeChat.Util.IConfigBuilder>();
        }


        /// <summary>
        /// 取得网页授权的access_token
        /// </summary>
        /// <param name="code">网页授权第一步获取的code参数</param>
        /// <returns></returns>
        public Response.CodeToAccessToken QueryAuthAccessToken(string code)
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
