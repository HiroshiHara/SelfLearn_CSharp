using SelfCSharp10_2.HiroshiHara.Chapter10.LinqLearn.Tables.Sub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfCSharp10_2.HiroshiHara.Chapter10.LinqLearn.Tables
{
    /// <summary>
    /// アプリケーションで使用するテーブルを保持するクラス<br>
    /// 静的クラス(インスタンスの生成ができない)
    /// </summary>
    internal static class AppTables
    {
        /// <summary>
        /// 全ての書籍情報を保持するプロパティ
        /// </summary>
        public static IEnumerable<Book> Books { get; private set; }

        /// <summary>
        /// 全てのレビュー情報を保持するプロパティ
        /// </summary>
        public static IEnumerable<Review> Reviews { get; private set; }

        /// <summary>
        /// 静的コンストラクタ(クラスロード時にのみ実行)
        /// </summary>
        static AppTables()
        {
            Books = new List<Book> {
                new Book {
                    Isbn = "978-4-7981-6849-4",
                    Title = "独習PHP",
                    Price = 3740,
                    Publisher = "翔泳社",
                    Published = new DateTime(2021,6,14)
                },
                new Book {
                    Isbn = "978-4-7981-6884-5",
                    Title = "独習Ruby",
                    Price = 3520,
                    Publisher = "翔泳社",
                    Published = new DateTime(2021,9,13)
                },
                new Book {
                    Isbn = "978-4-2960-8009-0",
                    Title = "Androidアプリ超入門",
                    Price = 2200,
                    Publisher = "日経BP",
                    Published = new DateTime(2021,11,11)
                },
                new Book {
                    Isbn = "978-4-2960-8014-4",
                    Title = "基礎からしっかり学ぶC#の教科書",
                    Price = 3190,
                    Publisher = "日経BP",
                    Published = new DateTime(2022,3,3)
                },
                new Book {
                    Isbn = "978-4-7980-6510-6",
                    Title = "はじめてのAndroidアプリ開発",
                    Price = 3520,
                    Publisher = "秀和システム",
                    Published = new DateTime(2021,11,30)
                }
            };

            Reviews = new List<Review> {
                new Review {
                    Isbn = "978-4-7981-6849-4",
                    Name = "山田太郎",
                    Body = "PHP開発に役立っています。"
                },
                new Review {
                    Isbn = "978-4-7981-6849-4",
                    Name = "鈴木花子",
                    Body = "急に仕事で扱うことになり、慌てて読み始めたら、分かりやすくて良かったです。"
                },
                new Review {
                    Isbn = "978-4-7981-6884-5",
                    Name = "山田太郎",
                    Body = "あやふやだったデータの操作が、この本でスッキリ分かるようになった。"
                },
                new Review {
                    Isbn = "978-4-7981-6884-5",
                    Name = "佐藤久美",
                    Body = "サンプルが作りたいものとマッチしていて、とても参考になりました。"
                },
                new Review {
                    Isbn = "978-4-7981-6884-5",
                    Name = "加藤次郎",
                    Body = "コンパクトにきちんと情報がまとまっていて、とても読みやすいと思う。"
                }
            };
        }
    }
}
