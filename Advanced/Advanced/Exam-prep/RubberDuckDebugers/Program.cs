using System.Runtime.CompilerServices;

int[] timeAsArray = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
Queue<int> time = new Queue<int>();

for (int i = 0; i < timeAsArray.Length; i++)
{
    time.Enqueue(timeAsArray[i]);
}

int[] tasksAsArray = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
Stack<int> tasks = new Stack<int>();

for (int i = 0; i < tasksAsArray.Length; i++)
{
    tasks.Push(tasksAsArray[i]);
}

int result = 0;
int darthCnt = 0;
int thorCnt = 0;
int bigCnt = 0;
int smallCnt = 0;
int tempTime = 0;
int tempTask = 0;


while (tasks.Any())
{
    tempTime = time.Dequeue();
    tempTask = tasks.Pop();
    result = tempTime * tempTask;


    if (result > 240)
    {
        tempTask = tempTask - 2;
        tasks.Push(tempTask);
        time.Enqueue(tempTime);
    }

    else if (result >= 0 && result <= 60)
    {
        darthCnt++;
    }

    else if (result >= 61 && result <= 120)
    {
        thorCnt++;
    }

    else if (result >= 121 && result <= 180)
    {
        bigCnt++;
    }

    else if (result >= 181 && result <= 240)
    {
        smallCnt++;
    }
}

Console.WriteLine("Congratulations, all tasks have been completed! Rubber ducks rewarded: ");
Console.WriteLine($"Darth Vader Ducky: {darthCnt}");
Console.WriteLine($"Thor Ducky: {thorCnt}");
Console.WriteLine($"Big Blue Rubber Ducky: {bigCnt}");
Console.WriteLine($"Small Yellow Rubber Ducky: {smallCnt}");