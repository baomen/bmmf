using BaoMen.WeChat.Pay.Request;
using BaoMen.WeChat.Pay.Response;
using BaoMen.WeChat.Pay.Util;
using Microsoft.Extensions.DependencyInjection;
using NLog;
using System;

namespace BaoMen.WeChat.Pay.WxPay
{
    /// <summary>
    /// 支付提供程序
    /// </summary>
    public class PayProvider : Util.IPayProvider
    {
        private readonly IConfigBuilder configBuilder;
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="serviceProvider">服务提供程序</param>
        public PayProvider(IServiceProvider serviceProvider)
        {
            configBuilder = serviceProvider.GetRequiredService<IConfigBuilder>();
        }

        /// <summary>
        /// 创建订单并返回二维码url
        /// </summary>
        /// <param name="request">请求数据</param>
        public CreateResponse Create(CreateRequest request)
        {
            CreateResponse response = new CreateResponse();
            try
            {
                Config config = configBuilder.BuildWeixinConifg(request.MerchantId);
                WxPayData data = new WxPayData();
                data.SetValue("body", request.Body);//商品描述
                //data.SetValue("attach", "");//附加数据
                data.SetValue("out_trade_no", request.TradeNo);//随机字符串
                data.SetValue("total_fee", request.Fee);//总金额
                //data.SetValue("goods_tag", deviceManager.Get(deviceOrder.DeviceId).Mac);//商品标记(微信代金券需要)
                data.SetValue("device_info", request.Device);
                //data.SetValue("product_id", Order.Helper.GetProductId(Device.Id, Goods.Id));//商品ID
                data.SetValue("product_id", 0);//商品ID
                data.SetValue("notify_url", GetNotifyUrl(config.NotifyUrl, request.OrderType, request.MerchantId));
                data.SetValue("trade_type", request.TradeType);//交易类型

                WxPayApi wxPayApi = new WxPayApi(config);
                WxPayData result = wxPayApi.UnifiedOrder(data);//调用统一下单接口
                if (result.GetValue("return_code").ToString() == "SUCCESS")
                {
                    if (result.GetValue("result_code").ToString() == "SUCCESS")
                    {
                        //TradeNo相同时，字段不变仍旧返回成功。金额变化时返回失败
                        response.Url = result.GetValue("code_url").ToString();
                    }
                    else
                    {
                        logger.Warn($"支付下单失败。result={result.ToJson()}");
                        throw new Pay.WxPay.WxPayException("return_code返回失败");
                    }
                }
                else
                {
                    logger.Warn($"支付下单失败。result={result.ToJson()}");
                    throw new Pay.WxPay.WxPayException("result_code返回失败");
                }
            }
            catch (Exception exception)
            {
                response.ErrorNumber = 1000;
                response.ErrorMessage = exception.Message;
                logger.Error(exception, "支付下单失败");
            }
            return response;
        }

        /// <summary>
        /// 发起退款
        /// </summary>
        /// <param name="request">请求数据</param>
        /// <returns></returns>
        public RefundResponse Refund(RefundRequest request)
        {
            RefundResponse responseData = new RefundResponse();
            if (request.RefundFee == 0) return responseData;
            try
            {
                WxPayData data = new WxPayData();
                if (!string.IsNullOrEmpty(request.PayPlatformTradeNo))//微信订单号存在的条件下，则已微信订单号为准
                {
                    data.SetValue("transaction_id", request.PayPlatformTradeNo);
                }
                else//微信订单号不存在，才根据商户订单号去退款
                {
                    data.SetValue("out_trade_no", request.TradeNo);
                }

                data.SetValue("total_fee", request.TotalFee);//订单总金额
                data.SetValue("refund_fee", request.RefundFee);//退款金额
                data.SetValue("out_refund_no", request.RefundNo);//随机生成商户退款单号
                data.SetValue("op_user_id", request.UserId);//操作员，默认为商户号

                Config config = configBuilder.BuildWeixinConifg(request.MerchantId);
                WxPayApi wxPayApi = new WxPayApi(config);

                //先查询下退款状态，避免重复退款
                if (IsRefund(wxPayApi,request.RefundNo))
                {
                    logger.Warn("order already refunded.need sync order status.");
                    return responseData;
                }

                WxPayData result = wxPayApi.Refund(data);//提交退款申请给API，接收返回数据
                if (!result.IsSet("return_code") || result.GetValue("return_code").ToString() != "SUCCESS")
                {
                    responseData.ErrorNumber = 1;
                    responseData.ErrorMessage = result.GetValue("return_msg").ToString();
                    return responseData;
                }
                if (!result.IsSet("result_code") || result.GetValue("result_code").ToString() != "SUCCESS")
                {
                    responseData.ErrorNumber = 1;
                    responseData.ErrorMessage = result.GetValue("err_code_des").ToString();
                    return responseData;
                }
                logger.Info("Refund process complete, result : " + result.ToXml());
            }
            catch (Exception e)
            {
                responseData.ErrorNumber = 5;
                responseData.ErrorMessage = e.Message;
                responseData.Exception = e;
                logger.Warn(e, "order refund failure.");
            }

            return responseData;
        }

        protected string GetNotifyUrl(string notifyUrl, string orderType, string merchantId)
        {
            return $"{notifyUrl}/{orderType}/{merchantId}";
        }

        /// <summary>
        /// 查询订单是否已经退款。
        /// </summary>
        /// <param name="refundNo"></param>
        /// <returns></returns>
        private bool IsRefund(WxPayApi wxPayApi, string refundNo)
        {
            WxPayData data = new WxPayData();
            data.SetValue("out_refund_no", refundNo);//商户退款单号，优先级第二
            WxPayData result = wxPayApi.RefundQuery(data);//提交退款查询给API，接收返回数据
            if (result.GetValue("return_code").ToString() == "SUCCESS")
            {
                // result.GetValue("err_code")==REFUNDNOTEXIST 退款单不存在
                logger.Info("query refund process complete, result : " + result.ToXml());
                return result.GetValue("result_code").ToString() == "SUCCESS";
            }
            else
            {
                throw new WxPayException("查询订单退款通信错误");
            }
        }
    }
}
