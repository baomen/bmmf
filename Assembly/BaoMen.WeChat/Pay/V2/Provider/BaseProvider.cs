using BaoMen.WeChat.Pay.Util;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace BaoMen.WeChat.Pay.V2.Provider
{
    /// <summary>
    /// 支付提供程序基类
    /// </summary>
    public class BaseProvider
    {
        /// <summary>
        /// 日志实例
        /// </summary>
        protected static readonly Logger logger = LogManager.GetCurrentClassLogger();

        private static readonly string userAgent = string.Format("BaoMen.WeChat.Pay/{0} ({1}) .net/{2}", typeof(BaseProvider).Assembly.GetName().Version, Environment.OSVersion, Environment.Version);

        private bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            //直接确认，否则打不开    
            return true;
        }

        /// <summary>
        /// 处理http GET请求，返回数据
        /// </summary>
        /// <param name="url">请求的url地址</param>
        /// <returns>http GET成功后返回的数据，失败抛WebException异常</returns>
        protected string Get(string url)
        {
            System.GC.Collect();
            string result = "";

            HttpWebRequest request = null;
            HttpWebResponse response = null;

            //请求url以获取数据
            try
            {
                //设置最大连接数
                ServicePointManager.DefaultConnectionLimit = 200;
                //设置https验证方式
                if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
                {
                    ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                }

                /***************************************************************
                * 下面设置HttpWebRequest的相关属性
                * ************************************************************/
                request = (HttpWebRequest)WebRequest.Create(url);
                request.UserAgent = userAgent;
                request.Method = "GET";

                //获取服务器返回
                response = (HttpWebResponse)request.GetResponse();

                //获取HTTP返回数据
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                result = sr.ReadToEnd().Trim();
                sr.Close();
            }
            catch (System.Threading.ThreadAbortException e)
            {
                logger.Error(e);
                System.Threading.Thread.ResetAbort();
            }
            catch (Exception e)
            {
                logger.Error(e);
                throw new WxPayException(innerException: e);
            }
            finally
            {
                //关闭连接和流
                if (response != null)
                {
                    response.Close();
                }
                if (request != null)
                {
                    request.Abort();
                }
            }
            return result;
        }

        /// <summary>
        /// POST数据
        /// </summary>
        /// <param name="xml">xml内容</param>
        /// <param name="url">URL地址</param>
        /// <param name="useCert">是否使用证书</param>
        /// <param name="timeout">超时时长</param>
        /// <param name="sslCertFile">证书路径</param>
        /// <param name="sslCertPassword">证书密码</param>
        /// <returns></returns>
        protected string Post(string xml, string url, bool useCert, int timeout, string sslCertFile = null, string sslCertPassword = null)
        {
            System.GC.Collect();//垃圾回收，回收没有正常关闭的http连接

            string result = "";//返回结果

            HttpWebRequest request = null;
            HttpWebResponse response = null;
            Stream reqStream = null;

            try
            {
                //设置最大连接数
                ServicePointManager.DefaultConnectionLimit = 200;
                //设置https验证方式
                if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
                {
                    ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                }

                /***************************************************************
                * 下面设置HttpWebRequest的相关属性
                * ************************************************************/
                request = (HttpWebRequest)WebRequest.Create(url);
                request.UserAgent = userAgent;
                request.Method = "POST";
                request.Timeout = timeout * 1000;

                //设置代理服务器
                //WebProxy proxy = new WebProxy();                          //定义一个网关对象
                //proxy.Address = new Uri(WxPayConfig.PROXY_URL);              //网关服务器端口:端口
                //request.Proxy = proxy;

                //设置POST的数据类型和长度
                request.ContentType = "text/xml";
                byte[] data = System.Text.Encoding.UTF8.GetBytes(xml);
                request.ContentLength = data.Length;

                //是否使用证书
                if (useCert)
                {
                    X509Certificate2 cert = new X509Certificate2(sslCertFile, sslCertPassword);
                    request.ClientCertificates.Add(cert);
                    logger.Debug("PostXml used cert");
                }

                //往服务器写入数据
                reqStream = request.GetRequestStream();
                reqStream.Write(data, 0, data.Length);
                reqStream.Close();

                //获取服务端返回
                response = (HttpWebResponse)request.GetResponse();

                //获取服务端返回数据
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                result = sr.ReadToEnd().Trim();
                sr.Close();
            }
            catch (System.Threading.ThreadAbortException e)
            {
                logger.Error(e);
                System.Threading.Thread.ResetAbort();
            }
            catch (Exception e)
            {
                logger.Error(e);
                throw new WxPayException(e.ToString());
            }
            finally
            {
                //关闭连接和流
                if (response != null)
                {
                    response.Close();
                }
                if (request != null)
                {
                    request.Abort();
                }
            }
            return result;
        }

        /// <summary>
        /// 获取内网IP
        /// </summary>
        /// <returns></returns>
        protected string GetIntranetIP()
        {
            IPHostEntry host;
            string localIP = "?";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    localIP = ip.ToString();
                    break;
                }
            }
            return localIP;
        }

        /// <summary>
        /// 创建随机字符串
        /// </summary>
        /// <returns></returns>
        protected virtual string CreateNonceString()
        {
            return Guid.NewGuid().ToString("N");
        }

        #region 通用微信接口
        /// <summary>
        /// 发放红包接口
        /// </summary>
        /// <param name="request">请求参数</param>
        /// <param name="config">配置</param>
        /// <returns></returns>
        public Response.GetSignKeyResponse GetSignKey(Request.GetSignKeyRequest request, GeneralConfig config)
        {
            if (request == null)
            {
                logger.Warn("SendRedPack 请求参数不能为null");
                throw new WxPayException("请求参数不能为null");
            }
            request.MchId = config.MchId;
            request.NonceStr = CreateNonceString();
            request.Validate();
            request.Sign = request.MakeSign(Constant.SignType.MD5, config.Key);

            string url = $"{config.ApiUrl}/pay/getsignkey";

            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();
            string xml = Post(request.ToXml(), url, false, 1);
            stopwatch.Stop();
            TimeSpan ts = stopwatch.Elapsed;
            int timeCost = (int)(ts.TotalMilliseconds);//获得接口耗时
            Response.GetSignKeyResponse response = new Response.GetSignKeyResponse(xml);
            //ReportCostTime(url, timeCost, result);//测速上报
            return response;
        }
        #endregion
    }
}
