using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfCSharp11_1.HiroshiHara.Chapter11.ThreadLearn.Main
{
    // 非同期処理の利用例
    // ネットワーク上のコンテンツを取得
    internal class AsyncHttp
    {
        public async Task GetHttpContentsAsync()
        {
            var client = new HttpClient();
            var result = await client.GetStringAsync("https://codezine.jp");
            Console.WriteLine(result);
        }
    }
}
