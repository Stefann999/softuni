using System;

List<string> names = Console.ReadLine().Split(", ").ToList();

string[] command = Console.ReadLine().Split();
int blacklistedCnt = 0;
int lostCnt = 0;

while (command[0] != "Report")
{
	if (command[0] == "Blacklist")
	{
		if (names.Contains(command[1]))
		{
			int index = names.IndexOf(command[1]);
			Console.WriteLine($"{names[index]} was blacklisted.");
			names[index] = "Blacklisted";
            blacklistedCnt++;
        }
		else
		{
            Console.WriteLine($"{command[1]} was not found.");
        }

	}
	else if (command[0] == "Error")
	{
		int numAsInt = int.Parse(command[1]); 
		if (numAsInt >= 0 && numAsInt < names.Count)
		{
			if (names[numAsInt] != "Blacklisted" && names[numAsInt] != "Lost")
			{
				Console.WriteLine($"{names[numAsInt]} was lost due to an error.");
				names[numAsInt] = "Lost";
                lostCnt++;
            }
		}
	}
	else if (command[0] == "Change")
	{
        int numAsInt = int.Parse(command[1]);
        if (numAsInt >= 0 && numAsInt < names.Count)
		{
			Console.WriteLine($"{names[numAsInt]} changed his username to {command[2]}.");
			names[numAsInt] = command[2];
		}
	}
	command = Console.ReadLine().Split();
}
Console.WriteLine($"Blacklisted names: {blacklistedCnt} ");
Console.WriteLine($"Lost names: {lostCnt}");
Console.WriteLine(string.Join(" ", names));