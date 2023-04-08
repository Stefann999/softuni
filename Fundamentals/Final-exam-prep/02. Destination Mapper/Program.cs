using System.Runtime;
using System.Text.RegularExpressions;

string input = Console.ReadLine();
string pattern = @"(=|/)[A-Z][A-Za-z]{2,}\1";
Regex regex = new Regex(pattern);

MatchCollection MatchCollection = Regex.Matches(input, pattern);
List<string> countryNames = new List<string>();

int pointsCnt = 0;

foreach (Match match in MatchCollection)
{
    countryNames.Add(match.Value.Trim('=').Trim('/'));
}
foreach (var item in countryNames)
{
    for (int i = 0; i < item.Length; i++)
    {
        pointsCnt++;
    }
}

Console.WriteLine($"Destinations: {string.Join(", ", countryNames)}");
Console.WriteLine($"Travel Points: {pointsCnt}");