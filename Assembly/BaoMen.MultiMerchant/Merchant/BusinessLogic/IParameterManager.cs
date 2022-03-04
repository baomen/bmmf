/*
Author: WangXinBin
CreateTime: 2019/10/23 9:48:21
*/

using BaoMen.Common.Data;
using BaoMen.MultiMerchant.Merchant.Entity;
using System;

namespace BaoMen.MultiMerchant.Merchant.BusinessLogic
{
    #region interface IParameterManager (generated)
    /// <summary>
    /// 商户参数业务逻辑接口
    /// </summary>
    public interface IParameterManager : IHierarchicalBusinessLogic<string, Parameter, ParameterFilter>
    {
        /// <summary>
        /// 获取系统参数
        /// </summary>
        /// <param name="parentId">父ID</param>
        /// <param name="value">参数值</param>
        /// <returns></returns>
        Parameter Get(string parentId, string value);

        /// <summary>
        /// 创建新的ID
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        string CreateId(string parentId);
    }
    #endregion
}