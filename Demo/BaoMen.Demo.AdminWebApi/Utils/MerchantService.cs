using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BaoMen.Demo.AdminWebApi.Utils
{
    /// <summary>
    /// 获取当前商户
    /// </summary>
    public class MerchantService : MultiMerchant.Util.IMerchantService
    {

        private readonly IHttpContextAccessor httpContextAccessor;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="httpContextAccessor"></param>
        public MerchantService(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;

        }
        /// <summary>
        /// 商户ID
        /// </summary>
        public string MerchantId
        {
            get
            {
                string merchantId = null;
                if (httpContextAccessor.HttpContext.Request.Headers.ContainsKey("MerchantId"))
                {
                    merchantId = httpContextAccessor.HttpContext.Request.Headers["MerchantId"];
                }
                if (string.IsNullOrEmpty(merchantId) || merchantId.Length != 32)
                {
                    throw new ArgumentException("invalid merchant id");
                }
                return merchantId;
            }
            set => throw new NotImplementedException();
        }


    }
}
