/*
Author: WangXinBin
CreateTime: 2020-07-23 11:07:32
*/

using System;
using System.Collections.Generic;
using System.Linq;
using BaoMen.MultiMerchant.WeChat.Pub.Entity;
using BaoMen.Common.Data;

namespace BaoMen.MultiMerchant.WeChat.Pub.BusinessLogic
{
    #region interface IAuthAccessTokenManager (generated)
    /// <summary>
    /// 微信公众号网页授权凭据业务逻辑接口
    /// </summary>
    public interface IAuthAccessTokenManager : ICacheableBusinessLogic<Tuple<string, string>, AuthAccessToken, AuthAccessTokenFilter>
    {
        /// <summary>
        /// 插入或更新数据
        /// </summary>
        /// <param name="item">应用访问凭据</param>
        /// <returns></returns>
        int InserOrUpdate(Entity.AuthAccessToken item);
    }
    #endregion
}