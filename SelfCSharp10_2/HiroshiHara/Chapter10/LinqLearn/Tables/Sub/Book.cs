using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfCSharp10_2.HiroshiHara.Chapter10.LinqLearn.Tables.Sub
{
    /// <summary>
    /// 書籍情報
    /// </summary>
    internal class Book
    {
        public string Isbn { get; set; } = "";
        public string Title { get; set; } = "";
        public int Price { get; set; } = 0;
        public string Publisher { get; set; } = "";
        public DateTime Published { get; set; } = DateTime.Today;

        public override string ToString()
        {
            return $"{Title}({Publisher}){Price}円 {Published:d}刊行";
        }
    }
}
