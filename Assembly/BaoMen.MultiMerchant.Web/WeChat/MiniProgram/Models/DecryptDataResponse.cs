using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaoMen.MultiMerchant.Web.WeChat.MiniProgram.Models
{
    /// <summary>
    /// 解密数据响应
    /// </summary>
    public class DecryptDataResponse : BaseResponse
    {
        /// <summary>
        /// 加密的数据
        /// </summary>
        public JObject DecryptedData { get; set; }
    }
}
