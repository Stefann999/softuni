using _01.GenericBoxofString;

int n = int.Parse(Console.ReadLine());

for (int i = 0; i < n; i++)
{
    string input = Console.ReadLine();
    Box<string> box = new Box<string>(input);
    Console.WriteLine(box.ToString());
}