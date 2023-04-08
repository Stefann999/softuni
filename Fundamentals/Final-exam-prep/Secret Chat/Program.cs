using System.Text;

string input = Console.ReadLine();

string[] cmdArgs = Console.ReadLine().Split(":|:");

StringBuilder sb = new StringBuilder(input);

while (cmdArgs[0] != "Reveal")
{
	if (cmdArgs[0] == "InsertSpace")
	{
		string sbAsString = sb.ToString();
		int index = int.Parse(cmdArgs[1]);
		string toAppend = Insert(sbAsString, index);
		sb.Clear();
		sb.Append(toAppend);
        cmdArgs = Console.ReadLine().Split(":|:");

    }

	else if (cmdArgs[0] == "Reverse")
	{
		string sbToString = sb.ToString();
		string toAppend = Reverse(sbToString, cmdArgs);
		sb.Clear();
		sb.Append(toAppend);
        cmdArgs = Console.ReadLine().Split(":|:");

    }

	else if (cmdArgs[0] == "ChangeAll")
	{
		string sbAsString = sb.ToString();
		string toAppend = ChangeAll(sbAsString, cmdArgs);
		sb.Clear();
		sb.Append(toAppend);
        cmdArgs = Console.ReadLine().Split(":|:");

    }
	Console.WriteLine(sb);
}

Console.WriteLine($"You have a new text message: {sb}");



static string Insert(string text, int index)
{
	text = text.Insert(index, " ");

	return text;
}

static string Reverse(string fullText, string[] cmdArgs)
{
	if (fullText.Contains(cmdArgs[1]))
	{
        int stringLenght = cmdArgs[1].Length;
        int firstIndex = fullText.IndexOf(cmdArgs[1]);
        fullText = fullText.Remove(firstIndex, stringLenght);
        string reversed = new string(cmdArgs[1].Reverse().ToArray());
        fullText = fullText.Insert(firstIndex, reversed);

        return fullText;
    }
	else
	{
        Console.WriteLine("error");
        cmdArgs = Console.ReadLine().Split(":|:");
        return fullText;
    }
	
}

static string ChangeAll(string text, string[] cmdArgs)
{
    text = text.Replace(cmdArgs[1], cmdArgs[2]);
    return text;
}