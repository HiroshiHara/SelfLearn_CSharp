using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfCSharp8_2
{
    internal class EliteBusinessPerson : BusinessPerson
    {

        // : base(引数...)で親クラスのコンストラクタに引数を渡す
        public EliteBusinessPerson(string firstName, string lastName, int age) : base(firstName, lastName, age)
        {
            Console.WriteLine("EliteBusinessPersonクラスのコンストラクタ実行...");
        }

        // base.親メソッド名で基底クラスのメソッド呼び出し
        public new void Show()
        {
            base.Show();
            Console.WriteLine("かつ、それは迅速です。");
        }

        public override void HowOld()
        {
            base.HowOld();
            Console.WriteLine($"年齢は{this.Age}歳の優秀な労働者です。");
        }
    }
}
