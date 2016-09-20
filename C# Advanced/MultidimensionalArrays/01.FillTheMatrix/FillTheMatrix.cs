using System;

class FillTheMatrix
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int[,] matrix = new int[n, n];
        char character = char.Parse(Console.ReadLine().ToLower());
        int k = 1;
        switch (character)
        {
            case 'a':
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        matrix[j,i] =k ;
                        k++;
                    }
                };
                break;
            case 'b':
                for (int i = 0; i < n; i++)
                {
                    if (i%2==0)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            matrix[j, i] = k;
                            k++;
                        }
                    }
                    else
                    {
                        for (int j = n-1; j >= 0; j--)
                        {
                            matrix[j, i] = k;
                            k++;
                        }
                    }
                };
                break;
            case 'c':
                int row = n - 1;
                int col = 0;
                int startRow = n - 1;
                int startCol = 0;

                while (k < n * n)
                {
                    if (row == (n - 1) && col < (n - 1))
                    {
                        if (k == 1)
                        {
                            matrix[row, col] = k;
                        }
                        startRow--;
                        startCol = 0;
                        row = startRow;
                        col = startCol;
                        k++;
                        matrix[row, col] = k;

                        while (row < (n - 1) && col < (n - 1))
                        {
                            row++;
                            col++;
                            k++;
                            matrix[row, col] = k;
                        }
                    }
                    if (row <= (n - 1) && col == (n - 1))
                    {
                        startRow = 0;
                        startCol++;
                        row = startRow;
                        col = startCol;
                        k++;
                        matrix[row, col] = k;

                        while (col < (n - 1))
                        {
                            col++;
                            row++;
                            k++;
                            matrix[row, col] = k;
                        }
                    }
                };
                break;
            case 'd':
                int startrow = 0;
                int endrow = n-1;
                int startcol = 0;
                int endcol = n-1;
                while (k <= n * n)
                {
                    for (int i = startrow; i <= endrow; i++)
                    {
                        matrix[i, startcol] = k;
                        k++;
                    }
                    startcol++;
                    for (int i = startcol; i <= endcol; i++)
                    {
                        matrix[endrow, i] = k;
                        k++;
                    };
                    endrow--;
                    for (int i = endrow; i >= startrow; i--)
                    {
                        matrix[i, endcol] = k;
                        k++;
                    }
                    endcol--;
                    for (int i = endcol; i >= startcol; i--)
                    {
                        matrix[startrow, i] = k;
                        k++;
                    }
                    startrow++;
                };
                break;
            default:
                Console.WriteLine("Bad input!");
                break;
        }
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (j!=n-1)
                {
                    Console.Write("{0} ", matrix[i, j]);
                }
                else
                {
                    Console.WriteLine(matrix[i,j]);
                }
            }
        }
    }
}

