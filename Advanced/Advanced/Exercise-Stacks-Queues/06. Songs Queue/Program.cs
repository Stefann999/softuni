string[] input = Console.ReadLine().Split(", ");

Queue<string> songs = new Queue<string>();

for (int i = 0; i < input.Length; i++)
{
	 if (!songs.Contains(input[i]))
		{
		songs.Enqueue(input[i]);
        }
		else
		{
		Console.WriteLine($"{input[i]} is already contained!");
		}
}	


while (songs.Count != 0)
{
    string[] cmdArgs = Console.ReadLine().Split();
    if (cmdArgs[0] == "Play")
	{
		songs.Dequeue();
	}
	else if (cmdArgs[0] == "Add")
	{
        string newSong = string.Join(" ", cmdArgs.Skip(1));
        if (!songs.Contains(newSong))
		{
            songs.Enqueue(newSong);
        }
		else
		{
			Console.WriteLine($"{newSong} is already contained!");
		}
	}
	else if (cmdArgs[0] == "Show")
	{
		Console.WriteLine(string.Join(", ", songs));
	}
}

Console.WriteLine("No more songs!");