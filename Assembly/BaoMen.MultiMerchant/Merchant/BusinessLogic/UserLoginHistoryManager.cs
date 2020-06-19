/*
Author: WangXinBin
CreateTime: 2020-04-07 17:36:11
*/

using Microsoft.Extensions.Configuration;
using BaoMen.MultiMerchant.Merchant.Entity;
using BaoMen.Common.Data;
using System;

namespace BaoMen.MultiMerchant.Merchant.BusinessLogic
{
    #region class UserLoginHistoryManager (generated)
    /// <summary>
    /// 商户用户登录历史业务逻辑
    /// </summary>
    public partial class UserLoginHistoryManager : BusinessLogicBase<int,UserLoginHistory,UserLoginHistoryFilter,DataAccess.UserLoginHistory>,IUserLoginHistoryManager
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="configuration">配置实例</param>
        public UserLoginHistoryManager(IConfiguration configuration) : base(configuration)
        {

        }

        /// <summary>
        /// 插入登录历史
        /// </summary>
        /// <param name="item">登录历史实体</param>
        /// <returns></returns>
        protected override int DoInsert(UserLoginHistory item)
        {
            item.MerchantId ??= string.Empty;
            item.LoginTime = DateTime.Now;
            return base.DoInsert(item);
        }
    }
    #endregion
}