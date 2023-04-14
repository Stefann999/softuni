int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

Func<int[], int> function = GetMinNumber;

Console.WriteLine(function(numbers));

int GetMinNumber(int[] arg)
{
    int minNum = int.MaxValue;

    for (int i = 0; i < arg.Length; i++)
    {
        if (arg[i] < minNum)
        {
            minNum = arg[i];
        }
    }

    return minNum;
}