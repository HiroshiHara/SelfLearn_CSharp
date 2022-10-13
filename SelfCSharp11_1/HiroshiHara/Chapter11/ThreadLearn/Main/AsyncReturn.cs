using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfCSharp11_1.HiroshiHara.Chapter11.ThreadLearn.Main
{
    // 値を返す非同期処理
    internal class AsyncReturn
    {
        // 戻り値がTask<T>となる
        public async Task<TimeSpan> RunAsync()
        {
            var watch = Stopwatch.StartNew();
            await Task.Run(() =>
            {
                Thread.Sleep(5000);
            });
            watch.Stop();
            return watch.Elapsed;
        }
    }
}
