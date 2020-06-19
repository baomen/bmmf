/*
Author: WangXinBin
CreateTime: 2019/10/23 12:03:54
*/

using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using BaoMen.MultiMerchant.System.Entity;
using BaoMen.Common.Data;
using System;
using Microsoft.Extensions.DependencyInjection;
using BaoMen.Common.Constant;
using System.Data;

namespace BaoMen.MultiMerchant.System.BusinessLogic
{
    #region class VersionManager (generated)
    /// <summary>
    /// 系统版本业务逻辑
    /// </summary>
    public partial class VersionManager : CacheableBusinessLogicBase<string,Entity.Version,VersionFilter,DataAccess.Version>,IVersionManager
    {
        private readonly IServiceProvider serviceProvider;
        private readonly VersionModuleManager versionModuleManager;
        private readonly IOperateHistoryManager operateHistoryManager;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="configuration">配置实例</param>
        /// <param name="serviceProvider">数据提供程序</param>
        public VersionManager(IConfiguration configuration, IServiceProvider serviceProvider) : base(configuration)
        {
            this.serviceProvider = serviceProvider;
            versionModuleManager = serviceProvider.GetRequiredService<VersionModuleManager>();
            operateHistoryManager = serviceProvider.GetRequiredService<IOperateHistoryManager>();
        }

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="item">系统角色实体</param>
        /// <returns></returns>
        protected override int DoInsert(Entity.Version item)
        {
            int affectRows = ProcessWithTransaction((transaction) =>
            {
                int rows = dal.Insert(item, transaction);
                rows += InsertExtention(item, transaction);
                return rows;
            });
            if (affectRows > 0)
            {
                operateHistoryManager.Insert(item.Id, item, DataOperationType.Insert);
            }
            return affectRows;
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="item">系统角色实体</param>
        /// <returns></returns>
        protected override int DoDelete(Entity.Version item)
        {
            int affectRows = ProcessWithTransaction((transaction) =>
            {
                int rows = DeleteExtention(item, transaction);
                int deleteRows = dal.Delete(item, transaction);
                if (deleteRows == 0)
                    throw new NoneRowModifiedException("原始数据已修改");
                rows += deleteRows;
                return rows;
            });
            if (affectRows > 0)
            {
                operateHistoryManager.Insert(item.Id, item, DataOperationType.Delete);
            }
            return affectRows;
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="item">系统角色实体</param>
        /// <returns></returns>
        protected override int DoUpdate(Entity.Version item)
        {
            int affectRows = ProcessWithTransaction((transaction) =>
            {
                int rows = dal.Update(item, transaction);
                if (rows == 0)
                    throw new NoneRowModifiedException("原始数据已修改");
                rows += DeleteExtention(item, transaction);
                rows += InsertExtention(item, transaction);
                return rows;
            });

            if (affectRows > 0)
            {
                operateHistoryManager.Insert(item.Id, item, DataOperationType.Update);
            }
            return affectRows;
        }

        /// <summary>
        /// 添加扩展属性
        /// </summary>
        /// <param name="item">系统角色实体</param>
        protected override void AppendExtention(Entity.Version item)
        {
            base.AppendExtention(item);
            IModuleManager moduleManager = serviceProvider.GetRequiredService<IModuleManager>();
            item.ModuleIds = versionModuleManager.GetList(new VersionModuleFilter { VersionId = item.Id }).Select(p => p.ModuleId).ToList();
        }

        private int InsertExtention(Entity.Version item, IDbTransaction transaction)
        {
            int rows = 0;
            if (item.ModuleIds?.Count > 0)
            {
                var versionModules = from p in item.ModuleIds select new VersionModule() { ModuleId = p, VersionId = item.Id };
                foreach (var versionModule in versionModules)
                {
                    rows += versionModuleManager.Dal.Insert(versionModule, transaction);
                }
            }
            return rows;
        }

        private int DeleteExtention(Entity.Version item, IDbTransaction transaction)
        {
            int rows = versionModuleManager.Dal.Delete(item.Id, transaction);
            return rows;
        }

        /// <summary>
        /// 移除缓存
        /// </summary>
        public override void RemoveCache()
        {
            versionModuleManager.RemoveCache();
            base.RemoveCache();
            Merchant.BusinessLogic.IMerchantManager merchantManager = serviceProvider.GetRequiredService<Merchant.BusinessLogic.IMerchantManager>();
            merchantManager.RemoveCache();
        }

    }
    #endregion
}