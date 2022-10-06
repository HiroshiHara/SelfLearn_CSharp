using System;

namespace SelfCSharp8_1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // プロパティによるget, setの利用
            var twp = new TriangleWithProps(1.0, 2.0);
            // setterを糖衣構文で呼び出し
            twp.Width = 3.0;
            twp.Height = 5.6;
            Console.WriteLine(twp.GetArea());
            // getterを糖衣構文で呼び出し
            Console.WriteLine(twp.Width);
            Console.WriteLine(twp.Height);

            Console.WriteLine("---------------------------");

            // 自動プロパティによるget, setの利用
            // プロパティ自体はpublicなのでオブジェクト初期化子でアクセスできる
            var tap = new TriangleAutoProps
            {
                Width = 2.0,
                Height = 6.0,
                Pi = 3.0
            };
            Console.WriteLine(tap.GetArea());
            tap.Width = 2.4;
            tap.Height = 3.2;
            // Init-Onlyプロパティを初期化以外のタイミングで変更するとコンパイルエラー
            //tap.Pi = 3.2;
            Console.WriteLine(tap.Width);
            Console.WriteLine(tap.Height);

            Console.WriteLine("---------------------------");

            // インデクサーの利用
            var idxAry = new IndexerArray(5);
            Console.WriteLine(idxAry.Length);
            idxAry[0] = 0;
            idxAry[1] = 100;
            idxAry[2] = 200;
            idxAry[3] = 300;
            idxAry[4] = 400;
            idxAry[5] = 999;
            Console.WriteLine(idxAry[-1]);
            Console.WriteLine(idxAry[0]);
        }
    }
}