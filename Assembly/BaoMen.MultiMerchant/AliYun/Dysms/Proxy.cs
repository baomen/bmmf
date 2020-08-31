using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Exceptions;
using Aliyun.Acs.Core.Http;
using Aliyun.Acs.Core.Profile;
using BaoMen.Common.Model;
using BaoMen.MultiMerchant.AliYun.Dysms.BusinessLogic;
using BaoMen.MultiMerchant.System.BusinessLogic;
using NLog;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace BaoMen.MultiMerchant.AliYun.Dysms
{
    /// <summary>
    /// DYSMS短信代理程序
    /// </summary>
    public class Proxy
    {
        private readonly ConfigBuilder configBuilder;
        private static readonly ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IParameterManager parameterManager;
        private readonly CaptchaManager captchaManager;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="configBuilder">配置构建器</param>
        /// <param name="parameterManager">系统参数业务逻辑</param>
        /// <param name="captchaManager">验证码业务逻辑</param>
        public Proxy(ConfigBuilder configBuilder, IParameterManager parameterManager, CaptchaManager captchaManager)
        {
            this.configBuilder = configBuilder;
            this.parameterManager = parameterManager;
            this.captchaManager = captchaManager;
        }

        /// <summary>
        /// 发送注册验证码
        /// </summary>
        /// <param name="phoneNumbers">手机号</param>
        /// <param name="code">验证码</param>
        /// <param name="merchantId">商户ID</param>
        /// <returns></returns>
        public CommonResponse SendRegistCaptcha(string phoneNumbers, string code, string merchantId = null)
        {
            DateTime now = DateTime.Now;
            Entity.Captcha captcha = captchaManager.Get(phoneNumbers);
            if (captcha != null)
            {
                if (captcha.ExpirationTime > DateTime.Now)
                {
                    throw new ArgumentException("未到重发时间，请不要频繁尝试");
                }
            }
            captcha = new Entity.Captcha
            {
                ExpirationTime = now.AddMinutes(1),
                PhoneNumber = phoneNumbers,
                SendTime = now,
                Type = Entity.CaptchaType.Regist,
                Code = code,
                Status = Entity.CaptchaStatus.Valid
            };
            CommonResponse commonResponse = SendSms(phoneNumbers, parameterManager.Get("030202020203")?.Value, GetCaptchaTemplateParam(code), merchantId);
            captchaManager.Set(captcha);
            return commonResponse;
        }

        /// <summary>
        /// 发送登录验证码
        /// </summary>
        /// <param name="phoneNumbers">手机号</param>
        /// <param name="code">验证码</param>
        /// <param name="merchantId">商户ID</param>
        /// <returns></returns>
        public CommonResponse SendLoginCaptcha(string phoneNumbers, string code, string merchantId = null)
        {
            DateTime now = DateTime.Now;
            Entity.Captcha captcha = captchaManager.Get(phoneNumbers);
            if (captcha != null)
            {
                if (captcha.ExpirationTime > DateTime.Now)
                {
                    throw new ArgumentException("未到重发时间，请不要频繁尝试");
                }
            }
            captcha = new Entity.Captcha
            {
                ExpirationTime = now.AddMinutes(1),
                PhoneNumber = phoneNumbers,
                SendTime = now,
                Type = Entity.CaptchaType.Login,
                Code = code,
                Status = Entity.CaptchaStatus.Valid
            };
            CommonResponse commonResponse = SendSms(phoneNumbers, parameterManager.Get("030202020205")?.Value, GetCaptchaTemplateParam(code), merchantId);
            captchaManager.Set(captcha);
            return commonResponse;
        }

        /// <summary>
        /// 获取验证的短信模板变量
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private string GetCaptchaTemplateParam(string code)
        {
            return global::System.Text.Json.JsonSerializer.Serialize(new { code });
        }

        /// <summary>
        /// 发送短信
        /// </summary>
        /// <param name="phoneNumbers">手机号码</param>
        /// <param name="templateCode">短信模板ID</param>
        /// <param name="templateParam">短信模板变量对应的实际值</param>
        /// <param name="merchantId">商户ID</param>
        private CommonResponse SendSms(string phoneNumbers, string templateCode, string templateParam, string merchantId = null)
        {
            Config config = configBuilder.BuildDysmsConfig(merchantId);
            IClientProfile profile = DefaultProfile.GetProfile("cn-hangzhou", config.AccessKeyId, config.AccessKeySecret);
            DefaultAcsClient client = new DefaultAcsClient(profile);
            CommonRequest request = new CommonRequest
            {
                Method = MethodType.POST,
                Domain = "dysmsapi.aliyuncs.com",
                Version = "2017-05-25",
                Action = "SendSms"
            };
            // request.Protocol = ProtocolType.HTTP;
            request.AddQueryParameters("PhoneNumbers", phoneNumbers);
            request.AddQueryParameters("SignName", config.SignName);
            request.AddQueryParameters("TemplateCode", templateCode);
            request.AddQueryParameters("TemplateParam", templateParam);
            try
            {
                CommonResponse response = client.GetCommonResponse(request);
                if (response.HttpStatus != 200)
                {
                    throw new HttpRequestException($"Http StatusCode is {response.HttpStatus}");
                }
                return response;
            }
            //catch (ServerException e)
            //{
            //    logger.Error(e);
            //}
            //catch (ClientException e)
            //{
            //    logger.Error(e);
            //}
            catch (Exception e)
            {
                logger.Error(e);
                throw e;
            }
        }
    }
}
