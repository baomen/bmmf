﻿/*
Author: WangXinBin
CreateTime: 2019/10/23 11:49:41
*/

using BaoMen.MultiMerchant.Merchant.Entity;
using BaoMen.Common.Data;
using BaoMen.Common.Constant;
using System.Data;

namespace BaoMen.MultiMerchant.Merchant.BusinessLogic
{
    #region interface IOperateHistoryManager (generated)
    /// <summary>
    /// 商户操作日志业务逻辑接口
    /// </summary>
    public interface IOperateHistoryManager : IBusinessLogic<int,OperateHistory,OperateHistoryFilter>
    {
        /// <summary>
        /// 插入操作历史
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="relatedId">相关ID</param>
        /// <param name="value">实体实例</param>
        /// <param name="dataOperationType">操作类型</param>
        /// <param name="user">操作人,为空时代表当前操作人</param>
        /// <param name="description">描述信息（可空）</param>
        /// <param name="transaction">数据库事务</param>
        /// <returns></returns>
        int Insert<T>(string relatedId, T value, DataOperationType dataOperationType, Util.IUser user = null, string description = null, IDbTransaction transaction = null);
    }
    #endregion
}