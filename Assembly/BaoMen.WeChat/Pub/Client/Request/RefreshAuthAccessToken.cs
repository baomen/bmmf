﻿using System;

namespace BaoMen.WeChat.Pub.Client.Request
{
    /// <summary>
    /// 刷新用户的access_token
    /// </summary>
    [Serializable]
    public class RefreshAuthAccessToken
    {
        /// <summary>
        /// refresh_token	 是	 填写通过access_token获取到的refresh_token参数
        /// </summary>
        public string RefreshToken { get; set; }
    }
}
