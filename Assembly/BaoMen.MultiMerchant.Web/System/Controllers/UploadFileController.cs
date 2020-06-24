using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BaoMen.MultiMerchant.Web.Util;
using BaoMen.MultiMerchant.System.BusinessLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Entity = BaoMen.MultiMerchant.System.Entity;
using Model = BaoMen.MultiMerchant.Web.System.Models;
namespace BaoMen.MultiMerchant.Web.System.Controllers
{
    /// <summary>
    /// 上传文件
    /// </summary>
    public abstract class UploadFileController : BaseController<int, Entity.UploadFile, Entity.UploadFileFilter, Model.UploadFile, IUploadFileManager>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="manager">业务逻辑实例</param>
        /// <param name="mapper">AutoMapper实例</param>
        public UploadFileController(IUploadFileManager manager, IMapper mapper) : base(manager, mapper)
        {
        }
    }
}