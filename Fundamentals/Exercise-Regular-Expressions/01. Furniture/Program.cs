using System;
using System.Text.RegularExpressions;

string input = Console.ReadLine();

List<string> furnitureNames = new List<string>();
string pattern = @">>(?<name>[A-Z-a-z]+)<<(?<price>\d+(\.\d+)?)!(?<quantity>\d+)";

decimal totalSpend = 0;

while (input != "Purchase")
{
    MatchCollection matchCollection = Regex.Matches(input, pattern);
    foreach (Match match in matchCollection)
    {
        var groups = match.Groups;

        string priceStr = groups["price"].Value;
        decimal price = decimal.Parse(priceStr);
        string quantityStr = groups["quantity"].Value;
        int quantity = int.Parse(quantityStr);

        decimal finalPrice = price * quantity;
        furnitureNames.Add(groups["name"].Value);

        totalSpend += finalPrice;
    }

    input = Console.ReadLine();
}

Console.WriteLine("Bought furniture:");
foreach (var item in furnitureNames)
{
    Console.WriteLine(item);
}
Console.WriteLine($"Total money spend: {totalSpend:f2}");