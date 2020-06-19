/*
Author: WangXinBin
CreateTime: 2019/10/23 11:49:53
*/

using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using BaoMen.MultiMerchant.Merchant.Entity;
using BaoMen.Common.Data;
using BaoMen.MultiMerchant.Util;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using BaoMen.Common.Constant;

namespace BaoMen.MultiMerchant.Merchant.BusinessLogic
{
    #region class DepartmentManager (generated)
    /// <summary>
    /// 商户部门业务逻辑
    /// </summary>
    public partial class DepartmentManager : MerchantHierarchicalCacheableBusinessLogicBase<string, Department, DepartmentFilter, DataAccess.Department>, IDepartmentManager
    {
        private readonly IOperateHistoryManager operateHistoryManager;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="configuration">配置实例</param>
        /// <param name="serviceProvider">数据提供程序</param>
        public DepartmentManager(IConfiguration configuration, IServiceProvider serviceProvider) : base(configuration, serviceProvider)
        {
            operateHistoryManager = serviceProvider.GetRequiredService<IOperateHistoryManager>();
        }

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="item">商户部门</param>
        /// <returns></returns>
        protected override int DoInsert(Department item)
        {
            item.ParentId ??= string.Empty;
            int affectRows = base.DoInsert(item);
            if (affectRows > 0)
            {
                operateHistoryManager.Insert(item.Id, item, DataOperationType.Insert);
            }
            return affectRows;
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="item">系统角色实体</param>
        /// <returns></returns>
        protected override int DoUpdate(Department item)
        {
            item.ParentId ??= string.Empty;
            int affectRows = base.DoUpdate(item);
            if (affectRows > 0)
            {
                operateHistoryManager.Insert(item.Id, item, DataOperationType.Update);
            }
            return affectRows;
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="item">系统角色实体</param>
        /// <returns></returns>
        protected override int DoDelete(Department item)
        {
            int affectRows = base.DoDelete(item);
            if (affectRows > 0)
            {
                operateHistoryManager.Insert(item.Id, item, DataOperationType.Delete);
            }
            return affectRows;
        }

        /// <summary>
        /// 移除缓存
        /// </summary>
        public override void RemoveCache()
        {
            base.RemoveCache();
            IUserManager userManager = serviceProvider.GetRequiredService<IUserManager>();
            userManager.RemoveCache();
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