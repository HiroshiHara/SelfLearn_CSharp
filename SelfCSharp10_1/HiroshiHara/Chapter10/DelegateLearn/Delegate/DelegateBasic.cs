using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfCSharp10_1.HiroshiHara.Chapter10.DelegateLearn.Delegate
{
    // ★デリゲート宣言
    // delegate 戻り値の型 デリゲート名(引数)
    // Processデリゲートには、戻り値がvoidでstring引数を1つ受け取るメソッドを渡せる
    // 本質は、メソッドの処理をシグニチャと切り分けられること
    // 同じシグニチャに対し、状況次第で複数の処理を用意できる
    delegate void Process(string str);
    delegate void OutputProcess(string str);
    delegate string GetOutputProcess(string str);
}
