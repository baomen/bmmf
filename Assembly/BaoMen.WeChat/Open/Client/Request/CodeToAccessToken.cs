using System;

namespace BaoMen.WeChat.Open.Client.Request
{
    /// <summary>
    /// 通过code获取access_token
    /// </summary>
    [Serializable]
    public class CodeToAccessToken
    {
        /// <summary>
        /// code	 是	 填写第一步获取的code参数
        /// </summary>
        public string Code { get; set; }
    }
}
