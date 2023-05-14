using _02._Generic_BoxofInteger;

int n = int.Parse(Console.ReadLine());

for (int i = 0; i < n; i++)
{
    int input = int.Parse(Console.ReadLine());
    Box<int> box = new Box<int>(input);
    Console.WriteLine(box.ToString());
}