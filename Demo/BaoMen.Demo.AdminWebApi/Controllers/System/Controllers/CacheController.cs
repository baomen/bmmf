using BaoMen.Common.Cache;
using BaoMen.Common.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NLog;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace BaoMen.Demo.AdminWebApi.System.Controllers
{
    /// <summary>
    /// 缓存控制器
    /// </summary>
    [Route("api/system/[controller]/[action]")]
    public class CacheController : MultiMerchant.Web.System.Controllers.CacheController
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="configuration">配置实例</param>
        public CacheController(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
