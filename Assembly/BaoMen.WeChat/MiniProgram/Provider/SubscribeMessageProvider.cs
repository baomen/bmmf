using BaoMen.WeChat.MiniProgram.Client.SubscribeMessage;
using NLog;

namespace BaoMen.WeChat.MiniProgram.Provider
{
    /// <summary>
    /// 订阅消息处理程序
    /// </summary>
    public class SubscribeMessageProvider : BaseProvider
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public SubscribeMessageProvider()
        {
            logger = LogManager.GetCurrentClassLogger();
        }

        /// <summary>
        /// 获取小程序全局唯一后台接口调用凭据（access_token）。
        /// </summary>
        /// <returns></returns>
        public SendResponse Send(SendRequest request)
        {
            return HttpPost<SendRequest, SendResponse>(request, $"https://{request.ApiDomain}/cgi-bin/message/subscribe/send?access_token={request.AccessToken}");
        }
    }
}
