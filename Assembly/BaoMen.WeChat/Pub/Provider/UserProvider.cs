using System;
using System.Collections.Generic;
using System.Text;

namespace BaoMen.WeChat.Pub.Provider
{
    /// <summary>
    /// 用户处理程序
    /// </summary>
    public class UserProvider : BaseProvider
    {
        /// <summary>
        /// 获取用户基本信息
        /// </summary>
        /// <param name="request">请求实例</param>
        /// <returns></returns>
        public Client.Response.QueryUserInfo QueryUserInfo(Client.Request.QueryUserInfo queryUserInfo)
        {
            return HttpGet<Client.Response.QueryUserInfo>(
                $"https://{queryUserInfo.ApiDomain}/cgi-bin/user/info?access_token={queryUserInfo.AccessToken}&openid={queryUserInfo.OpenId}&lang={queryUserInfo.Language}"
            );
        }
    }
}
