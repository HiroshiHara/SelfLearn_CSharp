using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfCSharp11_1.HiroshiHara.Chapter11.ThreadLearn.Main
{
    internal class AsyncBasic
    {
        // ★async-await
        // 1.asyncで非同期であることを宣言
        // 2.戻り値がTask型とし、呼び出し元に非同期処理の状況を通知する
        // 3.非同期処理部分にawait演算子をつける
        // 例)RunAsync()が呼び出される > 呼び出し元スレッドに処理が返る > RunAsync()のawait部分終了時、
        // RunAsync()の残りの処理が実行
        public async Task RunAsync()
        {
            await Task.Run(() => Count(1));
            Console.WriteLine("非同期処理が終了しました。");
        }

        void Count(int n)
        {
            for (int i = 0; i < 50; i++)
            {
                Console.WriteLine($"Async Task{n}: {i}");
            }
        }
    }
}
