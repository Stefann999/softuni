string[] input = Console.ReadLine().Split("||");

Dictionary<string, string[]> info = new Dictionary<string, string[]>();

while (input[0] != "Sail")
{
	if (!info.ContainsKey(input[0]))
	{
		string[] temp = new string[] { input[1], input[2] };
		info.Add(input[0], temp);
        input = Console.ReadLine().Split("||");
		continue;
    }
	string[] updating = info[input[0]];

	int populationIncreasing = int.Parse(input[1]);
	int oldPopulation = int.Parse(updating[0]);
	int newPopulation = oldPopulation + populationIncreasing;
	updating[0] = newPopulation.ToString();

	int goldIncreasing = int.Parse(input[2]);
	int oldGold = int.Parse(updating[1]);
	int newGold = oldGold + goldIncreasing;
	updating[1] = newGold.ToString();
	info[input[0]] = updating;

    input = Console.ReadLine().Split("||");
}

string[] cmdArgs = Console.ReadLine().Split("=>");

while (cmdArgs[0] != "End")
{
	if (cmdArgs[0] == "Plunder")
	{
		Console.WriteLine($"{cmdArgs[1]} plundered! {cmdArgs[3]} gold stolen, {cmdArgs[2]} citizens killed.");

		string[] temp = info[cmdArgs[1]];

        int populationLeft = int.Parse(temp[0]) - int.Parse(cmdArgs[2]);
        int goldLeft = int.Parse(temp[1]) - int.Parse(cmdArgs[3]);

		temp[0] = populationLeft.ToString();
		temp[1] = goldLeft.ToString();
		info[cmdArgs[1]] = temp;

        if (goldLeft <= 0 || populationLeft <= 0)
        {
            Console.WriteLine($"{cmdArgs[1]} has been wiped off the map!");
            info.Remove(cmdArgs[1]);
        }
    }

	else if (cmdArgs[0] == "Prosper")
	{
		if (int.Parse(cmdArgs[2]) < 0)
		{
			Console.WriteLine("Gold added cannot be a negative number!");
            cmdArgs = Console.ReadLine().Split("=>");
			continue;
        }
		string[] temp = info[cmdArgs[1]];

		int currGold = int.Parse(temp[1]);
		int newGold = currGold + int.Parse(cmdArgs[2]);
		int goldAdded = newGold - currGold;

		Console.WriteLine($"{goldAdded} gold added to the city treasury. {cmdArgs[1]} now has {newGold} gold.");
		temp[1] = newGold.ToString();
		info[cmdArgs[1]] = temp;
	}

    cmdArgs = Console.ReadLine().Split("=>");
}

if (info.Count > 0)
{
    Console.WriteLine($"Ahoy, Captain! There are {info.Count} wealthy settlements to go to:");

    foreach (var item in info)
	{
		Console.WriteLine($"{item.Key} -> Population: {item.Value[0]} citizens, Gold: {item.Value[1]} kg");
    }
}
else
{
	Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
}