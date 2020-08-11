using System;
using System.Collections.Generic;
using System.Text;

namespace BaoMen.WeChat.Pub.Provider
{
    /// <summary>
    /// 基础处理程序
    /// </summary>
    public class BasicProvider : BaseProvider
    {
        /// <summary>
        /// 取得公众号的全局唯一票据
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// access_token是公众号的全局唯一票据，公众号调用各接口时都需使用access_token。正常情况下access_token有效期为7200秒，重复获取将导致上次获取的access_token失效。
        /// 公众号可以使用AppID和AppSecret调用本接口来获取access_token。AppID和AppSecret可在开发模式中获得（需要已经成为开发者，且帐号没有异常状态）。注意调用所有微信接口时均需使用https协议。
        /// </remarks>
        public Client.TokenResponse Token(Client.TokenRequest token)
        {
            return HttpGet<Client.TokenResponse>(
                $"https://{token.ApiDomain}/cgi-bin/token?grant_type=client_credential&appid={token.AppId}&secret={token.AppSecret}"
            );
        }

        #region 网页授权
        /// <summary>
        /// 取得网页授权的access_token
        /// </summary>
        /// <param name="accessTokenRequest">请求包</param>
        /// <returns></returns>
        /// <remarks>
        /// 首先请注意，这里通过code换取的网页授权access_token,与基础支持中的access_token不同。
        /// 公众号可通过下述接口来获取网页授权access_token。如果网页授权的作用域为snsapi_base，则本步骤中获取到网页授权access_token的同时，
        /// 也获取到了openid，snsapi_base式的网页授权流程即到此为止。
        /// 由于access_token拥有较短的有效期，当access_token超时后，可以使用refresh_token进行刷新，
        /// refresh_token拥有较长的有效期（7天、30天、60天、90天），当refresh_token失效的后，需要用户重新授权。
        /// </remarks>
        public Client.Sns.AccessTokenResponse AccessToken(Client.Sns.AccessTokenRequest accessTokenRequest)
        {
            return HttpGet<Client.Sns.AccessTokenResponse>(
                $"https://{accessTokenRequest.ApiDomain}/sns/oauth2/access_token?appid={accessTokenRequest.AppId}&secret={accessTokenRequest.AppSecret}&code={accessTokenRequest.Code}&grant_type=authorization_code"
            );
        }

        /// <summary>
        /// 刷新网页授权的access_token
        /// </summary>
        /// <param name="refreshTokenRequest">请求包</param>
        /// <returns></returns>
        /// <remarks>
        /// 由于access_token拥有较短的有效期，当access_token超时后，可以使用refresh_token进行刷新，
        /// refresh_token拥有较长的有效期（7天、30天、60天、90天），当refresh_token失效的后，需要用户重新授权。
        /// </remarks>
        public Client.Sns.RefreshTokenResponse RefreshToken(Client.Sns.RefreshTokenRequest refreshTokenRequest)
        {
            return HttpGet<Client.Sns.RefreshTokenResponse>(
                $"https://{refreshTokenRequest.ApiDomain}/sns/oauth2/refresh_token?appid={refreshTokenRequest.AppId}&grant_type=refresh_token&refresh_token={refreshTokenRequest.RefreshToken}"
            );
        }

        /// <summary>
        /// 拉取用户信息(需scope为 snsapi_userinfo)
        /// </summary>
        /// <param name="userInfoRequest">请求包</param>
        /// <returns></returns>
        /// <remarks>
        /// 如果网页授权作用域为snsapi_userinfo，则此时开发者可以通过access_token和openid拉取用户信息了。
        /// </remarks>
        public Client.Sns.UserInfoResponse UserInfo(Client.Sns.UserInfoRequest userInfoRequest)
        {
            return HttpGet<Client.Sns.UserInfoResponse>(
                $"https://{userInfoRequest.ApiDomain}/sns/userinfo?access_token={userInfoRequest.AccessToken}&openid={userInfoRequest.OpenId}&lang={userInfoRequest.Language}"
            );
        }

        ///// <summary>
        ///// 检验用户的授权凭证（access_token）是否有效
        ///// </summary>
        ///// <param name="userAccessToken">请求包</param>
        ///// <returns></returns>
        ///// <remarks>
        ///// </remarks>
        //public Client.CheckUserAccessToken CheckUserAccessToken(Client.CheckUserAccessToken userAccessToken)
        //{
        //    return HttpGet<Client.CheckUserAccessToken, Client.CheckUserAccessToken>(
        //        userAccessToken,
        //        "0402020405",
        //        (url) => { return string.Format(url, userAccessToken.AccessToken, userAccessToken.OpenId); }
        //    );
        //}
        #endregion

        ///// <summary>
        ///// 上传多媒体文件
        ///// </summary>
        ///// <param name="uploadMultimediaFile"></param>
        ///// <returns></returns>
        //public Client.UploadMultimediaFile UploadMultimediaFile(Client.UploadMultimediaFile uploadMultimediaFile)
        //{
        //    return HttpUploadFile(uploadMultimediaFile, "70020102");
        //}

        ///// <summary>
        ///// 请求获得jsapi_ticket
        ///// </summary>
        ///// <param name="jsTicket">请求包</param>
        ///// <returns></returns>
        ///// <remarks>
        ///// 生成签名之前必须先了解一下jsapi_ticket，jsapi_ticket是公众号用于调用微信JS接口的临时票据。正常情况下，jsapi_ticket的有效期为7200秒，通过access_token来获取。
        ///// 由于获取jsapi_ticket的api调用次数非常有限，频繁刷新jsapi_ticket会导致api调用受限，影响自身业务，开发者必须在自己的服务全局缓存jsapi_ticket 。
        ///// </remarks>
        //public Client.JsTicket QueryJsTicket(Client.JsTicket jsTicket)
        //{
        //    return HttpGet<Client.JsTicket, Client.JsTicket>(
        //        jsTicket,
        //        "0402020103",
        //        (url) => { return string.Format(url, jsTicket.AccessToken, jsTicket.Type); }
        //    );
        //}
    }
}
