using System;

namespace SelfCSharp8_2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Person p = new Person("山田", "太郎", 22);
            p.Show();
            p.HowOld(); // virtualはそのまま呼び出せる

            Console.WriteLine("---------------------------");

            BusinessPerson bp = new BusinessPerson("佐藤", "和仁", 32);
            bp.Show();
            bp.ShowWork();
            bp.HowOld();

            Console.WriteLine("---------------------------");

            EliteBusinessPerson ebp = new EliteBusinessPerson("鈴木", "良治", 38);
            ebp.FirstName = "鈴木";
            ebp.LastName = "良治";
            ebp.Show();
            ebp.HowOld();

        }
    }
}