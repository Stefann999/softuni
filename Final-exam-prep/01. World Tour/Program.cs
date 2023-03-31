using System.Text;

string stops = Console.ReadLine();

string[] cmdArgs = Console.ReadLine().Split(':', StringSplitOptions.RemoveEmptyEntries);
StringBuilder sb = new StringBuilder();
sb.Append(stops);

while (cmdArgs[0] != "Travel")
{
	if (cmdArgs[0] == "Add Stop")
	{
		if (int.Parse(cmdArgs[1]) >= 0 && int.Parse(cmdArgs[1]) <= sb.Length)
		{
			string stop = cmdArgs.Last();
			sb.Insert(int.Parse(cmdArgs[1]), stop);
		}
	}
	else if (cmdArgs[0] == "Remove Stop")
	{
		if (int.Parse(cmdArgs[1]) >= 0 && int.Parse(cmdArgs[1]) < sb.Length && int.Parse(cmdArgs[2]) >= 0 && int.Parse(cmdArgs[2]) < sb.Length)
		{
			if (int.Parse(cmdArgs[1]) <= int.Parse(cmdArgs[2]))
			{
                int lenght = int.Parse(cmdArgs[2]) - int.Parse(cmdArgs[1]) + 1;
                sb.Remove(int.Parse(cmdArgs[1]), lenght);
            }
		}
	}
	else if (cmdArgs[0] == "Switch")
	{
			 sb.Replace(cmdArgs[1], cmdArgs[2]);
	}

    Console.WriteLine(sb);
    cmdArgs = Console.ReadLine().Split(':',StringSplitOptions.RemoveEmptyEntries);
}
Console.WriteLine($"Ready for world tour! Planned stops: {sb}");