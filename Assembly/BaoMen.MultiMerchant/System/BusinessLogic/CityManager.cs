﻿/*
Author: WangXinBin
CreateTime: 2019/11/1 12:38:36
*/

using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using BaoMen.MultiMerchant.System.Entity;
using BaoMen.Common.Data;
using System;
using Microsoft.Extensions.DependencyInjection;
using BaoMen.Common.Constant;

namespace BaoMen.MultiMerchant.System.BusinessLogic
{
    #region class CityManager (generated)
    /// <summary>
    /// 地市信息业务逻辑
    /// </summary>
    public partial class CityManager : CacheableBusinessLogicBase<string, City, CityFilter, DataAccess.City>, ICityManager
    {
        private readonly IOperateHistoryManager operateHistoryManager;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="configuration">配置实例</param>
        /// <param name="operateHistoryManager">操作日志业务逻辑</param>
        public CityManager(IConfiguration configuration, IOperateHistoryManager operateHistoryManager) : base(configuration)
        {
            this.operateHistoryManager = operateHistoryManager;
        }


        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="item">系统角色实体</param>
        /// <returns></returns>
        protected override int DoInsert(Entity.City item)
        {
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
        protected override int DoUpdate(Entity.City item)
        {
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
        protected override int DoDelete(Entity.City item)
        {
            int affectRows = base.DoDelete(item);
            if (affectRows > 0)
            {
                operateHistoryManager.Insert(item.Id, item, DataOperationType.Delete);
            }
            return affectRows;
        }

        /// <summary>
        /// 根据ID取得名称
        /// </summary>
        /// <param name="key">ID</param>
        /// <returns></returns>
        public string GetName(string key)
        {
            return Get(key)?.Name;
        }
    }
    #endregion
}