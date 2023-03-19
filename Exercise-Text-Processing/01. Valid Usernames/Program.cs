using System.Xml.Linq;

string[] names = Console.ReadLine().Split(", ");

int fail = 0;

if (names.Length >= 3 && names.Length <= 16)
{
    foreach (var name in names)
    {
        for (int i = 0; i < name.Length; i++)
        {
            if (name[i] < 0 || name[i] > 9 || name[i] < 'a' || name[i] > 'z' || name[i] < 'A' || name[i] > 'Z')
            {
                fail++;
            }
            
        }
        if (fail == 0)
        {
            Console.WriteLine(name);
        }
    }
}
