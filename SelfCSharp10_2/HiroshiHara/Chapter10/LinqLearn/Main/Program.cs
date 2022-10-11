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
            // ★クエリ構文
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



        }
    }
}
