using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfCSharp9_4.HiroshiHara.Chapter9.RecordTypeLearn.Record
{
    // ★レコード型
    // データの集合だけを扱うクラス
    // 1.既定でイミュータブル
    // 2.定型的なメンバーが自動生成
    // 3.メンバーの追加は自由
    internal record Person(string FirstName, string Lastname, int Age);
    // 名前の後ろにプロパティを列挙する(プライマリコンストラクタ)
    // 1.メンバ(get, initプロパティ)、及びコンストラクタを宣言したことと同義
    // (=プロパティは初期化以外のタイミングでは変更不可)
    
}
