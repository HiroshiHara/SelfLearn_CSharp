namespace SelfCSharp4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // fizzbuzz
            for (int i = 0; i <= 100; i++)
            {
                if (i % 15 == 0)
                {
                    Console.WriteLine("FizzBuzz");
                }
                else if(i % 5 == 0)
                {
                    Console.WriteLine("Buzz");
                }
                else if (i % 3 == 0)
                {
                    Console.WriteLine("Fizz");
                }
                else
                {
                    Console.WriteLine(i);
                }
            }

            Console.WriteLine("----------------------------");

            // switch
            // case式には整数型, char/string型, 列挙型が指定可
            for (int i = 0; i <= 100; i++)
            {
                switch(i)
                {
                    case 10:
                        Console.WriteLine("i is 10");
                        break;
                    case 50:
                        Console.WriteLine("i is 50");
                        break;
                    case 100:
                        Console.WriteLine("i is 100");
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine("----------------------------");

            // case式による型判定
            // whenで条件指定可能
            string str1 = "aaaaaaaaaaaaaaaaaaaaa";
            switch(str1)
            {
                case string str when str.Length >= 10:
                    Console.WriteLine($"str1 is over 10 length string:{str}");
                    break;
                default:
                    break;
            }

            Console.WriteLine("----------------------------");

            // switch式
            // 式にマッチするパターンの戻り値を返却
            // breakは不要、defaultは_で表現
            string str2 = "abc";
            Console.WriteLine(str2 switch
            {
                string str when (str.Length >= 10) => $"str2 is over length string:{str}",
                _ => "str2 is not match."
            });

            Console.WriteLine("----------------------------");

            // Practice
            const int Score = 75;
            if (Score >= 90)
            {
                Console.WriteLine("優");
            }
            else if (Score >= 70)
            {
                Console.WriteLine("良");
            }
            else if (Score >= 50)
            {
                Console.WriteLine("可");
            }
            else
            {
                Console.WriteLine("不可");
            }

            Console.WriteLine("----------------------------");

            // foreach
            foreach (string str in args)
            {
                Console.WriteLine(str);
            }

            Console.WriteLine("----------------------------");

            // Practice
            for (int i = 1; i <= 9; i++)
            {
                for (int j = 1; j <= 9; j++)
                {
                    Console.Write(i * j);
                    Console.Write(" ");
                }
                Console.WriteLine("");
            }

            Console.WriteLine("----------------------------");

            // プリプロセッサディレクティブ
            // コンパイラへの命令・制御構文
            // ●#if シンボル名(DEBUGはデフォルトで定義)～#endif
            // →シンボルが定義済の場合コンパイル
            // ●#region～#endregion
            // →折り畳み可能にする
#region
#if DEBUG
            Console.WriteLine("デバッグ時のみ実行");
            Console.WriteLine("実行しない場合はソリューション構成をReleaseに変更");
#endif
#endregion
        }
    }
}
