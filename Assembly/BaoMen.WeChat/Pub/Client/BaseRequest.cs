﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace BaoMen.WeChat.Pub.Client
{
    /// <summary>
    /// 客户端请求基类
    /// </summary>
    [Serializable]
    [JsonObject(MemberSerialization.OptIn)]
    public abstract class BaseRequest
    {
        /// <summary>
        /// 接口域名
        /// </summary>
        public string ApiDomain { get; set; }
    }
}