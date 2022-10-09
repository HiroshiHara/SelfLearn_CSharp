// 列挙型
// [修飾子] enum 名前 {列挙定数... }
// 修飾子はinternal(デフォルト), public のどちらか
// System.Enumクラスを暗黙的に継承したクラス
internal enum Season
{
    // 自動で連番が振られる
    Spring, // 0
    Summer, // 1
    Autumn, // 2
    Winter, // 3
}

// 列挙定数のデータ型は以下を指定可能
// byte, sbyte, shot, ushort, int, uint, long, ulong
internal enum ProgramLang : int
{
    // 列挙定数の値を任意に指定することができる
    Java = 1, 
    CSharp = 2,
    PHP = 3,
    Python = 4,
    // 全てのメンバーの値を演算した結果を割り当てることもできる
    All = Java + CSharp + PHP + Python,
}
