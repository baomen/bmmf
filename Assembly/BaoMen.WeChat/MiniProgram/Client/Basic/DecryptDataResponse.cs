using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaoMen.WeChat.MiniProgram.Client.Basic
{
    /// <summary>
    /// 解密数据响应
    /// </summary>
    /// <typeparam name="T">解密后数据的类型</typeparam>
    public class DecryptDataResponse<T> : BaseResponse
        where T : IDecryptedData
    {
        /// <summary>
        /// 加密的数据
        /// </summary>
        [JsonProperty("decryptedData")]
        public T DecryptedData { get; set; }
    }

    /// <summary>
    /// 解密数据接口
    /// </summary>
    public interface IDecryptedData
    {
        /// <summary>
        /// 水印数据
        /// </summary>
        public Watermark Watermark { get; }
    }

    /// <summary>
    /// 水印
    /// </summary>
    [Serializable]
    [JsonObject(MemberSerialization.OptIn)]
    public class Watermark
    {
        /// <summary>
        /// 小程序的AppId
        /// </summary>
        [JsonProperty("appid")]
        public string AppId { get; set; }

        /// <summary>
        /// 时间戳
        /// </summary>
        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }
    }

    /// <summary>
    /// 获取手机号码的解密后的数据
    /// </summary>
    /// <remarks>
    /// phoneNumber	String	用户绑定的手机号（国外手机号会有区号）
    /// purePhoneNumber String  没有区号的手机号
    /// countryCode String 区号
    /// </remarks>
    [Serializable]
    [JsonObject(MemberSerialization.OptIn)]
    public class PhoneNumberInfo : IDecryptedData
    {
        /// <summary>
        /// 用户绑定的手机号（国外手机号会有区号）
        /// </summary>
        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// 没有区号的手机号
        /// </summary>
        [JsonProperty("purePhoneNumber")]
        public string PurePhoneNumber { get; set; }

        /// <summary>
        /// 区号
        /// </summary>
        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }

        /// <summary>
        /// 水印
        /// </summary>
        [JsonProperty("watermark")]
        public Watermark Watermark { get; set; }
    }
}
