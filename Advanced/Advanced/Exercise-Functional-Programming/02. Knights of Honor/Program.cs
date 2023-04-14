string[] input = Console.ReadLine().Split();


for (int i = 0; i < input.Length; i++)
{
    Action<string> print = currName => Console.WriteLine(currName);
    print("Sir " + input[i]);
}