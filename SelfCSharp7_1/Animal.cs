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
}