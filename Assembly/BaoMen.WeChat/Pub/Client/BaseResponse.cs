using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace BaoMen.WeChat.Pub.Client
{
    /// <summary>
    /// 公众号的响应基类
    /// </summary>
    [Serializable]
    [JsonObject(MemberSerialization.OptIn)]
    public abstract class BaseResponse
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
