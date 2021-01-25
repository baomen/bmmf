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
    /// 系统用户登录历史
    /// </summary>
    [ApiExplorerSettings(GroupName = "system")]
    public abstract class UserLoginHistoryController : BaseController<int, Entity.UserLoginHistory, Entity.UserLoginHistoryFilter, Model.UserLoginHistory, IUserLoginHistoryManager>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="manager">业务逻辑实例</param>
        /// <param name="mapper">AutoMapper实例</param>
        public UserLoginHistoryController(IUserLoginHistoryManager manager, IMapper mapper) : base(manager, mapper)
        {
        }
    }
}
