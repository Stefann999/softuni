string input = Console.ReadLine();

Stack<string> stack = new Stack<string>();

for (int i = 0; i < input.Length; i++)
{
    if (input[i] == '{' || input[i] == '[' || input[i] == '(')
    {
        stack.Push(input[i].ToString());
    }
    else if (input[i] == '}')
    {
        if (stack.Count == 0)
        {
            Console.WriteLine("NO");
            return;
        }

        if (stack.Peek() == "{")
        {
            stack.Pop();
        }
        else
        {
            Console.WriteLine("NO");
            return;
        }
    }

    else if (input[i] == ']')
    {
        if (stack.Count == 0)
        {
            Console.WriteLine("NO");
            return;
        }

        if (stack.Peek() == "[")
        {
            stack.Pop();
        }
        else
        {
            Console.WriteLine("NO");
            return;
        }
    }

    else if (input[i] == ')')
    {
        if (stack.Count == 0)
        {
            Console.WriteLine("NO");
            return;
        }

        if (stack.Peek() == "(")
        {
            stack.Pop();
        }
        else
        {
            Console.WriteLine("NO");
            return;
        }
    }
}

 Console.WriteLine("YES");