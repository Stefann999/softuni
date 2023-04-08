using System;

namespace _04._Grandpa_Stavri
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            double sumLitres = 0;
            double sumDegrees = 0;


            for (int i = 1; i <= days; i++)
            {
                double liters = double.Parse(Console.ReadLine());
                double degrees = double.Parse(Console.ReadLine());

                sumLitres += liters;
                sumDegrees += liters * degrees;
            }

            double averageDegrees = sumDegrees / sumLitres;
            Console.WriteLine($"Liter: {sumLitres:f2}");
            Console.WriteLine($"Degrees: {averageDegrees:f2}");
            if (averageDegrees < 38)
            {
                Console.WriteLine($"Not good, you should baking!");
            }
            else if (averageDegrees >=38 && averageDegrees <= 42)
            {
                Console.WriteLine($"Super!");
            }
            else if (averageDegrees > 42)
            {
                Console.WriteLine($"Dilution with distilled water!");
            }
        }
    }
}
