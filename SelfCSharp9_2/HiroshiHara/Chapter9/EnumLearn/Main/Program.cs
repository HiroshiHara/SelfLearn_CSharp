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
        }
    }
}