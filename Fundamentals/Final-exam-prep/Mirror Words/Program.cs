using System.Text.RegularExpressions;

string text = Console.ReadLine();

string pattern = @"(@|#)([A-Za-z]{3,})\1\1([A-Za-z]{3,})\1";

List<string> validPairs = new List<string>();

MatchCollection matches = Regex.Matches(text, pattern);

foreach (Match match in matches)
{
    string firstWord = match.Groups[2].Value;
    string secondWord = match.Groups[3].Value;
    string reversedSecondWord = new string(secondWord.Reverse().ToArray());

    if (firstWord == reversedSecondWord)
    {
        validPairs.Add($"{firstWord} <=> {secondWord}");
    }
}
if (matches.Count == 0)
{
    Console.WriteLine("No word pairs found!");
}
else 
{
    Console.WriteLine($"{matches.Count} word pairs found!");
}
if (validPairs.Count == 0)
{
    Console.WriteLine("No mirror words!");
}
else
{
    Console.WriteLine("The mirror words are:");
    Console.WriteLine(string.Join(", ", validPairs));
}