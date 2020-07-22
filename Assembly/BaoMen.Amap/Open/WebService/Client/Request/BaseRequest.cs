using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace BaoMen.Amap.Open.WebService.Client.Request
{
    /// <summary>
    /// 客户端请求基类
    /// </summary>
    [Serializable]
    //[JsonObject(MemberSerialization.OptIn)]
    public abstract class BaseRequest
    {
        /// <summary>
        /// 所有参与签名的属性值的排序字典
        /// </summary>
        protected readonly SortedDictionary<string, object> values = new SortedDictionary<string, object>();

        /// <summary>
        /// APP密钥
        /// </summary>
        public string Key
        {
            get
            {
                return values.ContainsKey("key") ? (string)values["key"] : null;
            }
            set
            {
                values["key"] = value;
            }
        }

        /// <summary>
        /// 转换为URL字符串
        /// </summary>
        /// <returns></returns>
        public string ToUrl(string signKey = null)
        {
            return string.IsNullOrEmpty(signKey) ? ToUrlWithoutSign() : ToUrlWithSign(signKey);
        }

        /// <summary>
        /// 生成无签名的URL
        /// </summary>
        /// <returns></returns>
        private string ToUrlWithoutSign()
        {
            string buff = "";
            foreach (KeyValuePair<string, object> pair in values)
            {
                if (pair.Value.ToString() != "")
                {
                    buff += pair.Key + "=" + pair.Value + "&";
                }
            }
            buff = buff.Trim('&');
            return buff;
        }

        /// <summary>
        /// 生成带签名的URL
        /// </summary>
        /// <param name="signKey">密钥</param>
        /// <returns></returns>
        private string ToUrlWithSign(string signKey)
        {
            //转url格式
            string url = ToUrlWithoutSign();
            //在string后加入API KEY
            string signUrl = url + signKey;
            //MD5加密
            var md5 = MD5.Create();
            var bs = md5.ComputeHash(Encoding.UTF8.GetBytes(signUrl));
            var sb = new StringBuilder();
            foreach (byte b in bs)
            {
                sb.Append(b.ToString("x2"));
            }
            string sign = sb.ToString();
            return url + $"&sig={sign}";
        }

        ///// <summary>
        ///// 生成URL格式的参数
        ///// </summary>
        ///// <returns></returns>
        //public string ToUrl()
        //{
        //    JObject obj = JObject.FromObject(this);
        //    StringBuilder stringBuilder = new StringBuilder();
        //    string[] url = obj.Properties().Where(p => p.Value != null && !string.IsNullOrEmpty(p.Value.ToString())).Select(p => $"{p.Name}={p.Value}").ToArray();
        //    return string.Join('&', url);
        //}
    }
}
