using AutoMapper;
using BaoMen.Common.Model;
using BaoMen.MultiMerchant.Web.Util;
using BaoMen.MultiMerchant.System.BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Entity = BaoMen.MultiMerchant.System.Entity;
using Model = BaoMen.MultiMerchant.Web.System.Models;

namespace BaoMen.MultiMerchant.Web.System.Controllers
{
    /// <summary>
    /// 系统角色
    /// </summary>
    public abstract class RoleController : BaseController<string, Entity.Role, Entity.RoleFilter, Model.Role, Model.CreateRole, Model.UpdateRole, Model.DeleteRole, IRoleManager>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="manager">业务逻辑实例</param>
        /// <param name="mapper">AutoMapper实例</param>
        public RoleController(IRoleManager manager, IMapper mapper) : base(manager, mapper)
        {
        }

        /// <summary>
        /// 获取角色选项列表
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet]
        public ResponseData<ICollection<TextValue<string>>> GetOptions([FromQuery]Entity.RoleFilter filter)
        {
            filter.Status = 1;
            return DoGetList<TextValue<string>>(filter);
        }
    }
}
