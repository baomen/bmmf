using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace BaoMen.WeChat.Open.Client.Request
{
    /// <summary>
    /// 获取用户个人信息（UnionID机制）
    /// </summary>
    [Serializable]
    public class QueryUserInfo : BaseRequest
    {
        /// <summary>
        /// 普通用户的标识，对当前公众号唯一
        /// </summary>
        public string OpenId { get; set; }
    }
}
