int quantity = int.Parse(Console.ReadLine());

int[] orders = Console.ReadLine().Split().Select(int.Parse).ToArray();
Queue<int> queue = new Queue<int>();

for (int i = 0; i < orders.Length; i++)
{
	queue.Enqueue(orders[i]);
}

Console.WriteLine(queue.Max());

while (queue.Count != 0)
{
	if (quantity >= queue.Peek())
	{
		quantity -= queue.Dequeue();
	}
	else
	{
		break;
	}
}

if (queue.Count == 0)
{
	Console.WriteLine("Orders complete");
}
else
{
	Console.WriteLine($"Orders left: {string.Join(" ", queue)}");
}