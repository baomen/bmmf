using AutoMapper;
using BaoMen.MultiMerchant.System.BusinessLogic;
using BaoMen.MultiMerchant.Web.Util;
using Microsoft.AspNetCore.Mvc;
using Entity = BaoMen.MultiMerchant.System.Entity;
using Model = BaoMen.MultiMerchant.Web.System.Models;
namespace BaoMen.MultiMerchant.Web.System.Controllers
{
    /// <summary>
    /// 下载文件
    /// </summary>
    [ApiExplorerSettings(GroupName = "system")]
    public abstract class DownloadFileController : BaseController<int, Entity.DownloadFile, Entity.DownloadFileFilter, Model.DownloadFile, IDownloadFileManager>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="manager">业务逻辑实例</param>
        /// <param name="mapper">AutoMapper实例</param>
        public DownloadFileController(IDownloadFileManager manager, IMapper mapper) : base(manager, mapper)
        {
        }
    }
}