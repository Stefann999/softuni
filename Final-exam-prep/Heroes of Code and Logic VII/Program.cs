int n = int.Parse(Console.ReadLine());

Dictionary<string, string[]> heroes = new Dictionary<string, string[]>();

for (int i = 0; i < n; i++)
{
    string[] heroesInfo = Console.ReadLine().Split();
    string[] value = new string[] { heroesInfo[1], heroesInfo[2] };
    heroes.Add(heroesInfo[0], value);
}

string[] cmdArgs = Console.ReadLine().Split(" - ");
string[] temp = null;

while (cmdArgs[0] != "End")
{
    if (cmdArgs[0] == "CastSpell")
    {
        temp = heroes[cmdArgs[1]];
        if (int.Parse(temp[1]) >= int.Parse(cmdArgs[2]))
        {
            int manaLeft = int.Parse(temp[1]) - int.Parse(cmdArgs[2]);
            temp[1] = manaLeft.ToString();
            heroes[cmdArgs[1]] = temp;
            Console.WriteLine($"{cmdArgs[1]} has successfully cast {cmdArgs[3]} and now has {manaLeft} MP!");
            temp = null;
        }
        else
        {
            Console.WriteLine($"{cmdArgs[1]} does not have enough MP to cast {cmdArgs[3]}!");
        }
    }

    else if (cmdArgs[0] == "TakeDamage")
    {
        temp = heroes[cmdArgs[1]];
        int hpLeft = int.Parse(temp[0]) - int.Parse(cmdArgs[2]);
        if (hpLeft > 0)
        {
            temp[0] = hpLeft.ToString();
            heroes[cmdArgs[1]] = temp;
            Console.WriteLine($"{cmdArgs[1]} was hit for {cmdArgs[2]} HP by {cmdArgs[3]} and now has {temp[0]} HP left!");
            temp = null;
        }
        else
        {
            heroes.Remove(cmdArgs[1]);
            Console.WriteLine($"{cmdArgs[1]} has been killed by {cmdArgs[3]}!");
        }
    }

    else if (cmdArgs[0] == "Recharge")
    {
        temp = heroes[cmdArgs[1]];
        int result = int.Parse(temp[1]) + int.Parse(cmdArgs[2]);
        if (result > 200)
        {
            result = 200;
        }
        int used = result - int.Parse(temp[1]);
        temp[1] = result.ToString();
        heroes[cmdArgs[1]] = temp;
        Console.WriteLine($"{cmdArgs[1]} recharged for {used} MP!");
        temp = null;
    }

    else if (cmdArgs[0] == "Heal")
    {
        temp = heroes[cmdArgs[1]];
        int result = int.Parse(temp[0]) + int.Parse(cmdArgs[2]);
        if (result > 100)
        {
            result = 100;
        }
        int used = result - int.Parse(temp[0]);
        temp[0] = result.ToString();
        heroes[cmdArgs[1]] = temp;
        Console.WriteLine($"{cmdArgs[1]} healed for {used} HP!");
    }
    cmdArgs = Console.ReadLine().Split(" - ");
}

foreach (var item in heroes)
{
    Console.WriteLine(item.Key);
    Console.WriteLine($" HP: {item.Value[0]}");
    Console.WriteLine($" MP: {item.Value[1]}");
}