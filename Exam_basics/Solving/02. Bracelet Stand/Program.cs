using System;

namespace _02._Bracelet_Stand
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double dailyMoney = double.Parse(Console.ReadLine());
            double dailyIncome = double.Parse(Console.ReadLine());
            double outcomeForWholePeriod = double.Parse(Console.ReadLine());
            double giftPrice = double.Parse(Console.ReadLine());

            double incomeFromDailyMoney = 5 * dailyMoney;
            double incomeFromIncome = 5 * dailyIncome;

            double savedMoney = (incomeFromDailyMoney + incomeFromIncome) - outcomeForWholePeriod;

            if (savedMoney >= giftPrice)
            {
                Console.WriteLine($"Profit: {savedMoney:f2} BGN, the gift has been purchased.");
            }
            else
            {
                double neededMoney = giftPrice - savedMoney;
                Console.WriteLine($"Insufficient money: {neededMoney:f2} BGN.");
            }


        }
    }
}
