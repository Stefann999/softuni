Dictionary<string, int> miner = new Dictionary<string, int>();

while (true)
{
    string resource = Console.ReadLine();
    if (resource == "stop")
    {
        break;
    }

    int quantity = int.Parse(Console.ReadLine());

    if (!miner.ContainsKey(resource))
   {
      miner.Add(resource, 0);
   }

    miner[resource] += quantity;
}

foreach (var item in miner)
{
    Console.WriteLine($"{item.Key} -> {item.Value}");
}