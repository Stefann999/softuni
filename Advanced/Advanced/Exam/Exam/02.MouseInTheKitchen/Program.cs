int[] size = Console.ReadLine().Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
int rows = size[0];
int cols = size[1];


char[,] field = new char[rows, cols];

string info = null;

int r = 0;
int c = 0;

int cheeseCnt = 0;

for (int i = 0; i < rows; i++)
{
    info = Console.ReadLine();

    for (int j = 0; j < cols; j++)
    {
        field[i, j] = info[j];

        if (info[j] == 'M')
        {
            r = i;
            c = j;
        }
        else if (info[j] == 'C')
        {
            cheeseCnt++;
        }
    }
}
field[r, c] = '*';


string command = Console.ReadLine();

int foundCheeseCnt = 0;

while (command != "danger")
{
    if (command == "left")
    {
        c--;
        if (c < 0)
        {
            c++;
            Console.WriteLine("No more cheese for tonight!");
            field[r, c] = 'M';
            break;
        }

        if (field[r, c] == 'C')
        {
            foundCheeseCnt++;
            field[r, c] = '*';

            if (foundCheeseCnt == cheeseCnt)
            {
                Console.WriteLine("Happy mouse! All the cheese is eaten, good night!");
                field[r, c] = 'M';
                break;
            }
        }

        else if (field[r, c] == 'T')
        {
            Console.WriteLine("Mouse is trapped!");
            field[r, c] = 'M';
            break;
        }

        else if (field[r, c] == '@')
        {
            c++;
            command = Console.ReadLine();
            continue;
        }
    }

    else if (command == "right")
    {
        c++;
        if (c >= cols)
        {
            c--;
            Console.WriteLine("No more cheese for tonight!");
            field[r, c] = 'M';
            break;
        }

        if (field[r, c] == 'C')
        {
            foundCheeseCnt++;
            field[r, c] = '*';

            if (foundCheeseCnt == cheeseCnt)
            {
                Console.WriteLine("Happy mouse! All the cheese is eaten, good night!");
                field[r, c] = 'M';
                break;
            }
        }

        else if (field[r, c] == 'T')
        {
            Console.WriteLine("Mouse is trapped!");
            field[r, c] = 'M';
            break;
        }

        else if (field[r, c] == '@')
        {
            c--;
            command = Console.ReadLine();
            continue;
        }
    }

    else if (command == "down")
    {
        r++;
        if (r >= rows)
        {
            r--;
            Console.WriteLine("No more cheese for tonight!");
            field[r, c] = 'M';
            break;
        }

        if (field[r, c] == 'C')
        {
            foundCheeseCnt++;
            field[r, c] = '*';

            if (foundCheeseCnt == cheeseCnt)
            {
                Console.WriteLine("Happy mouse! All the cheese is eaten, good night!");
                field[r, c] = 'M';
                break;
            }
        }

        else if (field[r, c] == 'T')
        {
            Console.WriteLine("Mouse is trapped!");
            field[r, c] = 'M';
            break;
        }

        else if (field[r, c] == '@')
        {
            r--;
            command = Console.ReadLine();
            continue;
        }
    }

    else if (command == "up")
    {
        r--;
        if (r < 0)
        {
            r++;
            Console.WriteLine("No more cheese for tonight!");
            field[r, c] = 'M';
            break;
        }

        if (field[r, c] == 'C')
        {
            foundCheeseCnt++;
            field[r, c] = '*';

            if (foundCheeseCnt == cheeseCnt)
            {
                Console.WriteLine("Happy mouse! All the cheese is eaten, good night!");
                field[r, c] = 'M';
                break;
            }
        }

        else if (field[r, c] == 'T')
        {
            Console.WriteLine("Mouse is trapped!");
            field[r, c] = 'M';
            break;
        }

        else if (field[r, c] == '@')
        {
            r++;
            command = Console.ReadLine();
            continue;
        }

    }
    command = Console.ReadLine();
}


if (command == "danger")
{
    Console.WriteLine("Mouse will come back later!");
}

for (int i = 0; i < rows; i++)
{
    for (int j = 0; j < cols; j++)
    {
        Console.Write(field[i, j]);
    }
    Console.WriteLine();
}