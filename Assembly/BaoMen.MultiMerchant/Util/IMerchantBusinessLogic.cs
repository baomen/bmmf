using BaoMen.Common.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoMen.MultiMerchant.Util
{
    /// <summary>
    /// 商户缓存业务逻辑接口
    /// </summary>
    /// <typeparam name="TKey">实体标识类型</typeparam>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TFilter">实体过滤器类型</typeparam>
    public interface IMerchantCacheableBusinessLogic<TKey, TEntity, TFilter> : ICacheableBusinessLogic<TKey, TEntity, TFilter>
        where TEntity : class, new()
        where TFilter : class
    {
        /// <summary>
        /// 移除缓存
        /// </summary>
        /// <param name="merchantId">商户ID</param>
        void RemoveCache(string merchantId);
    }
}
