using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaoMen.Amap.Open.WebService.Client.Request
{
    /// <summary>
    /// 客户端请求基类
    /// </summary>
    [Serializable]
    [JsonObject(MemberSerialization.OptIn)]
    public class BaseRequest
    {
        /// <summary>
        /// 生成URL格式的参数
        /// </summary>
        /// <returns></returns>
        public string ToUrl()
        {
            JObject obj = JObject.FromObject(this);
            StringBuilder stringBuilder = new StringBuilder();
            string[] url = obj.Properties().Where(p => p.Value != null && !string.IsNullOrEmpty(p.Value.ToString())).Select(p => $"{p.Name}={p.Value}").ToArray();
            return string.Join('&', url);
        }
    }
}
