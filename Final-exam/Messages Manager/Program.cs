using System.Linq;

int capacity = int.Parse(Console.ReadLine());

Dictionary<string, List<int>> info = new Dictionary<string, List<int>>();

string[] cmdArgs = Console.ReadLine().Split('=');

while (cmdArgs[0] != "Statistics")
{
	if (cmdArgs[0] == "Add")
	{
		if (!info.ContainsKey(cmdArgs[1]))
		{
			List<int> temp = new List<int>();
			temp.Add(int.Parse(cmdArgs[2]));
			temp.Add(int.Parse(cmdArgs[3]));
			info.Add(cmdArgs[1], temp);
		}
		else
		{
            cmdArgs = Console.ReadLine().Split('=');
			continue;
        }
	}

	else if (cmdArgs[0] == "Message")
	{
		if (info.ContainsKey(cmdArgs[1]))
		{
			if (info.ContainsKey(cmdArgs[2]))
			{
				List<int> tempSender = info[cmdArgs[1]];
				tempSender[0]++;
				info[cmdArgs[1]] = tempSender;

				List<int> tempReceiver = info[cmdArgs[2]];
				tempReceiver[1]++;
				info[cmdArgs[2]] = tempReceiver;

				if (tempSender[0] + tempSender[1] == capacity)
				{
					//List<int> tempForMoveOne = info[cmdArgs[1]];
					//List<int> tempForMoveTwo = new List<int>();

					//for (int i = 1; i < info.Count; i++)
					//{
					//	tempForMoveTwo.Add(tempForMoveOne[i]);
					//}
					//info[cmdArgs[1]] = tempForMoveTwo;


                    Dictionary<string, List<int>> moving = new Dictionary<string, List<int>>();

					for (int i = 1; i < info.Count; i++)
					{
						foreach (var item in info)
						{
							if (item.Key == cmdArgs[1])
							{
								continue;
							}
							else
							{
								string key = item.Key;
								List<int> temp = info[key];
								moving.Add(key, temp);
								
                            }
						}info = moving;
					}

                    Console.WriteLine($"{cmdArgs[1]} reached the capacity!");
				}

				 if (tempReceiver[1] + tempReceiver[0] == capacity)
				{
                    //List<int> tempForMoveOne = info[cmdArgs[2]];
                    //List<int> tempForMoveTwo = new List<int>();

                    //for (int i = 1; i < info.Count; i++)
                    //{
                    //    tempForMoveTwo.Add(tempForMoveOne[i]);
                    //}
                    //info[cmdArgs[2]] = tempForMoveTwo;


                    Dictionary<string, List<int>> moving = new Dictionary<string, List<int>>();

                   
                        foreach (var item in info)
                        {
                            if (item.Key == cmdArgs[2])
                            {
                                continue;
                            }
                            else
                            {
                                string key = item.Key;
                                List<int> temp = info[key];
                                moving.Add(key, temp);
                               
                            }
                        } info = moving;
                    

                    Console.WriteLine($"{cmdArgs[2]} reached the capacity!");
                }
			}
		}
		else
		{
            cmdArgs = Console.ReadLine().Split('=');
            continue;
        }
	}
    else if (cmdArgs[0] == "Empty")
    {
        if (cmdArgs[1] == "All")
        {
            info.Clear();
        }
        else
        {
            Dictionary<string, List<int>> moving = new Dictionary<string, List<int>>();


            foreach (var item in info)
            {
                if (item.Key == cmdArgs[1])
                {
                    continue;
                }
                else
                {
                    string key = item.Key;
                    List<int> temp = info[key];
                    moving.Add(key, temp);
                }
            }

            info = moving;
        }
    }
    cmdArgs = Console.ReadLine().Split('=');
}

Console.WriteLine($"Users count: {info.Count}");
foreach (var item in info)
{
    Console.WriteLine($"{item.Key} - {item.Value[0] + item.Value[1]}");
}