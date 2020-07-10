using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaoMen.Demo.AdminWebApi.Controllers.WeChat.MiniProgram
{
    /// <summary>
    /// 微信小程序基础接口控制器
    /// </summary>
    [Route("api/wechat/miniprogram/[controller]/[action]")]
    public class BasicController : MultiMerchant.Web.WeChat.MiniProgram.BasicController
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="serviceProvider">服务提供程序</param>
        public BasicController(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }
    }
}
