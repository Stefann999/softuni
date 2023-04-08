using System;

namespace _05._Best_Player
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            string bestPlayer = "";
            int mostGoals = int.MinValue;

            while (command != "END")
            {
                int currentGoals = int.Parse(Console.ReadLine());
                if (currentGoals >= 10)
                {
                    Console.WriteLine($"{command} is the best player!");
                    Console.WriteLine($"He has scored {currentGoals} goals and made a hat-trick !!!");
                    return;
                }

                if (currentGoals > mostGoals)
                {
                    bestPlayer = command;
                    mostGoals = currentGoals;
                }
                command = Console.ReadLine();
            }



            Console.WriteLine($"{bestPlayer} is the best player!");
            if (mostGoals >= 3)
            {
                Console.WriteLine($"He has scored {mostGoals} goals and made a hat-trick !!!");
            }
            else
            {
                Console.WriteLine($"He has scored {mostGoals} goals.");
            }
        }
    }
}
