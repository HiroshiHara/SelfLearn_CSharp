using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfCSharp8_1
{
    internal class Triangle
    {
        private double width;
        private double height;

        // getter, setter
        public double GetWidth()
        {
            return this.width;
        }

        public double GetHeight()
        {
            return this.height;
        }

        public void SetWidth(double width)
        {
            if (width <= 0)
            {
                throw new ArgumentException("正数を指定してください。");
            }
            this.width = width;
        }

        public void SetHeight(double height)
        {
            if (height <= 0)
            {
                throw new ArgumentException("正数を指定してください。");
            }
            this.height = height;
        }
    }
}
