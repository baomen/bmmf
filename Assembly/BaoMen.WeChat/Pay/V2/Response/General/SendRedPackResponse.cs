namespace BaoMen.WeChat.Pay.V2.Response.General
{
    /// <summary>
    /// 发放红包响应数据
    /// </summary>
    public class SendRedPackResponse : BaseResponse
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="xml">XML</param>
        public SendRedPackResponse(string xml) : base(xml, checkSign: false)
        {

        }
    }
}
