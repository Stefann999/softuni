using System.Diagnostics.SymbolStore;

int n = int.Parse(Console.ReadLine());

Dictionary<string, Dictionary<string, int>> info = new Dictionary<string, Dictionary<string, int>>();

for (int i = 0; i < n; i++)
{
    string[] currClothes = Console.ReadLine().Split(new string[] { " -> ", "," }, StringSplitOptions.RemoveEmptyEntries);
    string color = currClothes[0];


    if (!info.ContainsKey(color))
    {
        info.Add(color, new Dictionary<string, int>());
    }

    for (int j = 1; j < currClothes.Length; j++)
    {
        if (!info[color].ContainsKey(currClothes[j]))
        {
            info[color].Add(currClothes[j], 0);
        }
        info[color][currClothes[j]]++;
    }
}

string[] searching = Console.ReadLine().Split();

foreach (var item in info)
{
    Console.WriteLine($"{item.Key} clothes: ");


    foreach (var itemm in item.Value)
    {
        string searchedColor = searching[0];
        string searchedCloth = searching[1];

        if (searchedColor == item.Key)
        {
            if (searchedCloth == itemm.Key)
            {
                Console.WriteLine($"* {itemm.Key} - {itemm.Value} (found!)");
                continue;
            }
        }

        Console.WriteLine($"* {itemm.Key} - {itemm.Value}");
    }
}