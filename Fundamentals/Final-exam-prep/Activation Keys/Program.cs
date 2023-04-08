using System.Text;

string input = Console.ReadLine();

string[] cmdArgs = Console.ReadLine().Split(">>>");


while (cmdArgs[0] != "Generate")
{
	if (cmdArgs[0] == "Contains")
	{
		Contains(input, cmdArgs[1]);
        cmdArgs = Console.ReadLine().Split(">>>");
        continue;
    }

	else if (cmdArgs[0] == "Flip")
	{
		input = Flip(input, cmdArgs);
        cmdArgs = Console.ReadLine().Split(">>>");
		continue;
    }

	else if (cmdArgs[0] == "Slice")
	{
		input = Slice(input, cmdArgs);
        cmdArgs = Console.ReadLine().Split(">>>");
        continue;
    }
}
Console.WriteLine($"Your activation key is: {input}");



static void Contains(string key, string substring)
{
	if (key.Contains(substring))
	{
		Console.WriteLine($"{key} contains {substring}");
	}
	else
	{
		Console.WriteLine("Substring not found!");
	}
}

static string Flip(string key, string[] cmds)
{
	int startIndex = int.Parse(cmds[2]);
	int lenght = int.Parse(cmds[3]) - startIndex;
	string substring = key.Substring(startIndex, lenght);
	key = key.Remove(startIndex, lenght);

	if (cmds[1] == "Upper")
	{
		substring = substring.ToUpper();
	}
	else if (cmds[1] == "Lower")
	{
		substring = substring.ToLower();
	}

	key = key.Insert(startIndex, substring);
	Console.WriteLine(key);
	return key;
}

static string Slice(string key, string[] cmds)
{
	int startIndex = int.Parse(cmds[1]);
	int endIndex = int.Parse(cmds[2]) - startIndex;

	key = key.Remove(startIndex, endIndex);
	Console.WriteLine(key);
	return key;
}