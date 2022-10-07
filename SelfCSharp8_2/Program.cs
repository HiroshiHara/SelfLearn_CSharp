using System;

namespace SelfCSharp8_2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Person p = new Person("山田", "太郎", 22);
            p.Show();
            p.HowOld(); // virtualはそのまま呼び出せる

            Console.WriteLine("---------------------------");

            BusinessPerson bp = new BusinessPerson("佐藤", "和仁", 32);
            bp.Show();
            bp.ShowWork();
            bp.HowOld();

            Console.WriteLine("---------------------------");

            EliteBusinessPerson ebp = new EliteBusinessPerson("鈴木", "良治", 38);
            ebp.FirstName = "鈴木";
            ebp.LastName = "良治";
            ebp.Show();
            ebp.HowOld();

            Console.WriteLine("---------------------------");

            // アップキャスト
            // あくまで親クラスの型なので、親クラスで未定義のメンバにはアクセスできない
            // 子クラスでオーバーライドしている場合は子クラス側の処理が呼ばれる
            // 隠蔽の場合は親クラス側の処理が呼ばれる
            Person upCast = new BusinessPerson("アップ", "キャスト", 999);
            upCast.Show(); // 隠蔽なので親クラスの処理
            upCast.HowOld(); // オーバーライドなので子クラスの処理

            Console.WriteLine("---------------------------");

            // ダウンキャスト
            // 明示的なキャストが必要
            Person beforeDownCast = new BusinessPerson("ダウン", "キャスト", 666);
            BusinessPerson afterDownCast = (BusinessPerson)beforeDownCast;
            afterDownCast.Show();
            afterDownCast.HowOld();

            Console.WriteLine("---------------------------");

            // 型判定
            // is-a関係か否か
            if (bp is BusinessPerson)
            {
                Console.WriteLine("true");
            }
            // is-a関係か否か(falseならnullをreturn)
            // ただしキャストに失敗するか否かの判定であり、
            // 全く継承関係にないクラス同士はコンパイルエラーになる
            var checkType = p as BusinessPerson;
            if (checkType == null)
            {
                Console.WriteLine("p is not a BusinessPerson.");
            }

            // is-a関係か否か(trueなら変数名に変換結果を格納)
            Person beforeDownCast2 = new BusinessPerson("ダウン", "キャスト2", 666);
            if (beforeDownCast2 is BusinessPerson bp2)
            {
                bp2.Show();
            }

        }
    }
}