using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using BaoMen.WeChat.MiniProgram.Client.Response;
using BaoMen.WeChat.MiniProgram;
using System.Security.Permissions;
using Microsoft.Extensions.DependencyInjection;
using BaoMen.WeChat.MiniProgram.Provider;
using BaoMen.Common.Model;
using NLog;
using BaoMen.MultiMerchant.WeChat.MiniProgram.Proxy;
using AutoMapper;
using Models = BaoMen.MultiMerchant.WeChat.MiniProgram.Models;
using BaoMen.WeChat.MiniProgram.Client.Sns;
using BaoMen.MultiMerchant.Util;

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
                responseData.Data = mapper.Map<Models.CodeToSessionResponse>(response);
                if (response.ErrorCode != 0)
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
