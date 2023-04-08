using System.Text;
using System.Text.RegularExpressions;

int n = int.Parse(Console.ReadLine());

Dictionary<string, byte[]> info = new Dictionary<string, byte[]>();

string pattern = @"(!)(?<command>[A-Z][a-z]{3,})\1(:)([)([A-Za-z]{8,})(])";

for (int i = 0; i < n; i++)
{
    string text = Console.ReadLine();

    Match match = Regex.Match(text, pattern);

    if (match.Success)
    {
        string command = match.Groups["command"].Value;

        string message = match.Groups[3].Value;
        message = message.Remove(0, 1);
        byte[] ASCIIValues = Encoding.ASCII.GetBytes(message);

        info.Add(command, ASCIIValues);


        foreach (var item in info)
        {
            Console.WriteLine($"{item.Key}: {string.Join(" ", item.Value)}");
        }


    }
    else
    {
        Console.WriteLine("The message is invalid");
    }

}