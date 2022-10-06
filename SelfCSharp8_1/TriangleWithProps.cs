using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfCSharp8_1
{
    internal class TriangleWithProps
    {
        private double _width;
        private double _height;

        public TriangleWithProps(double width, double height)
        {
            this._width = width;
            this._height = height;
        }

        public double GetArea()
        {
            return Width * Height / 2;
        }

        // プロパティ定義
        // setブロックが無いプロパティは実質読み取り専用(immutable)になる
        // set, get単位でアクセス修飾子の付与も可能。
        // ただし、プロパティ自身のアクセス権限未満になるようにする
        // ex.プロパティがpublicなら、protected internal, protected, internal, 
        // private protected, privateのいずれか
        public double Width
        {
            internal set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("正数を指定してください。");
                }
                this._width = value;
            }
            get
            {
                return this._width;
            }
        }

        public double Height
        {
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("正数を指定してください。");
                }
                this._height = value;
            }
            get
            {
                return this._height;
            }
        }
    }
}
