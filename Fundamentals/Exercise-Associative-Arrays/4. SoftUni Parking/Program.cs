int numOfCommands = int.Parse(Console.ReadLine());

Dictionary<string, string> userData = new Dictionary<string, string>();

for (int i = 0; i < numOfCommands; i++)
{
    string[] commandArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

	if (commandArgs[0] == "register")
	{
		if (!userData.ContainsKey(commandArgs[1]))
		{
			userData.Add(commandArgs[1], commandArgs[2]);
			Console.WriteLine($"{commandArgs[1]} registered {commandArgs[2]} successfully");
		}
		else
		{
			Console.WriteLine($"ERROR: already registered with plate number {commandArgs[2]}");
		}
	}
	else if (commandArgs[0] == "unregister")
	{
		if (!userData.ContainsKey(commandArgs[1]))
		{
			Console.WriteLine($"ERROR: user {commandArgs[1]} not found");
		}
		else
		{
			Console.WriteLine($"{commandArgs[1]} unregistered successfully");
			userData.Remove(commandArgs[1]);
		}
	}
}

foreach (var item in userData)
{
	Console.WriteLine($"{item.Key} => {item.Value}");
}