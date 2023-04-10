int n = int.Parse(Console.ReadLine());

Dictionary<int, int> info = new Dictionary<int, int>();

for (int i = 0; i < n; i++)
{
	int currNum = int.Parse(Console.ReadLine());

	if (!info.ContainsKey(currNum))
	{
		info.Add(currNum, 0);
	}
	info[currNum]++;
}

Console.WriteLine(info.Where(x => x.Value % 2 == 0).Select(y => y.Key).First());