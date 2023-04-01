using System.Text;

string input = Console.ReadLine();

string[] cmdArgs = Console.ReadLine().Split();

StringBuilder sb = new StringBuilder();
StringBuilder sbForOdd = new StringBuilder();
sb.Append(input);

while (cmdArgs[0] != "Done")
{
    if (cmdArgs[0] == "TakeOdd")
    {
        string temp = sb.ToString();
        sbForOdd.Append(temp);
        sb.Clear();
        for (int i = 0; i < sbForOdd.Length; i++)
        {
            if (i % 2 != 0)
            {
                sb.Append(sbForOdd[i]);
            }
        }
        sbForOdd.Clear();

    }
    else if (cmdArgs[0] == "Cut")
    {
        if (int.Parse(cmdArgs[1]) > sb.Length)
        {
            cmdArgs = Console.ReadLine().Split();
            continue;
        }

        int asd = int.Parse(cmdArgs[1]) + int.Parse(cmdArgs[2]);
        int lenght = int.Parse(cmdArgs[2]);
        if (sb.Length < asd)

        {
            lenght = asd - sb.Length - 1;
        }
        sb.Remove(int.Parse(cmdArgs[1]), lenght);
    }
    else if (cmdArgs[0] == "Substitute")
    {
        string sbToString = sb.ToString();
        if (!sbToString.Contains(cmdArgs[1]))
        {
            Console.WriteLine("Nothing to replace!");
            cmdArgs = Console.ReadLine().Split();
            continue;
        }
        else
        {
            sb.Replace(cmdArgs[1], cmdArgs[2]);
        }
    }
    Console.WriteLine(sb);
    cmdArgs = Console.ReadLine().Split();
}

Console.WriteLine($"Your password is: {sb}");