using System;

namespace _03._Courier_Express
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double boxWeight = double.Parse(Console.ReadLine());
            string type = Console.ReadLine();
            int destantion = int.Parse(Console.ReadLine());
            double price = 0;
            double kiloOverprice = 0;
            double kmOverprice = 0;

            if (type == "standard")
            {
                if (boxWeight < 1)
                {
                    price = 0.03 * destantion;
                }
                else if (boxWeight >= 1 && boxWeight < 10)
                {
                    price = 0.05 * destantion;
                }
                else if (boxWeight >= 10 && boxWeight < 40)
                {
                    price = 0.1 * destantion;
                }
                else if (boxWeight >= 40 && boxWeight < 90)
                {
                    price = 0.15 * destantion;
                }
                else if (boxWeight >= 90)
                {
                    price = 0.2 * destantion;
                }
            }
            else if (type == "express")
            {
                if (boxWeight < 1)
                {
                    kiloOverprice = 0.8 * 0.03;
                    kmOverprice = boxWeight * kiloOverprice;
                    price = 0.03 * destantion;
                    price += destantion * kmOverprice;
                }
                 if (boxWeight >= 1 && boxWeight < 10)
                {
                    kiloOverprice = 0.4 * 0.05;
                    kmOverprice = boxWeight * kiloOverprice;
                    price = 0.05 * destantion;
                    price += destantion * kmOverprice;
                }
                 if (boxWeight >= 10 && boxWeight < 40)
                {
                    kiloOverprice = 0.05 * 0.1;
                    kmOverprice = boxWeight * kiloOverprice;
                    price = 0.1 * destantion;
                    price += destantion * kmOverprice;
                }
                 if (boxWeight >= 40 && boxWeight < 90)
                {
                    kiloOverprice = 0.02 * 0.15;
                    kmOverprice = boxWeight * kiloOverprice;
                    price = 0.15 * destantion;
                    price += destantion * kmOverprice;
                }
                 if (boxWeight >= 90)
                {
                    kiloOverprice = 0.01 * 0.2;
                    kmOverprice = boxWeight * kiloOverprice;
                    price = 0.2 * destantion;
                    price += destantion * kmOverprice;
                }

               
            } Console.WriteLine($"The delivery of your shipment with weight of {boxWeight:f3} kg. would cost {price:f2} lv.");
        }          
    }
}
