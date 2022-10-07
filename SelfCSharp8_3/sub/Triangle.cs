using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SelfCSharp8_3.parent;

namespace SelfCSharp8_3.sub
{
    internal class Triangle : Figure
    {
        public Triangle(double width, double height) : base(width, height) { }

        // 抽象メソッドのオーバーライドにもoverrideキーワードが必要
        // (抽象メソッド側にはvirtualキーワードはない)
        public override double GetArea()
        {
            return Width * Height / 2;
        }
    }
}
