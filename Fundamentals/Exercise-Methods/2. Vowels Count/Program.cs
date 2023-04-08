namespace _2._Vowels_Count
{
    internal class Program
    {
        static void Main()
        {
            string word = Console.ReadLine();
            int vowelCnt = vowelCounter(word);
            Console.WriteLine(vowelCnt);


            static int vowelCounter(string text)
            {
                char[] vowels = new char[] { 'a', 'e', 'o', 'u', 'i', 'y'};

                int vowelCnt = 0;

                foreach (char letter in text.ToLower())
                {
                    if (vowels.Contains(letter))
                    {
                        vowelCnt++;
                    }
                }
                return vowelCnt;
            }

        }
    }
}