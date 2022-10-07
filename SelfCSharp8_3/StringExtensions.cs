using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfCSharp8_3
{
    // 拡張メソッド実装クラスはstaticである必要あり
    // ※staticクラス→インスタンス化禁止
    internal static class StringExtensions
    {
        // 拡張メソッド
        // 継承せず既存のクラスのメソッドを拡張する
        // 継承とは異なる仕組みの為sealedクラスにも有効
        // 条件
        // ・拡張元がstaticクラスのstaticメソッドであること
        // ・拡張先で第一引数にthisキーワードで拡張元クラス自身を指定すること
        public static string Repeat(this string str, int count)
        {
            // str.Repeat(int)で実行される
            // 第一引数が拡張メソッドの構文規則兼実際の操作対象
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < count; i++)
            {
                sb.Append(str);
            }
            return sb.ToString();
        }

        public static string ToTitleCase(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                throw new ArgumentException("文字列を指定してください。");
            }
            string upper = str.Substring(0, 1).ToUpper();
            string lower = str.Substring(1).ToLower();
            return upper + lower;
        }
    }
}
