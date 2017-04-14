namespace MatrixOperations
{
    using System;

    public class Matrix
    {
        private static readonly int[] dirX = { 1, 1, 1, 0, -1, -1, -1, 0 };
        private static readonly int[] dirY = { 1, 0, -1, -1, -1, 0, 1, 1 };
        private const int length = 7;

        public static void Change(ref int dx, ref int dy)
        {
            Validator.ValidateNull(dx);
            Validator.ValidateNull(dy);

            int cd = 0;

            for (int count = 0; count <= length; count++)
            {
                if (dirX[count] == dx && dirY[count] == dy)
                {
                    cd = count;
                    break;
                }
            }

            if( cd == length )
            {
                dx = dirX[0];
                dy = dirY[0];
                return;
            }
            
            dx = dirX[cd + 1];
            dy = dirY[cd + 1];
        }

        public static bool CheckOut(int[,] arr, int x, int y)
        {
            Validator.ValidateNull(arr);
            Validator.ValidateNull(x);
            Validator.ValidateNull(y);

            for(int i = 0; i <= length; i++)
            {
                if (x + dirX[i] < 0 || arr.GetLength(0) <= x + dirX[i])
                {
                    dirX[i] = 0;
                }

                if (y + dirY[i] < 0 || arr.GetLength(0) <= y + dirY[i])
                {
                    dirY[i] = 0;
                }
            }

            for (int i = 0; i <= length; i++)
            {
                if (arr[x + dirX[i], y + dirY[i]] == 0)
                {
                    return true;
                }
            }
            return false;
        }

        public static void FindCell (int[,] arr, out int x, out int y)
        {
            x = 0;
            y = 0;

            Validator.ValidateNull(arr);

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(0); j++)
                {
                    if (arr[i, j] == 0)
                    {
                        x = i;
                        y = j;
                        return;
                    }
                }
            }
        }

        public static void OutputMatrix(int[,] matrix, int n)
        {
            for (int p = 0; p < n; p++)
            {
                for (int q = 0; q < n; q++)
                {
                    Console.Write("{0,3}", matrix[p, q]);
                }
            }
        }

        public static void ChangeIfUndefined(int[,] matrix, int n)
        {
            int k = 1,
               dx = 1,
               dy = 1;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = k;

                    if (!CheckOut(matrix, i, j))
                    {
                        break;
                    }

                    if (j + dy >= n || i + dx >= n || matrix[i + dx, j + dy] != 0)
                    {
                        Change(ref dx, ref dy);
                        k++;
                    }
                }
            }
        }
    }
}
