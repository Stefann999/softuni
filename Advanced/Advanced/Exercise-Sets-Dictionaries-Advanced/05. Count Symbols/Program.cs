string text = Console.ReadLine();

SortedDictionary<char, int> info = new SortedDictionary<char, int>();

foreach (char ch in text)
{
	if (!info.ContainsKey(ch))
	{
		info.Add(ch, 0);
	}
	info[ch]++;
}

foreach (var item in info)
{
    Console.WriteLine($"{item.Key}: {item.Value} time/s");
}