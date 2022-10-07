using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfCSharp8_3.Interface
{
    // インターフェース
    // アクセス修飾子はpublic , internal, partialのみ
    internal interface IRectangle
    {
        // 定義可能なメンバ
        // 自動的にpublic abstractとなる
        // static sealed, virtualは利用できない

        // プロパティ, インデクサー
        double Width { get; set; }
        double Height { get; set; }

        // メソッド
        double GetArea();

        // イベント(割愛)
    }
}
