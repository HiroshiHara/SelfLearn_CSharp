using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfCSharp9_3.HiroshiHara.Chapter9.StructLearn.Struct
{
    // readonly専用の関数メンバー
    // クラスでは、インスタンスをreadonlyのフィールドに設定しても、
    // そのインスタンス配下のメンバまではreadonlyにならないという仕様だが、
    // 構造体では、インスタンスをreadonlyのフィールドに設定すると、
    // そのインスタンス配下のメンバもreadonlyになる
    internal struct MutableValue
    {
        public string Name { get; set; }
        public MutableValue()
        {
            this.Name = "名無しの権兵衛";
        }
        public void Update(string name)
        {
            this.Name = name;
            Console.WriteLine("Update method is finished!");
        }
    }
}
