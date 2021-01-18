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

        /// <summary>
        /// 创建下载文件实例
        /// </summary>
        /// <param name="relatedId">关联ID</param>
        /// <param name="type">类型</param>
        /// <param name="originalFileName">原始文件名</param>
        /// <returns></returns>
        DownloadFile CreateDownloadFile(string relatedId, int type, string originalFileName);

        /// <summary>
        /// 根据相对路径获取绝对路径
        /// </summary>
        /// <param name="relativePath"></param>
        /// <returns></returns>
        string GetPhysicalPath(string relativePath);
    }
    #endregion
}