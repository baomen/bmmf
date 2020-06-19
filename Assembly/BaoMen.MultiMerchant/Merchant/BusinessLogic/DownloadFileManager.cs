/*
Author: WangXinBin
CreateTime: 2020/1/13 10:58:04
*/

using Microsoft.Extensions.Configuration;
using BaoMen.MultiMerchant.Merchant.Entity;
using BaoMen.Common.Data;
using System;

namespace BaoMen.MultiMerchant.Merchant.BusinessLogic
{
    #region class DownloadFileManager (generated)
    /// <summary>
    /// 商户下载文件业务逻辑
    /// </summary>
    public partial class DownloadFileManager : Util.MerchantBusinessLogicBase<int,DownloadFile,DownloadFileFilter,DataAccess.DownloadFile>,IDownloadFileManager
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="configuration">配置实例</param>
        /// <param name="serviceProvider">数据提供程序</param>
        public DownloadFileManager(IConfiguration configuration, IServiceProvider serviceProvider) : base(configuration, serviceProvider)
        {

        }
    }
    #endregion
}