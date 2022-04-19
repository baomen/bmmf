/*
Author: WangXinBin
CreateTime: 2019/9/27 14:49:26
*/

using System.Collections.Generic;
using System.Linq;
using BaoMen.MultiMerchant.Merchant.Entity;
using BaoMen.Common.Data;
using System;

namespace BaoMen.MultiMerchant.Merchant.BusinessLogic
{
    #region interface IMerchantManager (generated)
    /// <summary>
    /// 商户业务逻辑接口
    /// </summary>
    public interface IMerchantManager : ICacheableBusinessLogic<string, Entity.Merchant, MerchantFilter>, Util.IGetNameManager<string>
    {
        /// <summary>
        /// 移除所有商户的缓存
        /// </summary>
        /// <param name="types">业务逻辑的类型</param>
        void RemoveAllCache(params Type[] types);

        /// <summary>
        /// 根据商户用户手机号查询商户列表
        /// </summary>
        /// <param name="mobile">商户用户手机号</param>
        ICollection<Entity.Merchant> GetListByMobile(string mobile);
    }
    #endregion
}