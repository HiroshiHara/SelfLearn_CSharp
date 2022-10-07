using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfCSharp8_2
{
    internal class Person
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public int Age { get; set; } = 0;

        public Person(string firstName, string lastName, int age)
        {
            Console.WriteLine("Personクラスのコンストラクタ実行...");
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        public void Show()
        {
            Console.WriteLine($"名前は{this.LastName}{this.LastName}です。");
        }
        
        // virtualでオーバーライド可能にする
        public virtual void HowOld()
        {
            Console.WriteLine($"年齢は{this.Age}歳です。");
        }
    }
}
