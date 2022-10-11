using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SelfCSharp10_2.HiroshiHara.Chapter10.LinqLearn.Tables;
using SelfCSharp10_2.HiroshiHara.Chapter10.LinqLearn.Tables.Sub;

namespace SelfCSharp10_2.HiroshiHara.Chapter10.LinqLearn.Main
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // ★Streamなので遅延実行
            // クエリの結果が要求されたとき(≠クエリ宣言）結果が得られる。
            // すなわちクエリ宣言後にオブジェクトに変更が生じた場合は変更後の結果が得られる。
            // 即時実行したい場合、クエリに対してToArray()などの関数を実行する。

            // ★クエリ構文(メソッド構文のシンタックスシュガー)
            // from, where, selectの順で記載
            // ・from... エイリアス(in)が必須、in句に指定するものはIEnumerable/IEnumerable<T>インターフェースの実装ならなんでもOK
            var bookList1 = from b in AppTables.Books
                            where b.Price <= 3000
                            select b.Title;
            bookList1.ToList().ForEach(b => Console.Write($"{b} "));
            Console.WriteLine("\r\n---------------------------");

            // 複数のプロパティを取得
            // (select句にカンマ区切りではNG)
            var bookList2 = from b in AppTables.Books
                            where b.Publisher == "翔泳社"
                            select new { Title = b.Title, Price = b.Price };
            bookList2.ToList().ForEach(b => Console.Write($"{b} "));
            Console.WriteLine("\r\n---------------------------");

            // ★メソッド構文
            // From句に相当するオブジェクトに対し、ラムダ式をチェーンする
            // where句はPredicate(引数あり、真偽判定)
            // Select句はFunc(引数、戻り値あり)
            var bookList1_m = AppTables.Books
                .Where(b => b.Price <= 3000)
                .Select(b => b.Title);
            bookList1_m.ToList().ForEach(b => Console.Write($"{b} "));
            Console.WriteLine("\r\n---------------------------");

            var bookList2_m = AppTables.Books
                .Where(b => b.Publisher == "翔泳社")
                .Select(b => $"{b.Title}:{b.Price}");
            bookList2_m.ToList().ForEach(b => Console.Write($"{b} "));
            Console.WriteLine("\r\n---------------------------");
            
        }
    }
}
