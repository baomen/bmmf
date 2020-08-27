using BaoMen.WeChat.Util;
using Newtonsoft.Json;
using System;

namespace BaoMen.WeChat.MiniProgram.Client
{
    /// <summary>
    /// 公众号的全局唯一票据
    /// </summary>
    [Serializable]
    [JsonObject(MemberSerialization.OptIn)]
    public class BaseResponse
    {
        /// <summary>
        ///  errcode	 错误代码
        /// </summary>
        [JsonProperty("errcode")]
        public int ErrorCode { get; set; }

        /// <summary>
        /// errmsg	 错误信息
        /// </summary>
        [JsonProperty("errmsg")]
        public string ErrorMessage { get; set; }

        /// <summary>
        /// 元数据
        /// </summary>
        public Metadata Metadata { get; set; }

        ///// <summary>
        ///// 反序列化事件
        ///// </summary>
        ///// <param name="context"></param>
        //[OnDeserialized]
        //internal void OnDeserializedMethod(StreamingContext context)
        //{
        //    if (string.IsNullOrEmpty(ErrorCode))
        //        ErrorCode = "0";
        //}
    }
}
