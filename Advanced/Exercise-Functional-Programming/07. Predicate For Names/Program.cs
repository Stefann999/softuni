using System.Globalization;

int n = int.Parse(Console.ReadLine());
string[] names = Console.ReadLine().Split();

List<string> valid = new List<string>();

Func<string[], List<string>> checker = check;
valid = checker(names);

foreach (string name in valid)
{
    Console.WriteLine(name);
}

List<string> check(string[] names)
{
   for (int i = 0; i < names.Length; i++)
    {
        if (names[i].Length <= n)
        {
            valid.Add(names[i]);
        }
    }
   return valid;
}