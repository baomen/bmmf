using AutoMapper;
using BaoMen.MultiMerchant.Merchant.BusinessLogic;
using Entity = BaoMen.MultiMerchant.Merchant.Entity;
using Model = BaoMen.MultiMerchant.Web.Merchant.Models;

namespace BaoMen.MultiMerchant.Web.Merchant.Controllers
{
    /// <summary>
    /// 商户操作日志
    /// </summary>
    public abstract class OperateHistoryController : Util.MerchantBaseController<int, Entity.OperateHistory, Entity.OperateHistoryFilter, Model.OperateHistory, IOperateHistoryManager>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="manager">业务逻辑实例</param>
        /// <param name="mapper">AutoMapper实例</param>
        /// <param name="merchantService">商户服务实例</param>
        public OperateHistoryController(IOperateHistoryManager manager, IMapper mapper, MultiMerchant.Util.IMerchantService merchantService) : base(manager, mapper, merchantService)
        {
        }
    }
}