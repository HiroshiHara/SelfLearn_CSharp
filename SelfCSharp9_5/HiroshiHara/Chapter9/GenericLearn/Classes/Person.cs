using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfCSharp9_5.HiroshiHara.Chapter9.GenericLearn.Classes
{
    internal class Person : IEquatable<Person>
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        // IEquatable<T>の実装
        public bool Equals(Person? other)
        {
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            // 型の判定
            if (other == null || this.GetType() != other.GetType())
            {
                return false;
            }
            // 同値性の判定
            return this.FirstName == other.FirstName &&
                this.LastName == other.LastName;
        }

        // Object.Equalsの実装
        public override bool Equals(object? obj)
        {
            return this.Equals(obj as Person);
        }

        public override int GetHashCode()
        {
            // 一般的にはEqualsメソッドで同値判定に利用するプロパティのハッシュ値の排他的論理和を返却
            // このインスタンスがDictionaryのキーとなる場合、
            // プロパティが変わるとハッシュ値も変わってしまうため
            // 原則ハッシュ値を算出するプロパティは不変とすべき
            return this.FirstName.GetHashCode() ^ this.LastName.GetHashCode();
        }
    }
}
