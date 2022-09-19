using System;
using System.Collections.Generic;

namespace SelfCSharp6_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // コレクション

            // List
            // ArrayListは非推奨
            Console.WriteLine("-*List-*-*-*-*-*-*-*-*-*-*-*");
            // 値の読み書き：高速
            // 値の追加/削除：先頭に近いほど低速
            List<string> strList = new List<string>()
            {
                "aaa", "bbb", "ccc", "ddd", "eee"
            };
            int[] intAry = { 1, 2, 3, 5, 4 };
            List<int> intList = new List<int>(intAry);

            PrintList("要素の抜き出し", strList.GetRange(0, 2));
            Console.WriteLine($"格納可能な要素数:{strList.Capacity}");
            Console.WriteLine($"現在の要素数:{strList.Count}");
            strList.Insert(strList.Count, "fff");
            PrintList("要素の追加", strList);
            strList.Add("ggg");
            PrintList("末尾に要素の追加", strList);
            strList.Remove("eee");
            PrintList("最初にマッチした要素を削除", strList);
            Console.WriteLine($"要素を含むか判定:{strList.Contains("aaa")}");

            // LinkedList
            Console.WriteLine("-*LinkedList-*-*-*-*-*-*-*-*-*-*-*");
            // 値の読み書き：中心ほど遅く、先頭または末尾からたどる為インデックスアクセス不可
            // 値の追加/削除：高速

            // Stack
            Console.WriteLine("-*Stack-*-*-*-*-*-*-*-*-*-*-*");
            Stack<int> intStack = new Stack<int>();
            intStack.Push(10);
            intStack.Push(30);
            intStack.Push(40);
            intStack.Push(20);
            intStack.Push(50);
            PrintList("スタック要素", intStack);
            Console.WriteLine($"スタック要素数:{intStack.Count}");
            Console.WriteLine($"要素を含むか判定:{intStack.Contains(60)}");
            Console.WriteLine($"スタックから取得(削除はしない):{intStack.Peek()}");
            Console.WriteLine($"スタックから取得して削除:{intStack.Pop()}");
            Console.WriteLine($"スタックから取得して削除:{intStack.Pop()}");
            PrintList("スタック要素", intStack);

            // Queue
            Console.WriteLine("-*Queue-*-*-*-*-*-*-*-*-*-*-*");
            Queue<int> intQueue = new Queue<int>();
            intQueue.Enqueue(10);
            intQueue.Enqueue(20);
            intQueue.Enqueue(40);
            intQueue.Enqueue(30);
            intQueue.Enqueue(50);
            PrintList("キュー要素", intQueue);
            Console.WriteLine($"キュー要素数:{intQueue.Count}");
            Console.WriteLine($"要素を含むか判定:{intQueue.Contains(60)}");
            Console.WriteLine($"キューから取得(削除はしない):{intQueue.Peek()}");
            Console.WriteLine($"キューから取得して削除:{intQueue.Dequeue()}");
            Console.WriteLine($"キューから取得して削除:{intQueue.Dequeue()}");
            PrintList("キュー要素", intQueue);

            // HashSet
            // 順番を持たないリスト, 数学の集合のイメージ
            // 値の重複は出来ない
            Console.WriteLine("-*HashSet-*-*-*-*-*-*-*-*-*-*-*");
            HashSet<string> hashSet = new HashSet<string>()
            {
                "aaa", "bbb", "ccc", "ddd", "eee"
            };
            HashSet<string> subHashSet = new HashSet<string>()
            {
                "ccc", "ddd"
            };
            PrintList("ハッシュセット要素", hashSet);
            hashSet.Add("fff");
            hashSet.Add("aaa"); // 重複した要素を入れると無視
            hashSet.Remove("aaa");
            Console.WriteLine($"ハッシュセット要素数:{hashSet.Count}");
            Console.WriteLine($"要素を含むか判定:{hashSet.Contains("bbb")}");
            Console.WriteLine($"集合を含むか判定(完全一致はfalse):{hashSet.IsProperSupersetOf(subHashSet)}");
            Console.WriteLine($"集合に含まれるか判定(完全一致はfalse):{subHashSet.IsProperSubsetOf(hashSet)}");
            Console.WriteLine($"集合を含むか判定(完全一致はtrue):{hashSet.IsSupersetOf(subHashSet)}");
            Console.WriteLine($"集合に含まれるか判定(完全一致はtrue):{subHashSet.IsSubsetOf(hashSet)}");

            hashSet.ExceptWith(subHashSet); // 差集合を取得
            PrintList("差集合を取得", hashSet);
            hashSet.UnionWith(subHashSet); // 和集合を取得
            PrintList("和集合を取得", hashSet);
            hashSet.IntersectWith(subHashSet); // 積集合を取得
            PrintList("積集合を取得", hashSet);

            // SortedSet
            // 順番を持つHashSet
            // 比較基準のカスタム, Max, Minプロパティを持つ
            // それ以外はHashSetと同等
            Console.WriteLine("-*SortedSet-*-*-*-*-*-*-*-*-*-*-*");
            SortedSet<string> sortedSet = new SortedSet<string>(hashSet);
            Console.WriteLine(sortedSet.Max);
            Console.WriteLine(sortedSet.Min);

            // ディクショナリ
            // Hashtableは非推奨
            // 自作クラスをディクショナリに追加する場合は
            // GetHashCodeの適切なオーバーライドする
            // 1)同値のオブジェクトは同じハッシュ値を返す
            // 2)ハッシュの重複が出ないようハッシュ値が適切に分布する
            // 2...ハッシュ値が重複すると内部的にリンクで保持するため検索のレスポンスが低下する
            // 3)ディクショナリの宣言は可能であればサイズを初期化する
            // 3...サイズ超過時のメモリ再割り当てにオーバーヘッドがあるため
            Console.WriteLine("-*Dictionary-*-*-*-*-*-*-*-*-*-*-*");
            Dictionary<string, string> dic = new Dictionary<string, string>(10)
            {
                ["userid"] = "hrhrs403",
                ["username"] = "原拓史",
                ["age"] = "31"
            };
            Console.WriteLine($"ディクショナリ要素数:{dic.Count}");
            Console.WriteLine($"キー有無の判定:{dic.ContainsKey("age")}");
            Console.WriteLine($"値有無の判定:{dic.ContainsKey("mrbob403")}");
            dic.TryGetValue("address", out var address);
            Console.WriteLine($"キーから値の取得:{address}");
            // 値の追加
            // Addメソッドでは重複するキー指定時ArgumentException
            // ブラケット構文では上書き
            dic.Add("address", "P県C市");
            dic.Add("job", "Programmer");
            //dic["job"] = "Programmer";
            Console.Write("キーの列挙:");
            foreach (string key in dic.Keys)
            {
                Console.Write($"{key} ");
            }
            Console.WriteLine();
            Console.Write("値の列挙:");
            foreach (string value in dic.Values)
            {
                Console.Write($"{value} ");
            }
            Console.WriteLine();
            Console.Write("キーと値の列挙(KeyValuePair型):");
            foreach (KeyValuePair<string, string> pair in dic)
            {
                Console.Write($"{pair.Key},{pair.Value} ");
            }
            Console.WriteLine();

            // ソート済みディクショナリ
            // 並び順を赤黒木構造で管理
            // 比較機をIComparerインタフェースの実装でカスタマイズ可能
            Console.WriteLine("-*SortedDictionary-*-*-*-*-*-*-*-*-*-*-*");
            SortedDictionary<string, string> sDic1 = new SortedDictionary<string, string>(
                dic, 
                new StringLengthComparer()
            );
            Console.Write("キーの列挙:");
            foreach (string key in sDic1.Keys)
            {
                Console.Write($"{key} ");
            }
            Console.WriteLine();
            
        }

        static void PrintList<T>(string preMsg, List<T> list)
        {
            Console.Write($"{preMsg}:");
            foreach(T t in list)
            {
                Console.Write($"{t} ");
            }
            Console.WriteLine();
        }

        static void PrintList<T>(string preMsg, Stack<T> stack)
        {
            Console.Write($"{preMsg}:");
            foreach (T t in stack)
            {
                Console.Write($"{t} ");
            }
            Console.WriteLine();
        }

        static void PrintList<T>(string preMsg, Queue<T> queue)
        {
            Console.Write($"{preMsg}:");
            foreach (T t in queue)
            {
                Console.Write($"{t} ");
            }
            Console.WriteLine();
        }

        static void PrintList<T>(string preMsg, HashSet<T> hashSet)
        {
            Console.Write($"{preMsg}:");
            foreach (T t in hashSet)
            {
                Console.Write($"{t} ");
            }
            Console.WriteLine();
        }
    }

    internal class StringLengthComparer : IComparer<string>
    {
        public int Compare(string? x, string? y)
        {
            // 比較結果で0をreturnするとキーの重複とみなされ
            // ArgumentExceptionを引き起こすので、
            // 実際はもっと厳密に判定する
            // (長さが同じなら自然言語順とか)
            int result = x.Length - y.Length;
            if (result != 0)
            {
                return result;
            } 
            else
            {
                return 1;
            }
        }
    }
}