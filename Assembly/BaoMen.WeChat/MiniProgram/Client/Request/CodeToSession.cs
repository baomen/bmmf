using System;

namespace BaoMen.WeChat.MiniProgram.Client.Request
{
    /// <summary>
    /// 登录凭证校验
    /// </summary>
    [Serializable]
    public class CodeToSession
    {
        /// <summary>
        /// js_code	string		是	登录时获取的 code
        /// </summary>
        public string JsCode { get; set; }
    }
}
