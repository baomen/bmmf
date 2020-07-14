using AutoMapper;
using BaoMen.MultiMerchant.System.BusinessLogic;
using Microsoft.AspNetCore.Mvc;

namespace BaoMen.Demo.AdminWebApi.System.Controllers
{
    /// <summary>
    /// 系统地市
    /// </summary>
    [Route("api/system/[controller]/[action]")]
    public class CityController : MultiMerchant.Web.System.Controllers.CityController
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="manager">业务逻辑实例</param>
        /// <param name="mapper">AutoMapper实例</param>
        public CityController(ICityManager manager, IMapper mapper) : base(manager, mapper)
        {
        }
    }
}
