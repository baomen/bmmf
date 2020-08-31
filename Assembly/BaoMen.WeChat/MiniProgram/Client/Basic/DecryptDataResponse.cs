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
    public class DecryptDataResponse : BaseResponse
    {
        /// <summary>
        /// 加密的数据
        /// </summary>
        [JsonProperty("decryptedData")]
        public JObject DecryptedData { get; set; }
    }
}
