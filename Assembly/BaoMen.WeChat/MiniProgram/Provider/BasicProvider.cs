using NLog;

namespace BaoMen.WeChat.MiniProgram.Provider
{
    /// <summary>
    /// 基础处理程序
    /// </summary>
    public class BasicProvider : BaseProvider
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public BasicProvider()
        {
            logger = LogManager.GetCurrentClassLogger();
        }

        ///// <summary>
        ///// 获取小程序全局唯一后台接口调用凭据
        ///// </summary>
        ///// <returns></returns>
        //public Client.Response.QueryAccessToken QueryAccessToken()
        //{
        //    return HttpGet<Client.Response.QueryAccessToken>(
        //        $"https://{config.ApiDomain}/cgi-bin/token?grant_type=client_credential&appid={config.AppId}&secret={config.AppSecret}"
        //    );
        //}

        /// <summary>
        /// 登录凭证校验
        /// </summary>
        /// <param name="codeToSessionRequest">请求包</param>
        /// <returns></returns>
        /// <remarks>
        /// 通过 wx.login 接口获得临时登录凭证 code 后传到开发者服务器调用此接口完成登录流程。更多使用方法详见 小程序登录。
        /// </remarks>
        public Client.Sns.CodeToSessionResponse CodeToSession(Client.Sns.CodeToSessionRequest codeToSessionRequest)
        {
            return HttpGet<Client.Sns.CodeToSessionResponse>(
                $"https://{codeToSessionRequest.ApiDomain}/sns/jscode2session?appid={codeToSessionRequest.AppId}&secret={codeToSessionRequest.AppSecret}&js_code={codeToSessionRequest.JsCode}&grant_type={codeToSessionRequest.GrantType}"
            );
        }
    }
}
