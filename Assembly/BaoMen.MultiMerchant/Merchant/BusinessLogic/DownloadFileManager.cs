/*
Author: WangXinBin
CreateTime: 2020/1/13 10:58:04
*/

using Microsoft.Extensions.Configuration;
using BaoMen.MultiMerchant.Merchant.Entity;
using BaoMen.Common.Data;
using System;
using System.Runtime.InteropServices;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

namespace BaoMen.MultiMerchant.Merchant.BusinessLogic
{
    #region class DownloadFileManager (generated)
    /// <summary>
    /// 商户下载文件业务逻辑
    /// </summary>
    public partial class DownloadFileManager : Util.MerchantBusinessLogicBase<int, DownloadFile, DownloadFileFilter, DataAccess.DownloadFile>, IDownloadFileManager
    {
        private readonly System.BusinessLogic.IParameterManager parameterManager;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="configuration">配置实例</param>
        /// <param name="serviceProvider">数据提供程序</param>
        public DownloadFileManager(IConfiguration configuration, IServiceProvider serviceProvider) : base(configuration, serviceProvider)
        {
            parameterManager = serviceProvider.GetRequiredService<System.BusinessLogic.IParameterManager>();
        }

        /// <summary>
        /// 获取下载路径
        /// </summary>
        /// <param name="merchantId">商户ID</param>
        /// <returns></returns>
        public string GetDownloadPath(string merchantId)
        {
            return Path.Combine(GetDownloadPath(), merchantId);
        }

        /// <summary>
        /// 获取上传文件相对路径
        /// </summary>
        /// <param name="merchantId">商户ID</param>
        /// <returns></returns>
        public string GetRelativePath(string merchantId)
        {
            return $"{GetRelativePath()}/{merchantId}";
        }

        /// <summary>
        /// 获取上传文件的目录路径
        /// </summary>
        /// <returns></returns>
        private string GetDownloadPath()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                return parameterManager.Get("0102020201").Value;
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return parameterManager.Get("0102020201").Value;
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// 获取上传文件相对路径
        /// </summary>
        /// <returns></returns>
        private string GetRelativePath()
        {
            return parameterManager.Get("0102020203").Value;
        }
    }
    #endregion
}