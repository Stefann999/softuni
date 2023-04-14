Stack<string> stack = new Stack<string>();

stack.Push(string.Empty);

int n = int.Parse(Console.ReadLine());

for (int i = 0; i < n; i++)
{
    string input = Console.ReadLine();
    string command = input.Split().First();
    string item = input.Split().Last();


    if (command == "1")
    {
        stack.Push(stack.Peek() + item);
    }
    else if (command == "2")
    {
        int count = int.Parse(item);
        string newState = stack.Peek().Remove(stack.Peek().Length - count);
        stack.Push(newState);
    }

    else if (command == "3")
    {
        int index = int.Parse(item) - 1;
        Console.WriteLine(stack.Peek()[index]);
    }

    else if (command == "4")
    {
        stack.Pop();
    }
}