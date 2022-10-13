using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SelfCSharp11_4.HiroshiHara.Chapter11.EventLearn.Event;

namespace SelfCSharp11_4.HiroshiHara.Chapter11.EventLearn.Main
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            MyEvent ev = new MyEvent();
            ev.KeyCommand += EventBasic.OnKeyCommand;
            ev.Run();
        }
    }
}
