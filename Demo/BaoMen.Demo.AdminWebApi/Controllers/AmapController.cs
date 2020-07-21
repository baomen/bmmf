using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaoMen.Amap.Open.WebService;
using BaoMen.Common.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace BaoMen.Demo.AdminWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AmapController : ControllerBase
    {
        /// <summary>
        /// 逆地理编码
        /// </summary>
        /// <param name="longitude">经度</param>
        /// <param name="latitude">纬度</param>
        /// <returns></returns>
        [HttpGet]
        public ResponseData<Amap.Open.WebService.Client.Response.ReGeoResponse> ReGeo([FromQuery] decimal longitude, decimal latitude)
        {
            ResponseData<Amap.Open.WebService.Client.Response.ReGeoResponse> response = new ResponseData<Amap.Open.WebService.Client.Response.ReGeoResponse>();
            try
            {
                MultiMerchant.Amap.ConfigBuilder configBuilder = HttpContext.RequestServices.GetRequiredService<MultiMerchant.Amap.ConfigBuilder>();
                var config = configBuilder.BuildOpenConfig();
                Provider provider = new Provider(config);
                Amap.Open.WebService.Client.Request.ReGeoRequest request = new Amap.Open.WebService.Client.Request.ReGeoRequest
                {
                    Location = $"{longitude:0.000000},{latitude:0.000000}"
                };
                response.Data = provider.ReGeo(request);
            }
            catch (Exception e)
            {
                response.ErrorNumber = 1;
                response.ErrorMessage = e.Message;
                response.Exception = e;
            }
            return response;
        }
    }
}
