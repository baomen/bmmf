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
    /// 操作记录
    /// </summary>
    [ApiExplorerSettings(GroupName = "system")]
    public abstract class OperateHistoryController : BaseController<int, Entity.OperateHistory, Entity.OperateHistoryFilter, Model.OperateHistory, IOperateHistoryManager>
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
