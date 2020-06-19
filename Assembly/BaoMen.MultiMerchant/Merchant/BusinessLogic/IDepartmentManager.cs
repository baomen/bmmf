/*
Author: WangXinBin
CreateTime: 2019/10/23 11:49:53
*/

using System.Collections.Generic;
using System.Linq;
using BaoMen.MultiMerchant.Merchant.Entity;
using BaoMen.Common.Data;

namespace BaoMen.MultiMerchant.Merchant.BusinessLogic
{
    #region interface IDepartmentManager (generated)
    /// <summary>
    /// 商户部门业务逻辑接口
    /// </summary>
    public interface IDepartmentManager : IHierarchicalBusinessLogic<string, Department, DepartmentFilter>, Util.IGetNameManager<string>
    {

    }
    #endregion
}