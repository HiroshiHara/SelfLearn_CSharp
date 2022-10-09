using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfCSharp9_3.HiroshiHara.Chapter9.StructLearn.Struct
{
    // readonly構造体
    // 全てのフィールドにreadonly属性を付与しなければならいあ
    readonly internal struct ReadOnlyCoordinates
    {
        // ★readonlyプロパティの皮例にGet-Onlyプロパティでも可
        public readonly double X;
        public readonly double Y;

        public ReadOnlyCoordinates(double x, double y)
        {
            X = x;
            Y = y;
        }


    }
}
