using AutoMapper;
using BaoMen.Common.Model;
using BaoMen.MultiMerchant.Merchant.BusinessLogic;
using BaoMen.MultiMerchant.Web.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Entity = BaoMen.MultiMerchant.Merchant.Entity;

namespace BaoMen.MultiMerchant.Web.Merchant.Controllers
{
    /// <summary>
    /// 商户
    /// </summary>
    [ApiExplorerSettings(GroupName = "merchant")]
    public abstract class MerchantController : BaseController<string, Entity.Merchant, Entity.MerchantFilter, Models.Merchant, Models.CreateMerchant, Models.UpdateMerchant, Models.DeleteMerchant, IMerchantManager>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="manager">业务逻辑实例</param>
        /// <param name="mapper">AutoMapper实例</param>
        public MerchantController(IMerchantManager manager, IMapper mapper) : base(manager, mapper)
        {

        }

        /// <summary>
        /// 获取数量
        /// </summary>
        /// <param name="filter">过滤器</param>
        /// <returns></returns>
        [HttpGet]
        public virtual ResponseData<int> GetListCount([FromQuery]Entity.MerchantFilter filter)
        {
            return DoGetListCount(filter);
        }

        /// <summary>
        /// 获取商户选项列表
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet]
        public ResponseData<ICollection<TextValue<string>>> GetOptions([FromQuery]Entity.MerchantFilter filter)
        {
            filter.Status = 1;
            return DoGetList<TextValue<string>>(filter);
        }
    }
}
