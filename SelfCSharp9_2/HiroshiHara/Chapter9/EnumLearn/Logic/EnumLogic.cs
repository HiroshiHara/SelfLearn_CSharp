using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfCSharp9_2.HiroshiHara.Chapter9.EnumLearn.Logic
{
    internal static class EnumLogic
    {
        public static void ProcessSeason(Season season)
        {
            Console.WriteLine(season.ToString());
        }

        public static void ProcessProgramLang(ProgramLang plang)
        {
            Console.WriteLine(plang.ToString());
        }
    }
}
