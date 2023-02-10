namespace _7._NxN_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            nxnMatrix(n);

            static void nxnMatrix(int n)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        Console.Write(n);
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}