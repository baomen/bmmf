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
    /// 系统地区
    /// </summary>
    public abstract class DistrictController : BaseController<string, Entity.District, Entity.DistrictFilter, Model.District, Model.CreateDistrict, Model.UpdateDistrict, Model.DeleteDistrict, IDistrictManager>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="manager">业务逻辑实例</param>
        /// <param name="mapper">AutoMapper实例</param>
        public DistrictController(IDistrictManager manager, IMapper mapper) : base(manager, mapper)
        {
        }

        /// <summary>
        /// 获取地区选项列表
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet]
        public ResponseData<ICollection<TextValue<string>>> GetOptions([FromQuery]Entity.DistrictFilter filter)
        {
            filter.Status = 1;
            return DoGetList<TextValue<string>>(filter);
        }
    }
}
