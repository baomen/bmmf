using AutoMapper;
using BaoMen.MultiMerchant.Web.Util;
using BaoMen.MultiMerchant.Merchant.BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Entity = BaoMen.MultiMerchant.Merchant.Entity;
using Model = BaoMen.MultiMerchant.Web.Merchant.Models;
namespace BaoMen.MultiMerchant.Web.Merchant.Controllers
{
    /// <summary>
    /// 下载文件
    /// </summary>
    [ApiExplorerSettings(GroupName = "merchant")]
    public abstract class DownloadFileController : MerchantBaseController<int, Entity.DownloadFile, Entity.DownloadFileFilter, Model.DownloadFile, IDownloadFileManager>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="manager">业务逻辑实例</param>
        /// <param name="mapper">AutoMapper实例</param>
        /// <param name="merchantService">商户服务实例</param>
        public DownloadFileController(IDownloadFileManager manager, IMapper mapper, MultiMerchant.Util.IMerchantService merchantService) : base(manager, mapper, merchantService)
        {
        }
    }
}