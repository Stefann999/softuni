using System;
using System.Text;

namespace Person;

public class Person
{

        private int age;
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public override string ToString() => $"Name: {Name}, Age: {Age}";
}
