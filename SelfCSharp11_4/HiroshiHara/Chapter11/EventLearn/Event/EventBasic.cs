using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfCSharp11_4.HiroshiHara.Chapter11.EventLearn.Event
{
    /// <summary>
    /// イベント受け取り側
    /// </summary>
    internal static class EventBasic
    {
        public static void OnKeyCommand(string data)
        {
            if (data.ToLower() == "c")
            {
                Console.WriteLine($"現在の日時は{DateTime.Now}です。");
            }
            else if (data.ToLower() == "x")
            {
                var r = new Random();
                Console.WriteLine($"乱数は{r.Next()}です。");
            }
            else if (data.ToLower() == "h")
            {
                Console.WriteLine("何も入力せずEnterで終了します。");
            }
            else
            {
                Console.WriteLine("認識できないコマンドです。");
            }
        }
    }
}
