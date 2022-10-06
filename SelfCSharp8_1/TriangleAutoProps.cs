using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfCSharp8_1
{
    internal class TriangleAutoProps
    {
        // 自動プロパティ
        // プロパティ名 {get; set;} = 初期値
        // 内部的に__width, __heightが生成され、糖衣構文経由でget/setを行
        // 通常のプロパティと同様の規則でアクセス修飾子が付与可能
        // get;のみ(Get-Only自動プロパティ)として宣言し、readonlyにすることが可能
        public double Width { get; set; } = 0;
        public double Height { get; set; } = 0;
        // set;の代わりにinit;を使用(Init-Onlyプロパティ)することができる
        // オブジェクト初期化のタイミングでのみセット可能という意味
        public double Pi { get; init; } = 3.14;

        public double GetArea()
        {
            // __width, __heightはコンパイラが便宜上用意する変数の為クラス内部からも直接アクセスできない
            return Width * Height / 2;
        }
    }
}
