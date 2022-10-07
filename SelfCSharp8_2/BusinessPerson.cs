using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfCSharp8_2
{
    internal class BusinessPerson : Person
    {
        // : base(引数...)で親クラスのコンストラクタに引数を渡す
        public BusinessPerson(string firstName, string lastName, int age) : base(firstName, lastName, age)
        {
            Console.WriteLine("BusinessPersonクラスのコンストラクタ実行...");
        }

        public void ShowWork()
        {
            Console.WriteLine($"{this.FirstName}{this.LastName}は働きます。");
        }

        // newキーワードで親クラスの同名メンバを隠蔽(≠オーバーライド)
        //隠蔽はほとんどすべてのメンバが可能
        // ポリモーフィズムが動作しないので原則使用しない
        public new void Show()
        {
            Console.WriteLine($"{this.FirstName}{this.LastName}は会社員です。");
        }

        // overrideキーワードでvirtualメソッドをオーバーライド
        // オーバーライド可能なのはメソッド、プロパティ、インデクサー、イベントのみ
        // abstract, static, private, override修飾子との併用不可
        public override void HowOld()
        {
            Console.WriteLine($"年齢は{this.Age}歳の労働者です。");
        }
    }
}
