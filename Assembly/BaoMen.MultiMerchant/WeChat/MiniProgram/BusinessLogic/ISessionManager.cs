/*
Author: WangXinBin
CreateTime: 2020-08-31 19:01:29
*/

using System;
using BaoMen.MultiMerchant.WeChat.MiniProgram.Entity;
using BaoMen.Common.Data;

namespace BaoMen.MultiMerchant.WeChat.MiniProgram.BusinessLogic
{
    #region interface ISessionManager (generated)
    /// <summary>
    /// 微信小程序登录凭证校验业务逻辑接口
    /// </summary>
    public interface ISessionManager : IBusinessLogic<Tuple<string,string>,Session,SessionFilter>
    {
        /// <summary>
        /// 插入或更新数据
        /// </summary>
        /// <param name="item">微信小程序登录凭证</param>
        /// <returns></returns>
        int InserOrUpdate(Entity.Session item);
    }
    #endregion
}