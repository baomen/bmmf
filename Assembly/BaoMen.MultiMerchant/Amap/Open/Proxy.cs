using BaoMen.Amap.Open.WebService;
using BaoMen.Amap.Open.WebService.Client.Request;
using BaoMen.Amap.Open.WebService.Client.Response;
using BaoMen.Amap.Utils;
using Microsoft.Extensions.DependencyInjection;
using NLog;
using NLog.Fluent;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaoMen.MultiMerchant.Amap.Open
{
    /// <summary>
    /// 高德Web服务代理
    /// </summary>
    public class Proxy
    {
        private readonly Provider provider;
        private readonly ILogger logger;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="serviceProvider">服务提供程序</param>
        public Proxy(IServiceProvider serviceProvider)
        {
            logger = LogManager.GetCurrentClassLogger();
            IConfigBuilder configBuilder = serviceProvider.GetRequiredService<IConfigBuilder>();
            var config = configBuilder.BuildOpenConfig();
            provider = new Provider(config);
        }

        /// <summary>
        /// 逆地理编码
        /// </summary>
        /// <param name="request">请求数据</param>
        /// <returns></returns>
        public ReGeoResponse ReGeo(ReGeoRequest request)
        {
            try
            {
                logger.Debug("ReGeo {request}", request);
                return provider.ReGeo(request);
            }
            catch (Exception e)
            {
                logger.Error(e);
                throw;
            }
        }
    }
}
