using System;

namespace _1._Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int wagonsCnt = int.Parse(Console.ReadLine());
            int[] wagonsPassengers = new int[wagonsCnt];
            int sumOfPassengers = 0;

            for (int i = 0; i < wagonsCnt; i++)
            {
                wagonsPassengers[i] = int.Parse(Console.ReadLine());
                sumOfPassengers += wagonsPassengers[i];
                Console.Write($"{wagonsPassengers[i]} ");
            }
            Console.WriteLine();
            Console.WriteLine(sumOfPassengers);
        }
    }
}
