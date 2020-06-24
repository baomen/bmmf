using AutoMapper;
using BaoMen.MultiMerchant.Web.Util;
using BaoMen.MultiMerchant.Merchant.BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Entity = BaoMen.MultiMerchant.Merchant.Entity;
using Model = BaoMen.MultiMerchant.Web.Merchant.Models;

namespace BaoMen.MultiMerchant.Web.Merchant.Controllers
{
    /// <summary>
    /// 上传文件
    /// </summary>
    public abstract class UploadFileController : Util.MerchantBaseController<int, Entity.UploadFile, Entity.UploadFileFilter, Model.UploadFile, IUploadFileManager>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="manager">业务逻辑实例</param>
        /// <param name="mapper">AutoMapper实例</param>
        /// <param name="merchantService">商户服务实例</param>
        public UploadFileController(IUploadFileManager manager, IMapper mapper, MultiMerchant.Util.IMerchantService merchantService) : base(manager, mapper, merchantService)
        {
        }
    }
}