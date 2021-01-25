using AutoMapper;
using BaoMen.Common.Model;
using BaoMen.MultiMerchant.System.BusinessLogic;
using BaoMen.MultiMerchant.Web.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Entity = BaoMen.MultiMerchant.System.Entity;
using Model = BaoMen.MultiMerchant.Web.System.Models;

namespace BaoMen.MultiMerchant.Web.System.Controllers
{
    /// <summary>
    /// 系统版本
    /// </summary>
    [ApiExplorerSettings(GroupName = "system")]
    public abstract class VersionController : BaseController<string, Entity.Version, Entity.VersionFilter, Model.Version, Model.CreateVersion, Model.UpdateVersion, Model.DeleteVersion, IVersionManager>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="manager">业务逻辑实例</param>
        /// <param name="mapper">AutoMapper实例</param>
        public VersionController(IVersionManager manager, IMapper mapper) : base(manager, mapper)
        {
        }

        /// <summary>
        /// 获取选项列表
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet]
        public ResponseData<ICollection<TextValue<string>>> GetOptions([FromQuery]Entity.VersionFilter filter)
        {
            filter.Status = 1;
            return DoGetList<TextValue<string>>(filter);
        }

        /// <summary>
        /// 获取单个实例
        /// </summary>
        /// <param name="id">标识</param>
        /// <returns></returns>
        [HttpGet]
        public ResponseData<Model.Version> Get([FromQuery]string id)
        {
            return DoGet<Model.Version>(id);
        }
    }
}
