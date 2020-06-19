/*
Author: WangXinBin
CreateTime: 2019/10/23 11:52:57
*/

using Microsoft.Extensions.Configuration;
using BaoMen.MultiMerchant.Merchant.Entity;
using BaoMen.Common.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BaoMen.MultiMerchant.Merchant.BusinessLogic
{
    #region class UserTokenManager (generated)
    /// <summary>
    /// 商户用户令牌业务逻辑
    /// </summary>
    public partial class UserTokenManager : Util.MerchantCacheableBusinessLogicBase<string, UserToken, UserTokenFilter, DataAccess.UserToken>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="configuration">配置实例</param>
        /// <param name="serviceProvider">服务提供程序</param>
        public UserTokenManager(IConfiguration configuration, IServiceProvider serviceProvider) : base(configuration, serviceProvider)
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
            get { return "UserId"; }
        }

        /// <summary>
        /// 取得缓存的数据
        /// </summary>
        /// <remarks>
        /// 用于获取指定商户ID的缓存数据
        /// </remarks>
        /// <returns></returns>
        internal IDictionary<string, Entity.UserToken> GetCacheData(string merchantId)
        {
            string cacheKey = $"{this.cacheKey}.{merchantId}";
            IDictionary<string, Entity.UserToken> cacheData = (IDictionary<string, Entity.UserToken>)cache.Get(cacheKey);
            if (cacheData == null)
            {
                ICollection<Entity.UserToken> items = dal.GetList(new Entity.UserTokenFilter { MerchantId = merchantId });
                foreach (Entity.UserToken item in items)
                {
                    if (item != null)
                        AppendExtention(item);
                }
                cacheData = items.ToDictionary(CreateKeyExpression().Compile());
                cache.Set(cacheKey, cacheData);
            }
            return cacheData;
        }

        /// <summary>
        /// 内部使用的数据访问实体
        /// </summary>
        internal DataAccess.UserToken Dal => dal;
    }
    #endregion
}