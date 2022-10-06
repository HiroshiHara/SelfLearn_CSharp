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
        }
    }
}