/*
Author: WangXinBin
CreateTime: 2020-07-23 11:07:29
*/

using BaoMen.Common.Data;
using BaoMen.MultiMerchant.WeChat.MiniProgram.Entity;

namespace BaoMen.MultiMerchant.WeChat.MiniProgram.BusinessLogic
{
    #region interface IAppAccessTokenManager (generated)
    /// <summary>
    /// 微信小程序凭据业务逻辑接口
    /// </summary>
    public interface IAppAccessTokenManager : ICacheableBusinessLogic<string,AppAccessToken,AppAccessTokenFilter>
    {
        /// <summary>
        /// 插入或更新数据
        /// </summary>
        /// <param name="item">应用访问凭据</param>
        /// <returns></returns>
        int InserOrUpdate(Entity.AppAccessToken item);
    }
    #endregion
}