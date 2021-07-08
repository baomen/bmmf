using AutoMapper;
using BaoMen.MultiMerchant.Web.Util;
using BaoMen.MultiMerchant.Merchant.BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Entity = BaoMen.MultiMerchant.Merchant.Entity;
using BaoMen.Common.Model;
using System;

namespace BaoMen.MultiMerchant.Web.Merchant.Controllers
{
    /// <summary>
    /// 上传文件
    /// </summary>
    [ApiExplorerSettings(GroupName = "merchant")]
    public abstract class UploadFileController : Util.MerchantBaseController<int, Entity.UploadFile, Entity.UploadFileFilter, Models.UploadFile, IUploadFileManager>
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

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ResponseData<Models.UploadFile> UploadFile([FromForm] Models.CreateUploadFile createUploadFile)
        {
            ResponseData<Models.UploadFile> responseData = new ResponseData<Models.UploadFile>();
            try
            {
                Entity.UploadFile uploadFile = manager.CreateUploadFile(
                    merchantService.MerchantId,
                    //createUploadFile.CreateUserId, 
                    merchantService.MerchantUserId,
                    createUploadFile.RelatedId, 
                    createUploadFile.Type, 
                    createUploadFile.File.FileName);
                string physicalPath = manager.GetPhysicalPath(uploadFile.RelativePath);
                manager.SaveFile(physicalPath, createUploadFile.File);
                int rows = manager.Insert(uploadFile);
                if (rows > 0)
                    responseData.Data = mapper.Map<Models.UploadFile>(uploadFile);
                else
                {
                    responseData.ErrorNumber = 1001;
                    responseData.ErrorMessage = Properties.Resources.Error_1001;
                }
            }
            catch (Exception exception)
            {
                responseData.ErrorNumber = 1006;
                responseData.ErrorMessage = Properties.Resources.Error_1006;
                responseData.Exception = exception;
                logger.Error(exception);
            }
            return responseData;
        }
    }
}