using Newtonsoft.Json;
using System;

namespace BaoMen.WeChat.MiniProgram.Client.Request
{
    /// <summary>
    /// 客户端请求基类
    /// </summary>
    [Serializable]
    [JsonObject(MemberSerialization.OptIn)]
    public class BaseRequest
    {
        /// <summary>
        ///  公众号的全局唯一票据
        /// </summary>
        public string AccessToken { get; set; }
    }
}
