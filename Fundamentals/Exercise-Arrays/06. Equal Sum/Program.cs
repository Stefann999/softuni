int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

string output = "no";

for (int current = 0; current < arr.Length; current++)
{
    int leftSum = 0;
    int rightSum = 0;
    for (int i = 0; i < current; i++)
    {
        leftSum += arr[i];
    }

    for (int i = current + 1; i < arr.Length; i++)
    {
        rightSum += arr[i];
    }

    if (leftSum == rightSum)
    {
        output = current.ToString();
    }
}
    Console.WriteLine(output);