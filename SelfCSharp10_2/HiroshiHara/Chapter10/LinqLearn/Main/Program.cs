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

            // ★where句
            // 部分一致検索=Contains
            // 前方一致=StartsWith, 後方一致=EndsWith
            var contains1 = from b in AppTables.Books
                            where b.Title.Contains("Android")
                            select b;
            contains1.ToList().ForEach(b => Console.Write($"{b} "));
            Console.WriteLine("\r\n---------------------------");

            var contains2 = AppTables.Books
                .Where(b => b.Title.Contains("Android"))
                .Select(b => b);
            contains2.ToList().ForEach(b => Console.Write($"{b} "));
            Console.WriteLine("\r\n---------------------------");

            // 候補値検索(IN句)
            var in1 = from b in AppTables.Books
                      where (new int[] { 3, 6 }.Contains(b.Published.Month))
                      select (b);
            in1.ToList().ForEach(b => Console.Write($"{b} "));
            Console.WriteLine("\r\n---------------------------");

            var in2 = AppTables.Books
                .Where(b => new int[] { 3, 6 }.Contains(b.Published.Month))
                .Select(b => b);
            in2.ToList().ForEach(b => Console.Write($"{b} "));
            Console.WriteLine("\r\n---------------------------");

            // スカラ副問い合わせ(Whereの代わりにシングル)
            // データ件数が2件以上の場合InvalidOperationException
            var scalarSub = AppTables.Books
                .Single(b => b.Isbn == "978-4-7981-6884-5");
            Console.WriteLine(scalarSub.ToString());
            Console.WriteLine("---------------------------");

            // ★order by句
            // 規定値=ascending=昇順
            // descending=降順
            var orderby1 = from b in AppTables.Books
                           orderby b.Published descending
                           select b;
            orderby1.ToList().ForEach(b => Console.WriteLine($"{b}"));
            Console.WriteLine("---------------------------");

            var orderby2 = AppTables.Books
                .OrderByDescending(b => b.Published)
                .Select(b => b);
            orderby2.ToList().ForEach(b => Console.WriteLine($"{b}"));
            Console.WriteLine("---------------------------");

            // ★select句
            // プロパティの加工/演算が可能
            var select1 = from b in AppTables.Books
                          select new
                          {
                              ShortTitle = b.Title.Substring(0, 5) + "...",
                              DiscountPrice = b.Price * 0.9,
                              isReleased = (b.Published <= DateTime.Now ? "発売中" : "発売予定")
                          };
            select1.ToList().ForEach(b => Console.WriteLine($"{b}"));
            Console.WriteLine("---------------------------");

            var select2 = AppTables.Books
                   .Select(b => new
                   {
                       ShortTitle = b.Title.Substring(0, 5) + "...",
                       DiscountPrice = b.Price * 0.9,
                       isReleased = (b.Published <= DateTime.Now ? "発売中" : "発売予定")
                   });
            select2.ToList().ForEach(b => Console.WriteLine($"{b}"));
            Console.WriteLine("---------------------------");

            // Distinct
            var distinct = AppTables.Books
                .Select(b => b.Publisher)
                .Distinct();
            distinct.ToList().ForEach(b => Console.WriteLine($"{b}"));
            Console.WriteLine("---------------------------");

            // group by
            // group句/GroupBy()の戻り値は
            // IEnumerable<IGrouping<K, S>>型
            // Kがグループ化に使用したキー
            // Sは集合
            var groupby1 = from b in AppTables.Books
                          group b by b.Publisher;
            groupby1.ToList().ForEach(g =>
            {
                Console.WriteLine($"[{g.Key}]");
                g.ToList().ForEach(b =>
                {
                    Console.WriteLine($"{b.Title}({b.Price})");
                });
            });
            Console.WriteLine("---------------------------");

            var groupby2 = AppTables.Books
                .Select(b => b)
                .GroupBy(b => b.Publisher);
            groupby2.ToList().ForEach(g =>
            {
                Console.WriteLine($"[{g.Key}]");
                g.ToList().ForEach(b =>
                {
                    Console.WriteLine($"{b.Title}({b.Price})");
                });
            });
            Console.WriteLine("---------------------------");

            // Join
            // 内部結合のみ
            // 外部結合は頑張る必要がある
            var join1 = from b in AppTables.Books
                        join r in AppTables.Reviews
                        on b.Isbn equals r.Isbn
                        select new
                        {
                            Title = b.Title,
                            Reviewer = r.Name,
                            Body = r.Body
                        };
            join1.ToList().ForEach(b => Console.WriteLine($"{b}"));
            Console.WriteLine("---------------------------");

            // IEnumerable<TResult> Join(TOuter, TInner, TKey, TResult>(
            //  IEnumerable<TInner> inner 結合する要素の型
            //  Func<TOuter, TKey> outerkey 結合キー1
            //  Func<TInner, TKey> innerkey 結合キー2
            //  Func<TOuter, TInner, TResult> result 結合結果
            var join2 = AppTables.Books.Join(
                AppTables.Reviews,
                b => b.Isbn,
                r => r.Isbn,
                (b, r) => new
                {
                    Title = b.Title,
                    Reviewer = r.Name,
                    Body = r.Body
                }
            );
            join2.ToList().ForEach(b => Console.WriteLine($"{b}"));
            Console.WriteLine("---------------------------");
        }
    }
}
