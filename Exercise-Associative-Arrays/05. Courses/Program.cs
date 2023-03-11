Dictionary<string, List<string>> coursesData = new Dictionary<string, List<string>>();

string[] cmdArgs = Console.ReadLine().Split(" : ");

while (cmdArgs[0] != "end")
{
    if (!coursesData.ContainsKey(cmdArgs[0]))
    {
        List<string> currList = new List<string>();
        currList.Add("1");
        currList.Add(cmdArgs[1]);

        coursesData[cmdArgs[0]] = currList;
    }
    else if (coursesData.ContainsKey(cmdArgs[0]))
    {
        List<string> manipulationList = new List<string>();
        manipulationList = coursesData[cmdArgs[0]];
        int studentsCnt = int.Parse(manipulationList[0]);
        studentsCnt++;
        string newNumAsString = studentsCnt.ToString();
        manipulationList[0] = newNumAsString;
        manipulationList.Add(cmdArgs[1]);
        coursesData[cmdArgs[0]] = manipulationList;
    }

    cmdArgs = Console.ReadLine().Split(" : ");
}

foreach (var course in coursesData)
{
    Console.WriteLine($"{course.Key}: {course.Value[0]}");
    for (int i = 1; i < course.Value.Count; i++)
    {
        Console.WriteLine($"-- {course.Value[i]}");
    }
}