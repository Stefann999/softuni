using System.Text;

string encryptedText = Console.ReadLine();
StringBuilder sb = new StringBuilder();
sb.Append(encryptedText);
string[] cmdArgs = Console.ReadLine().Split('|');

while (cmdArgs[0] != "Decode")
{
	if (cmdArgs[0] == "Move")
	{
		for (int i = 0; i < int.Parse(cmdArgs[1]); i++)
		{
			sb.Append(sb[i]);
		}
		sb.Remove(0, int.Parse(cmdArgs[1]));
	}
	if (cmdArgs[0] == "Insert")
	{
		sb.Insert(int.Parse(cmdArgs[1]), cmdArgs[2]);
	}
	if (cmdArgs[0] == "ChangeAll")
	{
		sb.Replace(cmdArgs[1], cmdArgs[2]);
	}

    cmdArgs = Console.ReadLine().Split('|');
}
Console.WriteLine($"The decrypted message is: {sb}");