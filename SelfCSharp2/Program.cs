using System;

namespace SelfCSharp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 変数の宣言
            // 数値で始まる、記号を含むものはNGs
            int num = 100;
            string str = "Hello";

            // 定数の宣言(Pascal記法)
            const double Tax = 10.0;

            // 組込型(全て.NET型のエイリアス)
            // 真偽型
            bool isHoge = true;
            // 文字型
            char c = 'a';
            // 符号あり整数
            sbyte sb = 1;
            short s = 1;
            int i = 1;
            long l = 1;
            // 符号なし整数
            ushort us = 1;
            uint ui = 1;
            ulong ul = 1;
            // 小数点
            float f = 1;
            double d = 0.1;
            decimal dec = 1; // 有効ケア通28桁まで誤差が発生しない性質
            // 文字列(参照値)
            string str2 = "world.";
            // オブジェクト(参照値)
            object obj = null;

            // 数値セパレータ(桁数の多い数値の可読性向上のための区切り文字(_))
            int separator = 123_513_173;

            // 逐語的文字列リテラル(文字列の先頭に@をつけることでエスケープなしで表現)
            Console.WriteLine(@"C:\Windows\mrbob");
            Console.WriteLine(@"aaa
                bbb
                ccc");

            // 文字列への変数展開
            Console.WriteLine($"{str}, {str2}");

            // 文字列-数値変換
            // 文字列-整数
            Console.WriteLine(Int32.Parse("108"));
            // 文字列-小数
            Console.WriteLine(Single.Parse("0.108"));
            // 数値-文字列
            Console.WriteLine(i.ToString());

            // コンストラクタの型省略
            string skipConstructor = new("aaa");
            Console.WriteLine(skipConstructor);

            // null条件演算子(変数がnull以外ならアクセス、そうでないならnullをreturn)
            string nullStr = null;
            string trimed = nullStr?.Trim();

            // Nullable型(基本型? = Nullable<基本型>)
            int? nullNum = null;
            Nullable<int> nullable = null;
            Console.WriteLine(nullNum.HasValue);
            // Nullable型と基本型の演算は自動でNullable.Valueが参照されるので可能(ちなみにこのときはInvalidOperationExceptionにならない)
            Console.WriteLine(nullNum + nullable);
            // Nullable参照型(プロジェクト(orファイル)設定でnullを禁止した場合の逃げ道
            string? nullStr2 = null;
            // Null免除演算子
            // null許容の場合nullableな変数にアクセスすると警告が出る場合がある
            // ex.
            string?[] format = { "2022-02-02 11:11:11" };
            // Parse()の引数に警告が出るが、!で無視できる
            DateTime dt = DateTime.Parse(format[0]!);

            // 配列
            int[] numAry1 = new int[5];
            int[] numAry2 = { 1, 2, 3, 4, 5 };
            int[] numAry3;
            numAry3 = new[] { 1, 2, 3 };
            // 配列へのアクセス
            Console.WriteLine(numAry2[1]);
            Console.WriteLine(numAry3.Length);
            // 多次元配列(ブラケットの中のカンマの数だけ長さ、要素数が制限)
            // Javaの多次元配列はジャグ配列となる
            int[,] num2DAry =
            {
                {1, 2, 3 },
                {4, 5, 6 },
            };

            // Practice
            const double Discount = 0.90;
            int price = 500;
            double sum = price * Discount;
            Console.WriteLine($"値引き後の価格は{sum}円です。");
            // Practice

            // stringクラスの同値性
            string data1 = "aaa";
            string data2 = "aaa";
            Console.WriteLine(data1 == data2); // "=="厳密等価演算子は内部でEqualsに変換される
            Console.WriteLine(data1.Equals(data2)); // Equalsは型安全でない、したがって"=="を推奨

            // 浮動小数点数の比較
            // double型では誤差が生じるので、小数点以下何位までの誤差を許容するかを定義し、
            // 比較対象の絶対値の差が定義値(EPSILON)より少なければ等しいとみなす
            // またはdecimal型(有効桁数が多い)を使用。ただし遅い。
            const double EPSILON = 0.00001;
            double d1 = 0.2 * 3;
            double d2 = 0.6;
            Console.WriteLine(d1); // 0.600...001
            Console.WriteLine(d2); // 0.6
            Console.WriteLine(Math.Abs(d1 - d2) < EPSILON); // true

            // 配列の比較(同値性)
            int[] intAry1 = { 1, 2, 3 };
            int[] intAry2 = { 1, 2, 3 };
            Console.WriteLine(intAry1 == intAry2); // false
            Console.WriteLine(intAry1.Equals(intAry2)); // false
            Console.WriteLine(intAry1.SequenceEqual(intAry2)); // true

            // null合体演算子
            // variable1 ?? variable2
            // v1がnullでなければv1を、そうでないならv2をreturn
            string? nullVal = null;
            string notNullVal = "aaa";
            Console.WriteLine(nullVal ?? notNullVal);

            // null合体代入
            // variable ??= "値"
            // variableがnullなら値を代入
            nullVal ??= "bbb";

            // Practice
            string p1 = "aaa";
            Console.WriteLine(p1 == null ? "規定値" : p1);
            Console.WriteLine(p1 ?? "規定値");

            // sizeof演算子
            // 値型のサイズをバイト単位で取得
            // unsafeモードで参照型以外の構造体のサイズも取得可能
            Console.WriteLine(sizeof(int)); // 4

            // nameof演算子
            // 変数、クラス、メンバーなど識別子を文字列リテラルとして返す
            // ログ等に変数名を埋め込むとき、一括名称変更でIDEで変換できるので便利
            Console.WriteLine(nameof(Main)); // Main


        }
    }
}
