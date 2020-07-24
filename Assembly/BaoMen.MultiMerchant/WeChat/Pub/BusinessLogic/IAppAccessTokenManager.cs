/*
Author: WangXinBin
CreateTime: 2020-07-23 11:07:29
*/

using System.Collections.Generic;
using System.Linq;
using BaoMen.MultiMerchant.WeChat.Pub.Entity;
using BaoMen.Common.Data;

namespace BaoMen.MultiMerchant.WeChat.Pub.BusinessLogic
{
    #region interface IAppAccessTokenManager (generated)
    /// <summary>
    /// 微信公众号凭据业务逻辑接口
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