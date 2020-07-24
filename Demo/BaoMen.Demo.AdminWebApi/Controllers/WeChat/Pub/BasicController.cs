using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaoMen.MultiMerchant.Web.WeChat.Pub;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaoMen.Demo.AdminWebApi.Controllers.WeChat.Pub
{
    /// <summary>
    /// 微信基础接口控制器
    /// </summary>
    [Route("api/wechat/[controller]/[action]")]
    public class BasicController : MultiMerchant.Web.WeChat.Pub.Controller.BasicController
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="serviceProvider">服务提供程序</param>
        public BasicController(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {

        }
    }
}
