namespace BaoMen.WeChat.Pay.Util
{
    /// <summary>
    /// 费用帮助类
    /// </summary>
    public class FeeHelper
    {
        /// <summary>
        /// 元->分
        /// </summary>
        /// <param name="value">金额</param>
        /// <returns></returns>
        public static int YuanToFen(decimal value)
        {
            return (int)(value * 100);
        }

        /// <summary>
        /// 元->分
        /// </summary>
        /// <param name="value">金额</param>
        /// <returns></returns>
        public static int YuanToFen(string value)
        {
            decimal.TryParse(value, out decimal result);
            return YuanToFen(result);
        }

        /// <summary>
        /// 分->元
        /// </summary>
        /// <param name="value">金额</param>
        /// <returns></returns>
        public static decimal FenToYuan(int value)
        {
            return ((decimal)value) / 100;
        }

        /// <summary>
        /// 分->元
        /// </summary>
        /// <param name="value">金额</param>
        /// <returns></returns>
        public static decimal FenToYuan(string value)
        {
            int.TryParse(value, out int result);
            return FenToYuan(result);
        }

        /// <summary>
        /// 格式化元的价格为小数点后两位
        /// </summary>
        /// <param name="price"></param>
        /// <returns></returns>
        public static string FormatYuan(decimal price)
        {
            return price.ToString("F2");
        }

        /// <summary>
        /// 格式化分的价格为小数点后两位元的价格
        /// </summary>
        /// <param name="price"></param>
        /// <returns></returns>
        public static string FormatFenToYuan(int price)
        {
            decimal yuan = FenToYuan(price);
            return yuan.ToString("F2");
        }
    }
}
