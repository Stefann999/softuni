string[] words = Console.ReadLine().Split();

string stringOne = words[0];
string stringTwo = words[1];
int minLenght = Math.Min(stringOne.Length, stringTwo.Length);
int sum = 0;

string longerStr = stringOne;
string check = "yes";
if (stringTwo.Length > stringOne.Length)
{
    longerStr = stringTwo;
    check = "no";
}

for (int i = 0; i < minLenght; i++)
{
    sum += stringOne[i] * stringTwo[i];
}

int left = 0;

if (check == "yes")
{
    left = stringOne.Length - stringTwo.Length;
}
else
{
    left = stringTwo.Length - stringOne.Length;
}

for (int i = minLenght; i < longerStr.Length; i++)
{
    sum += longerStr[i];
}
Console.WriteLine(sum);