using System;
using System.Collections.Generic;
using System.Text;

namespace BaoMen.WeChat.Util
{
    /// <summary>
    /// 元数据
    /// </summary>
    public class Metadata
    {
        /// <summary>
        /// 调用时间
        /// </summary>
        public DateTime CallTime { get; set; }

        /// <summary>
        /// 时长
        /// </summary>
        public TimeSpan Elapsed { get; set; }

        /// <summary>
        /// 原始返回数据
        /// </summary>
        public string RowResponse { get; set; }

        /// <summary>
        /// 原始请求数据
        /// </summary>
        public string RowRequest { get; set; }
    }
}
