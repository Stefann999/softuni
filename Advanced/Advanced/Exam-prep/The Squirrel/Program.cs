using System.Xml;

int size = int.Parse(Console.ReadLine());

string[] moves = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

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

        if (info[j] == 's')
        {
            r = i;
            c = j;
        }
    }
}

int hazelnutsCnt = 0;

for (int i = 0; r < moves.Length; i++)
{
    if (moves[i] == "left")
    {
        c--;
        if (c == 0)
        {
            Console.WriteLine("The squirrel is out of the field.");
            Console.WriteLine($"Hazelnuts collected: {hazelnutsCnt}");
            break;
        }

        if (field[r, c] == 'h')
        {
            hazelnutsCnt++;

            if (hazelnutsCnt == 3)
            {
                Console.WriteLine("Good job! You have collected all hazelnuts!");
                Console.WriteLine($"Hazelnuts collected: {hazelnutsCnt}");
                break;
            }
        }

        else if (field[r, c] == 't')
        {
            Console.WriteLine("Unfortunately, the squirrel stepped on a trap...");
            Console.WriteLine($"Hazelnuts collected: {hazelnutsCnt}");
            break;
        }
    }

    else if (moves[i] == "right")
    {
        c++;
        if (c == size)
        {
            Console.WriteLine("The squirrel is out of the field.");
            Console.WriteLine($"Hazelnuts collected: {hazelnutsCnt}");
            break;
        }

        if (field[r, c] == 'h')
        {
            hazelnutsCnt++;

            if (hazelnutsCnt == 3)
            {
                Console.WriteLine("Good job! You have collected all hazelnuts!");
                Console.WriteLine($"Hazelnuts collected: {hazelnutsCnt}");
                break;
            }
        }

        else if (field[r, c] == 't')
        {
            Console.WriteLine("Unfortunately, the squirrel stepped on a trap...");
            Console.WriteLine($"Hazelnuts collected: {hazelnutsCnt}");
            break;
        }
    }

    else if (moves[i] == "down")
    {
        r++;
        if (r == size)
        {
            Console.WriteLine("The squirrel is out of the field.");
            Console.WriteLine($"Hazelnuts collected: {hazelnutsCnt}");
            break;
        }

        if (field[r, c] == 'h')
        {
            hazelnutsCnt++;

            if (hazelnutsCnt == 3)
            {
                Console.WriteLine("Good job! You have collected all hazelnuts!");
                Console.WriteLine($"Hazelnuts collected: {hazelnutsCnt}");
                break;
            }
        }

        else if (field[r, c] == 't')
        {
            Console.WriteLine("Unfortunately, the squirrel stepped on a trap...");
            Console.WriteLine($"Hazelnuts collected: {hazelnutsCnt}");
            break;
        }
    }

    else if (moves[i] == "up")
    {
        r--;
        if (r == 0)
        {
            Console.WriteLine("The squirrel is out of the field.");
            Console.WriteLine($"Hazelnuts collected: {hazelnutsCnt}");
            break;
        }

        if (field[r, c] == 'h')
        {
            hazelnutsCnt++;

            if (hazelnutsCnt == 3)
            {
                Console.WriteLine("Good job! You have collected all hazelnuts!");
                Console.WriteLine($"Hazelnuts collected: {hazelnutsCnt}");
                break;
            }
        }

        else if (field[r, c] == 't')
        {
            Console.WriteLine("Unfortunately, the squirrel stepped on a trap...");
            Console.WriteLine($"Hazelnuts collected: {hazelnutsCnt}");
            break;
        }
    }
}