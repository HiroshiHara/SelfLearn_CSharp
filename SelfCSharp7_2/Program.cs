using System;
using System.Collections;

namespace SelfCSharp7_2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int data = 1;
            int[] numAry = { 1, 2, 3, 4, 5 };
            var p = new PassBasic();

            // 値型の値渡し
            // 実引数(呼び出し元の値)をメソッド側の仮引数にコピーすること
            Console.WriteLine(p.CountUp(data)); // 2
            Console.WriteLine(data); // 1

            // 参照型の値渡し
            // 参照型は値を格納したメモリ上のアドレスを格納しているため、
            // メソッド側で参照型を操作すると実引数に影響を及ぼす
            Console.WriteLine(p.UpdateAry(numAry, 0, 999)[0]); // 999
            Console.WriteLine(numAry[0]); // 999

            // 値型の参照渡し
            // メソッド側の仮引数及び実行時にrefキーワードをつけることで
            // 値型の実引数を参照渡しの時と同様のふるまいにさせる
            // なおrefキーワードをつける引数は初期化が必須
            Console.WriteLine(p.RefCountUp(ref data)); // 2
            Console.WriteLine(data); // 2

            // 参照型の参照渡し
            // メソッド側の仮引数及び実行時にrefキーワードをつけることで
            // 参照型の実引数を参照渡しの時と同様のふるまいにさせる
            // (＝メソッド側で仮引数の値そのものを差し替えたとき、実引数に影響を及ぼす)
            Console.WriteLine(p.RefUpdateAry(ref numAry, new int[] { 10, 20, 30 })[0]); // 10
            Console.WriteLine(numAry[0]); // 10

            // 戻り値の参照渡し
            // 値型の実引数を操作するメソッドの戻り値を参照渡しすることで、戻り値を受け取った変数に変更を加えると
            // 実引数側に影響を及ぼす
            // 受け取り時、メソッド実行時にrefキーワードをつける
            // なおローカル変数は戻り値の参照渡しができない
            ref int refNum = ref p.ReturnRef(numAry);
            refNum = 888;
            Console.WriteLine(refNum); // 888
            Console.WriteLine(numAry[0]); // 888

            // 出力引数(outキーワード)
            // 仮引数にoutを指定することで、実引数の値をメソッドの中で書き換える
            // (＝メソッドから複数の戻り値を返すことができる)
            int resultMax, resultMin;
            p.GetMaxMin(100, 80, out resultMax, out resultMin);
            Console.WriteLine(resultMax); // 100
            Console.WriteLine(resultMin); // 80
            // 以下のようにoutキーワードをつける変数を仮引数宣言時に省略可能
            //p.GetMaxMin(100, 80, out int resultMax, out int resultMin);

            // タプル
            // メソッドから複数の値の組を返却する仕組み
            // 戻り値型, 戻り値を(type value, type2 value2...)と記載する
            // 引数の型や変数宣言、タプルのネストも可能
            var t = new TupleBasic();
            (int max, int min) maxmin = t.GetMaxMin(132, 272);
            Console.WriteLine(maxmin.max); // 272
            Console.WriteLine(maxmin.min); // 132

            // 匿名型
            // 読み取り専用のキーと値の組
            var info = new { Title = "独習C#", Price = "3500", Unit = "Yen" };
            Console.WriteLine(info.Title);

            // イテレータ
            var it = new IteratorBasic();
            foreach (var str in it.GetStrings())
            {
                Console.WriteLine(str);
            }

            var primes = new PrimeNumber();
            foreach (var num in primes.GetPrimes(100))
            {
                Console.WriteLine(num);
            }

            var enumPrimes = new EnumerablePrimeNumber(100);
            // IEnumerable<T>の実装クラスの場合、インスタンス自身が反復可能
            foreach (var num in enumPrimes)
            {
                Console.WriteLine(num);
            }
        }
    }

    class PassBasic
    {
        public int CountUp(int data)
        {
            data++;
            return data;
        }

        public int RefCountUp(ref int data)
        {
            data++;
            return data;
        }

        public int[] UpdateAry(int[] data, int idx, int newVal)
        {
            data[idx] = newVal;
            return data;
        }

        public int[] RefUpdateAry(ref int[] data, int[] newData)
        {
            data = newData;
            return data;
        }

        public ref int ReturnRef(int[] data)
        {
            return ref data[0];
        }

        public void GetMaxMin(int x, int y, out int max, out int min)
        {
            if (x >= y)
            {
                max = x;
                min = y;
            }
            else
            {
                max = y;
                min = x;
            }
        }
    }

    class TupleBasic
    {
        public (int max, int min) GetMaxMin(int x, int y)
        {
            return x >= y ? (x, y) : (y, x);
        }

        public (double addtion, double subtraction) AddSubtract(double x, double y)
        {
            return (x + y, x - y);
        }
    }

    class IteratorBasic
    {
        // イテレータ
        // yieldキーワードで実行のたびに異なる結果を返すことができる
        // 戻り値の型はIEnumerator<T> または IEnumerable<T>である
        // 通常はこれらを実装したクラスであるべきだが、yield return命令を使うことで
        // 必要な機能が内部的に自動生成される
        public IEnumerable<string> GetStrings()
        {
            yield return "あいうえお";
            yield return "かきくけこ";
            yield return "さしすせそ";
        }
    }

    class PrimeNumber
    {
        /// <summary>
        /// max以下の素数を返却する
        /// </summary>
        /// <param name="max">最大値</param>
        /// <returns></returns>
        public IEnumerable<int> GetPrimes(int max)
        {
            // ローカル関数
            // valueが素数かどうかを判定
            bool IsPrime(int value)
            {
                bool result = true;
                for (int i = 2; i <= Math.Floor(Math.Sqrt(value)); i++)
                {
                    if (value % i == 0)
                    {
                        result = false;
                        break;
                    }
                }
                return result;
            }

            // 最小の素数
            const int Min = 2;

            // 引数maxが2未満ならエラー
            if (max < Min)
            {
                Console.WriteLine("引数maxは2以上の値を指定してください");
                // yield break命令でイテレータが終了する
                yield break;
            }
            // 2から順に素数判定、素数ならreturn
            for (int num = Min; num <= max; num++)
            {
                if ((IsPrime(num)))
                {
                    yield return num;
                }
            }
        }
    }

    class EnumerablePrimeNumber : IEnumerable<int>
    {
        // 素数の最大値(規定値)
        int max = 2;

        // コンストラクタ
        public EnumerablePrimeNumber(int max)
        {
            this.max = max;
        }

        /// <summary>
        /// IEnumerable<T>型のGetEnumeratorの実装
        /// </summary>
        /// <returns></returns>
        public IEnumerator<int> GetEnumerator()
        {
            // ローカル関数
            // valueが素数かどうかを判定
            bool IsPrime(int value)
            {
                bool result = true;
                for (int i = 2; i <= Math.Floor(Math.Sqrt(value)); i++)
                {
                    if (value % i == 0)
                    {
                        result = false;
                        break;
                    }
                }
                return result;
            }
            // 最小の素数
            const int Min = 2;

            // 引数maxが2未満ならエラー
            if (max < Min)
            {
                Console.WriteLine("引数maxは2以上の値を指定してください");
                // yield break命令でイテレータが終了する
                yield break;
            }
            // 2から順に素数判定、素数ならreturn
            for (int num = Min; num <= max; num++)
            {
                if ((IsPrime(num)))
                {
                    yield return num;
                }
            }
        }

        /// <summary>
        /// IEnumerable(非ジェネリック型)のGetEnumeratorの実装
        /// IEnumerable<T>がIEnumerable(非ジェネリック型)を実装しているため必須
        /// 中身はIEnumerable<T>.GetEnumeratorの呼び出しでOK
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}