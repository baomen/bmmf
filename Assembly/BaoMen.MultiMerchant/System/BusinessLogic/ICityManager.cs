/*
Author: WangXinBin
CreateTime: 2019/11/1 12:38:36
*/

using System.Collections.Generic;
using System.Linq;
using BaoMen.MultiMerchant.System.Entity;
using BaoMen.Common.Data;

namespace BaoMen.MultiMerchant.System.BusinessLogic
{
    #region interface ICityManager (generated)
    /// <summary>
    /// 地市信息业务逻辑接口
    /// </summary>
    public interface ICityManager : ICacheableBusinessLogic<string,City,CityFilter>, Util.IGetNameManager<string>
    {
        
    }
    #endregion
}