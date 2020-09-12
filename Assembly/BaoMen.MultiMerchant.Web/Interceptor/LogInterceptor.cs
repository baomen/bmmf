using AspectCore.DependencyInjection;
using AspectCore.DynamicProxy;
using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BaoMen.MultiMerchant.Web.Interceptor
{
    /// <summary>
    /// 日志拦截器
    /// </summary>
    public class LogInterceptor : AbstractInterceptor
    {
        /// <summary>
        /// 日志实例
        /// </summary>
        [FromServiceContext]
        public ILogger<LogInterceptor> _logger { get; set; }

        ///// <inheritdoc/>
        //public async override Task Invoke(AspectContext context, AspectDelegate next)
        //{
        //    try
        //    {
        //        await next(context);
        //    }
        //    catch (AutoMapperMappingException autoMapperMappingException)
        //    {
        //        context.
        //        responseData.ErrorNumber = 1009;
        //        responseData.ErrorMessage = Properties.Resources.Error_1009;
        //        //responseData.Exception = autoMapperMappingException;
        //        logger.Error(autoMapperMappingException);
        //    }
        //    catch (Exception exception)
        //    {
        //        responseData.ErrorNumber = 1000;
        //        responseData.ErrorMessage = Properties.Resources.Error_1000;
        //        responseData.Exception = exception;
        //        logger.Error(exception);
        //    }
        //}
    }
}
