using System;

namespace BaoMen.WeChat.Pub.Client.Request
{
    /// <summary>
    /// 获取网页授权的access_token
    /// </summary>
    [Serializable]
    public class QueryAuthAccessToken : QueryAccessToken
    {
        /// <summary>
        /// code	 是	 填写第一步获取的code参数
        /// </summary>
        public string Code { get; set; }
    }
}
