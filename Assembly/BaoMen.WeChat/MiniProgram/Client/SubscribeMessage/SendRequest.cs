using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BaoMen.WeChat.MiniProgram.Client.SubscribeMessage
{
    /// <summary>
    /// 发送订阅消息请求数据
    /// </summary>
    public class SendRequest : BaseAccessTokenRequest
    //where T : class
    {
        /// <summary>
        /// 必填。接收者（用户）的 openid
        /// </summary>
        [JsonPropertyName("touser")]
        [JsonProperty(PropertyName = "touser")]
        public string ToUser { get; set; }

        /// <summary>
        /// 必填。所需下发的订阅模板id
        /// </summary>
        [JsonPropertyName("template_id")]
        [JsonProperty(PropertyName = "template_id")]
        public string TemplateId { get; set; }

        /// <summary>
        /// 不必填。点击模板卡片后的跳转页面，仅限本小程序内的页面。支持带参数,（示例index? foo = bar）。该字段不填则模板无跳转。
        /// </summary>
        [JsonPropertyName("page")]
        [JsonProperty(PropertyName = "page")]
        public string Page { get; set; }

        /// <summary>
        /// 模板内容，格式形如 { "key1": { "value": any}, "key2": { "value": any} }
        /// </summary>
        [JsonPropertyName("data")]
        [JsonProperty(PropertyName = "data")]
        public IDictionary<string, ValueProperty> Data { get; set; }
        //public T Data { get; set; }

        /// <summary>
        /// 不必填。跳转小程序类型：developer为开发版；trial为体验版；formal为正式版；默认为正式版
        /// </summary>
        [JsonPropertyName("miniprogram_state")]
        [JsonProperty(PropertyName = "miniprogram_state")]
        public string MiniProgramState { get; set; }

        /// <summary>
        /// 不必填。进入小程序查看”的语言类型，支持zh_CN(简体中文)、en_US(英文)、zh_HK(繁体中文)、zh_TW(繁体中文)，默认为zh_CN
        /// </summary>
        [JsonPropertyName("lang")]
        [JsonProperty(PropertyName = "lang")]
        public string Lang { get; set; }

        /// <summary>
        /// 数据的值
        /// </summary>
        public class ValueProperty
        {
            /// <summary>
            /// 默认构造函数
            /// </summary>
            public ValueProperty()
            {

            }

            /// <summary>
            /// 构造函数
            /// </summary>
            /// <param name="value">值</param>
            public ValueProperty(object value)
            {
                Value = value;
            }

            /// <summary>
            /// 值
            /// </summary>
            [JsonPropertyName("value")]
            [JsonProperty(PropertyName = "value")]
            public object Value { get; set; }
        }
    }
}
