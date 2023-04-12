int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
int n = int.Parse(Console.ReadLine());

List<int> numsForPrint = new();

Func<int[], List<int>> checker = check;
string forPrint = string.Join(" ", checker(input));
Console.WriteLine(forPrint);

List<int> check(int[] nums)
{
    for (int i = 0; i < nums.Length; i++)
    {
        if (nums[i] % n != 0)
        {
            numsForPrint.Add(nums[i]);
        }
    }
    numsForPrint.Reverse();
    return numsForPrint;
}