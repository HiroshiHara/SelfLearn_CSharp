using System;

namespace SelfCSharp
{
	internal class Program
	{
		/// <summary>
		/// メインクラス
		/// </summary>
		/// <param name="args">指定なし</param>
		static void Main(string[] args)
		{
			Console.WriteLine(Console.Out.Encoding);
			Console.WriteLine("あなたの名前は？");
			string? name = Console.ReadLine();
			Console.WriteLine($"こんにちは、{name}さん！");
		}
	}
}
