using AutoMapper;
using BaoMen.MultiMerchant.Merchant.BusinessLogic;
using Microsoft.AspNetCore.Mvc;

namespace BaoMen.Demo.AdminWebApi.Merchant.Controllers
{
    /// <summary>
    /// 商户
    /// </summary>
    [Route("api/merchant/[controller]/[action]")]
    public class MerchantController : MultiMerchant.Web.Merchant.Controllers.MerchantController
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="manager">业务逻辑实例</param>
        /// <param name="mapper">AutoMapper实例</param>
        public MerchantController(IMerchantManager manager, IMapper mapper) : base(manager, mapper)
        {

        }
    }
}
