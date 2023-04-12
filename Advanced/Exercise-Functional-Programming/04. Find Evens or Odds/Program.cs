int[] bounds = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

List<int> numbers = new();

for (int i = bounds[0]; i <= bounds[1]; i++)
{
    numbers.Add(i);
}

string command = Console.ReadLine();

if (command.ToLower() == "even")
{
    Predicate<int> forEven = x => x % 2 == 0;
    List<int> evenNums = numbers.FindAll(forEven);
    Console.WriteLine(string.Join(" ", evenNums));
}

else if (command.ToLower() == "odd")
{
    Predicate<int> forOdd = x => x % 2 == 1 || x % 2 == -1;
    List<int> oddNums = numbers.FindAll(forOdd);
    Console.WriteLine(string.Join(" ", oddNums));
}