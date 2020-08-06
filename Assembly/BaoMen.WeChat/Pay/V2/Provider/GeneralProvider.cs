using BaoMen.WeChat.Pay.Util;
using NLog;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaoMen.WeChat.Pay.V2.Provider
{
    /// <summary>
    /// 普通商户提供程序
    /// </summary>
    public class GeneralProvider : BaseProvider
    {
        #region 现金红包接口
        /// <summary>
        /// 发放红包接口
        /// </summary>
        /// <param name="request">请求参数</param>
        /// <param name="config">配置</param>
        /// <returns></returns>
        public Response.General.SendRedPackResponse SendRedPack(Request.General.SendRedPackRequest request, GeneralConfig config)
        {
            if (request == null)
            {
                logger.Warn("SendRedPack 请求参数不能为null");
                throw new WxPayException("请求参数不能为null");
            }
            request.ClientIp = GetIntranetIP();
            request.MchId = config.MchId;
            request.NonceStr = CreateNonceString();
            request.WxAppId = config.AppId;
            request.Validate();
            request.Sign = request.MakeSign(Constant.SignType.MD5, config.Key);

            string url = $"{config.ApiUrl}/mmpaymkttransfers/sendredpack";

            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();
            string xml = Post(request.ToXml(), url, true, 1, config.SslCertPath, config.SslCertPassword);
            stopwatch.Stop();
            TimeSpan ts = stopwatch.Elapsed;
            int timeCost = (int)(ts.TotalMilliseconds);//获得接口耗时
            Response.General.SendRedPackResponse response = new Response.General.SendRedPackResponse(xml);
            //ReportCostTime(url, timeCost, result);//测速上报
            return response;
        }
        #endregion

        #region 企业付款接口实现
        /// <summary>
        /// 企业付款
        /// </summary>
        /// <param name="request">请求参数</param>
        /// <param name="config">配置</param>
        /// <returns></returns>
        public Response.General.TransferResponse Transfer(Request.General.TransferRequest request, GeneralConfig config)
        {
            if (request == null)
            {
                logger.Warn("SendRedPack 请求参数不能为null");
                throw new WxPayException("请求参数不能为null");
            }
            request.CheckName = string.IsNullOrEmpty(request.ReUserName) ? "NO_CHECK" : "FORCE_CHECK";
            request.MchAppId = config.AppId;
            request.MchId = config.MchId;
            request.NonceStr = CreateNonceString();
            request.SpBillCreateIp = GetIntranetIP();
            request.Validate();
            request.Sign = request.MakeSign(Constant.SignType.MD5, config.Key);
            
            string url = $"{config.ApiUrl}/mmpaymkttransfers/promotion/transfers";

            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();
            string xml = Post(request.ToXml(), url, true, 1, config.SslCertPath, config.SslCertPassword);
            stopwatch.Stop();
            TimeSpan ts = stopwatch.Elapsed;
            int timeCost = (int)(ts.TotalMilliseconds);//获得接口耗时
            Response.General.TransferResponse response = new Response.General.TransferResponse(xml);
            //ReportCostTime(url, timeCost, result);//测速上报
            return response;
        }
        #endregion

        //public static WxPayData Report(WxPayData inputObj, int timeOut = 1)
        //{
        //    string url = "https://api.mch.weixin.qq.com/payitil/report";
        //    //检测必填参数
        //    if (!inputObj.IsSet("interface_url"))
        //    {
        //        throw new WxPayException("接口URL，缺少必填参数interface_url！");
        //    }
        //    if (!inputObj.IsSet("return_code"))
        //    {
        //        throw new WxPayException("返回状态码，缺少必填参数return_code！");
        //    }
        //    if (!inputObj.IsSet("result_code"))
        //    {
        //        throw new WxPayException("业务结果，缺少必填参数result_code！");
        //    }
        //    if (!inputObj.IsSet("user_ip"))
        //    {
        //        throw new WxPayException("访问接口IP，缺少必填参数user_ip！");
        //    }
        //    if (!inputObj.IsSet("execute_time_"))
        //    {
        //        throw new WxPayException("接口耗时，缺少必填参数execute_time_！");
        //    }

        //    inputObj.SetValue("appid", WxPayConfig.GetConfig().GetAppID());//公众账号ID
        //    inputObj.SetValue("mch_id", WxPayConfig.GetConfig().GetMchID());//商户号
        //    inputObj.SetValue("user_ip", WxPayConfig.GetConfig().GetIp());//终端ip
        //    inputObj.SetValue("time", DateTime.Now.ToString("yyyyMMddHHmmss"));//商户上报时间	 
        //    inputObj.SetValue("nonce_str", GenerateNonceStr());//随机字符串
        //    inputObj.SetValue("sign_type", WxPayData.SIGN_TYPE_HMAC_SHA256);//签名类型
        //    inputObj.SetValue("sign", inputObj.MakeSign());//签名
        //    string xml = inputObj.ToXml();

        //    Log.Info("WxPayApi", "Report request : " + xml);

        //    string response = HttpService.Post(xml, url, false, timeOut);

        //    Log.Info("WxPayApi", "Report response : " + response);

        //    WxPayData result = new WxPayData();
        //    result.FromXml(response);
        //    return result;
        //}

        ///// <summary>
        ///// 交易保障
        ///// </summary>
        ///// <param name="interface_url">接口URL</param>
        ///// <param name="timeCost">接口耗时</param>
        ///// <param name="inputObj">参数数组</param>
        //private static void ReportCostTime(string interface_url, int timeCost, WxPayData inputObj)
        //{
        //    //如果不需要进行上报
        //    if (WxPayConfig.GetConfig().GetReportLevel() == 0)
        //    {
        //        return;
        //    }

        //    //如果仅失败上报
        //    if (WxPayConfig.GetConfig().GetReportLevel() == 1 && inputObj.IsSet("return_code") && inputObj.GetValue("return_code").ToString() == "SUCCESS" &&
        //     inputObj.IsSet("result_code") && inputObj.GetValue("result_code").ToString() == "SUCCESS")
        //    {
        //        return;
        //    }

        //    //上报逻辑
        //    WxPayData data = new WxPayData();
        //    data.SetValue("interface_url", interface_url);
        //    data.SetValue("execute_time_", timeCost);
        //    //返回状态码
        //    if (inputObj.IsSet("return_code"))
        //    {
        //        data.SetValue("return_code", inputObj.GetValue("return_code"));
        //    }
        //    //返回信息
        //    if (inputObj.IsSet("return_msg"))
        //    {
        //        data.SetValue("return_msg", inputObj.GetValue("return_msg"));
        //    }
        //    //业务结果
        //    if (inputObj.IsSet("result_code"))
        //    {
        //        data.SetValue("result_code", inputObj.GetValue("result_code"));
        //    }
        //    //错误代码
        //    if (inputObj.IsSet("err_code"))
        //    {
        //        data.SetValue("err_code", inputObj.GetValue("err_code"));
        //    }
        //    //错误代码描述
        //    if (inputObj.IsSet("err_code_des"))
        //    {
        //        data.SetValue("err_code_des", inputObj.GetValue("err_code_des"));
        //    }
        //    //商户订单号
        //    if (inputObj.IsSet("out_trade_no"))
        //    {
        //        data.SetValue("out_trade_no", inputObj.GetValue("out_trade_no"));
        //    }
        //    //设备号
        //    if (inputObj.IsSet("device_info"))
        //    {
        //        data.SetValue("device_info", inputObj.GetValue("device_info"));
        //    }

        //    try
        //    {
        //        Report(data);
        //    }
        //    catch (WxPayException ex)
        //    {
        //        //不做任何处理
        //    }
        //}
    }
}
