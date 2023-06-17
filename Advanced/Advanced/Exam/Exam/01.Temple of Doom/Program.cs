Queue<int> tools = new Queue<int>();
Stack<int> substances = new Stack<int>();

int[] toolsArr = Console.ReadLine().Split().Select(int.Parse).ToArray();
int[] substancesArr = Console.ReadLine().Split().Select(int.Parse).ToArray();
List<int> challenges = Console.ReadLine().Split().Select(int.Parse).ToList();

for (int i = 0; i < toolsArr.Length; i++)
{
    tools.Enqueue(toolsArr[i]);
}

for (int i = 0; i < substancesArr.Length; i++)
{
    substances.Push(substancesArr[i]);
}

int result = 0;
bool isFound = false;


while (tools.Count != 0 && substances.Count != 0 && challenges.Count != 0)
{
    result = tools.Peek() * substances.Peek();
    bool isMatch = false;

    for (int i = 0; i < challenges.Count; i++)
    {
        if (result == challenges[i])
        {
            challenges.Remove(challenges[i]);
            tools.Dequeue();
            substances.Pop();
            isMatch = true;
            break;
        }
    }
    if (!isMatch)
    {
        int temp = tools.Dequeue();
        temp += 1;
        tools.Enqueue(temp);
        int tempTwo = substances.Pop();
        tempTwo -= 1;
        if (tempTwo > 0)
        {
            substances.Push(tempTwo);
        }
        else
        {
            continue;
        }
    }
    if (challenges.Count == 0)
    {
        isFound = true;
        break;
    }
}

if (isFound)
{
    Console.WriteLine("Harry found an ostracon, which is dated to the 6th century BCE.");
}
else
{
    Console.WriteLine("Harry is lost in the temple. Oblivion awaits him.");
}


if (tools.Any())
{
    Console.Write("Tools: ");
    Console.WriteLine(string.Join(", ", tools));
}

if (substances.Any())
{
    Console.Write("Substances: ");
    Console.WriteLine(string.Join(", ", substances));
}

if (challenges.Any())
{
    Console.Write("Challenges: ");
    Console.WriteLine(string.Join(", ", challenges));
}