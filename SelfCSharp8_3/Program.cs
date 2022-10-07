// 拡張メソッド使用にはそのメソッドの名前空間を指定する必要あり
// この例は同じnamespaceに存在するので指定不要

using SelfCSharp8_3.parent;
using SelfCSharp8_3.sub;

namespace SelfCSharp8_3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string repeat = "repeat";
            Console.WriteLine(repeat.Repeat(20));

            Console.WriteLine("---------------------------");

            // ポリモーフィズム
            // メソッドの振る舞いは型でなくオブジェクトによって決定される
            // 機能を差し替えるときは型を変更する必要は無く、インスタンスの差し替えで済む
            Figure t = new Triangle(2, 20);
            Console.WriteLine(t.GetArea());
            Figure s = new Square(39, 2);
            Console.WriteLine(s.GetArea());
        }
    }
}