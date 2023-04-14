int[] cmdArgs = Console.ReadLine().Split().Select(int.Parse).ToArray();
int minNum = int.MaxValue;
int currNum = 0;


Stack<int> stack = new Stack<int>();
List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();


for (int i = 0; i < cmdArgs[0]; i++)
{
    stack.Push(list[i]);
}

for (int i = 0; i < cmdArgs[1]; i++)
{
    stack.Pop();
}

if (stack.Contains(cmdArgs[2]))
{
    Console.WriteLine("true");
}
else
{
    if (stack.Count > 0)
    {
        for (int i = 0; i < stack.Count; i++)
        {
            currNum = stack.Peek();

                if (currNum < minNum)
                {
                    minNum = stack.Pop();
                }
                else
                {
                    stack.Pop();
                }

        }
        Console.WriteLine(minNum);
    }
    else
    {
        Console.WriteLine(0);
    }
}