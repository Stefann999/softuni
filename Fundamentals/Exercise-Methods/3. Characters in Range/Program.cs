namespace _3._Characters_in_Range
{
    internal class Program
    {
        static void Main(string[] args)
        {
          char first = char.Parse(Console.ReadLine());
          char second = char.Parse(Console.ReadLine());

          charFinder(first, second);


            static void charFinder(char start, char end)
            {
                if (start > end)
                {
                    char temp = end;
                    end = start;
                    start = temp;
                }

                for (int i = start + 1; i < end; i++)
                {
                    Console.Write((char)i + " ");
                }
            }
        }
    }
}