using AutoMapper;
using BaoMen.Common.Model;
using BaoMen.MultiMerchant.Util;
using BaoMen.MultiMerchant.WeChat;
using BaoMen.MultiMerchant.WeChat.Pub;
using BaoMen.MultiMerchant.WeChat.Pub.Proxy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using Client = BaoMen.WeChat.Pub.Client;

namespace BaoMen.MultiMerchant.Web.WeChat.Pub.Controllers
{
    /// <summary>
    /// 微信基础API
    /// </summary>
    [ApiController]
    public abstract class BasicController : ControllerBase
    {
        private readonly BasicProxy basicProxy;
        private readonly IMapper mapper;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="serviceProvider">服务提供程序</param>
        public BasicController(IServiceProvider serviceProvider)
        {
            basicProxy = serviceProvider.GetRequiredService<BasicProxy>();
            mapper = serviceProvider.GetRequiredService<IMapper>();
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
                IConfigBuilder configBuilder = HttpContext.RequestServices.GetRequiredService<IConfigBuilder>();
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
        public ResponseData<Models.AccessTokenResponse> QueryAuthAccessToken(string merchantId, string code)
        {
            ResponseData<Models.AccessTokenResponse> responseData = new ResponseData<Models.AccessTokenResponse>();
            try
            {
                IMerchantService merchantService = HttpContext.RequestServices.GetRequiredService<IMerchantService>();
                merchantService.MerchantId = merchantId;
                Client.Sns.AccessTokenResponse response = basicProxy.AccessToken(merchantId, code);

                if (response.ErrorCode == 0)
                {
                    responseData.Data = mapper.Map<Models.AccessTokenResponse>(response);
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

        /// <summary>
        /// 拉取用户信息(需scope为 snsapi_userinfo)
        /// </summary>
        /// <param name="merchantId">商户ID</param>
        /// <param name="openId">用户微信OpenId</param>
        /// <param name="accessToken">网页授权接口调用凭证</param>
        /// <returns></returns>
        /// <remarks>
        /// 如果网页授权作用域为snsapi_userinfo，则此时开发者可以通过access_token和openid拉取用户信息了。
        /// </remarks>
        [HttpGet]
        public ResponseData<Models.UserInfoResponse> UserInfo(string merchantId, string openId, string accessToken)
        {
            ResponseData<Models.UserInfoResponse> responseData = new ResponseData<Models.UserInfoResponse>();
            try
            {
                IMerchantService merchantService = HttpContext.RequestServices.GetRequiredService<IMerchantService>();
                merchantService.MerchantId = merchantId;
                Client.Sns.UserInfoResponse response = basicProxy.UserInfo(merchantId, openId, accessToken);

                if (response.ErrorCode == 0)
                {
                    responseData.Data = mapper.Map<Models.UserInfoResponse>(response);
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
