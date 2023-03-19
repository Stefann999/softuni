using System.Text;

string path = Console.ReadLine();

int dotLastIndex = path.LastIndexOf('.');

StringBuilder ext = new StringBuilder();

for (int i = dotLastIndex + 1; i < path.Length; i++)
{
    ext.Append(path[i]);
}
string extention = ext.ToString();

StringBuilder name = new StringBuilder();

int slashLastIndex = path.LastIndexOf('\\');

for (int i = slashLastIndex + 1; i < dotLastIndex; i++)
{
    name.Append(path[i]);
}
string fileName = name.ToString();

Console.WriteLine($"File name: {fileName}");
Console.WriteLine($"File extension: {extention}");

