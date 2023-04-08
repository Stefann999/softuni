Dictionary<string, List<string>> companyInfo = new Dictionary<string, List<string>>();
string[] cmdArgs = Console.ReadLine().Split(" -> ");

while (cmdArgs[0] != "End")
{
	if (!companyInfo.ContainsKey(cmdArgs[0]))
	{
		List<string> ids = new List<string>();
		ids.Add(cmdArgs[1]);
		companyInfo[cmdArgs[0]] = ids;
	}
	else if (companyInfo.ContainsKey(cmdArgs[0]))
	{
		List<string> temp = companyInfo[cmdArgs[0]];
		bool isThere = false;

		if (temp.Contains(cmdArgs[1]))
		{
			isThere = true;
		}
		if (isThere)
		{
            cmdArgs = Console.ReadLine().Split(" -> ");
			continue;
        }
		else
		{
			temp.Add(cmdArgs[1]);
			companyInfo[cmdArgs[0]] = temp;
		}

	}
    cmdArgs = Console.ReadLine().Split(" -> ");
}

foreach (var company in companyInfo)
{
	Console.WriteLine($"{company.Key}");
	for (int i = 0; i < company.Value.Count; i++)
	{
		Console.WriteLine($"-- {company.Value[i]}");

    }
}