using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaoMen.MultiMerchant.AliYun.Dysms.DataAccess.Redis
{
    /// <summary>
    /// 验证码
    /// </summary>
    public class Captcha : Common.Data.RedisDataAccess<string, Entity.Captcha>
    {
        ///<inheritdoc/>
        public Captcha(string connectionString) : base(connectionString)
        {

        }

        /// <inheritdoc/>
        protected override RedisKey GetRedisKey(string id)
        {
            return $"captcha{keySeparator}{id}";
        }
    }
}
