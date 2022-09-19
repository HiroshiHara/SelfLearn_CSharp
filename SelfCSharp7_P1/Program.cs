using System;

namespace SelfCSharp7_P1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Circle c = new Circle(5.0);
            Console.WriteLine(c.GetArea());
        }
    }
}