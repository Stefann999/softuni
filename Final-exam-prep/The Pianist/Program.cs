using System.Diagnostics;

int n = int.Parse(Console.ReadLine());
Dictionary<string, string[]> allInfo = new Dictionary<string, string[]>();


for (int i = 0; i < n; i++)
{
    string[] info = Console.ReadLine().Split('|');
    string piece = info[0];
    string composer = info[1];
    string key = info[2];
    string[] data = new string[] { composer, key };
    allInfo.Add(piece, data);
}

string[] cmdArgs = Console.ReadLine().Split('|');

while (cmdArgs[0] != "Stop")
{
    if (cmdArgs[0] == "Add")
    {
        if (allInfo.ContainsKey(cmdArgs[1]))
        {
            Console.WriteLine($"{cmdArgs[1]} is already in the collection!");
            cmdArgs = Console.ReadLine().Split('|');
            continue;
        }
        string newPiece = cmdArgs[1];
        string[] newInfo = new string[] { cmdArgs[2], cmdArgs[3] };
        allInfo.Add(newPiece, newInfo);
        Console.WriteLine($"{cmdArgs[1]} by {cmdArgs[2]} in {cmdArgs[3]} added to the collection!");
    }
    else if (cmdArgs[0] == "Remove")
    {
        if (!allInfo.ContainsKey(cmdArgs[1]))
        {
            Console.WriteLine($"Invalid operation! {cmdArgs[1]} does not exist in the collection.");
            cmdArgs = Console.ReadLine().Split('|');
            continue;
        }
        allInfo.Remove(cmdArgs[1]);
        Console.WriteLine($"Successfully removed {cmdArgs[1]}!");
    }
    else if (cmdArgs[0] == "ChangeKey")
    {
        if (!allInfo.ContainsKey(cmdArgs[1]))
        {
            Console.WriteLine($"Invalid operation! {cmdArgs[1]} does not exist in the collection.");
            cmdArgs = Console.ReadLine().Split('|');
            continue;
        }
        string[] temp = allInfo[cmdArgs[1]];
        temp[1] = cmdArgs[2];
        allInfo[cmdArgs[1]] = temp;
        Console.WriteLine($"Changed the key of {cmdArgs[1]} to {cmdArgs[2]}!");
    }
    cmdArgs = Console.ReadLine().Split('|');
}

foreach (var item in allInfo)
{
    Console.WriteLine($"{item.Key} -> Composer: {item.Value[0]}, Key: {item.Value[1]}");
}