using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SelfCSharp9_1.HiroshiHara.Chapter9.ExceptionLearn.MyException
{
    // 例外クラスの拡張
    // Exceptionを継承する
    internal class MyAppException : Exception
    {
        // 独自処理が不要なら、ExceptionクラスのコンストラクタをオーバーライドするのみでOK
        // message... 例外メッセージ
        // innerException... 例外の原因となる例外
        // info... 例外に関する情報(シリアル化オブジェクト)
        // context... 情報の転送元/先についてのコンテキスト情報
        public MyAppException() { }
        public MyAppException(string message) : base(message) { }
        public MyAppException(string message, Exception innerException) : base(message, innerException) { }
        public MyAppException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
