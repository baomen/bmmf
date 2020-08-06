//using BaoMen.MultiMerchant.Merchant.BusinessLogic;
//using BaoMen.WeChat.Pay.V2.Request.General;
//using BaoMen.WeChat.Pay.V2.Response.General;
//using Microsoft.Extensions.DependencyInjection;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BaoMen.MultiMerchant.WeChat.Pay.Proxy
//{
//    /// <summary>
//    /// 普通商户代理
//    /// </summary>
//    public class GeneralProxy
//    {
//        private readonly IMerchantManager merchantManager;

//        public GeneralProxy(IServiceProvider serviceProvider)
//        {
//            merchantManager = serviceProvider.GetRequiredService<IMerchantManager>();
//        }

//        /// <summary>
//        /// 发放红包接口
//        /// </summary>
//        /// <param name="merchantId">商户ID</param>
//        /// <param name="openId">微信OpenId</param>
//        /// <param name="fee">红包金额</param>
//        /// <returns></returns>
//        public SendRedPackResponse SendRedPack(string merchantId, string openId, int fee)
//        {
//            Merchant.Entity.Merchant merchant = merchantManager.Get(merchantId);
//            SendRedPackRequest sendRedPackRequest = new SendRedPackRequest
//            {
//                ActName = "微信红包",
//                MchBillNo = "123",
//                ReOpenId = openId,
//                SendName= merchant.Name,
//                TotalAmount=fee,
//                TotalNum = 1,
//                Wishing

//            }
//        }
//    }
//}
