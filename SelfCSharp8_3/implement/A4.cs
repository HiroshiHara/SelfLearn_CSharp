using SelfCSharp8_3.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfCSharp8_3.implement
{
    internal class A4 : IRectangle
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public A4()
        {
            Width = 595;
            Height = 842;
        }
        
        public double GetArea()
        {
            return Width * Height;
        }
    }
}
