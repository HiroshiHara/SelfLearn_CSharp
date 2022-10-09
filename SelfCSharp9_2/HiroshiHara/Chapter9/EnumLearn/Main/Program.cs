using SelfCSharp9_2.HiroshiHara.Chapter9.EnumLearn.Logic;

namespace SelfCSharp9_2.HiroshiHara.Chapter9.EnumLearn.Main
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            EnumLogic.ProcessSeason(Season.Spring);
            EnumLogic.ProcessProgramLang(ProgramLang.All);
            Console.WriteLine((int)ProgramLang.All); // 10

            Console.WriteLine("---------------------------");

            // 以下は同義
            Console.WriteLine(Season.Summer);
            Console.WriteLine(Season.Summer.ToString());

            Console.WriteLine("---------------------------");

            // Parse/TryParse
            Season str = (Season)Enum.Parse(typeof(Season), "Summer");
            Console.WriteLine($"{str}:{str.GetType()}");
            Season season = (Season)Enum.Parse(typeof(Season), "2");
            Console.WriteLine($"{season}:{season.GetType()}");
            bool isSeasonSummer = Enum.TryParse("Summer", out Season s);
            Console.WriteLine($"{isSeasonSummer}:{s}");

            Console.WriteLine("---------------------------");

            // 列挙型のメンバーを全て取得
            Array seasons = Enum.GetValues(typeof(Season));
            foreach (Season name in seasons) {
                Console.WriteLine($"{name}:{(int)name}");
            }

            Console.WriteLine("---------------------------");

            // ビットフィールド列挙型を利用
            FontStyle fStyle = FontStyle.Bold | FontStyle.Italic;
            if (fStyle.HasFlag(FontStyle.Bold))
            {
                Console.WriteLine("太字が指定されています。");
            }
        }
    }
}