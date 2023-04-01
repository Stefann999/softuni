using System.Runtime.CompilerServices;

int n = int.Parse(Console.ReadLine());

Dictionary<string, List<string>> plantsInfo = new Dictionary<string, List<string>>();

for (int i = 0; i < n; i++)
{
    string[] info = Console.ReadLine().Split("<->");
    List<string> tempForNames = new List<string>() { info[1] };
    plantsInfo.Add(info[0], tempForNames);
}
string[] cmdArgs = Console.ReadLine().Split();
List<string> temp = new List<string>();

while (cmdArgs[0] != "Exhibition")
{
    if (!plantsInfo.ContainsKey(cmdArgs[1]))
    {
        Console.WriteLine("error");
        cmdArgs = Console.ReadLine().Split();
        continue;
    }

    if (cmdArgs[0] == "Rate:")
    {
        temp = plantsInfo[cmdArgs[1]];
        temp.Add(cmdArgs[3]);
      plantsInfo[cmdArgs[1]] = temp;
    }

    else if (cmdArgs[0] == "Update:")
    {
        temp = plantsInfo[cmdArgs[1]];
        temp[0] = cmdArgs[3];
        plantsInfo[cmdArgs[1]] = temp;
    }

    else if (cmdArgs[0] == "Reset:")
    {
        temp = plantsInfo[cmdArgs[1]];
        string rarityTemp = temp[0];
        temp = new List<string>();
        temp.Add(rarityTemp);
        plantsInfo[cmdArgs[1]] = temp;
    }
    cmdArgs = Console.ReadLine().Split();
}

Console.WriteLine("Plants for the exhibition:");
foreach (var item in plantsInfo)
{
    int cnt = 0;
    double sum = 0;
    double result = 0;
    if (item.Value.Count == 1)
    {
        Console.WriteLine($"- {item.Key}; Rarity: {item.Value[0]}; Rating: {result:f2}");
    }
    else
    {
        for (int i = 1; i < item.Value.Count; i++)
        {
            sum += int.Parse(item.Value[i]);
            cnt++;
        }
        result = sum / cnt;
        Console.WriteLine($"- {item.Key}; Rarity: {item.Value[0]}; Rating: {result:f2}");
    }
}