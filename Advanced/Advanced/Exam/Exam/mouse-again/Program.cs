string[] dimensions = Console.ReadLine().Split(',');
int rows = int.Parse(dimensions[0]);
int cols = int.Parse(dimensions[1]);

char[,] matrix = new char[rows, cols];
int mouseR = -1;
int mouseC = -1;

int cheeseCount = 0;

for (int i = 0; i < rows; i++)
{
    string input = Console.ReadLine();
    for (int j = 0; j < cols; j++)
    {
        matrix[i, j] = input[j];
        if (matrix[i, j] == 'M')
        {
            mouseR = i;
            mouseC = j;
        }
        else if (matrix[i, j] == 'C')
        {
            cheeseCount++;
        }
    }
}

while (true)
{
    string cmd = Console.ReadLine();

    if (cmd == "danger")
    {
        Console.WriteLine("Mouse will come back later!");
        break;
    }

    int newMouseR = mouseR;
    int newMouseC = mouseC;

    if (cmd == "up")
    {
        newMouseR--;
    }
    else if (cmd == "down")
    {
        newMouseR++;
    }

    else if (cmd == "left")
    {
        newMouseC--;
    }

    else if (cmd == "right")
    {
        newMouseC++;
    }

    if (!IsInsideMatrix(newMouseR, newMouseC, rows, cols))
    {
        Console.WriteLine("No more cheese for tonight!");
        break;
    }


    if (matrix[newMouseR, newMouseC] == '@')
    {
        continue;
    }
    else if (matrix[newMouseR, newMouseC] == 'T')
    {
        matrix[mouseR, mouseC] = '*';
        matrix[newMouseR, newMouseC] = 'M';
        Console.WriteLine("Mouse is trapped!");
        break;
    }
    else if (matrix[newMouseR, newMouseC] == 'C')
    {
        matrix[mouseR, mouseC] = '*';
        matrix[newMouseR, newMouseC] = 'M';
        cheeseCount--;

        if (cheeseCount == 0)
        {
            Console.WriteLine("Happy mouse! All the cheese is eaten, good night!");
            break;
        }
    }
    else if (matrix[newMouseR, newMouseC] == '*')
    {
        matrix[mouseR, mouseC] = '*';
        matrix[newMouseR, newMouseC] = 'M';
    }

    mouseR = newMouseR;
    mouseC = newMouseC;
}

for (int row = 0; row < rows; row++)
{
    for (int col = 0; col < cols; col++)
    {
        Console.Write(matrix[row, col]);
    }
    Console.WriteLine();
}


static bool IsInsideMatrix(int row, int col, int rows, int cols)
{
    return row >= 0 && row < rows && col >= 0 && col < cols;
}