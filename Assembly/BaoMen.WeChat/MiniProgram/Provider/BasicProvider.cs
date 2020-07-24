//namespace BaoMen.WeChat.MiniProgram.Provider
//{
//    /// <summary>
//    /// 基础处理程序
//    /// </summary>
//    public class BasicProvider : BaseProvider
//    {
//        /// <summary>
//        /// 构造函数
//        /// </summary>
//        /// <param name="config">微信公众号配置信息</param>
//        public BasicProvider(Config config)
//            : base(config)
//        {

//        }

//        /// <summary>
//        /// 获取小程序全局唯一后台接口调用凭据
//        /// </summary>
//        /// <returns></returns>
//        public Client.Response.QueryAccessToken QueryAccessToken()
//        {
//            return HttpGet<Client.Response.QueryAccessToken>(
//                $"https://{config.ApiDomain}/cgi-bin/token?grant_type=client_credential&appid={config.AppId}&secret={config.AppSecret}"
//            );
//        }

//        /// <summary>
//        /// 登录凭证校验
//        /// </summary>
//        /// <param name="codeToSession">请求包</param>
//        /// <returns></returns>
//        /// <remarks>
//        /// 通过 wx.login 接口获得临时登录凭证 code 后传到开发者服务器调用此接口完成登录流程。更多使用方法详见 小程序登录。
//        /// </remarks>
//        public Client.Response.CodeToSession CodeToSession(Client.Request.CodeToSession codeToSession)
//        {
//            return HttpGet< Client.Response.CodeToSession>(
//                $"https://{config.ApiDomain}/sns/jscode2session?appid={config.AppId}&secret={config.AppSecret}&js_code={codeToSession.JsCode}&grant_type=authorization_code"
//            );
//        }
//    }
//}
