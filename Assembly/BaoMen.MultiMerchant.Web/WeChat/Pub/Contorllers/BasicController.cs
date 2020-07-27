using BaoMen.Common.Model;
using BaoMen.MultiMerchant.Util;
using BaoMen.MultiMerchant.WeChat;
using BaoMen.MultiMerchant.WeChat.Pub;
using BaoMen.MultiMerchant.WeChat.Pub.Proxy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using Response = BaoMen.WeChat.Pub.Client.Response;

namespace BaoMen.MultiMerchant.Web.WeChat.Pub.Controller
{
    /// <summary>
    /// 微信基础API
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
        /// 获取AppId
        /// </summary>
        /// <param name="merchantId">商户ID</param>
        /// <returns></returns>
        [HttpGet]
        public ResponseData<string> GetAppId(string merchantId)
        {
            ResponseData<string> responseData = new ResponseData<string>();
            try
            {
                IMerchantService merchantService = HttpContext.RequestServices.GetRequiredService<IMerchantService>();
                merchantService.MerchantId = merchantId;
                ConfigBuilder configBuilder = HttpContext.RequestServices.GetRequiredService<ConfigBuilder>();
                Config config = configBuilder.BuildPubConifg(merchantId);
                responseData.Data = config.AppId;
            }
            catch (Exception exception)
            {
                responseData.ErrorNumber = 1008;
                responseData.ErrorMessage = Properties.Resources.Error_1008;
                responseData.Exception = exception;
            }
            return responseData;
        }

        /// <summary>
        /// 取得网页授权的access_token
        /// </summary>
        /// <param name="merchantId">商户ID</param>
        /// <param name="code">网页授权第一步获取的code参数</param>
        /// <returns></returns>
        [HttpGet]
        public ResponseData<Response.QueryAuthAccessToken> QueryAuthAccessToken(string merchantId, string code)
        {
            ResponseData<Response.QueryAuthAccessToken> responseData = new ResponseData<Response.QueryAuthAccessToken>();
            try
            {
                IMerchantService merchantService = HttpContext.RequestServices.GetRequiredService<IMerchantService>();
                merchantService.MerchantId = merchantId;
                Response.QueryAuthAccessToken response = basicProxy.QueryAuthAccessToken(merchantId, code);

                if (response.ErrorCode == 0)
                {
                    responseData.Data = response;
                }
                else
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
