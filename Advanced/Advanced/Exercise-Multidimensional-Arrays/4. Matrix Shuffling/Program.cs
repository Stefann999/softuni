int[] matrixInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
int rows = matrixInfo[0];
int cols = matrixInfo[1];

string[,] matrix = new string[rows, cols];

for (int row = 0; row < rows; row++)
{
    string[] rowInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

    for (int col = 0; col < cols; col++)
    {
        matrix[row, col] = rowInfo[col];
    }
}

string[] cmdArgs = Console.ReadLine().Split();

while (cmdArgs[0] != "END")
{
    if (cmdArgs[0] == "swap")
    {
        if (cmdArgs.Length == 5)
        {
            int firstRow = int.Parse(cmdArgs[1]);
            int firstCol = int.Parse(cmdArgs[2]);
            int secondRow = int.Parse(cmdArgs[3]);
            int secondCol = int.Parse(cmdArgs[4]);

            if (firstRow >= 0 && firstRow <= rows && secondRow >= 0 && secondRow <= rows && firstCol >= 0 && firstCol <= cols && secondCol >= 0 && secondCol <= cols)
            {
                string temp1 = matrix[firstRow, firstCol];
                matrix[firstRow, firstCol] = matrix[secondRow, secondCol];
                matrix[secondRow, secondCol] = temp1;

                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        Console.Write(matrix[row,col] + " ");
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Invalid input!");
            }
        }
        else
        {
            Console.WriteLine("Invalid input!");
        }
      
    }
    else
    {
        Console.WriteLine("Invalid input!");
    }

    cmdArgs = Console.ReadLine().Split();
}