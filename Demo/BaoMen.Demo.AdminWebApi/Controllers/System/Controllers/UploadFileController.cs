using AutoMapper;
using BaoMen.Common.Model;
using BaoMen.MultiMerchant.System.BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using System;
using Entity = BaoMen.MultiMerchant.System.Entity;

namespace BaoMen.Demo.AdminWebApi.System.Controllers
{
    /// <summary>
    /// 上传文件
    /// </summary>
    [Route("api/system/[controller]/[action]")]
    
    public class UploadFileController : MultiMerchant.Web.System.Controllers.UploadFileController
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