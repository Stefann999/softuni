using System.Text.RegularExpressions;

string text = Console.ReadLine();

string pattern = @"(#|\|)([A-Za-z]+\s*?[A-Za-z]+?)\1(\d{2}/\d{2}/\d{2})\1(\d{1,5})\1";

MatchCollection matchCollection = Regex.Matches(text, pattern);

int calories = 0;

foreach (Match match in matchCollection)
{
    calories += int.Parse(match.Groups[4].Value);
}

int daysLeft = calories / 2000;

Console.WriteLine($"You have food to last you for: {daysLeft} days!");

foreach (Match match in matchCollection)
{
    Console.WriteLine($"Item: {match.Groups[2]}, Best before: {match.Groups[3]}, Nutrition: {match.Groups[4]}");
}