int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
for (int i = 0; i < arr.Length - 1; i++)
{
    bool isTop = true;

    for (int j = i + 1; j < arr.Length; j++)

    if (arr[i] <= arr[j])
    {
        isTop = false;
    }
    if (isTop)
    {
        Console.Write(arr[i] + " ");
    }
}
Console.WriteLine(arr[arr.Length - 1]);