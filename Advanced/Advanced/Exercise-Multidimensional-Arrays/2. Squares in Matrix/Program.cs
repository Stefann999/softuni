using System.Drawing;

int[] matrixInfo = Console.ReadLine().Split().Select(int.Parse).ToArray();
int rows = matrixInfo[0];
int cols = matrixInfo[1];

string[,] matrix = new string[rows, cols];

for (int row = 0; row < rows; row++)
{
    string[] rowInfo = Console.ReadLine().Split();

    for (int col = 0; col < cols; col++)
    {
        matrix[row, col] = rowInfo[col];
    }
}

int cnt = 0;

for (int row = 0; row <= rows; row++)
{
    for (int col = 0; col < cols; col++)
    {
        if (row >= rows - 1 || col >= cols - 1)
        {
            continue;
        }

        else
        {
            if (matrix[row,col] == matrix[row+1, col])
            {
                if (matrix[row, col] == matrix[row, col + 1])
                {
                    if (matrix[row, col] == matrix[row + 1, col + 1])
                    {
                        cnt++;
                    }
                }
            }
        }
    }
}

Console.WriteLine(cnt);