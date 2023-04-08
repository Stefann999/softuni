using System.Security.Principal;
using System.Text.RegularExpressions;

int n = int.Parse(Console.ReadLine());
string input = Console.ReadLine();

string pattern = @"(@)(#)+(?<first>[A-Z])(?<second>[A-Za-z-0-9]{4,})(?<third>[A-Z])\1(#)+$";

for (int i = 0; i < n; i++)
{
    Match match = Regex.Match(input, pattern);

    if (match.Success)
    {
        string firstGroup = match.Groups["first"].Value;
        string secondGroup = match.Groups["second"].Value;
        string thirdGroup = match.Groups["third"].Value;

        List<int> nums = new List<int>();

        int asInt = 0;
        if (char.IsDigit(firstGroup[0]))
        {
            asInt = int.Parse(firstGroup[0].ToString());
            nums.Add(asInt);
        }
        for (int j = 0; j < secondGroup.Length; j++)
        {
            if (char.IsDigit(secondGroup[j]))
            {
                asInt = int.Parse(secondGroup[j].ToString());
                nums.Add(asInt);
            }
        }
        if (char.IsDigit(thirdGroup[0]))
        {
            asInt = int.Parse(thirdGroup[0].ToString());
            nums.Add(asInt);
        }

        if (nums.Count == 0)
        {
            Console.WriteLine("Product group: 00");
        }
        else
        {
            Console.WriteLine($"Product group: {string.Join(string.Empty, nums)}");
        }

        nums = new List<int>();
        input = Console.ReadLine();
    }
    else
    {
        Console.WriteLine("Invalid barcode");
        input = Console.ReadLine();
    }
}