
/*
Author: WangXinBin
CreateTime: 2020-07-23 11:07:29
*/

using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using BaoMen.MultiMerchant.WeChat.MiniProgram.Entity;
using BaoMen.Common.Data;

namespace BaoMen.MultiMerchant.WeChat.MiniProgram.BusinessLogic
{
    #region class AppAccessTokenManager (generated)
    /// <summary>
    /// 微信小程序凭据业务逻辑
    /// </summary>
    public partial class AppAccessTokenManager : MultiMerchant.Util.MerchantCacheableBusinessLogicBase<string, AppAccessToken, AppAccessTokenFilter, DataAccess.AppAccessToken>, IAppAccessTokenManager
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="configuration">配置实例</param>
        /// <param name="serviceProvider">服务提供程序</param>
        public AppAccessTokenManager(IConfiguration configuration, IServiceProvider serviceProvider) : base(configuration, serviceProvider)
        {

        }

        /// <summary>
        /// 获取实体标识字段名称
        /// </summary>
        /// <remarks>
        /// <para>默认标识字段不为Id。覆盖此属性</para>
        /// </remarks>
        protected override string IdentityPropertyName
        {
            get { return "AppId"; }
        }

        /// <summary>
        /// 插入或更新数据
        /// </summary>
        /// <param name="item">应用访问凭据</param>
        /// <returns></returns>
        public int InserOrUpdate(Entity.AppAccessToken item)
        {
            int rows = ProcessUpdate(() =>
             {
                 item.MerchantId ??= string.Empty;
                 return dal.InserOrUpdate(item);
             }, (log) =>
             {
                 log.Properties[nameof(item)] = item;
             });
            if (rows > 0)
            {
                RemoveCache();
            }
            return rows;
        }
    }
    #endregion
}