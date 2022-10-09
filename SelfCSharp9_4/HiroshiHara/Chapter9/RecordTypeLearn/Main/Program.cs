using SelfCSharp9_4.HiroshiHara.Chapter9.RecordTypeLearn.Record;

namespace SelfCSharp9_4.HiroshiHara.Chapter9.RecordTypeLearn.Main
{
    internal class Program
    {
        public static void Main(string[] args) {
            // レコード型利用のサンプル
            Person p1 = new Person("山田", "太郎", 22);
            Person p2 = new Person("田中", "二郎", 29);
            Person p3 = new Person("山田", "太郎", 22);
            Console.WriteLine(p1); // ToStringの自動生成
            Console.WriteLine(p1 == p3); // true(プロパティ個々の同値性で判定)
            (string fname, string lname, int age) = p2; // 分割代入
            Console.WriteLine(fname);

            Console.WriteLine("---------------------------");

            // with式によるレコードの複製
            // 元のレコードを複製+値を変更する仕組み(イミュータブルなまま変更したいとき)
            Person p1with = p1 with { Age = 33 };
            Console.WriteLine(p1with.Age);// 33
            Console.WriteLine(p1.Age); // 22
        }
    }
}