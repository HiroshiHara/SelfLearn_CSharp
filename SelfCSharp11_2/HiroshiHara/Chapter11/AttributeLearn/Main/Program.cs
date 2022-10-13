using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfCSharp11_2.HiroshiHara.Chapter11.AttributeLearn.Main
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            NotUseThis();
        }

        // ★非推奨を示す属性(Obsolete)
        // [対象:属性(値,...)
        // 値には名前付き引数を利用可能
        // 対象は省略可(明示的に決まる場合は)
        // 明示的に決まらず、省略不可なのは以下
        // 1.assembly/module
        // AssemblyInfo.csに自動出力。\obj\Debug\net6.0に存在。\bin\Debug\net6.0\.exeのプロパティ詳細に反映。
        // 2.method/return
        // どの対象か判断が付かない場合に明示的に指定する
        [method:Obsolete(message:"非推奨です。")]
        public static void NotUseThis()
        {
            Console.WriteLine("NotUseThis");
        }
    }
}
