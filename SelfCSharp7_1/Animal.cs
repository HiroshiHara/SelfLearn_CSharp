using System;

public class Animal
{
    string howling;

    // 引数の規定値
    public Animal(string howling = "bowwow")
    {
        this.howling = howling;
    }

    public void Show()
    {
        Console.WriteLine(this.howling);
    }

    // paramsキーワードで可変長引数
    // 可変長引数はメソッド側で配列として扱う
    public int Sum(params int[] values)
    {
        int result = 0;
        foreach (int value in values)
        {
            result += value;
        }
        return result;
    }
}