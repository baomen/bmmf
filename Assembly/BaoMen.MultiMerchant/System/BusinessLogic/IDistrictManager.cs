/*
Author: WangXinBin
CreateTime: 2019/11/1 12:38:37
*/

using System.Collections.Generic;
using System.Linq;
using BaoMen.MultiMerchant.System.Entity;
using BaoMen.Common.Data;

namespace BaoMen.MultiMerchant.System.BusinessLogic
{
    #region interface IDistrictManager (generated)
    /// <summary>
    /// 地区信息业务逻辑接口
    /// </summary>
    public interface IDistrictManager : ICacheableBusinessLogic<string,District,DistrictFilter>, Util.IGetNameManager<string>
    {
        
    }
    #endregion
}