using System;

namespace _06._Unique_PIN_Codes
{
    internal class Program
    {
        static void Main(string[] args)
        {
          int firstMax = int.Parse(Console.ReadLine());
          int secondMax = int.Parse(Console.ReadLine());
          int thirdMax = int.Parse(Console.ReadLine());


            for (int i = 2; i <= firstMax; i++)
            {
                if (i % 2 == 0)
                {
                    for (int j = 2; j <= secondMax; j++)
                    {
                        if (j == 2 || j == 3 || j == 5 || j == 7)
                        {
                            for (int k = 2; k <= thirdMax; k++)
                            {
                                if (k % 2 == 0)
                                {
                                    Console.WriteLine($"{i} {j} {k}");
                                }
                            }
                        }
                    }
                }
              
            }
        }
    }
}
