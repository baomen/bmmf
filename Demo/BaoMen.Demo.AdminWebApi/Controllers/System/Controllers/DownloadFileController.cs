using AutoMapper;
using BaoMen.MultiMerchant.System.BusinessLogic;
using Microsoft.AspNetCore.Mvc;
namespace BaoMen.Demo.AdminWebApi.System.Controllers
{
    /// <summary>
    /// 下载文件
    /// </summary>
    [Route("api/system/[controller]/[action]")]
    
    public class DownloadFileController : MultiMerchant.Web.System.Controllers.DownloadFileController
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