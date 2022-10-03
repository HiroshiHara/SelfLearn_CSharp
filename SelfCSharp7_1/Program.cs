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
            Console.WriteLine("heelo");
            // 引数の規定値
            Animal dog1 = new Animal();
            Animal dog2 = new Animal("わんわん");
            dog1.Show();
            dog2.Show();
            // 名前付き引数
            Animal dog3 = new Animal(howling: "グルル");
            dog3.Show();
            Console.WriteLine(dog3.Sum(1, 2, 3));
        }
    }
}