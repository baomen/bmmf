/*
Author: WangXinBin
CreateTime: 2019/9/27 14:49:26
*/

using BaoMen.Common.Constant;
using BaoMen.Common.Data;
using BaoMen.Common.Extension;
using BaoMen.MultiMerchant.Merchant.Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace BaoMen.MultiMerchant.Merchant.BusinessLogic
{
    #region class MerchantManager (generated)
    /// <summary>
    /// 商户业务逻辑
    /// </summary>
    public partial class MerchantManager : CacheableBusinessLogicBase<string, Entity.Merchant, MerchantFilter, DataAccess.Merchant>, IMerchantManager
    {
        private readonly System.BusinessLogic.IOperateHistoryManager operateHistoryManager;
        private readonly System.BusinessLogic.IVersionManager versionManager;
        private readonly IServiceProvider serviceProvider;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="configuration">配置实例</param>
        /// <param name="serviceProvider">服务提供程序</param>
        public MerchantManager(IConfiguration configuration, IServiceProvider serviceProvider) : base(configuration)
        {
            this.serviceProvider = serviceProvider;
            operateHistoryManager = serviceProvider.GetRequiredService<System.BusinessLogic.IOperateHistoryManager>();
            versionManager = serviceProvider.GetRequiredService<System.BusinessLogic.IVersionManager>();
        }

        /// <summary>
        /// 插入商户
        /// </summary>
        /// <param name="item">实体</param>
        /// <returns></returns>
        protected override int DoInsert(Entity.Merchant item)
        {
            if (item.DefaultUserPassword != null)
            {
                item.DefaultUserPassword = item.DefaultUserPassword.To32MD5();
            }
            int rows = base.DoInsert(item);
            if (rows == 1)
            {
                Util.ICurrentUserService currentUserService = serviceProvider.GetRequiredService<Util.ICurrentUserService>();
                Util.IUser user = currentUserService.GetCurrentUser() ?? new Entity.User { Id = "merchant_regist" };
                operateHistoryManager.Insert(item.Id, item, DataOperationType.Insert, user);
            }
            return rows;
        }

        /// <summary>
        /// 更新商户
        /// </summary>
        /// <param name="item">实体</param>
        /// <returns></returns>
        protected override int DoUpdate(Entity.Merchant item)
        {
            int affectRows = base.DoUpdate(item);
            if (affectRows == 1)
            {
                operateHistoryManager.Insert(item.Id, item, DataOperationType.Update);
            }
            return affectRows;
        }

        /// <summary>
        /// 删除商户
        /// </summary>
        /// <param name="item">实体</param>
        /// <returns></returns>
        protected override int DoDelete(Entity.Merchant item)
        {
            int affectRows = base.DoDelete(item);
            if (affectRows == 1)
                operateHistoryManager.Insert(item.Id, item, DataOperationType.Delete);
            return affectRows;
        }

        /// <summary>
        /// 添加实体的扩展属性
        /// </summary>
        /// <param name="item"></param>
        protected override void AppendExtention(Entity.Merchant item)
        {
            item.Version = versionManager.Get(item.VersionId);
        }

        /// <summary>
        /// 移除所有商户的缓存
        /// </summary>
        /// <param name="types">业务逻辑的类型</param>
        public void RemoveAllCache(params Type[] types)
        {
            ICollection<Entity.Merchant> merchants = GetList(new MerchantFilter { Status = 1 });
            foreach (Entity.Merchant merchant in merchants)
            {
                foreach (Type type in types)
                {
                    cache.Remove($"{type.FullName}.CacheKey.{merchant.Id}");
                }
            }
        }

        /// <summary>
        ///  根据ID取得名称
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetName(string key)
        {
            return Get(key)?.Name;
        }
    }
    #endregion
}