using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfCSharp11_4.HiroshiHara.Chapter11.EventLearn.Main
{
    // ★イベントハンドラに対応するデリゲート
    delegate void KeyCommandEventHandler(string data);

    internal class MyEvent
    {
        // イベントを登録
        // eventキーワードは、イベントハンドラ(デリゲート)の追加/削除だけをクラス外部に公開する
        public event KeyCommandEventHandler KeyCommand = v => { };

        // メイン処理
        public void Run()
        {
            Console.WriteLine("コマンドを入力してください。");
            Console.WriteLine("c:現在時刻を表示、x:乱数表示、h:ヘルプ");
            // コマンド入力を無限ループで受付
            while (true)
            {
                // ユーザからの入力を要求
                Console.Write("コマンド：");
                string? input = Console.ReadLine();
                if (input == null || input == "")
                {
                    break;
                }
                // KeyCommandイベントを発生
                KeyCommand(input);
            }
        }
    }
}
