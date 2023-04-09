int size = int.Parse(Console.ReadLine());

int[,] matrix = new int[size, size];

for (int row = 0; row < size; row++)
{
    int[] rowInfo = Console.ReadLine().Split().Select(int.Parse).ToArray();

    for (int col = 0; col < rowInfo.Length; col++)
    {
        matrix[row, col] = rowInfo[col];
    }
}

List<int> firstDiagonal = new List<int>();
List<int> secondDiagonal = new List<int>();

for (int i = 0; i < size; i++)
{
    firstDiagonal.Add(matrix[i,i]);
}

for (int i = size - 1; i >= 0; i--)
{
    secondDiagonal.Add(matrix[size - i - 1, i]);
}

int difference = Math.Abs(firstDiagonal.Sum() - secondDiagonal.Sum());

Console.WriteLine(difference);