using System.Text;

string text = Console.ReadLine();
StringBuilder sb = new StringBuilder();

foreach (char item in text)
{
    int currPos = item;
    currPos += 3;
    sb.Append((char)currPos);
}
Console.WriteLine(sb);
