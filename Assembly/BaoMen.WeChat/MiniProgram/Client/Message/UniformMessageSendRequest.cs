using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoMen.WeChat.MiniProgram.Client.Message
{
    /// <summary>
    /// 发送统一服务消息请求数据
    /// </summary>
    /// <remarks>
    /// 属性 类型  默认值 必填  说明
    /// access_token / cloudbase_access_token string 是   接口调用凭证
    /// touser string 是   用户openid，可以是小程序的openid，也可以是mp_template_msg.appid对应的公众号的openid
    /// weapp_template_msg Object 否   小程序模板消息相关的信息，可以参考小程序模板消息接口; 有此节点则优先发送小程序模板消息；（小程序模板消息已下线，不用传此节点）
    /// mp_template_msg Object      是 公众号模板消息相关的信息，可以参考公众号模板消息接口；有此节点并且没有weapp_template_msg节点时，发送公众号模板消息
    /// </remarks>
    public class UniformMessageSendRequest : BaseAccessTokenRequest
    {
        /// <summary>
        /// 必填。用户openid，可以是小程序的openid，也可以是mp_template_msg.appid对应的公众号的openid
        /// </summary>
        public string ToUser { get; set; }

        /// <summary>
        /// 必填。公众号模板消息相关的信息，可以参考公众号模板消息接口；有此节点并且没有weapp_template_msg节点时，发送公众号模板消息
        /// </summary>
        public MpTemplateMessage MpTemplateMessage { get; set; }
    }

    /// <summary>
    /// 小程序模板消息相关的信息
    /// </summary>
    public class WeappTemplateMessage
    {
        /// <summary>
        /// 必填。小程序模板ID
        /// </summary>
        public string TemplateId { get; set; }

        /// <summary>
        /// 必填。小程序页面路径
        /// </summary>
        public string Page { get; set; }

        /// <summary>
        /// 必填。小程序模板消息formid
        /// </summary>
        public string FormId { get; set; }

        /// <summary>
        /// 必填。小程序模板数据
        /// </summary>
        public string Date { get; set; }

        /// <summary>
        /// 必填。小程序模板放大关键词
        /// </summary>
        public string EmphasisKeyword { get; set; }
    }

    /// <summary>
    /// 公众号模板消息相关的信息
    /// </summary>
    public class MpTemplateMessage
    {
        /// <summary>
        /// 必填。公众号appid，要求与小程序有绑定且同主体
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// 必填。公众号模板id
        /// </summary>
        public string TemplateId { get; set; }

        /// <summary>
        /// 必填。公众号模板消息所要跳转的url
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 必填。公众号模板消息所要跳转的小程序，小程序的必须与公众号具有绑定关系
        /// </summary>
        public string MiniProgram { get; set; }

        /// <summary>
        /// 必填。公众号模板消息的数
        /// </summary>
        public string Data { get; set; }
    }
}
