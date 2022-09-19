using System;
using System.Text;

namespace SelfCSharp5_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string sw1Path = @"E:\Workspace\CSharp\SelfCSharp5_2\output\sw1.log";
            // StreamWriter(テキストファイル書き込み)
            // 第二引数：append: 名前付き引数で指定すると見やすい, trueで追記モード
            // 第三引数：encoding: エンコードは未指定の場合System.Text(UTF-8)
            // 指定する場合はEncoding.GetEncoding("Shift-JIS")
            // なお.NET6ではUnicode系, ASCII, ISO-8859-1のみ。
            // Shift-JISなどその他を指定する場合は
            // Encoding.RegisterProvider(CodePagesEncodingProvider.Instance)を先に実行
            // 第四引数：bufferSize デフォルトは1024バイト

            // using命令はtry-with-resourceと同じ意味
            // ブロックを抜けた時点で自動クローズ
            // using命令を宣言できるのはDisposeメソッドまたはIDisposabeインタフェースの実装のみ
            using (StreamWriter sw1 = new StreamWriter(sw1Path, append: true))
            {
                sw1.WriteLine(DateTime.Now);
            }

            Console.WriteLine("-*-*-*-*-*-*-*-*-*-*-*-*-*-*");

            // StreamReader(テキストファイル読み込み）
            // 第二引数：encoding
            // 第三引数：BOM付きか否か
            // 第四引数：bufferSize デフォルトは1024バイト
            using (StreamReader sr1 = new StreamReader(sw1Path))
            {   
                // 全行読み込み
                Console.WriteLine(sr1.ReadToEnd());
            }

            using (StreamReader sr2 = new StreamReader(sw1Path))
            {
                // EOFまで一行ずつ読み込み
                while(!sr2.EndOfStream)
                {
                    Console.WriteLine(sr2.ReadLine());
                }
            }

            Console.WriteLine("-*-*-*-*-*-*-*-*-*-*-*-*-*-*");

            // ファイルアクセス(FileInfoクラス)
            // 静的クラスFileでユーティリティだけ呼び出すことが可能
            FileInfo fileInfo = new FileInfo(@"E:\Workspace\CSharp\SelfCSharp5_2\output\FileInfo.txt");
            Console.WriteLine(fileInfo.Exists);
            Console.WriteLine(fileInfo.Name);
            Console.WriteLine(fileInfo.FullName);
            Console.WriteLine(fileInfo.DirectoryName);
            Console.WriteLine(fileInfo.Directory);
            Console.WriteLine(fileInfo.IsReadOnly);
            Console.WriteLine(fileInfo.LastAccessTime);
            Console.WriteLine(fileInfo.LastWriteTime);
            Console.WriteLine(fileInfo.Length); // バイトでサイズを取得
            // ファイルコピー(第二引数は同名ファイルを上書きするか否か)
            FileInfo copyFile = fileInfo.CopyTo(@"E:\Workspace\CSharp\SelfCSharp5_2\output\FileInfo_copy.txt", true);
            // ファイル移動
            FileInfo targetFile = new FileInfo(@"E:\Workspace\CSharp\SelfCSharp5_2\output2\FileInfo_copy.txt");
            if (!targetFile.Exists)
            {
                copyFile.MoveTo(@"E:\Workspace\CSharp\SelfCSharp5_2\output2\FileInfo_copy.txt");
            }
            // ファイル削除、リネーム
            if (targetFile.Exists)
            {
                targetFile.Delete();
                //targetFile.MoveTo(@"E:\Workspace\CSharp\SelfCSharp5_2\output2\FileInfo_renamed.txt");
            }

            Console.WriteLine("-*-*-*-*-*-*-*-*-*-*-*-*-*-*");

            // ディレクトリアクセス
            // 静的クラスDirectoryでユーティリティだけ呼び出すことが可能
            DirectoryInfo dir1 = new DirectoryInfo(@"E:\Workspace\CSharp\SelfCSharp5_2\dir1");
            Console.WriteLine(dir1.Exists);
            Console.WriteLine(dir1.Name);
            Console.WriteLine(dir1.FullName);
            Console.WriteLine(dir1.Root);
            Console.WriteLine(dir1.CreationTime);
            Console.WriteLine(dir1.LastAccessTime);
            Console.WriteLine(dir1.LastWriteTime);
            // 直下のサブフォルダ一覧取得
            DirectoryInfo[] dir1sub = dir1.GetDirectories();
            foreach (DirectoryInfo d in dir1sub)
            {
                Console.WriteLine(d.FullName);
            }
            // 全てのサブフォルダ一覧取得
            DirectoryInfo[] dir1sub2 = dir1.GetDirectories("*", SearchOption.AllDirectories);
            foreach (DirectoryInfo d in dir1sub2)
            {
                Console.WriteLine(d.FullName);
            }
            // 直下のファイル一覧取得
            FileInfo[] dir1file = dir1.GetFiles();
            foreach(FileInfo f in dir1file)
            {
                Console.WriteLine(f.FullName);
            }
            // 全てのファイル一覧取得
            FileInfo[] dir1file2 = dir1.GetFiles("*", SearchOption.AllDirectories);
            foreach(FileInfo f in dir1file2)
            {
                Console.WriteLine(f.FullName);
            }
            //// フォルダ削除
            //dir1.Delete();
            //// サブコンテンツ含め全削除
            //dir1.Delete(true);

            Console.WriteLine("-*-*-*-*-*-*-*-*-*-*-*-*-*-*");

            // 配列操作
            int[] intAry1 = { 343, 7, 2, 23, 52 };
            Console.WriteLine(intAry1.Length);
            Console.WriteLine(intAry1.Rank); // 次元数取得
            Array.Sort(intAry1); // ソート
            foreach (int i in intAry1)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            Array.Reverse(intAry1); // 逆順ソート
            foreach (int i in intAry1)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            Console.WriteLine(Array.BinarySearch(intAry1, 8)); // 線形探索

            Console.WriteLine("-*-*-*-*-*-*-*-*-*-*-*-*-*-*");

            // Span構造体
            // 連続データの範囲を抽出(参照するため抽出もとに影響あり)
            // イミュータブルなデータのスパンを変更するとコンパイルエラー
            string[] strAry1 = {"sam", "bob", "chrlie", "dom", "edy" };
            Span<string> span = new Span<string>(strAry1, 1, 3);
            foreach(var s in span)
            {
                Console.Write(s + " ");
            }
            Console.WriteLine();
            string str1 = "sbcde";
            ReadOnlySpan<char> strSpan = str1.AsSpan(0, 2);
            foreach(var s in strSpan)
            {
                Console.Write(s + " ");
            }
            Console.WriteLine();

        }
    }
}