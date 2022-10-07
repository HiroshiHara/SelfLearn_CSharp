using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SelfCSharp8_3.parent;

namespace SelfCSharp8_3
{
    internal class Square : Figure
    {
        public Square(double width, double height) : base(width, height) { }

        public override double GetArea()
        {
            return Width * Height;
        }
    }
}
