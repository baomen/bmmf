using System;
using System.Collections.Generic;
using System.Text;

namespace BaoMen.WeChat.Pub.Client.Sns
{
    /// <summary>
    /// 获取用户的基本信息
    /// </summary>
    /// <remarks>
    ///参数	是否必须	说明
    ///access_token	 是	 调用接口凭证
    ///openid	 是	 普通用户的标识，对当前公众号唯一
    ///lang	 否	 返回国家地区语言版本，zh_CN 简体，zh_TW 繁体，en 英语
    /// </remarks>
    [Serializable]
    public class UserInfoRequest : BaseRequest
    {
        /// <summary>
        /// 普通用户的标识，对当前公众号唯一
        /// </summary>
        public string OpenId { get; set; }

        /// <summary>
        /// 国家地区语言版本，zh_CN 简体，zh_TW 繁体，en 英语
        /// </summary>
        public string Language { get; set; } = "zh_CN";

        /// <summary>
        /// access_token	是	调用接口凭证
        /// </summary>
        public string AccessToken { get; set; }
    }
}
