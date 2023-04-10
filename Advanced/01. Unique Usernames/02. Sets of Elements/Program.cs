int[] info = Console.ReadLine().Split().Select(int.Parse).ToArray();

int n = info[0];
int m = info[1];

List<int> listN = new List<int>();
List<int> listM = new List<int>();
List<int> matched = new List<int>(); 


for (int i = 0; i < n; i++)
{
    listN.Add(int.Parse(Console.ReadLine()));
}

for (int i = 0;i < m; i++)
{
    listM.Add(int.Parse(Console.ReadLine()));
}

for(int i = 0; i < n ; i++)
{
    if (listM.Contains(listN[i]))
    {
        if (!matched.Contains(listN[i]))
        {
            matched.Add(listN[i]);
        }
    }
}
Console.WriteLine(string.Join(" ", matched));