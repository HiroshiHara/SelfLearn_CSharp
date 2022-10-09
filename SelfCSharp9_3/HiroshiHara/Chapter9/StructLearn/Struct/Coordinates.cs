using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfCSharp9_3.HiroshiHara.Chapter9.StructLearn.Struct
{
    // 構造体... 値型のクラス
    // 継承NG、インターフェースOK
    // 継承に関係する修飾子(abstract, virtual, override, sealedなど)は使用できない
    // 引数無しのコンストラクタは定義できない
    // staticクラスにはできない
    // ファイナライザは使用できない
    // 暗黙的にValueTypeクラスを継承(=Objectクラスも継承)(=ToString等はオーバーライドできる)
    /// <summary>
    /// Latitude(緯度)/Longitude(経度)を表現する構造体
    /// </summary>
    internal struct Coordinates
    {
        // ★フィールド
        // C#9.0以前ではstatic/const以外のフィールドに初期値は指定できない
        /// <summary>
        /// 緯度
        /// </summary>
        public double Latitude;

        /// <summary>
        /// 経度
        /// </summary>
        public double Longitude;

        // ★コンストラクタ
        // 1.全てのフィールドを初期化しなければならない
        // 2.全てのフィールドが初期化されるまで他のメンバーは使用できない
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        public Coordinates(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public override string ToString()
        {
            return $"緯度：{this.Latitude}/経度：{this.Longitude}";
        }
    }
}
