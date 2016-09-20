using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class MaximalSum
{
    static void Main(string[] args)
    {
        int[] NM = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int N = NM[0];
        int M = NM[1];
        int[,] matrix = new int[N, M];

        for (int row = 0; row < N; row++)
        {
            int[] currentLine = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            for (int i = 0; i < currentLine.Length; i++)
            {
                matrix[row, i] = currentLine[i];
            }
        }

        int currentSum = 0;
        int maxSum = int.MinValue;
        for (int i = 0; i < matrix.GetLength(0)-2; i++)
        {
            for (int j = 0; j < matrix.GetLength(1)-2; j++)
            {
                currentSum += matrix[i, j] + matrix[i, j + 1] + matrix[i, j + 2]
                            + matrix[i + 1, j] + matrix[i + 1, j + 1] + matrix[i + 1, j + 2]
                            + matrix[i + 2, j] + matrix[i + 2, j + 1] + matrix[i + 2, j + 2];
                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                }
                currentSum = 0;
            }
        }
        Console.WriteLine(maxSum);
    }
}

