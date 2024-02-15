namespace FuckUGenshin.Tools
{
    internal class BVtoAV
    {
        /// <summary>
        /// 抄的
        /// 来自：https://blog.csdn.net/tong2108/article/details/105116325
        /// （煞笔睿站真滞涨，现在av号的接口还能用）
        /// </summary>
        private static readonly string table = "fZodR9XQDSUm21yCkr6zBqiveYah8bt4xsWpHnJE7jL5VG3guMTKNPAwcF";
        private static readonly Dictionary<string, long> b2aDic = new();
        private static readonly Dictionary<long, string> a2bDic = new();
        private static readonly int[] ss = { 11, 10, 3, 8, 4, 6, 2, 9, 5, 7 };
        private static readonly long xor = 177451812;
        private static readonly long add = 8728348608L;

        /// <summary>
        /// 泡我（依赖性）
        /// </summary>
        /// <param name="a">英文字母的第一个字母</param>
        /// <param name="b">英文字母的第二个字幕</param>
        /// <returns>想要的结果（废话）</returns>
        public static long Power(int a, int b)
        {
            long power = 1;
            for (int i = 0; i < b; i++)
            {
                power *= a;
            }
            return power;
        }
        /// <summary>
        /// BV号转av号
        /// </summary>
        /// <param name="str">带有BV前缀的编号</param>
        /// <returns>带有小写av前缀的编号</returns>
        public static string BV2AV(string str)
        {
            try
            {
                str = str.Trim();
                b2aDic.Clear();
                long r = 0;
                for (int i = 0; i < 58; i++)
                {
                    string s1 = table.Substring(i, 1);
                    b2aDic.Add(s1, i);
                }
                for (int i = 0; i < 6; i++)
                {
                    r += b2aDic[str.Substring(ss[i], 1)] * Power(58, i);
                }
                return "av" + ((r - add) ^ xor);
            }
            catch (Exception)
            {
                //MessageBox.Show(e.ToString());
                return "Error";
                throw;
            }
        }
    }
}
