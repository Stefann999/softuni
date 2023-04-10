using System.Reflection.Metadata.Ecma335;

int n = int.Parse(Console.ReadLine());

List<string> list = new List<string>();

for (int i = 0; i < n; i++)
{
    string name = Console.ReadLine();
    if (!list.Contains(name))
    {
        list.Add(name);
    }
}

foreach (string name in list)
{
    Console.WriteLine(name);
}