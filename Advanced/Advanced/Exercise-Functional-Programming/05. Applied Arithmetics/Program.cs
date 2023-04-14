using System.Globalization;
using System.Threading.Channels;

int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();


string cmd = Console.ReadLine();

while (cmd != "end")
{

    if (cmd == "add")
    {
        Func<int[], int[]> addFunc = add;
        numbers = addFunc(numbers);
    }

    else if (cmd == "multiply")
    {
        Func<int[], int[]> multiplyFunc = multiply;
        numbers = multiplyFunc(numbers);
    }
    
    else if (cmd == "subtract")
    {
        Func<int[], int[]> subtractFunc = subtract;
        numbers = subtractFunc(numbers);
    }

    else if (cmd == "print")
    {
        string numbersForPrint = string.Join(" ", numbers);
        Action<string> print = numbersForPrint => Console.WriteLine(numbersForPrint);
        print(numbersForPrint);
    }

    cmd = Console.ReadLine();
}

int[] subtract(int[] nums)
{
    for (int i = 0; i < nums.Length; i++)
    {
        nums[i] = nums[i] - 1;
    }
    return nums;
}

int[] multiply(int[] nums)
{
    for (int i = 0; i < nums.Length; i++)
    {
        nums[i] = nums[i] * 2;
    }
    return nums;
}

int[] add(int[] nums)
{
    for (int i = 0; i < nums.Length; i++)
    {
        nums[i] = nums[i] + 1;
    }
    return nums;
}