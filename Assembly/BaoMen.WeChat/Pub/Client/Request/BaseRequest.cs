using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace BaoMen.WeChat.Pub.Client.Request
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
