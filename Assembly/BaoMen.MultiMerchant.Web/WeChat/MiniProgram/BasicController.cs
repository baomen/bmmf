//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using BaoMen.WeChat.MiniProgram.Client.Response;
//using BaoMen.WeChat.MiniProgram;
//using System.Security.Permissions;
//using Microsoft.Extensions.DependencyInjection;
//using BaoMen.WeChat.MiniProgram.Provider;
//using BaoMen.Common.Model;
//using NLog;

//namespace BaoMen.MultiMerchant.Web.WeChat.MiniProgram
//{
//    /// <summary>
//    /// 基础控制器
//    /// </summary>
//    public abstract class BasicController : ControllerBase
//    {
//        protected readonly BaoMen.WeChat.Util.IConfigBuilder configBuilder;

//        /// <summary>
//        /// 日志实例
//        /// </summary>
//        protected readonly ILogger logger;

//        public BasicController(IServiceProvider serviceProvider)
//        {
//            configBuilder = serviceProvider.GetRequiredService<BaoMen.WeChat.Util.IConfigBuilder>();
//            logger = LogManager.GetLogger(GetType().FullName);
//        }

//        /// <summary>
//        /// 获取小程序全局唯一后台接口调用凭据
//        /// </summary>
//        /// <returns></returns>
//        public QueryAccessToken QueryAccessToken()
//        {
//            try
//            {
//                Config config = configBuilder.BuildMiniProgramConifg();
//                BasicProvider provider = new BasicProvider(config);
//                return provider.QueryAccessToken();
//            }
//            catch (Exception exception)
//            {
//                return new QueryAccessToken
//                {
//                    ErrorCode = 1,
//                    ErrorMessage = exception.Message
//                };
//            }
//        }

//        /// <summary>
//        /// 登录凭证校验
//        /// </summary>
//        /// <param name="code">	登录时获取的 code</param>
//        /// <returns></returns>
//        /// <remarks>
//        /// 通过 wx.login 接口获得临时登录凭证 code 后传到开发者服务器调用此接口完成登录流程。更多使用方法详见 小程序登录。
//        /// </remarks>
//        public ResponseData<CodeToSession> CodeToSession(string code)
//        {
//            ResponseData<CodeToSession> responseData = new ResponseData<CodeToSession>();
//            try
//            {
//                if (string.IsNullOrEmpty(code))
//                {
//                    throw new ArgumentNullException("code");
//                }
//                BaoMen.WeChat.MiniProgram.Client.Request.CodeToSession codeToSession = new BaoMen.WeChat.MiniProgram.Client.Request.CodeToSession
//                {
//                    JsCode = code
//                };
//                Config config = configBuilder.BuildMiniProgramConifg();
//                BasicProvider provider = new BasicProvider(config);
//                CodeToSession response = provider.CodeToSession(codeToSession);
//                if (response.ErrorCode == 0)
//                {
//                    responseData.Data = response;
//                }
//                else
//                {
//                    responseData.ErrorNumber = response.ErrorCode;
//                    responseData.ErrorMessage = response.ErrorMessage;
//                }
//            }
//            catch (Exception exception)
//            {
//                responseData.ErrorNumber = 1000;
//                responseData.ErrorMessage = Properties.Resources.Error_1000;
//                responseData.Exception = exception;
//                logger.Error(exception);
//            }
//            return responseData;
//        }
//    }
//}
