using System;

namespace BaoMen.WeChat.MiniProgram.Client.Basic
{
    /// <summary>
    /// 获取小程序全局唯一后台接口调用凭据
    /// </summary>
    /// <remarks>
    /// grant_type	string		是	填写 client_credential
    /// appid string 是   小程序唯一凭证，即 AppID，可在「微信公众平台 - 设置 - 开发设置」页中获得。（需要已经成为开发者，且帐号没有异常状态）
    /// secret string 是   小程序唯一凭证密钥，即 AppSecret，获取方式同 appid
    /// </remarks>
    [Serializable]
    public class GetAccessTokenRequest : BaseAppRequest
    {
        /// <summary>
        /// grant_type string 是   授权类型，填写 client_credential
        /// </summary>
        public string GrantType { get; } = "client_credential";
    }
}
