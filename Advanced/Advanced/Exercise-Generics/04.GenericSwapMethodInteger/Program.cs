List<int> list = new List<int>();

int n = int.Parse(Console.ReadLine());

for (int i = 0; i < n; i++)
{
    list.Add(int.Parse(Console.ReadLine()));
}


int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
int firstIndex = input[0];
int secondIndex = input[1];

List<int> swappedList = Swap(list, firstIndex, secondIndex);

foreach (var item in swappedList)
{
    Console.WriteLine($"{item.GetType()}: {item}");
}

static List<T> Swap<T>(List<T> list, int firstIndex, int secondIndex)
{
    T temp = list[firstIndex];
    list[firstIndex] = list[secondIndex];
    list[secondIndex] = temp;
    return list;
}