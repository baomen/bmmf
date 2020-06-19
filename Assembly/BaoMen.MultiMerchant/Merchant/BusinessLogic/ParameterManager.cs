/*
Author: WangXinBin
CreateTime: 2019/10/23 9:48:21
*/

using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using BaoMen.MultiMerchant.Merchant.Entity;
using BaoMen.Common.Data;
using BaoMen.Common.Constant;
using System;

namespace BaoMen.MultiMerchant.Merchant.BusinessLogic
{
    #region class ParameterManager (generated)
    /// <summary>
    /// 商户参数业务逻辑
    /// </summary>
    public partial class ParameterManager : Util.MerchantHierarchicalCacheableBusinessLogicBase<string, Parameter, ParameterFilter, DataAccess.Parameter>, IParameterManager
    {
        private readonly System.BusinessLogic.IOperateHistoryManager operateHistoryManager;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="configuration">配置实例</param>
        /// <param name="operateHistoryManager">系统操作日志业务逻辑</param>
        /// <param name="serviceProvider">数据提供程序</param>
        public ParameterManager(IConfiguration configuration, System.BusinessLogic.IOperateHistoryManager operateHistoryManager, IServiceProvider serviceProvider) : base(configuration, serviceProvider)
        {
            this.operateHistoryManager = operateHistoryManager;
        }

        /// <summary>
        /// 插入商户参数
        /// </summary>
        /// <param name="item">实体</param>
        /// <returns></returns>
        protected override int DoInsert(Parameter item)
        {
            int rows = base.DoInsert(item);
            if (rows == 1)
                operateHistoryManager.Insert(item.Id, item, DataOperationType.Insert);
            return rows;
        }

        /// <summary>
        /// 更新商户参数
        /// </summary>
        /// <param name="item">实体</param>
        /// <returns></returns>
        protected override int DoUpdate(Parameter item)
        {
            int affectRows = base.DoUpdate(item);
            if (affectRows == 1)
            {
                operateHistoryManager.Insert(item.Id, item, DataOperationType.Update);
            }
            return affectRows;
        }

        /// <summary>
        /// 删除商户参数
        /// </summary>
        /// <param name="item">实体</param>
        /// <returns></returns>
        protected override int DoDelete(Parameter item)
        {
            Parameter parameter = DoGet(item.Id);
            if (parameter == null)
                throw new BusinessLogicException("参数不存在");
            ICollection<Parameter> children = DoGetChildren(item.Id);
            if (children.Count > 0)
                throw new BusinessLogicException("请先删除子节点");
            int affectRows = base.DoDelete(item);
            if (affectRows == 1)
                operateHistoryManager.Insert(item.Id, item, DataOperationType.Delete);
            return affectRows;
        }

        /// <summary>
        /// 获取商户参数
        /// </summary>
        /// <param name="parentId">父ID</param>
        /// <param name="value">参数值</param>
        /// <returns></returns>
        public Parameter Get(string parentId, string value)
        {
            ICollection<Parameter> itemList = GetChildren(parentId);
            return itemList.SingleOrDefault(p => p.Value == value);
        }

        /// <summary>
        /// 创建新的ID
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public string CreateId(string parentId)
        {
            if (string.IsNullOrEmpty(parentId))
            {
                parentId = "00";
            }
            for (int i = 1; i < 100; i++)
            {
                string id = i.ToString("00");
                if (parentId != "00")
                    id = parentId + id;
                Parameter item = DoGet(id);
                if (item == null)
                {
                    return id;
                }
            }
            throw new ArgumentException("数据已达99条，无法生成新Id");
        }
    }

    #endregion
}