﻿using BaoMen.WeChat.MiniProgram.Client.Basic;
using NLog;

namespace BaoMen.WeChat.MiniProgram.Provider
{
    /// <summary>
    /// 基础处理程序
    /// </summary>
    public class BasicProvider : BaseProvider
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public BasicProvider()
        {
            logger = LogManager.GetCurrentClassLogger();
        }

        /// <summary>
        /// 获取小程序全局唯一后台接口调用凭据（access_token）。
        /// </summary>
        /// <remarks>
        /// 调用绝大多数后台接口时都需使用 access_token，开发者需要进行妥善保存。
        /// </remarks>
        /// <returns></returns>
        public GetAccessTokenResponse GetAccessToken(GetAccessTokenRequest request)
        {
            return HttpGet<GetAccessTokenResponse>(
                $"https://{request.ApiDomain}/cgi-bin/token?grant_type={request.GrantType}&appid={request.AppId}&secret={request.AppSecret}"
            );
        }

        /// <summary>
        /// 登录凭证校验
        /// </summary>
        /// <param name="request">请求包</param>
        /// <returns></returns>
        /// <remarks>
        /// 通过 wx.login 接口获得临时登录凭证 code 后传到开发者服务器调用此接口完成登录流程。更多使用方法详见 小程序登录。
        /// </remarks>
        public CodeToSessionResponse CodeToSession(CodeToSessionRequest request)
        {
            return HttpGet<CodeToSessionResponse>(
                $"https://{request.ApiDomain}/sns/jscode2session?appid={request.AppId}&secret={request.AppSecret}&js_code={request.JsCode}&grant_type={request.GrantType}"
            );
        }

        /// <summary>
        /// 用户支付完成后，获取该用户的 UnionId，无需用户授权。本接口支持第三方平台代理查询。
        /// </summary>
        /// <param name="request">请求包</param>
        /// <returns></returns>
        /// <remarks>
        /// 注意：调用前需要用户完成支付，且在支付后的五分钟内有效。
        /// </remarks>
        public GetPaidUnionIdReponse GetPaidUnionId(GetPaidUnionIdRequest request)
        {
            string url = $"https://{request.ApiDomain}/wxa/getpaidunionid?access_token={request.AccessToken}&openid={request.OpenId}";
            if (!string.IsNullOrEmpty(request.TransactionId)) url += $"&transaction_id={request.TransactionId}";
            if (!string.IsNullOrEmpty(request.MchId)) url += $"&mch_id={request.MchId}";
            if (!string.IsNullOrEmpty(request.OutTradeNo)) url += $"&out_trade_no={request.OutTradeNo}";
            return HttpGet<GetPaidUnionIdReponse>(
                //$"https://{request.ApiDomain}/wxa/getpaidunionid?access_token={request.AccessToken}&openid={request.OpenId}&transaction_id={request.TransactionId}&mch_id={request.MchId}&out_trade_no={request.OutTradeNo}"
                url
            );
        }
    }
}
