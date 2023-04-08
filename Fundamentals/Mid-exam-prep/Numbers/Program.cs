
List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

double avg = Queryable.Average(numbers.AsQueryable());
List<int> overAvg = new List<int>();

for (int i = 0; i < numbers.Count; i++)
{
	if (numbers[i] > avg)
	{
		overAvg.Add(numbers[i]);
	}
}
int numsCnt = overAvg.Count();

if (numsCnt < 5 && numsCnt > 0)
{
	overAvg.Sort();
	overAvg.Reverse();
	foreach (var item in overAvg)
	{
		Console.Write(item + " ");
	}
}
else if (numsCnt >= 5)
{
	overAvg.Sort();
	overAvg.Reverse();
	
	for (int i = 0; i < 5; i++)
	{
		Console.Write(overAvg[i] + " ");
	}
}
else if (numsCnt == 0)
{
	Console.WriteLine("No");
}