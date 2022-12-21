using System;
using System.Linq;

namespace _3._Zig_Zag_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lenght = int.Parse(Console.ReadLine());

            int[] firstArr = new int[lenght];
            int[] secondArr = new int[lenght];


            for (int i = 0; i < lenght; i++)
            {
                int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

                if (i % 2 == 0)
                {
                    firstArr[i] = numbers[0];
                    secondArr[i] = numbers[1];
                }
                else
                {
                    firstArr[i] = numbers[1];
                    secondArr[i] = numbers[0];
                }
            }

            Console.WriteLine(String.Join(" ", firstArr));
            Console.WriteLine(String.Join(" ", secondArr));
        }
    }
}
