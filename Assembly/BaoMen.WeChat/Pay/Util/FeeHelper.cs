namespace BaoMen.WeChat.Pay.Util
{
    public class FeeHelper
    {
        public static int YuanToFen(decimal price)
        {
            return (int)(price * 100);
        }

        public static int YuanToFen(string price)
        {
            decimal.TryParse(price, out decimal result);
            return YuanToFen(result);
        }

        public static decimal FenToYuan(int price)
        {
            return ((decimal)price) / 100;
        }

        public static decimal FenToYuan(string price)
        {
            int.TryParse(price, out int result);
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
