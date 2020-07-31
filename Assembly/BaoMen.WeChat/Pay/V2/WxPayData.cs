using BaoMen.WeChat.Pay.Util;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace BaoMen.WeChat.Pay.V2
{
    /// <summary>
    /// 微信支付数据
    /// </summary>
    public abstract class WxPayData
    {
        /// <summary>
        /// 日志
        /// </summary>
        protected readonly Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// 所有参与签名的属性值的排序字典
        /// </summary>
        protected SortedDictionary<string, object> m_values = new SortedDictionary<string, object>();

        /// <summary>
        /// 签名
        /// </summary>
        /// <param name="signType">签名类型</param>
        /// <param name="key">密钥</param>
        /// <returns></returns>
        public string MakeSign(string signType, string key)
        {
            //转url格式
            string str = ToUrl();
            //在string后加入API KEY
            str += "&key=" + key;
            if (signType == Constant.SignType.MD5)
            {
                var md5 = MD5.Create();
                var bs = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
                var sb = new StringBuilder();
                foreach (byte b in bs)
                {
                    sb.Append(b.ToString("x2"));
                }
                //所有字符转为大写
                return sb.ToString().ToUpper();
            }
            else if (signType == Constant.SignType.HMACSHA256)
            {
                return CalcHMACSHA256Hash(str, key);
            }
            else
            {
                throw new WxPayException("sign_type 不合法");
            }
        }

        private string CalcHMACSHA256Hash(string plaintext, string salt)
        {
            string result = "";
            var enc = Encoding.Default;
            byte[]
            baText2BeHashed = enc.GetBytes(plaintext),
            baSalt = enc.GetBytes(salt);
            HMACSHA256 hasher = new HMACSHA256(baSalt);
            byte[] baHashedText = hasher.ComputeHash(baText2BeHashed);
            result = string.Join("", baHashedText.ToList().Select(b => b.ToString("x2")).ToArray());
            return result;
        }

        /// <summary>
        /// 转换为URL字符串
        /// </summary>
        /// <returns></returns>
        private string ToUrl()
        {
            string buff = "";
            foreach (KeyValuePair<string, object> pair in m_values)
            {
                if (pair.Value != null && pair.Value.ToString() != "")
                {
                    buff += pair.Key + "=" + pair.Value + "&";
                }
            }
            buff = buff.Trim('&');
            return buff;
        }
    }
}
