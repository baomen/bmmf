using Newtonsoft.Json;
using System;

namespace BaoMen.WeChat.MiniProgram.Client
{
    /// <summary>
    /// 客户端请求基类
    /// </summary>
    [Serializable]
    [JsonObject(MemberSerialization.OptIn)]
    public class BaseRequest
    {
        /// <summary>
        /// 接口域名
        /// </summary>
        public string ApiDomain { get; set; }

    }

    /// <summary>
    /// 带AppId及Secret的请求
    /// </summary>
    public class BaseAppRequest : BaseRequest
    {
        /// <summary>
        /// 小程序的AppId
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// 小程序的开发者密码
        /// </summary>
        public string AppSecret { get; set; }

    }

    /// <summary>
    /// 带AccessToken的请求
    /// </summary>
    public class BaseAccessTokenRequest : BaseRequest
    {
        /// <summary>
        /// 接口调用凭证
        /// </summary>
        public string AccessToken { get; set; }

    }
}
