using BaoMen.Common.Data;
using BaoMen.MultiMerchant.AliYun.Dysms.DataAccess.Redis;
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaoMen.MultiMerchant.AliYun.Dysms.BusinessLogic
{
    /// <summary>
    /// 验证码业务逻辑
    /// </summary>
    public class CaptchaManager
    {
        private readonly DataAccess.Redis.Captcha dal;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="configuration">配置</param>
        public CaptchaManager(IConfiguration configuration)
        {
            dal = DataAccessFactory.CreateRedis<DataAccess.Redis.Captcha>(configuration);
        }

        /// <summary>
        /// 获取单个实例
        /// </summary>
        /// <param name="phoneNumber">手机号码</param>
        /// <returns></returns>
        public Entity.Captcha Get(string phoneNumber)
        {
            return dal.Get(phoneNumber);
        }

        /// <summary>
        /// 设置实例
        /// </summary>
        /// <param name="captcha">验证码</param>
        public void Set(Entity.Captcha captcha)
        {
            dal.Set(captcha.PhoneNumber, captcha);
        }
    }
}
