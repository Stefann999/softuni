int n = int.Parse(Console.ReadLine());
int[] sequence = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
List<int> valid = new List<int>();

int cntToBeValid = 0;

Func<int[], List<int>> func = check;
Console.WriteLine(string.Join(" ", func(sequence)));

List<int> check(int[] arg)
{
    for (int i = 1; i <= n; i++)
    {
        cntToBeValid = sequence.Length;
        int cnt = 0;

        for (int j = 0; j < sequence.Length; j++)
        {
            if (i % sequence[j] == 0)
            {
                cnt++;
            }
            if (cnt == cntToBeValid)
            {
                valid.Add(i);
            }
        }
    }
    return valid;
}

