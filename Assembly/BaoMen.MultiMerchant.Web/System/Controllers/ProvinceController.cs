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
    /// 系统省份
    /// </summary>
    [ApiExplorerSettings(GroupName = "system")]
    public abstract class ProvinceController : BaseController<string, Entity.Province, Entity.ProvinceFilter, Model.Province, Model.CreateProvince, Model.UpdateProvince, Model.DeleteProvince, IProvinceManager>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="manager">业务逻辑实例</param>
        /// <param name="mapper">AutoMapper实例</param>
        public ProvinceController(IProvinceManager manager, IMapper mapper) : base(manager, mapper)
        {
        }

        /// <summary>
        /// 获取省份选项列表
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet]
        public ResponseData<ICollection<TextValue<string>>> GetOptions([FromQuery]Entity.ProvinceFilter filter)
        {
            filter.Status = 1;
            return DoGetList<TextValue<string>>(filter);
        }
    }
}
