using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace SelfCSharp5_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 文字列の操作
            string str1 = "abcde";
            string salogate = "叱る";
            // 長さの取得
            Console.WriteLine($"abcde：{str1.Length}");
            // サロゲートペアである文字は正しく計算できないので
            // StringInfo.LengthInTextElementsを使用
            Console.WriteLine($"叱る：{new StringInfo(salogate).LengthInTextElements}");

            Console.WriteLine("----------------------------");

            // 文字列を大文字小文字、全角半角、ひらカナを区別せず比較
            string str3 = "wings";
            string str4 = "WINGS";
            // string.Equalの第二引数にSringComparison.OrdinalIgnoreCaseを指定
            Console.WriteLine(str3.Equals(str4, StringComparison.OrdinalIgnoreCase)); // true
            // string.Compare(str1 > str2なら正数, str1 = str2なら0, str1 < str2なら負数)
            Console.WriteLine(string.Compare(str3, str4, StringComparison.OrdinalIgnoreCase)); // 0
            string str5 = "ＷＩＮＧＳ";
            string str6 = "WINGS";
            // CompareInfo.Compareの第三引数にオプションを指定
            CompareInfo cInfo = CultureInfo.CurrentCulture.CompareInfo;
            Console.WriteLine(cInfo.Compare(str5, str6, CompareOptions.IgnoreWidth)); // 0
            string hira = "うぃんぐす";
            string kana = "ウィングス";
            Console.WriteLine(cInfo.Compare(hira, kana, CompareOptions.IgnoreKanaType)); // 0

            Console.WriteLine("----------------------------");

            // 文字列のnull/空文字判定
            string emptyStr = "";
            string? nullStr = null;
            string spaceStr = " ";
            Console.WriteLine(string.IsNullOrEmpty(emptyStr));
            Console.WriteLine(string.IsNullOrEmpty(nullStr));
            Console.WriteLine(string.IsNullOrWhiteSpace(spaceStr));

            Console.WriteLine("----------------------------");

            // 文字列検索
            string lyric = "いろはにほへとちりぬるを";
            Console.WriteLine(lyric.IndexOf("ち")); // 7
            Console.WriteLine(lyric.Contains("いろは")); // true
            Console.WriteLine(lyric.StartsWith("い")); // true
            Console.WriteLine(lyric.EndsWith("を")); // true

            Console.WriteLine("----------------------------");

            // 部分文字列の取得
            Console.WriteLine(lyric.Substring(lyric.IndexOf("ちり"), 5)); // ちりぬるを
            // 文字列の区切り文字による分割、結合
            string fruits = "うめ,もも,あんず,りんご";
            string[] result1 = fruits.Split(',');
            Console.WriteLine(string.Join('#', result1));

            Console.WriteLine("----------------------------");

            // 文字列のフォーマット
            Console.WriteLine(string.Format(
                "{0}は{1}, {2}歳です。", // フォーマット
                "桜", "女の子", "15" // 書式文字列にあてはめる値(可変長引数)
            ));
            Console.WriteLine(string.Format(
                "{0, 5}は女の子, {1}歳です。", // 右詰め, 書式文字列が5以下なら空白を入れる
                "桜", "15"
            ));
            Console.WriteLine(string.Format(
                "{0, -5}は女の子, {1}歳です。", // 左詰め
                "桜", "15"
            ));

            Console.WriteLine("----------------------------");

            // 正規表現
            // パターンの先頭には逐語的文字列リテラル(@)をつけて余計なエスケープを省略する
            string testStr1 = "XYZ";
            string testStr2 = "5";
            Regex rgx1 = new Regex(@"XYZ"); // 特定の文字列にマッチ
            Console.WriteLine(rgx1.IsMatch(testStr1)); // true
            Regex rgx2_1 = new Regex(@"[XYZ]"); // []内のいずれかの文字にマッチ
            Console.WriteLine(rgx2_1.IsMatch(testStr1)); // true
            Regex rgx2_2 = new Regex(@"[^XYZ]"); // []内のいずれにもマッチしない([]の中の^は否定)
            Console.WriteLine(rgx2_2.IsMatch(testStr1)); // false
            Regex rgx3 = new Regex(@"[0-9]"); // []内の範囲にマッチ
            Console.WriteLine(rgx3.IsMatch(testStr2)); // true
            Regex rgx4 = new Regex(@"X.Z"); // 任意の一文字(.)
            Console.WriteLine(rgx4.IsMatch(testStr1)); // true
            Regex rgx5_1 = new Regex(@"^X"); // 前方一致(^)
            Console.WriteLine(rgx5_1.IsMatch(testStr1)); // true
            Regex rgx5_2 = new Regex(@"Z$"); // 後方一致($)
            Console.WriteLine(rgx5_2.IsMatch(testStr1)); // true

            Console.WriteLine("----------------------------");

            // 正規表現・文字列の繰り返しパターン(量指定子)
            string testStr3 = "soooon";
            Regex rgx6_1 = new Regex(@"so*n"); // 0文字以上のo(o*)
            Console.WriteLine(rgx6_1.IsMatch(testStr3)); // true
            Regex rgx6_2 = new Regex(@"so+n"); // 1文字以上のo(o+)
            Console.WriteLine(rgx6_2.IsMatch(testStr3)); // true
            Regex rgx6_3 = new Regex(@"so?n"); // 0文字または1文字のo(o?)
            Console.WriteLine(rgx6_3.IsMatch(testStr3)); // false
            Regex rgx6_4 = new Regex(@"so{4}n"); // n文字のo(o{N})
            Console.WriteLine(rgx6_4.IsMatch(testStr3)); // true
            Regex rgx6_5 = new Regex(@"so{4,}n"); // n文字以上のo(o{N,})
            Console.WriteLine(rgx6_5.IsMatch(testStr3)); // true
            Regex rgx6_6 = new Regex(@"so{4,5}n"); // n～m文字のo(o{N,M})
            Console.WriteLine(rgx6_6.IsMatch(testStr3)); // true

            Console.WriteLine("----------------------------");

            // 日付・時刻
            Console.WriteLine(DateTime.Now); // 現在時刻
            Console.WriteLine(DateTime.Today); // 今日の日付
            DateTime dt1 = new DateTime(2022, 09, 12, 20, 17, 01);
            Console.WriteLine(dt1);
            string dateStr1 = "2022/02/02 15:37:27";
            string dateStr2 = "令和3年2月15日 13時18分48秒";
            string dateStr3 = "Dienstag, 15, Februar 2022 13:47:32";
            Console.WriteLine(DateTime.Parse(dateStr1)); // 書式文字列からパース
            Console.WriteLine(DateTime.Parse(dateStr2)); // 日本語環境なら和暦もOK
            Console.WriteLine(DateTime.Parse(dateStr3, new CultureInfo("de-DE"))); // 地域指定
            // 変換に失敗したときのみ表示(TryParseの第二引数が出力引数)
            DateTime outputArg;
            if (DateTime.TryParse(dateStr1, out outputArg))
            {
                Console.WriteLine(outputArg);
            }
            // 任意のフォーマットを指定(ParseExact/TryParseExact)
            // arg1の日時がarg2の書式に一致したときyyyy/MM/dd HH:mm:ssをreturnする
            Console.WriteLine(DateTime.ParseExact("20210205163828", "yyyyMMddHHmmss", new CultureInfo("ja-JP")));
            Console.WriteLine($"{dt1.Year}");
            Console.WriteLine($"{dt1.Month}");
            Console.WriteLine($"{dt1.Day}");
            Console.WriteLine($"{dt1.DayOfWeek}"); // 曜日
            Console.WriteLine($"{dt1.DayOfYear}"); // 年初からの日数
            Console.WriteLine($"{dt1.Hour}");
            Console.WriteLine($"{dt1.Minute}");
            Console.WriteLine($"{dt1.Second}");
            Console.WriteLine($"{dt1.Millisecond}");
            Console.WriteLine($"{dt1.Ticks}"); // 0001/01/01 00:00:00からの経過時間(100ナノ秒単位)
            // ToString(整形)
            Console.WriteLine(dt1.ToString("D")); // 標準指定子により現在のロケールに合わせて整形
            // 日付の加減算(AddXxxは省略)
            // TimeSpan構造体(N日後、N日前等を表現)
            TimeSpan tp = new TimeSpan(3, 2, 0, 0, 0); // 3日と2時間
            Console.WriteLine(dt1.Add(tp));
            Console.WriteLine(dt1.Subtract(tp));
            // 日付の差分
            DateTime dt2 = new DateTime(2021, 09, 12, 20, 17, 01);
            // DateTime.Subtractの引数にDateTimeを渡すことで差分を表現するTimeSpanオブジェクトを取得
            TimeSpan during = dt1.Subtract(dt2); // dt1 - dt2
            Console.WriteLine(during.ToString("G")); // 指定子でフォーマット可能
            // 加減算と比較は算術演算子でもOK
            Console.WriteLine(dt1 + tp);
            Console.WriteLine(dt1 - tp);
            Console.WriteLine(dt1 == dt2);
            Console.WriteLine(dt1 >= dt2);

        }
    }
}