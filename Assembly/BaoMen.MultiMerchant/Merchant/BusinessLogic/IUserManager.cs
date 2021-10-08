/*
Author: WangXinBin
CreateTime: 2019/10/23 11:51:58
*/

using BaoMen.MultiMerchant.Merchant.Entity;
using BaoMen.Common.Data;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace BaoMen.MultiMerchant.Merchant.BusinessLogic
{
    #region interface IUserManager (generated)
    /// <summary>
    /// 商户用户业务逻辑接口
    /// </summary>
    public interface IUserManager : ICacheableBusinessLogic<string,User,UserFilter>, Util.IGetNameManager<string>
    {
        /// <summary>
        /// 获取用户令牌
        /// </summary>
        /// <param name="merchantId">商户ID</param>
        /// <param name="token">令牌</param>
        /// <returns></returns>
        UserToken GetUserToken(string merchantId, string token);

        /// <summary>
        /// 更新用户令牌
        /// </summary>
        /// <param name="item">用户令牌实例</param>
        /// <returns></returns>
        int UpdateUserToken(UserToken item);

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="item">用户实体</param>
        /// <param name="newPassword">新密码</param>
        /// <returns></returns>
        int ModifyPassword(User item, string newPassword);

        /// <summary>
        /// 重置密码
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        string ResetPassword(User item);

        /// <summary>
        /// 过期Token
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns></returns>
        int ExpireToken(string userId);

        /// <summary>
        /// 过期Token（多个）
        /// </summary>
        /// <param name="userIds">用户ID</param>
        /// <returns></returns>
        int ExpireTokens(ICollection<string> userIds);

        /// <summary>
        /// 根据用户ID查询用户，直接查询数据库，不走缓存
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        User GetById(string id);

        /// <summary>
        /// 根据手机号码查询用户，直接查询数据库，不走缓存
        /// </summary>
        /// <param name="mobile"></param>
        /// <returns></returns>
        User GetByMobile(string mobile);

        /// <summary>
        /// 根据微信小程序OpenId查询用户，直接查询数据库，不走缓存
        /// </summary>
        /// <param name="openId"></param>
        /// <returns></returns>
        User GetByWechatMpOpenId(string openId);

        /// <summary>
        /// 修改头像
        /// </summary>
        /// <param name="item">用户实例</param>
        /// <param name="file">文件流</param>
        /// <returns></returns>
        int UpdateAvatar(User item, IFormFile file);

        /// <summary>
        /// 用户修改个人设置
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        int ModifyPersonalSetting(User item);

        /// <summary>
        /// 绑定微信小程序OpenId和UnionId
        /// </summary>
        /// <param name="item">用户实体</param>
        int BindWechatMpOpenId(User item);
    }
    #endregion
}