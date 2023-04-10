int n = int.Parse(Console.ReadLine());

SortedSet<string> elements = new SortedSet<string>();

for (int i = 0; i < n; i++)
{
    string[] currElements = Console.ReadLine().Split();

    for (int j = 0; j < currElements.Length; j++)
    {
        elements.Add(currElements[j]);
    }
}

Console.WriteLine(string.Join(" ", elements));