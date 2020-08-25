using BaoMen.WeChat.MiniProgram.Client.Request;
using System;

namespace BaoMen.WeChat.MiniProgram.Client.Sns
{
    /// <summary>
    /// 登录凭证校验
    /// </summary>
    /// <remarks>
    /// appid	string		是	小程序 appId
    /// secret string 是   小程序 appSecret
    /// js_code string 是   登录时获取的 code
    /// grant_type string 是   授权类型，此处只需填写 authorization_code
    /// </remarks>
    [Serializable]
    public class CodeToSessionRequest : BaseRequest
    {
        /// <summary>
        /// js_code	string		是	登录时获取的 code
        /// </summary>
        public string JsCode { get; set; }

        /// <summary>
        /// grant_type string 是   授权类型，此处只需填写 authorization_code
        /// </summary>
        public string GrantType { get; } = "authorization_code";
    }
}
