string text = Console.ReadLine();

Dictionary<char, int> dict = new Dictionary<char, int>();

foreach (char item in text)
{
	if (item == ' ')
	{
		continue;
	}

	if (!dict.ContainsKey(item))
	{
		dict.Add(item, 0);
	}
	dict[item]++;
}
foreach (var item in dict)
{
	Console.WriteLine($"{item.Key} -> {item.Value}");
}
