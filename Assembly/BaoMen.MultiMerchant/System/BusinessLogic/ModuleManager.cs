/*
Author: WangXinBin
CreateTime: 2019/9/23 14:34:58
*/

using BaoMen.MultiMerchant.System.Entity;
using BaoMen.Common.Constant;
using BaoMen.Common.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BaoMen.MultiMerchant.System.BusinessLogic
{
    #region class ModuleManager (generated)
    /// <summary>
    /// 系统模块业务逻辑
    /// </summary>
    public partial class ModuleManager : HierarchicalCacheableBusinessLogicBase<string, Module, ModuleFilter, DataAccess.Module>, IModuleManager
    {
        private readonly IServiceProvider serviceProvider;
        private readonly IOperateHistoryManager operateHistoryManager;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="configuration">配置实例</param>
        /// <param name="serviceProvider">服务提供程序</param>
        public ModuleManager(IConfiguration configuration, IServiceProvider serviceProvider) : base(configuration)
        {
            this.serviceProvider = serviceProvider;
            operateHistoryManager = serviceProvider.GetRequiredService<IOperateHistoryManager>();
        }

        /// <summary>
        /// 插入系统模块
        /// </summary>
        /// <param name="item">模块实例</param>
        /// <returns></returns>
        protected override int DoInsert(Module item)
        {
            Module parent = DoGet(item.ParentId);
            if (parent != null && parent.IsNode == 0)
            {
                int affectRows = ProcessWithTransaction((transaction) =>
                {
                    int rows = dal.UpdateNode(parent.Id, 1, transaction);
                    rows += dal.Insert(item, transaction);
                    operateHistoryManager.Insert(item.Id, item, DataOperationType.Insert, transaction: transaction);
                    return rows;
                });
                return affectRows;
            }
            else
            {
                return base.DoInsert(item);
            }
        }

        /// <summary>
        /// 更新系统模块
        /// </summary>
        /// <param name="item">模块实例</param>
        /// <returns></returns>
        protected override int DoUpdate(Module item)
        {
            int affectRows = ProcessWithTransaction((transaction) =>
            {
                int rows = dal.Update(item, transaction);
                if (rows == 1)
                {
                    operateHistoryManager.Insert(item.Id, item, DataOperationType.Update, transaction: transaction);
                }
                return rows;
            });
            return affectRows;
        }

        /// <summary>
        /// 删除系统模块
        /// </summary>
        /// <param name="item">模块实例</param>
        /// <returns></returns>
        protected override int DoDelete(Module item)
        {
            Module module = DoGet(item.Id);
            if (module == null)
                throw new BusinessLogicException("数据不存在");
            ICollection<Module> children = DoGetChildren(item.Id);
            if (children.Count > 0)
                throw new BusinessLogicException("请先删除子节点");
            int affectRows;
            RoleModuleManager roleModuleManager = serviceProvider.GetRequiredService<RoleModuleManager>();
            VersionModuleManager versionModuleManager = serviceProvider.GetRequiredService<VersionModuleManager>();
            MultiMerchant.Merchant.BusinessLogic.RoleModuleManager merchantRoleModuleManager = serviceProvider.GetRequiredService<MultiMerchant.Merchant.BusinessLogic.RoleModuleManager>();

            //如果不是根节点判断是否还有兄弟节点
            if (!string.IsNullOrEmpty(module.ParentId))
            {
                ICollection<Module> brothers = DoGetChildren(module.ParentId).Where(p => p.Id != item.Id).ToList();
                if (brothers.Count == 0)
                {
                    Module parent = DoGet(module.ParentId);
                    affectRows = ProcessWithTransaction((transaction) =>
                    {
                        int rows = dal.UpdateNode(parent.Id, 0, transaction);
                        rows += dal.Delete(item, transaction);
                        rows += roleModuleManager.Dal.DeleteByModuleId(item.Id, transaction);
                        rows += merchantRoleModuleManager.Dal.DeleteByModuleId(item.Id, transaction);
                        rows += versionModuleManager.Dal.DeleteByModuleId(item.Id, transaction);
                        if (rows > 0)
                        {
                            operateHistoryManager.Insert(item.Id, item, DataOperationType.Delete, transaction: transaction);
                        }
                        return rows;
                    });
                    if (affectRows > 0)
                        RemoveCache();
                    return affectRows;
                }
            }
            affectRows = ProcessWithTransaction((transaction) =>
            {
                int rows = dal.Delete(item, transaction);
                rows += roleModuleManager.Dal.DeleteByModuleId(item.Id, transaction);
                rows += merchantRoleModuleManager.Dal.DeleteByModuleId(item.Id, transaction);
                if (rows > 0)
                {
                    operateHistoryManager.Insert(item.Id, item, DataOperationType.Delete, transaction: transaction);
                }
                return rows;
            });
            return affectRows;
        }

        /// <summary>
        /// 移除缓存
        /// </summary>
        public override void RemoveCache()
        {
            Type[] types =
{
                typeof(Merchant.BusinessLogic.RoleModuleManager),
                typeof(Merchant.BusinessLogic.RoleManager),
                typeof(Merchant.BusinessLogic.UserRoleManager),
                typeof(Merchant.BusinessLogic.UserManager)
            };
            IRoleManager roleManager = serviceProvider.GetRequiredService<IRoleManager>();
            IVersionManager versionManager = serviceProvider.GetRequiredService<IVersionManager>();
            Merchant.BusinessLogic.IMerchantManager merchantManager = serviceProvider.GetRequiredService<Merchant.BusinessLogic.IMerchantManager>();

            base.RemoveCache();
            roleManager.RemoveCache();
            versionManager.RemoveCache();
            merchantManager.RemoveAllCache(types);
        }

        /// <summary>
        /// 执行自定义的过滤
        /// </summary>
        /// <param name="items">实体枚举数</param>
        /// <param name="filter">实体过滤器</param>
        protected override IEnumerable<Module> ExecuteCustomFilter(IEnumerable<Module> items, ModuleFilter filter)
        {
            if (filter.MerchantId != null)
            {
                if (filter.MerchantId.CompareOperator == DbCompareOperator.Equal)
                {
                    Merchant.BusinessLogic.IMerchantManager merchantManager = serviceProvider.GetRequiredService<Merchant.BusinessLogic.IMerchantManager>();
                    Merchant.Entity.Merchant merchant = merchantManager.Get(filter.MerchantId.Value);
                    if (merchant == null)
                    {
                        items = new List<Module>();
                    }
                    else
                    {
                        items = items.Where(p => merchant.Version.ModuleIds.Contains(p.Id));
                    }
                }
                else
                {
                    throw new NotImplementedException("ModuleFilter's property MerchantId only implemented Equal");
                }
            }
            return items;
        }
    }
    #endregion
}