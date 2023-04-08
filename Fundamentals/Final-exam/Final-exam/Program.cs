using System.Text;

string input = Console.ReadLine();

string[] cmdArgs = Console.ReadLine().Split();
string text = input;

StringBuilder sbForUpper = new StringBuilder();
StringBuilder sbForLower = new StringBuilder();

while (cmdArgs[0] != "Finish")
{
	if (cmdArgs[0] == "Replace")
	{
		text = text.Replace(cmdArgs[1], cmdArgs[2]);
		Console.WriteLine(text);
	}

	else if (cmdArgs[0] == "Cut")
	{
		int startIndex = int.Parse(cmdArgs[1]);
		int endIndex = int.Parse(cmdArgs[2]);
		int lenght = endIndex - startIndex;
		lenght += 1;

		if (startIndex >= 0 && startIndex < text.Length && endIndex >= 0 && endIndex < text.Length)
		{
			text = text.Remove(startIndex, lenght);
			Console.WriteLine(text);
		}
		else
		{
			Console.WriteLine("Invalid indices!");
            cmdArgs = Console.ReadLine().Split();
            continue;
        }
	}

	else if (cmdArgs[0] == "Make")
	{
		if (cmdArgs[1] == "Upper")
		{
			sbForUpper.Append(text);
			for (int i = 0; i < text.Length; i++)
			{
				sbForUpper[i] = char.ToUpper(text[i]);
			}
			text = sbForUpper.ToString();
			sbForUpper.Clear();
			Console.WriteLine(text);
		}
		else if (cmdArgs[1] == "Lower")
		{
			sbForLower.Append(text);
			for (int i = 0; i < text.Length; i++)
			{
				sbForLower[i] = char.ToLower(text[i]);
			}
			text = sbForLower.ToString();
			sbForLower.Clear();
			Console.WriteLine(text);
		}
	}

	else if (cmdArgs[0] == "Check")
	{
		if (text.Contains(cmdArgs[1]))
		{
			Console.WriteLine($"Message contains {cmdArgs[1]}");
		}
		else
		{
			Console.WriteLine($"Message doesn't contain {cmdArgs[1]}");
		}
	}

	else if (cmdArgs[0] == "Sum")
	{

		int startIndex = int.Parse(cmdArgs[1]);
		int endIndex = int.Parse(cmdArgs[2]);
		int lenght = endIndex - startIndex;
		lenght += 1;

		int substringSum = 0;

		if (startIndex >= 0 && startIndex < text.Length && endIndex >= 0 && endIndex < text.Length)
		{
			string substring = text.Substring(startIndex, lenght);

			for (int i = 0; i < substring.Length; i++)
			{
				substringSum += substring[i];
			}
			Console.WriteLine(substringSum);
		}
		else
		{
			Console.WriteLine("Invalid indices!");
            cmdArgs = Console.ReadLine().Split();
			continue;
        }

	}


    cmdArgs = Console.ReadLine().Split();
}