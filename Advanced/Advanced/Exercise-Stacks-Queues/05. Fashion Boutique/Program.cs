int[] clothes = Console.ReadLine().Split().Select(int.Parse).ToArray();
int rackCapacity = int.Parse(Console.ReadLine());
int racksCnt = 1;
int usedFromRack = 0;

Stack<int> stack = new Stack<int>();

for (int i = 0; i < clothes.Length; i++)
{
	stack.Push(clothes[i]);
}

while(stack.Count != 0)
{
	if (usedFromRack + stack.Peek() <= rackCapacity)
	{
		usedFromRack += stack.Peek();
		if (usedFromRack == 16)
		{
			racksCnt++;
			usedFromRack = 0;
		}
		stack.Pop();
	}
	else
	{
		racksCnt++;
		usedFromRack = 0;
	}
}

Console.WriteLine(racksCnt);