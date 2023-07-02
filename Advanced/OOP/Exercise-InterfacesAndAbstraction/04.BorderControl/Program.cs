using _04.BorderControl.Models;

int n = int.Parse(Console.ReadLine());

List<IBuyer> buyers = new List<IBuyer>();

for (int i = 0; i < n; i++)
{
    string[] info = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

    if (info.Length == 4)
    {
        Citizen citizen = new Citizen(info[0], int.Parse(info[1]), info[2], info[3]);
        buyers.Add(citizen);
    }
    else 
    {
        Rebel rebel = new Rebel(info[0], int.Parse(info[1]), info[2]);
        buyers.Add(rebel);
    }

}

while (true)
{
    string input = Console.ReadLine();

    if (input == "End")
    {
        break;
    }

    foreach (var buyer in buyers)
    {
       if (buyers.Any(x => x.Name == input))
       {
            buyers.FirstOrDefault(x => x.Name == input).BuyFood();
            break;
       }
    }
}

Console.WriteLine(buyers.Sum(b => b.Food));