using System;

namespace _01._Excursion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int peopleCnt = int.Parse(Console.ReadLine());
            int nightsCnt = int.Parse(Console.ReadLine());
            int transportCards = int.Parse(Console.ReadLine());
            int ticketsCnt = int.Parse(Console.ReadLine());

            double nightsPerPerson = nightsCnt * 20;
            double transportCardsPerPerson = transportCards * 1.60;
            double ticketsPerPerson = ticketsCnt * 6;

            double sumForOnePerson = nightsPerPerson + transportCardsPerPerson + ticketsPerPerson;
            double sumForAllPeople = sumForOnePerson * peopleCnt;
            double finalPrice = sumForAllPeople + (sumForAllPeople * 0.25);

            Console.WriteLine($"{finalPrice:f2}");
        }
    }
}
