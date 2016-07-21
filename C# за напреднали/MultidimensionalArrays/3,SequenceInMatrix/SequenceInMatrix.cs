using System;
using System.Linq;
class SequenceInMatrix
{
    static void Main(string[] args)
    {
        int[] nm = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int n = nm[0];
        int m = nm[1];
        int[,] arr = new int[n, m];

        for (int i = 0; i < n; i++)
        {
            int[] currentline= Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            for (int j = 0; j < currentline.Length; j++)
            {
                arr[i, j] = currentline[j];
            }
        }
        int horizontalMax = HorizontalCount(arr, n, m);
        int verticalMax = VerticalCount(arr, n, m);
        int diagonalMax = DiagonalCount(arr, n, m);

        Console.WriteLine(Math.Max(horizontalMax, Math.Max(verticalMax, diagonalMax)));
    }
    public static int HorizontalCount(int[,] arr, int sizeY, int sizeX)
    {
        int count = 1;
        int result = 0;

        for (int i = 0; i < sizeY; i++)
        {
            for (int j = 0; j < sizeX - 1; j++)
            {
                if (arr[i, j + 1] == arr[i, j])
                {
                    count++;
                }
            }
            if (count > result)
            {
                result = count;
            }
            count = 1;
        }
        return result;
    }
    public static int VerticalCount(int[,] arr, int sizeY, int sizeX)
    {
        int count = 1;
        int result = 0;

        for (int i = 0; i < sizeX; i++)
        {
            for (int j = 0; j < sizeY - 1; j++)
            {
                if (arr[j + 1, i] == arr[j, i])
                {
                    count++;
                }
            }
            if (count > result)
            {
                result = count;
            }
            count = 1;
        }
        return result;
    }

    public static int DiagonalCount(int[,] arr, int sizeY, int sizeX)
    {
        int count = 1;
        int result = 0;

        //BOOTOM LEFT
        int row = sizeY - 2; //6-2 = 4
        int col = 0;

        for (int i = 0; i < sizeY - 1; i++)
        {
            for (int j = 0; j < i + 1 && j < sizeX - 1; j++)
            {
                if (arr[row + j, col + j] == arr[row + j + 1, col + j + 1])
                {
                    count++;
                }
            }
            if (count > result)
            {
                result = count;
            }
            count = 1;
            row--;
        }
        //TOP RIGHT
        col = sizeX - 2; //6-2 =4
        row = 0;
        for (int i = 0; i < sizeX - 2; i++)
        {
            for (int j = 0; j < i + 1 && j < sizeY - 1; j++)
            {
                if (arr[row + j, col + j] == arr[row + j + 1, col + j + 1])
                {
                    count++;
                }
            }
            if (count > result)
            {
                result = count;
            }
            count = 1;
            col--;
        }

        //BOTTOM RIGHT
        row = sizeY - 2;
        col = sizeX - 1;

        for (int i = 0; i < sizeY - 1; i++)
        {
            for (int j = 0; j < i + 1 && j < sizeX - 1; j++)
            {
                if (arr[row + j, col - j] == arr[row + j + 1, col - j - 1])
                {
                    count++;
                }
            }
            if (count > result)
            {
                result = count;
            }
            count = 1;
            row--;
        }
        //TOP LEFT
        col = 1;
        row = 0;
        for (int i = 0; i < sizeX - 2; i++)
        {
            for (int j = 0; j < i + 1 && j < sizeY - 1; j++)
            {
                if (arr[row + j, col - j] == arr[row + j + 1, col - j - 1])
                {
                    count++;
                }
            }
            if (count > result)
            {
                result = count;
            }
            count = 1;
            col++;
        }
        return result;
    }
}

