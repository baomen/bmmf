using AutoMapper;
using BaoMen.Common.Model;
using BaoMen.MultiMerchant.Web.Util;
using BaoMen.MultiMerchant.Merchant.BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Entity = BaoMen.MultiMerchant.Merchant.Entity;
using Model = BaoMen.MultiMerchant.Web.Merchant.Models;

namespace BaoMen.MultiMerchant.Web.Merchant.Controllers
{
    /// <summary>
    /// 商户角色
    /// </summary>
    [ApiExplorerSettings(GroupName = "merchant")]
    public abstract class RoleController : MerchantBaseController<string, Entity.Role, Entity.RoleFilter, Model.Role, Model.CreateRole, Model.UpdateRole, Model.DeleteRole, IRoleManager>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="manager">业务逻辑实例</param>
        /// <param name="mapper">AutoMapper实例</param>
        /// <param name="merchantService">商户服务实例</param>
        public RoleController(IRoleManager manager, IMapper mapper, MultiMerchant.Util.IMerchantService merchantService) : base(manager, mapper, merchantService)
        {
        }

        /// <summary>
        /// 获取角色选项列表
        /// </summary>
        ///  <param name="filter"></param>
        /// <returns></returns>
        [HttpGet]
        public ResponseData<ICollection<TextValue<string>>> GetOptions([FromQuery]Entity.RoleFilter filter)
        {
            filter.Status = 1;
            return DoGetList<TextValue<string>>(filter);
        }

        /// <summary>
        /// 获取数量
        /// </summary>
        /// <param name="filter">过滤器</param>
        /// <returns></returns>
        [HttpGet]
        public virtual ResponseData<int> GetListCount([FromQuery]Entity.RoleFilter filter)
        {
            return DoGetListCount(filter);
        }

        /// <summary>
        /// 获取单个实例
        /// </summary>
        /// <param name="id">角色ID</param>
        /// <returns></returns>
        [HttpGet]
        public ResponseData<Model.RoleDetail> Get([FromQuery] string id)
        {
            return DoGet<Model.RoleDetail>(id);
        }
    }
}
