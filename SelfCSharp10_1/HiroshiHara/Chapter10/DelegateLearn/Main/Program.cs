using SelfCSharp10_1.HiroshiHara.Chapter10.DelegateLearn.Delegate;

namespace SelfCSharp10_1.HiroshiHara.Chapter10.DelegateLearn.Main
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Process p = new Process(Run);
            // Process p = Runでも可
            p("Runメソッド");
            string[] ary = { "aaa", "bbb", "ccc" };
            OutputProcess? op1 = AddBracket;
            ArrayWalk(ary, op1);
            OutputProcess? op2 = AddCanma;
            ArrayWalk(ary, op2);

            Console.WriteLine("---------------------------");

            // マルチキャストデリゲート
            // +=演算子で同時に複数の処理をデリゲートに渡す
            op1 += op2;
            ArrayWalk(ary, op1);
            // -=演算子で登録済みの処理を解除することも可能
            op1 -= op2;
            ArrayWalk(ary, op1!);

            Console.WriteLine("---------------------------");

            // 戻り値のあるメソッドをマルチキャストデリゲートに渡した場合、
            // 最後に実行したメソッドの結果が優先される
            GetOutputProcess gop = GetWithBracket;
            gop += GetWithCanma;
            Console.WriteLine(ArrayWalk(ary, gop));

            Console.WriteLine("---------------------------");

            // 匿名メソッドを使用してデリゲートに渡すメソッド(=使い捨て)をその場で宣言できる
            ArrayWalkAnonymous(ary, delegate (string s)
            {
                return $"[{s}]";
            });

            Console.WriteLine("---------------------------");

            // ラムダ式を利用して匿名メソッドを置き換え
            ArrayWalkAnonymous(ary, (string s) =>
            {
                return $"[{s}]";
            });
            // 処理が1文のみならブロック省略可、return命令省略可
            ArrayWalkAnonymous(ary, (string s) => $"[{s}]");
            // 引数の方は暗黙的に推論されるので基本的に省略、引数が1つならカッコも省略
            ArrayWalkAnonymous(ary, s => $"[{s}]");

            Console.WriteLine("---------------------------");

            // 外部変数のキャプチャ
            // ラムダ式で外部の変数(下記例では引数)を参照すると、
            // ラムダ式が破棄されるまでその値を維持する
            Action show = CreateAction(10);
            show(); // 11
            show(); // 12

            Console.WriteLine("---------------------------");

            // ラムダ式を伴うListクラスのメソッド
            // void ForEach(Action<T> action)
            var list = new List<int>() { 1, 4, 5, 3, 2, 6, 2, 1 };
            list.ForEach(v => Console.Write($"{v * v},"));
            Console.Write("\r\n");
            Console.WriteLine("---------------------------");

            // List<TOputput> ConvertAll<TOutput>(Converter<T, TOutput> converter)
            var strList = new List<string>() { "aaa", "bbb", "ccc" };
            strList = strList.ConvertAll(str => str.ToUpper());
            strList.ForEach(str => Console.Write($"{str},"));
            Console.Write("\r\n");
            Console.WriteLine("---------------------------");

            // T? Find(Predicate<T> match)
            var findResult = strList.Find(str => str.Equals("aaa"));
            Console.WriteLine(findResult);

        }

        public static void Run(string s)
        {
            Console.WriteLine($"{s}を実行");
        }

        // 第二引数にデリゲートを受け取る(具体的な処理内容を受け取る)
        // 「配列を走査する」部分だけを定義して、走査で何をするかを移譲(delegate)する
        public static void ArrayWalk(string[] ary, OutputProcess process)
        {
            foreach (var val in ary)
            {
                // デリゲートの実行
                process(val);
            }
        }

        public static string ArrayWalk(string[] ary, GetOutputProcess process)
        {
            var result = "";
            foreach (var val in ary)
            {
                // デリゲートの実行
                result += process(val);
            }
            return result;
        }

        // 匿名メソッド用
        // ★標準ライブラリで頻繁に使用するデリゲートは用意されている
        // 下記例ではFunc<in T, out TResult>(T arg)を使用(引数Tを1つ、戻り値がT型)
        public static void ArrayWalkAnonymous(string[] ary, Func<string, string> process)
        {
            foreach (var val in ary)
            {
                Console.WriteLine(process(val));
            }
        }

        // ラムダ式を返却するメソッド
        public static Action CreateAction(int init)
        {
            int val = init;
            return () =>
            {
                val++;
                Console.WriteLine(val);
            };
        }

        // OutputProcessに対応した処理
        static void AddBracket(string str)
        {
            Console.WriteLine($"[{str}]");
        }

        static void AddCanma(string str)
        {
            Console.WriteLine($"{str},");
        }

        // GetOutputProcessに対応した処理
        static string GetWithBracket(string str)
        {
            return $"[{str}]";
        }

        static string GetWithCanma(string str)
        {
            return $"{str},";
        }
    }
}