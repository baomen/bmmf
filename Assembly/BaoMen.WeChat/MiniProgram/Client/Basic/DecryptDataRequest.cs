using System;
using System.Collections.Generic;
using System.Text;

namespace BaoMen.WeChat.MiniProgram.Client.Basic
{
    /// <summary>
    /// 解密数据请求
    /// </summary>
    public class DecryptDataRequest
    {
        /// <summary>
        /// 小程序的AppId
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// 加密的数据
        /// </summary>
        public string EncryptedData { get; set; }

        /// <summary>
        /// 会话密钥
        /// </summary>
        public string SessionKey { get; set; }

        /// <summary>
        /// 向量
        /// </summary>
        public string IV { get; set; }
    }
}
