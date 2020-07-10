using System;
using System.Collections.Generic;
using System.Text;

namespace BaoMen.WeChat.Open.Provider
{
    /// <summary>
    /// 基础处理程序
    /// </summary>
    public class BasicProvider : BaseProvider
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="config">微信公众号配置信息</param>
        public BasicProvider(Config config)
            : base(config)
        {

        }

        /// <summary>
        /// 通过code获取access_token
        /// </summary>
        /// <param name="codeToAccessToken">请求包</param>
        /// <returns></returns>
        public Client.Response.CodeToAccessToken CodeToAccessToken(Client.Request.CodeToAccessToken codeToAccessToken)
        {
            return HttpGet< Client.Response.CodeToAccessToken>(
                $"https://{config.ApiDomain}/sns/oauth2/access_token?appid={config.AppId}&secret={config.AppSecret}&code={codeToAccessToken.Code}&grant_type=authorization_code"
            );
        }

        /// <summary>
        /// 刷新access_token有效期
        /// </summary>
        /// <param name="refreshAccessToken">请求包</param>
        /// <returns></returns>
        /// <remarks>
        /// access_token是调用授权关系接口的调用凭证，由于access_token有效期（目前为2个小时）较短，当access_token超时后，可以使用refresh_token进行刷新
        /// efresh_token拥有较长的有效期（30天），当refresh_token失效的后，需要用户重新授权。
        /// </remarks>
        public Client.Response.RefreshAccessToken RefreshAccessToken(Client.Request.RefreshAccessToken refreshAccessToken)
        {
            return HttpGet<Client.Response.RefreshAccessToken>(
                $"https://{config.ApiDomain}/sns/oauth2/refresh_token?appid={config.AppId}&grant_type=refresh_token&refresh_token={refreshAccessToken.RefreshToken}"
            );
        }

        /// <summary>
        /// 获取用户个人信息（UnionID机制）
        /// </summary>
        /// <param name="queryUserInfo">请求包</param>
        /// <returns></returns>
        public Client.Response.QueryUserInfo QueryUserInfo(Client.Request.QueryUserInfo queryUserInfo)
        {
            return HttpGet<Client.Response.QueryUserInfo>(
                $"https://{config.ApiDomain}sns/auth?access_token={queryUserInfo.AccessToken}&openid={queryUserInfo.OpenId}"
            );
        }
    }
}
