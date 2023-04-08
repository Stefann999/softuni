int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

string[] command = Console.ReadLine().Split();

while (command[0] != "end")
{
	if (command[0] == "swap")
	{
		int firstIndex = int.Parse(command[1]);
		int secondIndex = int.Parse(command[2]);

		int temp = nums[firstIndex];

		nums[firstIndex] = nums[secondIndex];
		nums[secondIndex] = temp;
	}
	if (command[0] == "multiply")
	{
		int firstIndex = int.Parse(command[1]);
		int secondIndex = int.Parse(command[2]);

		nums[firstIndex] = nums[firstIndex] * nums[secondIndex];
    }
	if (command[0] == "decrease")
	{ 
		for (int i = 0; i < nums.Length; i++)
		{
			nums[i] = nums[i] - 1;
		}
	}
	command = Console.ReadLine().Split();
}
Console.WriteLine(string.Join(", ", nums));