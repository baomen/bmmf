using AutoMapper;
using BaoMen.MultiMerchant.System.BusinessLogic;
using Microsoft.AspNetCore.Mvc;

namespace BaoMen.Demo.AdminWebApi.System.Controllers
{
    /// <summary>
    /// 系统省份
    /// </summary>
    [Route("api/system/[controller]/[action]")]
    
    public class ProvinceController : MultiMerchant.Web.System.Controllers.ProvinceController
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="manager">业务逻辑实例</param>
        /// <param name="mapper">AutoMapper实例</param>
        public ProvinceController(IProvinceManager manager, IMapper mapper) : base(manager, mapper)
        {
        }
    }
}
