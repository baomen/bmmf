using BaoMen.Common.Model;
using BaoMen.MultiMerchant.Amap.Open;
using BaoMen.MultiMerchant.Util;
using BaoMen.MultiMerchant.WeChat;
using BaoMen.MultiMerchant.WeChat.Pub.Proxy;
using BaoMen.WeChat.Pub;
using BaoMen.WeChat.Pub.Provider;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using Request = BaoMen.WeChat.Pub.Client.Request;
using Response = BaoMen.WeChat.Pub.Client.Response;

namespace BaoMen.MultiMerchant.Web.WeChat.Pub.Controller
{
    /// <summary>
    /// 基础控制器
    /// </summary>
    [ApiController]
    public abstract class BasicController : ControllerBase
    {
        private readonly BasicProxy basicProxy;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="serviceProvider">服务提供程序</param>
        public BasicController(IServiceProvider serviceProvider)
        {
            basicProxy = serviceProvider.GetRequiredService<BasicProxy>();
        }

        /// <summary>
        /// 取得网页授权的access_token
        /// </summary>
        /// <param name="merchantId">商户ID</param>
        /// <param name="code">网页授权第一步获取的code参数</param>
        /// <returns></returns>
        public ResponseData<Response.QueryAuthAccessToken> QueryAuthAccessToken(string merchantId, string code)
        {
            ResponseData<Response.QueryAuthAccessToken> responseData = new ResponseData<Response.QueryAuthAccessToken>();
            try
            {
                IMerchantService merchantService = HttpContext.RequestServices.GetRequiredService<IMerchantService>();
                merchantService.MerchantId = merchantId;
                Response.QueryAuthAccessToken response = basicProxy.QueryAuthAccessToken(merchantId, code);
                if (response.ErrorCode != 0)
                {
                    responseData.ErrorNumber = 1007;
                    responseData.ErrorMessage = Properties.Resources.Error_1007;
                }
            }
            catch (Exception exception)
            {
                responseData.ErrorNumber = 1008;
                responseData.ErrorMessage = Properties.Resources.Error_1008;
                responseData.Exception = exception;
            }
            return responseData;
        }
    }
}
