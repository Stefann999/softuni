List<string> log = new List<string>();

string[] command = Console.ReadLine().Split();

while (command[0] != "end")
{
	if (command[0] == "Chat")
	{
		log.Add(command[1]);
	}
	else if (command[0] == "Delete")
	{
		if (log.Contains(command[1]))
		{
            int index = log.IndexOf(command[1]);
			log.Remove(log[index]);
		}
	}
	else if (command[0] == "Edit")
	{
		if (log.Contains(command[1]))
		{
            int index = log.IndexOf(command[1]);
			log[index] = command[2];
		}
	}
	else if (command[0] == "Pin")
	{
        int index = log.IndexOf(command[1]);
        log.Add(log[index]);
        log.Remove(log[index]);
    }
	else if (command[0] == "Spam")
	{
		for (int i = 1; i < command.Length; i++)
		{
			log.Add(command[i]);
		}
	}
	command = Console.ReadLine().Split();
}
foreach (var item in log)
{
	Console.WriteLine(item);
}