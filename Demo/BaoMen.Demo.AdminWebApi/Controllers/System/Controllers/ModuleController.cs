using AutoMapper;
using BaoMen.MultiMerchant.System.BusinessLogic;
using Microsoft.AspNetCore.Mvc;

namespace BaoMen.Demo.AdminWebApi.System.Controllers
{
    /// <summary>
    /// 系统模块
    /// </summary>
    [Route("api/system/[controller]/[action]")]
    public class ModuleController : MultiMerchant.Web.System.Controllers.ModuleController
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="manager">业务逻辑实例</param>
        /// <param name="mapper">AutoMapper实例</param>
        public ModuleController(IModuleManager manager, IMapper mapper) : base(manager, mapper)
        {

        }
    }
}
