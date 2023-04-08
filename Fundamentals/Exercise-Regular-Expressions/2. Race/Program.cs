using System;
using System.Text.RegularExpressions;

string[] participants = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

Dictionary<string, int> info = new Dictionary<string, int>();

foreach (string participant in participants)
{
    info.Add(participant, 0);
}
string input = Console.ReadLine();

while (input != "end of race")
{
    MatchCollection nameRegexColl = Regex.Matches(input, @"([A-Z-a-z]+)");
    MatchCollection distRegexColl = Regex.Matches(input, @"(\d)");

    string name = string.Join(string.Empty, nameRegexColl);
    if (info.ContainsKey(name))
    {
        info[name] += distRegexColl.Select(x => int.Parse(x.Value)).Sum();
    }
    input = Console.ReadLine();
}
var topThree = info.OrderByDescending(x => x.Value).Take(3);
int counter = 1;

foreach (var item in topThree)
{
    string suffix = counter == 1 ? "st" : counter == 2 ? "nd" : "rd";
    Console.WriteLine($"{counter++}{suffix} place: {item.Key}");
}