using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SelfCSharp7_1
{
    internal class Person : IDisposable
    {
        // 定数宣言
        // const
        // ... 無条件でstatic
        // ... コンパイル時に初期化, 変更の反映にはexeのリビルドが必須
        // ... 型は値型, stringのみ
        public const string Race = "Human";
        // readonly(推奨)
        // ... static or インスタンスメンバ
        // ... ソースコード実行時に初期化, 変更の反映にはdllの更新のみで可
        // ... 型は何でもいい(つまり配列などの要素変更に注意)
        public static readonly string Domain = "Marmal";

        // フィールド宣言
        // varキーワードは使用できない
        // publicなフィールドはPascal記法
        // privteなフィールドはcamelCase記法
        // アクセス修飾子を省略するとprivate
        private string _firstName;
        private string _lastName;

        // ★
        // Disposeが既に実行されたか
        private bool _disposed = false;

        // コンストラクタ宣言
        // 修飾子はアクセス修飾子, static, externのみ
        public Person(string firstName, string lastName)
        {
            this._firstName = firstName;
            this._lastName = lastName;
        }
        // コンストラクタ初期化子
        // コンストラクタ実行前に別のコンストラクタを呼び出す
        // メソッドの最初にthis.別コンストラクタはコンパイルエラー
        public Person() : this("苗字", "名前") { }

        // 静的コンストラクタ
        // クラスに初めてアクセスするときだけ実行
        // 主にクラスフィールドの初期化に使用
        static Person()
        {
            Console.WriteLine("静的コンストラクタ");
        }

        // ファイナライザ宣言
        // ~(チルダ)+クラス名
        // 修飾子、引数、初期化子は持てない
        // 1クラス1つ
        // 明示的に呼び出せない
        // オーバーヘッドが大きいのでDisposeの実装にすべき
        ~Person()
        {
            // ★
            // ファイナライザで破棄するのは.NETの管理下にない
            // リソースが想定されるため、
            // マネージリソースの解放はしないように
            // Disposeを実行しない
            Dispose(false);
            Console.WriteLine("finalize");
        }

        // ★
        // Disposeメソッド(IDispsableの実装)による
        // リソースの明示的な解放
        public void Dispose()
        {
            Dispose(true);
            // ガベージコレクタに対してファイナライザの
            // 呼び出しが不要であることを通知
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }
            else
            {
                Console.WriteLine("...マネージリソースの解放...");
            }
            Console.WriteLine("...アンマネージリソースの解放...");
        }

        // メソッド宣言
        // Pascal記法
        public void Show ()
        {
            Console.WriteLine($"名前は{this._lastName} {this._firstName}です。");
        }
    }
}
