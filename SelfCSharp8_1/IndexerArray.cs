using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfCSharp8_1
{
    internal class IndexerArray
    {
        // 配列サイズ
        private int _size;
        // 配列本体
        private int[] _list;

        // コンストラクタ
        public IndexerArray(int size)
        {
            _size = size;
            _list = new int[size];
        }

        // ★インデクサー
        // 修飾子 戻り値の型 this[インデックスの型 インデックス変数]
        // 配列/リスト型のフィールドにアクセスることを目的にした特殊なプロパティ
        public int this[int index]
        {
            set
            {
                // 指定のインデックスに値をセット
                _list[GetIndex(index)] = value;
            }
            get
            {
                // 指定のインデックスの値を取得
                return _list[GetIndex(index)];
            }
        }

        // 通常のプロパティ
        public int Size
        {
            get
            {
                return _size;
            }
        }

        /// <summary>
        /// 指定されたインデックスが0未満の場合は無条件に0番目のインデックスを返却<br>
        /// 指定されたインデックスがサイズの上限を超えている場合は、指定値と元のサイズの余剰のインデックスを返却<br>
        /// (元のサイズから余った分だけ先頭から数えなおす)
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private int GetIndex(int index)
        {
            if (index < 0)
            {
                return 0;
            }
            return index % _size;
        }
    }
}
