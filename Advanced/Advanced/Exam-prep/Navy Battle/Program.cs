int size = int.Parse(Console.ReadLine());


char[,] field = new char[size, size];

string info = null;

int r = 0;
int c = 0;

for (int i = 0; i < size; i++)
{
    info = Console.ReadLine();

    for (int j = 0; j < size; j++)
    {
        field[i, j] = info[j];

        if (info[j] == 'S')
        {
            r = i;
            c = j;
        }
    }
}

int hitCnt = 0;
int destroyedCruisersCnt = 0;
field[r, c] = '-';

while (true)
{
    string direction = Console.ReadLine();

    if (direction == "left")
    {
        c--;

        if (field[r, c] == '*')
        {
            field[r, c] = '-';

            hitCnt++;

            if (hitCnt == 3)
            {
                Console.WriteLine($"Mission failed, U-9 disappeared! Last known coordinates [{r}, {c}]!");
                field[r, c] = 'S';
                break;
            }
        }

        else if (field[r, c] == 'C')
        {
            field[r, c] = '-';
            destroyedCruisersCnt++;
            if (destroyedCruisersCnt == 3)
            {
                Console.WriteLine("Mission accomplished, U-9 has destroyed all battle cruisers of the enemy!");
                field[r, c] = 'S';
                break;
            }
        }
    }

    else if (direction == "right")
    {
        c++;

        if (field[r, c] == '*')
        {
            field[r, c] = '-';

            hitCnt++;

            if (hitCnt == 3)
            {
                Console.WriteLine($"Mission failed, U-9 disappeared! Last known coordinates [{r}, {c}]!");
                field[r, c] = 'S';
                break;
            }
        }

        else if (field[r, c] == 'C')
        {
            field[r, c] = '-';
            destroyedCruisersCnt++;
            if (destroyedCruisersCnt == 3)
            {
                Console.WriteLine("Mission accomplished, U-9 has destroyed all battle cruisers of the enemy!");
                field[r, c] = 'S';
                break;
            }
        }
    }

    else if (direction == "down")
    {
        r++;
        if (field[r, c] == '*')
        {
            field[r, c] = '-';

            hitCnt++;

            if (hitCnt == 3)
            {
                Console.WriteLine($"Mission failed, U-9 disappeared! Last known coordinates [{r}, {c}]!");
                field[r, c] = 'S';
                break;
            }
        }

        else if (field[r, c] == 'C')
        {
            field[r, c] = '-';
            destroyedCruisersCnt++;
            if (destroyedCruisersCnt == 3)
            {
                Console.WriteLine("Mission accomplished, U-9 has destroyed all battle cruisers of the enemy!");
                field[r, c] = 'S';
                break;
            }
        }
    }

    else if (direction == "up")
    {
        r--;

        if (field[r, c] == '*')
        {
            field[r, c] = '-';

            hitCnt++;

            if (hitCnt == 3)
            {
                Console.WriteLine($"Mission failed, U-9 disappeared! Last known coordinates [{r}, {c}]!");
                field[r, c] = 'S';
                break;
            }
        }

        else if (field[r, c] == 'C')
        {
            field[r, c] = '-';
            destroyedCruisersCnt++;
            if (destroyedCruisersCnt == 3)
            {
                Console.WriteLine("Mission accomplished, U-9 has destroyed all battle cruisers of the enemy!");
                field[r, c] = 'S';
                break;
            }
        }
    }
}

for (int i = 0; i < size; i++)
{
    for (int j = 0; j < size; j++)
    {
        Console.Write(field[i, j]);
    }
    Console.WriteLine();
}