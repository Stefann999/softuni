namespace _1._Smallest_of_Three_Number
{
    internal class Program
    {
        static void Main()
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int thirdNum = int.Parse(Console.ReadLine());

            minNumFinding(firstNum, secondNum, thirdNum);


            static void minNumFinding(int firstNum, int secondNum, int thirdNum)
            {
                int minNum = int.MaxValue;

                if (firstNum < secondNum && firstNum < thirdNum)
                {
                    Console.WriteLine(firstNum);
                }
                else if (secondNum < firstNum && secondNum < thirdNum)
                {
                    Console.WriteLine(secondNum);
                }
                else if (thirdNum < firstNum && thirdNum < secondNum)
                {
                    Console.WriteLine(thirdNum);
                }
            }
        }
    }
}