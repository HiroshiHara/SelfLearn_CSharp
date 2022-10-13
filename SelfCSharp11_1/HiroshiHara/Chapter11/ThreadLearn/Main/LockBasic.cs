using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfCSharp11_1.HiroshiHara.Chapter11.ThreadLearn.Main
{
    internal class LockBasic
    {
        // ★volatileキーワードで最適化しない
        // 最適化=変数の中身をキャッシュせず、毎回設定する=他スレッドからの変更に強くなる≠排他制御ではない
        //private volatile int _num = 0;
        private readonly object _lockobj = new();

        //public int Num
        //{
        //    get => this._num;
        //    private set => this._num = Num;
        //}

        public int Num { get; private set; } = 0;

        // 排他制御(lock)
        public void Increment()
        {
            // lockブロックで排他制御を行う
            lock (_lockobj)
            {
                this.Num++;
            }
        }
    }
}
