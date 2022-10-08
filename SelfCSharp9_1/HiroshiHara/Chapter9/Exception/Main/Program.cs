namespace SelfCSharp9_1.HiroshiHara.Chapter9.Exception.Main
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // try-catchによる例外処理
            try
            {
                using (var sr = new StreamReader(@"E:\Workspace\CSharp\SelfCSharp9_1\file\exception.log"))
                {
                    Console.WriteLine(sr.ReadToEnd());
                }
            } catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.StackTrace);
                // ★例外クラスの主なプロパティ
                // ・例外に関するユーザー定義の情報
                var data = ex.Data;
                Console.WriteLine($"・例外に関するユーザー定義の情報={data.Keys}:{data.Values}");
                // ・例外に関するヘルプへのリンク
                Console.WriteLine($"・例外に関するヘルプへのリンク={ex.HelpLink}");
                // ・例外の原因となる例外
                var cause = ex.InnerException;
                if (cause != null)
                {
                    Console.WriteLine(cause.Message);
                }
                // ・例外メッセージ
                Console.WriteLine($"・例外メッセージ={ex.Message}");
                // ・例外の原因となるアプリ/オブジェクトの名前
                var source = ex.Source;
                if (source != null)
                {
                    Console.WriteLine($"・例外の原因となるアプリ/オブジェクトの名前={source}");
                }
                // ・現在の例外がスローされたメソッド
                var method = ex.TargetSite;
                if (method != null)
                {
                    Console.WriteLine($"・現在の例外がスローされたメソッド={method.Name}");
                }
            }
        }
    }
}