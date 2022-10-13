using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SelfCSharp11_1.HiroshiHara.Chapter11.ThreadLearn.Main
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //// ★クラシカルなスレッド処理
            //Thread t1 = new Thread(Count);
            //Thread t2 = new Thread(Count);
            //Thread t3 = new Thread(Count);

            //// スレッド開始
            //t1.Start(1);
            //t2.Start(2);
            //t3.Start(3);

            //// スレッド終了まで待機
            //t1.Join();
            //t2.Join();
            //t3.Join();
            //Console.WriteLine("全てのスレッドが終了。");

            // ★スレッドプールを使用する(タスク)
            // タスクを開始
            Task t1 = Task.Run(() => Count(1));
            Task t2 = Task.Run(() => Count(2));
            Task t3 = Task.Run(() => Count(3));
            // タスクの終了まで待機
            t1.Wait();
            t2.Wait();
            t3.Wait();
            Console.WriteLine("全てのタスクが終了。");

            Console.WriteLine("---------------------------");

            // ★排他制御を行う
            const int TaskNum = 50;
            var ts = new Task[TaskNum];
            var tb = new LockBasic();
            // タスクを起動
            for (int i = 0; i < TaskNum; i++)
            {
                ts[i] = Task.Run(() => tb.Increment());
            }
            // 各タスクの終了まで待機
            for (int i = 0; i < TaskNum; i++)
            {
                ts[i].Wait();
            }
            // 実行結果の表示
            Console.WriteLine(tb.Num);

            Console.WriteLine("---------------------------");

            // ★非同期処理を行う
            var asyncb = new AsyncBasic();
            Task async = asyncb.RunAsync();
            Console.WriteLine("---メインスレッドの処理---");
            async.Wait();

            Console.WriteLine("---------------------------");

            // ★非同期処理から値を返却する
            var asyncr = new AsyncReturn();
            Task<TimeSpan> async2 = asyncr.RunAsync();
            Console.WriteLine("---メインスレッドの処理---");
            // 非同期処理の終了待ち
            while (!async2.IsCompleted)
            {
                async2.Wait(200);
                Console.Write(".");
            }
            Console.WriteLine(async2.Result);

            Console.WriteLine("---------------------------");

            // ★非同期処理でインターネットのコンテンツを取得
            var asyncHttp = new AsyncHttp();
            Task asyncHttpResult = asyncHttp.GetHttpContentsAsync();
            Console.WriteLine("---メインスレッドの処理---");
            asyncHttpResult.Wait();

        }

        // クラシカルなスレッド処理(実処理)
        static void Count(object? n)
        {
            for (int i = 0; i < 50; i++)
            {
                Console.WriteLine($"Thread{n}: {i}");
            }
        }
    }
}
