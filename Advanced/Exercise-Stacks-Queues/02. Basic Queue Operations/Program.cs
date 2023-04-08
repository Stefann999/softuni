int[] cmdArgs = Console.ReadLine().Split().Select(int.Parse).ToArray();
int minNum = int.MaxValue;


Queue<int> queue = new Queue<int>();
List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();


for (int i = 0; i < cmdArgs[0]; i++)
{
    queue.Enqueue(list[i]);
}

for (int i = 0; i < cmdArgs[1]; i++)
{
    queue.Dequeue();
}

if (queue.Contains(cmdArgs[2]))
{
    Console.WriteLine("true");
}

else if(queue.Count == 0)
{
    Console.WriteLine(0);
}

else
{
    while (queue.Count != 0)
    {

        if (queue.Peek() < minNum)
        {
            minNum = queue.Dequeue();
        }
        else
        {
            queue.Dequeue();
        }

    }

    Console.WriteLine(minNum);
}