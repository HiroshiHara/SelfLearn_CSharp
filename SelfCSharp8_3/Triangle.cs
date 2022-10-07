using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfCSharp8_3
{
    internal class Triangle : Figure
    {
        public Triangle(double width, double height) : base(width, height) { }

        public override double GetArea()
        {
            return Width * Height / 2;
        }
    }
}
