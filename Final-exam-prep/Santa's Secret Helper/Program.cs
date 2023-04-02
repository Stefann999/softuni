using System.Text;
using System.Text.RegularExpressions;

int n = int.Parse(Console.ReadLine());

string input = Console.ReadLine();

StringBuilder sb = new StringBuilder();



List<string> list = new List<string>();

while (input != "end")
{
    for (int i = 0; i < input.Length; i++)
    {

        char firstChar = input[i];
        char charToAdd = (char)(firstChar - 3);
        sb.Append(charToAdd.ToString());
    }

    string pattern = @"(@)(?<name>[A-Z][a-z]+)[^@\-!:>]*(!)(?<behaviour>[GN])(!)";

    Match match = Regex.Match(sb.ToString(), pattern);

    if (match.Success)
    {
        string name = match.Groups["name"].Value;
        string behaviour = match.Groups["behaviour"].Value;

        if (behaviour == "G")
        {
            list.Add(name);
        }
    }
    input = Console.ReadLine();
    sb.Clear();
}

foreach (var item in list)
{
    Console.WriteLine(item);
}