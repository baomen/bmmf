using AutoMapper;
using BaoMen.MultiMerchant.System.BusinessLogic;
using Microsoft.AspNetCore.Mvc;

namespace BaoMen.Demo.AdminWebApi.System.Controllers
{
    /// <summary>
    /// 操作记录
    /// </summary>
    [Route("api/system/[controller]/[action]")]
    
    public class OperateHistoryController : MultiMerchant.Web.System.Controllers.OperateHistoryController
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="manager">业务逻辑实例</param>
        /// <param name="mapper">AutoMapper实例</param>
        public OperateHistoryController(IOperateHistoryManager manager, IMapper mapper) : base(manager, mapper)
        {
        }
    }
}
