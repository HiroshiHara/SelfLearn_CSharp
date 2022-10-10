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
            OutputProcess op1 = AddBracket;
            ArrayWalk(ary, op1);
            OutputProcess op2 = AddCanma;
            ArrayWalk(ary, op2);
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

        // OutputProcessに対応した処理
        static void AddBracket(string str)
        {
            Console.WriteLine($"[{str}]");
        }

        static void AddCanma(string str)
        {
            Console.WriteLine($"{str},");
        }
    }
}