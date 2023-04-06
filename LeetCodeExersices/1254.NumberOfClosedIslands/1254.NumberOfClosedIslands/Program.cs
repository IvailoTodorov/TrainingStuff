//int[,] grid = new int[,] { { 1, 1, 1, 1, 1, 1, 1, 0 }, { 1, 0, 0, 0, 0, 1, 1, 0 }, { 1, 0, 1, 0, 1, 1, 1, 0 }, { 1, 0, 0, 0, 0, 1, 0, 1 }, { 1, 1, 1, 1, 1, 1, 1, 0 } };
int[,] grid = new int[,] { { 0, 0, 1, 0, 0 }, { 0, 1, 0, 1, 0 }, { 0, 1, 1, 1, 0 } };
// Printing the grid
int row = grid.GetLength(0);
int col = grid.GetLength(1);
for (int i = 0; i < row; i++)
{
    for (int j = 0; j < col; j++)
    {
        Console.Write(grid[i, j] + " ");
    }
    Console.WriteLine();
}

int counter = 0;

for (int j = 0; j < row; j++)
{
    for (int i = 0; i < col; i++)
    {
        if (grid[j, i] != 0)
        {
            continue;
        }

        if (i + 3 > col)
        {
            break;
        }

        if (grid[j, i] == 0 &&
         grid[j, i + 1] == 0 &&
         grid[j, i + 2] == 0 &&
         grid[j, i + 3] == 0)
        {

            counter++;
            grid[j, i] = 2;
            grid[j, i + 1] = 2;
            grid[j, i + 2] = 2;
            grid[j, i + 3] = 2;
            continue;
        }

        if (j > 0 && j < row && i > 0 && i < col)
        {

            if (grid[j + 1, i] == 1 &&
            grid[j, i - 1] == 1 &&
            grid[j, i + 1] == 1 &&
            grid[j - 1, i] == 1)
            {

                counter++;
                continue;
            }
        }
    }
}

Console.WriteLine();
Console.WriteLine(counter);
Console.WriteLine();
Console.WriteLine("------------------------------------------------");
Console.WriteLine();
// Printing the grid
for (int i = 0; i < row; i++)
{
    for (int j = 0; j < col; j++)
    {
        Console.Write(grid[i, j] + " ");
    }
    Console.WriteLine();
}