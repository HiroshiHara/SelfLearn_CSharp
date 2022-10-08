namespace SelfCSharp9_1.HiroshiHara.Chapter9.ExceptionLearn.Main
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("---------------------------");

            StreamReader sr = null;
            // try-catch-finallyによる例外処理
            // (リソースのクローズを目的にfinallyを使うよりはusing命令の方がシンプル)
            try
            {
                sr = new StreamReader(@"E:\Workspace\CSharp\SelfCSharp9_1\file\exception.log");
                Console.WriteLine(sr.ReadToEnd());
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
            finally
            {
                Console.WriteLine("finallyブロック...");
                if (sr != null)
                {
                    sr.Close();
                }
            }

            Console.WriteLine("---------------------------");

            // 例外フィルター
            // when (条件式)でcatchブロックに入るための条件式を指定できる
            try
            {
                Console.WriteLine(args[1]);
            }
            catch (IndexOutOfRangeException ex) when (args.Length == 0)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine($"引数{nameof(args)}が空です。");
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine($"引数{nameof(args)}に第二引数を指定してください。");
            }

            Console.WriteLine("---------------------------");

            try
            {
                // throw命令
                if (args.Length == 0)
                {
                    throw new ArgumentException($"引数{nameof(args)}を指定してください。");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("---------------------------");

            // throw式
            try
            {
                // 1. 三項演算子の結果で例外をthrowする
                var i = -1;
                Console.WriteLine(i > 0 ? i : throw new Exception("iは正数でなければいけません。"));
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                // 2. null合体演算子でnullであれば例外をthrowする
                string? str = null;
                Console.WriteLine(str ?? throw new Exception($"変数{nameof(str)}がnullです。"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                // 3. ラムダ式で例外を返却する
                void Hoge() => throw new NotSupportedException("未実装です。");
                Hoge();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}