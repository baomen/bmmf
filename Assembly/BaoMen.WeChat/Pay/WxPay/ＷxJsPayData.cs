using Newtonsoft.Json;
using System;

namespace BaoMen.WeChat.Pay.WxPay
{
    [Serializable]
    [JsonObject(MemberSerialization.OptIn)]
    public class WxJsPayData
    {
        /// <summary>
        /// 公众号名称
        /// </summary>
        [JsonProperty("appId")]
        public string AppId { get; set; }

        /// <summary>
        /// 时间戳，自1970年以来的秒数   
        /// </summary>
        [JsonProperty("timeStamp")]
        public string Timestamp { get; set; }

        /// <summary>
        /// 随机串
        /// </summary>
        [JsonProperty("nonceStr")]
        public string Nonce { get; set; }

        /// <summary>
        /// prepay_id=u802345jgfjsdfgsdg888
        /// </summary>
        [JsonProperty("package")]
        public string Package { get; set; }

        /// <summary>
        /// 微信签名方式
        /// </summary>
        [JsonProperty("signType")]
        public string SignType { get; set; }

        /// <summary>
        /// 微信签名
        /// </summary>
        [JsonProperty("paySign")]
        public string PaySign { get; set; }
    }
}
