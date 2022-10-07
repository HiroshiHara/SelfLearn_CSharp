using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfCSharp8_3
{
    internal class Animal
    {
        public string? Name { get;}
        private int _age;

        public Animal(string? name, int age)
        {
            Name = name;
            Age = age;
        }

        public int Age
        {
            get { return this._age; }
            private set
            {
                if (value < 0)
                {
                    this._age = 0;
                }
                this._age = value;
            }
        }

        public void Intro()
        {
            Console.WriteLine($"My name is {Name}. {Age} yo.");
        }
    }
}
