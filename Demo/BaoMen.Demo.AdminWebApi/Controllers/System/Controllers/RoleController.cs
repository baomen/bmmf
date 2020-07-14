using AutoMapper;
using BaoMen.MultiMerchant.System.BusinessLogic;
using Microsoft.AspNetCore.Mvc;

namespace BaoMen.Demo.AdminWebApi.System.Controllers
{
    /// <summary>
    /// 系统角色
    /// </summary>
    [Route("api/system/[controller]/[action]")]
    
    public class RoleController : MultiMerchant.Web.System.Controllers.RoleController
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="manager">业务逻辑实例</param>
        /// <param name="mapper">AutoMapper实例</param>
        public RoleController(IRoleManager manager, IMapper mapper) : base(manager, mapper)
        {
        }
    }
}
