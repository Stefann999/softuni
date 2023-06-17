Stack<int> food = new Stack<int>();
Queue<int> stamina = new Queue<int>();

int[] foodArr = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
int[] staminaArr = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();



for (int i = 0; i < 7; i++)
{
    food.Push(foodArr[i]);
}
for (int i = 0; i < 7; i++)
{
    stamina.Enqueue(staminaArr[i]);
}

int cnt = 0;

while (food.Any())
{
    if (cnt == 0)
    {
        if (food.Pop() + stamina.Dequeue() >= 80)
        {
            cnt++;
        }
    }

    else if (cnt == 1)
    {
        if (food.Pop() + stamina.Dequeue() >= 90)
        {
            cnt++;
        }

    }

    else if (cnt == 2)
    {
        if (food.Pop() + stamina.Dequeue() >= 100)
        {
            cnt++;

        }
    }

    else if (cnt == 3)
    {
        if (food.Pop() + stamina.Dequeue() >= 60)
        {
            cnt++;

        }
    }

    else if (cnt == 4)
    {
        if (food.Pop() + stamina.Dequeue() >= 70)
        {
            cnt++;

        }
    }

    else if(cnt == 5)
    {
        break;
    }
}


if (cnt == 5)
{
    Console.WriteLine("Alex did it! He climbed all top five Pirin peaks in one week -> @FIVEinAWEEK");
    Console.WriteLine("Conquered peaks: ");
    Console.WriteLine("Vihren");
    Console.WriteLine("Kutelo");
    Console.WriteLine("Banski Suhodol");
    Console.WriteLine("Polezhan");
    Console.WriteLine("Kamenitza");
    return;
}


    Console.WriteLine("Alex failed! He has to organize his journey better next time -> @PIRINWINS");

if (cnt == 0)
{
    return;
}
Console.WriteLine("Conquered peaks: ");

if (cnt == 1)
{
    Console.WriteLine("Vihren");
}

else if (cnt == 2)
{
    Console.WriteLine("Vihren");
    Console.WriteLine("Kutelo");
}

else if (cnt == 3)
{
    Console.WriteLine("Vihren");
    Console.WriteLine("Kutelo");
    Console.WriteLine("Banski Suhodol");
}
else if (cnt == 4)
{
    Console.WriteLine("Vihren");
    Console.WriteLine("Kutelo");
    Console.WriteLine("Banski Suhodol");
    Console.WriteLine("Polezhan");
}