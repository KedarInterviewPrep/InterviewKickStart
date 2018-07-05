using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class.LLStackQueue
{
    public class MyPerson : IComparable<MyPerson>
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public int CompareTo(MyPerson other)
        {
            return this.Age.CompareTo(other.Age);
        }

        public override string ToString()
        {
            return $"Name: {this.Name}, Age: {this.Age}";
        }
    }
}
