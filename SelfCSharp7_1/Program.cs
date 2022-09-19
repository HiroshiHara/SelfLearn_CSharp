using System;
using System.Runtime.CompilerServices;

namespace SelfCSharp7_1
{
    // internal
    // 同じプロジェクトからのみ参照可能
    internal class Program
    {

        // モジュール初期化子
        // このクラスが含まれるモジュール(アセンブリ)を読み込んだタイミングで実行
        // プロジェクト実行時に確実に呼び出したい場合に使用
        [ModuleInitializer]
        public static void Init()
        {
            Console.WriteLine("ModuleInitializer called");
        }

        static void Main(string[] args)
        {
            Person person1 = new Person("山田", "太郎");
            person1.Show();
            Person person2 = new Person();
            person2.Show();
            // オブジェクト初期化子
            // 初期化子にアクセスできるのはpublicのみ
            //Person person = new Person()
            //{
            //    _firstName = "山田",
            //    _lastName = "太郎"
            //};
            using (Person person = new Person("佐々木", "小次郎"))
            {
                person.Show();
            }
        }
    }
}