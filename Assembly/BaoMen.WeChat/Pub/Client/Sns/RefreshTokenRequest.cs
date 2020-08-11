using System;

namespace BaoMen.WeChat.Pub.Client.Sns
{
    /// <summary>
    /// 刷新用户的access_token
    /// </summary>
    [Serializable]
    public class RefreshTokenRequest : BaseRequest
    {
        /// <summary>
        /// 第三方用户唯一凭证
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// refresh_token	 是	 填写通过access_token获取到的refresh_token参数
        /// </summary>
        public string RefreshToken { get; set; }
    }
}
