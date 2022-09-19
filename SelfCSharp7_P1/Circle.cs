using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfCSharp7_P1
{
    internal class Circle
    {
        private double _radius;
        public Circle(double radius)
        {
            this._radius = radius;
        }
        public Circle() : this(1) { }
        public double GetArea()
        {
            return _radius * _radius * Math.PI;
        }
    }
}
