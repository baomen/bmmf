using Microsoft.Extensions.DependencyInjection;
using System;

namespace BaoMen.MultiMerchant.WeChat.MiniProgram.Proxy
{
    public class BaseProxy
    {
        protected readonly IServiceProvider serviceProvider;

        public BaseProxy(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }
    }
}
