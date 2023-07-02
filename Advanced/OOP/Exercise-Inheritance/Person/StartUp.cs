﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Person
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            if (age > 15)
            {
                Person person = new(name, age);
                Console.WriteLine(person);
            }
            else if (age > 0 && age <= 15)
            {
                Child child = new(name, age);
                Console.WriteLine(child);
            }
        }
    }
}