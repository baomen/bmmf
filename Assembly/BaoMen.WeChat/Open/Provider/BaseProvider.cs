using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using NLog;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace BaoMen.WeChat.Open.Provider
{
    /// <summary>
    /// 处理程序基类
    /// </summary>
    public class BaseProvider
    {
        /// <summary>
        /// 日志实例
        /// </summary>
        protected ILogger logger;

        /// <summary>
        /// 公众号配置信息
        /// </summary>
        protected readonly Config config;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="config">微信公众号配置信息</param>
        public BaseProvider(Config config)
        {
            logger = LogManager.GetCurrentClassLogger();
            this.config = config;
        }

        /// <summary>
        /// 发送http GET请求
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <returns></returns>
        protected string HttpGet(string url)
        {
            ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback((sender, certificate, chain, errors) => { return true; });
            WebRequest webRequest = WebRequest.Create(url);
            webRequest.Method = "GET";
            HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
            Stream dataStream = webResponse.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            reader.Close();
            dataStream.Close();
            webResponse.Close();
            return responseFromServer;
        }

        /// <summary>
        /// 发送http POST请求
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="data">发送的数据</param>
        /// <returns></returns>
        protected string HttpPost(string url, string data)
        {
            ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback((sender, certificate, chain, errors) => { return true; });
            WebRequest webRequest = WebRequest.Create(url);
            webRequest.Method = "POST";
            byte[] bytes = Encoding.UTF8.GetBytes(data);
            webRequest.ContentLength = bytes.Length;
            Stream outstream = webRequest.GetRequestStream();
            outstream.Write(bytes, 0, bytes.Length);
            outstream.Close();
            HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
            Stream dataStream = webResponse.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            reader.Close();
            dataStream.Close();
            webResponse.Close();
            return responseFromServer;
        }

        /// <summary>
        /// 向微信接口发送http get请求。（Json序列化的请求与响应）
        /// </summary>
        /// <typeparam name="TResponse">响应类型</typeparam>
        /// <param name="url">接口URL</param>
        /// <returns></returns>
        protected TResponse HttpGet<TResponse>(string url)
            where TResponse : Client.Response.BaseResponse, new()
        {
            LogEventInfo log = new LogEventInfo() { LoggerName = logger.Name };
            log.Properties["method"] = "BaoMen.WeChat.Pub.Provider.HttpGet<TResponse>(string parameterId, Func<string, string> formatUrl, string httpMethod)";
            log.Properties["url"] = url;
            TResponse response;
            if (string.IsNullOrEmpty(url))
            {
                log.Level = LogLevel.Warn;
                log.Message = "传入的URL不正确";
                response = new TResponse();
                response.ErrorCode = 1;
                response.ErrorMessage = "传入的URL不正确";
            }
            else
            {
                log.Level = LogLevel.Debug;
                string responseFromServer = HttpGet(url);
                log.Properties["responseFromServer"] = responseFromServer;
                response = JsonConvert.DeserializeObject<TResponse>(responseFromServer);
                if (response.ErrorCode != 0)
                {
                    log.Level = LogLevel.Warn;
                    log.Message = "微信返回异常";
                }
            }
            log.Properties["response"] = response;
            logger.Log(log);
            return response;
        }

        /// <summary>
        /// 向微信接口发送http post请求。（Json序列化的请求与响应）
        /// </summary>
        /// <typeparam name="TRequest">请求类型</typeparam>
        /// <typeparam name="TResponse">响应类型</typeparam>
        /// <param name="request">请求实例</param>
        /// <param name="url">接口URL</param>
        /// <returns></returns>
        protected TResponse HttpPost<TRequest, TResponse>(TRequest request, string url)
            //where TRequest : Client.Request.BaseRequest
            where TResponse : Client.Response.BaseResponse, new()
        {
            LogEventInfo log = new LogEventInfo() { LoggerName = logger.Name };
            log.Properties["method"] = "BaoMen.WeChat.Pub.Provider.HttpPost<TRequest, TResponse>(TRequest request, string parameterId, Func<string, string> formatUrl, string httpMethod)";
            log.Properties["request"] = request;
            log.Properties["url"] = url;
            TResponse response;
            if (request == null)
            {
                log.Level = LogLevel.Warn;
                log.Message = "传入的参数不正确";
                response = new TResponse();
                response.ErrorCode = 1;
                response.ErrorMessage = "传入的参数不正确";
            }
            else
            {
                if (string.IsNullOrEmpty(url))
                {
                    log.Level = LogLevel.Warn;
                    log.Message = "未配置接口地址";
                    response = new TResponse();
                    response.ErrorCode = 1;
                    response.ErrorMessage = "未配置接口地址";
                }
                else
                {
                    log.Level = LogLevel.Debug;
                    string data = JsonConvert.SerializeObject(request);
                    log.Properties["data"] = data;
                    string responseFromServer = HttpPost(url, data);
                    log.Properties["responseFromServer"] = responseFromServer;
                    response = JsonConvert.DeserializeObject<TResponse>(responseFromServer);
                    if (response.ErrorCode != 0)
                    {
                        log.Level = LogLevel.Warn;
                        log.Message = "微信返回异常";
                    }
                }
            }
            log.Properties["response"] = response;
            logger.Log(log);
            return response;
        }
    }
}
