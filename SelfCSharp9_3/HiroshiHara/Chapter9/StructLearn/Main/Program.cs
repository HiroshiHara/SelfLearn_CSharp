using SelfCSharp9_3.HiroshiHara.Chapter9.StructLearn.Struct;

namespace SelfCSharp9_3.HiroshiHara.Chapter9.StructLearn.Main
{
    internal class Program
    {
        // readonly専用の関数メンバーのテスト
        static readonly MutableValue mv = new();

        public static void Main(string[] args)
        {
            Console.WriteLine("---------------------------");

            Coordinates c = new Coordinates(29.2, 283.2);
            Console.WriteLine(c.ToString());

            Console.WriteLine("---------------------------");

            // new演算子を使用せずともインスタンス化可能
            Coordinates c1;
            c1.Latitude = 23.1;
            c1.Longitude = 382.1;
            Console.WriteLine(c1.ToString());

            Console.WriteLine("---------------------------");
            //mv.Name = "田中太郎"; コンパイルエラー
            mv.Update("田中太郎");
            Console.WriteLine(mv.Name); // 名無しの権兵衛
            // →構造体のメソッドでは、内部的にインスタンスを複製してから実行する
            // つまり、
            // 1.mvをコピー(Name=名無しの権兵衛)
            // 2.コピーしたmv2のUpdateを実行
            // 3.mvのNameはそのままなので実行結果は田中太郎にならない
            // 結局は構造体のメソッドでフィールドの更新がない場合が明らかであるなら
            // メソッドにもreadonlyをつけた方がよい
        }
    }
}