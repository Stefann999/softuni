using Telephony.Models;

string[] phoneNumbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
string[] URLS = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

foreach (string number in phoneNumbers)
{
    if (!number.All(c => char.IsDigit(c)))
    {
        Console.WriteLine("Invalid number!");
        continue;
    }
    else
    {
        if (number.Length == 7)
        {
            Stationaryphone stationaryphone = new();
            Console.WriteLine(stationaryphone.Dialing(number));
        }
        else
        {
            Smatphone smatphone = new Smatphone();
            Console.WriteLine(smatphone.Calling(number));
        }
    }
}

foreach (string url in URLS)
{
    if (url.All(c => char.IsDigit(c)))
    {
        Console.WriteLine("Invalid URL!");
    }
    else
    {
        Smatphone smatphone = new Smatphone();
        Console.WriteLine(smatphone.Browsing(url));
    }
}