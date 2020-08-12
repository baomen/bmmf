/*
Author: WangXinBin
CreateTime: 2020/1/13 10:58:04
*/

using BaoMen.MultiMerchant.Merchant.Entity;
using BaoMen.Common.Data;

namespace BaoMen.MultiMerchant.Merchant.BusinessLogic
{
    #region interface IDownloadFileManager (generated)
    /// <summary>
    /// 商户下载文件业务逻辑接口
    /// </summary>
    public interface IDownloadFileManager : IBusinessLogic<int, DownloadFile, DownloadFileFilter>
    {
        /// <summary>
        /// 获取下载路径
        /// </summary>
        /// <param name="merchantId">商户ID</param>
        /// <returns></returns>
        string GetDownloadPath(string merchantId);

        /// <summary>
        /// 获取上传文件相对路径
        /// </summary>
        /// <param name="merchantId">商户ID</param>
        /// <returns></returns>
        string GetRelativePath(string merchantId);
    }
    #endregion
}