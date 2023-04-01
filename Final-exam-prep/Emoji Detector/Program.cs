using System.Numerics;
using System.Text.RegularExpressions;

string input = Console.ReadLine();

string pattern = @"(::|\*\*)[A-Z][a-z]{2,}\1";

MatchCollection MatchCollection = Regex.Matches(input, pattern);

BigInteger coolThreshold = 1;

for (int i = 0; i < input.Length; i++)
{
	if (char.IsDigit(input[i]))
	{
		coolThreshold *= int.Parse(input[i].ToString());
	}
}

Dictionary<string, int> coolEmojis = new Dictionary<string, int>();

foreach (Match match in MatchCollection)
{
	int sum = 0;
	string temp = match.Value;

	for (int i = 2; i < match.Length - 2; i++)
	{
		sum += temp[i];
	}
	if (sum >= coolThreshold)
	{
		coolEmojis.Add(match.Value, sum);
	}
}
Console.WriteLine($"Cool threshold: {coolThreshold}");
Console.WriteLine($"{MatchCollection.Count} emojis found in the text. The cool ones are:");
foreach (var item in coolEmojis)
{
	Console.WriteLine(item.Key);
}