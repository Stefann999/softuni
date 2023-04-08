int numberOfPumps = int.Parse(Console.ReadLine());
Queue<string> pumps = new Queue<string>();
for (int i = 0; i < numberOfPumps; i++)
{
    pumps.Enqueue(Console.ReadLine());
}
for (int index = 0; index < numberOfPumps; index++)
{
    if (CanCompleteFullCircle(pumps))
    {
        Console.WriteLine(index);
        break;
    }
    pumps.Enqueue(pumps.Dequeue());
}


static bool CanCompleteFullCircle(Queue<string> pumps)
{
    int fuel = 0;
    bool canCompleteCirle = true;
    for (int i = 0; i < pumps.Count; i++)
    {
        int petrolAmount = int.Parse(pumps.Peek().Split().First());
        int distance = int.Parse(pumps.Peek().Split().Last());
        fuel += petrolAmount - distance;
        if (fuel < 0)
            canCompleteCirle = false;
        pumps.Enqueue(pumps.Dequeue());
    }

    return canCompleteCirle;
}