using System.Reflection.Metadata.Ecma335;

namespace _6._Middle_Characters
{
    internal class Program
    {
        static void Main(string[] args)
        {
           string text = Console.ReadLine();
            
            middleCharFinder(text);


            static void middleCharFinder(string text)
            {
                int lenght = text.Length;

                if (lenght % 2 == 0)
                {
                    int firstIndex = lenght / 2 - 1;
                    int secondIndex = lenght / 2;


                    Console.WriteLine($"{text[firstIndex]}{text[secondIndex]}");
                }
                else
                {
                    double n = lenght / 2 - 0.5;
                    int index = (int)n;
                    Console.WriteLine(text[index]);
                }
            }
        }
    }
}