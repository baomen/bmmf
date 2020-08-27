using AutoMapper;
using BaoMen.Common.Model;
using BaoMen.MultiMerchant.Util;
using BaoMen.MultiMerchant.WeChat.MiniProgram.Proxy;
using BaoMen.WeChat.MiniProgram.Client.Basic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using NLog;
using System;
using Models = BaoMen.MultiMerchant.WeChat.MiniProgram.Models;

namespace BaoMen.MultiMerchant.Web.WeChat.MiniProgram.Controllers
{
    /// <summary>
    /// 基础控制器
    /// </summary>
    public abstract class BasicController : ControllerBase
    {

        /// <summary>
        /// 日志实例
        /// </summary>
        protected readonly ILogger logger = LogManager.GetCurrentClassLogger();

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
        /// 登录凭证校验
        /// </summary>
        /// <param name="merchantId">商户ID</param>
        /// <param name="code">	登录时获取的 code</param>
        /// <returns></returns>
        /// <remarks>
        /// 通过 wx.login 接口获得临时登录凭证 code 后传到开发者服务器调用此接口完成登录流程。更多使用方法详见 小程序登录。
        /// </remarks>
        [HttpGet]
        public ResponseData<Models.CodeToSessionResponse> CodeToSession(string merchantId, string code)
        {
            ResponseData<Models.CodeToSessionResponse> responseData = new ResponseData<Models.CodeToSessionResponse>();
            try
            {
                if (string.IsNullOrEmpty(code))
                {
                    throw new ArgumentNullException("code");
                }
                IMerchantService merchantService = HttpContext.RequestServices.GetRequiredService<IMerchantService>();
                merchantService.MerchantId = merchantId;
                CodeToSessionResponse response = basicProxy.CodeToSession(code, merchantId);
                if (response.ErrorCode == 0)
                {
                    responseData.Data = mapper.Map<Models.CodeToSessionResponse>(response);
                }
                else
                {
                    responseData.ErrorNumber = response.ErrorCode;
                    responseData.ErrorMessage = response.ErrorMessage;
                }
            }
            catch (Exception exception)
            {
                responseData.ErrorNumber = 1000;
                responseData.ErrorMessage = Properties.Resources.Error_1000;
                responseData.Exception = exception;
                logger.Error(exception);
            }
            return responseData;
        }

        /// <summary>
        /// 用户支付完成后，获取该用户的 UnionId，无需用户授权。本接口支持第三方平台代理查询。
        /// </summary>
        /// <param name="merchantId">商户ID</param>
        /// <param name="openId">微信小程序OpenIdparam>
        /// <returns></returns>
        /// <remarks>
        /// 注意：调用前需要用户完成支付，且在支付后的五分钟内有效。
        /// </remarks>
        [HttpGet]
        public ResponseData<Models.GetPaidUnionIdReponse> GetPaidUnionId(string merchantId,string openId)
        {
            ResponseData<Models.GetPaidUnionIdReponse> responseData = new ResponseData<Models.GetPaidUnionIdReponse>();
            try
            {
                if (string.IsNullOrEmpty(openId))
                {
                    throw new ArgumentNullException("openId");
                }
                IMerchantService merchantService = HttpContext.RequestServices.GetRequiredService<IMerchantService>();
                merchantService.MerchantId = merchantId;
                GetPaidUnionIdReponse response = basicProxy.GetPaidUnionId(openId, merchantId);
                if (response.ErrorCode == 0)
                {
                    responseData.Data = mapper.Map<Models.GetPaidUnionIdReponse>(response);
                }
                else
                {
                    responseData.ErrorNumber = response.ErrorCode;
                    responseData.ErrorMessage = response.ErrorMessage;
                }
            }
            catch (Exception exception)
            {
                responseData.ErrorNumber = 1000;
                responseData.ErrorMessage = Properties.Resources.Error_1000;
                responseData.Exception = exception;
                logger.Error(exception);
            }
            return responseData;
        }
    }
}
