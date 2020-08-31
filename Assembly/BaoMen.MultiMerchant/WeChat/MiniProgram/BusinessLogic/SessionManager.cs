
/*
Author: WangXinBin
CreateTime: 2020-08-31 19:01:29
*/

using Microsoft.Extensions.Configuration;
using System;
using BaoMen.MultiMerchant.WeChat.MiniProgram.Entity;
using BaoMen.Common.Data;

namespace BaoMen.MultiMerchant.WeChat.MiniProgram.BusinessLogic
{
    #region class SessionManager (generated)
    /// <summary>
    /// 微信小程序登录凭证校验业务逻辑
    /// </summary>
    public partial class SessionManager : MultiMerchant.Util.MerchantBusinessLogicBase<Tuple<string,string>,Session,SessionFilter,DataAccess.Session>,ISessionManager
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="configuration">配置实例</param>
        /// <param name="serviceProvider">服务提供程序</param>
        public SessionManager(IConfiguration configuration, IServiceProvider serviceProvider) : base(configuration, serviceProvider)
        {

        }

        /// <summary>
        /// 插入或更新数据
        /// </summary>
        /// <param name="item">微信小程序登录凭证</param>
        /// <returns></returns>
        public int InserOrUpdate(Entity.Session item)
        {
            return ProcessUpdate(() =>
            {
                item.MerchantId ??= string.Empty;
                return dal.InserOrUpdate(item);
            }, (log) =>
            {
                log.Properties[nameof(item)] = item;
            });
        }
    }
    #endregion
}