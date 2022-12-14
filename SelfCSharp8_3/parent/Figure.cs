using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfCSharp8_3.parent
{
    // abstract... 抽象クラス
    internal abstract class Figure
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public Figure(double width, double height)
        {
            Width = width;
            Height = height;
        }

        // 面積を求めるメソッド
        // abstract... 抽象メソッド
        public abstract double GetArea();
    }
}
