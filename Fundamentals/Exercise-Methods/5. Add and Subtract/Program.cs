using System.Diagnostics.CodeAnalysis;

namespace _5._Add_and_Subtract
{
    internal class Program
    {
        static void Main(string[] args)
        {
          
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int thirdNum = int.Parse(Console.ReadLine());

            int sum = add(firstNum, secondNum);
            int substractionResult = substract(sum, thirdNum);
            Console.WriteLine(substractionResult);

            add(firstNum, secondNum);

            static int add(int first, int second)
            {
                int sum = first + second;
                return sum;
            }

            static int substract(int sum, int third)
            {
                int subst = sum - third;
                return subst;
            }
        }
    }
}