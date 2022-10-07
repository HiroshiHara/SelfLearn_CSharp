// 拡張メソッド使用にはそのメソッドの名前空間を指定する必要あり
// この例は同じnamespaceに存在するので指定不要

namespace SelfCSharp8_3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string repeat = "repeat";
            Console.WriteLine(repeat.Repeat(20));
        }
    }
}