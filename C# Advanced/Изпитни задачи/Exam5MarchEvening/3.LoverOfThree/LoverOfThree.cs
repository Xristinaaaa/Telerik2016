using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.LoverOfThree
{
    class LoverOfThree
    {
        //static void Main(string[] args)
        //{
        //    //rows and cols
        //    int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        //    int R = numbers[0];
        //    int C = numbers[1];

        //    int[,] matrix = new int[R, C];

        //    int startNum = 0;
        //    for (int i = R - 1; i >= 0; i--)
        //    {
        //        int num = startNum;
        //        for (int j = 0; j < C; j++)
        //        {
        //            matrix[i, j] = num;
        //            num += 3;
        //        }
        //        startNum += 3;
        //    }

        //    int currentRow = matrix.GetLength(0) - 1;
        //    int currentCol = 0;
        //    long sum = 0;

        //    //num of directions
        //    int N = int.Parse(Console.ReadLine());
        //    for (int i = 0; i < N; i++)
        //    {
        //        //RU LU DL DR
        //        object[] DK = Console.ReadLine().Split(' ');
        //        string currentDirection = Convert.ToString(DK[0]);
        //        int currentStep = Convert.ToInt32(DK[1]);

        //        if (currentDirection == "RU" || currentDirection == "UR")
        //        {
        //            for (int j = 0; j < currentStep - 1; j++)
        //            {
        //                currentRow--;
        //                currentCol++;

        //                if (currentRow < 0 || currentRow >= matrix.GetLength(0) || currentCol < 0 || currentCol >= matrix.GetLength(1))
        //                {
        //                    if (currentRow < 0)
        //                    {
        //                        currentRow++;
        //                        currentCol--;
        //                        break;
        //                    }
        //                    if (currentCol >= matrix.GetLength(1))
        //                    {
        //                        currentCol--;
        //                        currentRow++;
        //                        break;
        //                    }
        //                }
        //                else
        //                {
        //                    int number = matrix[currentRow, currentCol];
        //                    sum += number;
        //                }
        //                matrix[currentRow, currentCol] = 0;
        //            }
        //        }

        //        else if (currentDirection == "LU" || currentDirection == "UL")
        //        {
        //            for (int j = 0; j < currentStep - 1; j++)
        //            {
        //                currentRow--;
        //                currentCol--;

        //                if (currentRow < 0 || currentRow >= matrix.GetLength(0) || currentCol < 0 || currentCol >= matrix.GetLength(1))
        //                {
        //                    if (currentRow < 0)
        //                    {
        //                        currentRow++;
        //                        currentCol++;
        //                        break;
        //                    }
        //                    if (currentCol < 0)
        //                    {
        //                        currentCol++;
        //                        currentRow++;
        //                        break;
        //                    }
        //                }
        //                else
        //                {
        //                    int number = matrix[currentRow, currentCol];
        //                    sum += number;
        //                }
        //                matrix[currentRow, currentCol] = 0;
        //            }
        //        }

        //        else if (currentDirection == "DL" || currentDirection == "LD")
        //        {

        //            for (int j = 0; j < currentStep - 1; j++)
        //            {
        //                currentRow++;
        //                currentCol--;

        //                if (currentRow < 0 || currentRow >= matrix.GetLength(0) || currentCol < 0 || currentCol >= matrix.GetLength(1))
        //                {
        //                    if (currentRow >= matrix.GetLength(0))
        //                    {
        //                        currentRow--;
        //                        currentCol++;
        //                        break;
        //                    }
        //                    if (currentCol < 0)
        //                    {
        //                        currentCol++;
        //                        currentRow--;
        //                        break;
        //                    }
        //                }
        //                else
        //                {
        //                    int number = matrix[currentRow, currentCol];
        //                    sum += number;
        //                }
        //                matrix[currentRow, currentCol] = 0;
        //            }
        //        }

        //        else if (currentDirection == "DR" || currentDirection == "RD")
        //        {
        //            for (int j = 0; j < currentStep - 1; j++)
        //            {
        //                currentRow++;
        //                currentCol++;

        //                if (currentRow < 0 || currentRow >= matrix.GetLength(0) || currentCol < 0 || currentCol >= matrix.GetLength(1))
        //                {
        //                    if (currentRow >= matrix.GetLength(0))
        //                    {
        //                        currentRow--;
        //                        currentCol--;
        //                        break;
        //                    }
        //                    if (currentCol >= matrix.GetLength(1))
        //                    {
        //                        currentCol--;
        //                        currentRow--;
        //                        break;
        //                    }
        //                }
        //                else
        //                {
        //                    int number = matrix[currentRow, currentCol];
        //                    sum += number;
        //                }
        //                matrix[currentRow, currentCol] = 0;
        //            }
        //        }
        //    }
        //    Console.WriteLine(sum);
        //}       




        //1.read sizes and create boolean field
        //2.read directions
        //2.1.go in that direction until possible
        //2.2 sum cells on the way using formula
        //2.2.2 keep inf if we have already collected
        //2.3 read another direcion
        //3. print the result

        static void Main ()
        {
            var fieldSizes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var rowsCount = fieldSizes[0];
            var colCount = fieldSizes[1];

            var field = new bool[rowsCount, colCount];

            var n = int.Parse(Console.ReadLine());
            long result = 0;

            int row = rowsCount - 1;
            int col = 0;
            int currentCell = 0;
            for (int i = 0; i < n; i++)
            {
                var move = Console.ReadLine().Split(' ');

                var direction = move[0];
                var repeats = int.Parse(move[1]);

                var deltaRow = direction.Contains("U") ? -1 : 1;
                var deltaCol = direction.Contains("L") ? -1 : 1;

                //or 0 to repeats-1
                for (int j = 1; j < repeats; j++)
                {
                    if (IsInside(row+deltaRow, col+deltaCol, field))
                    {
                        row += deltaRow;
                        col += deltaCol;

                        if (deltaRow==-1 && deltaCol==1)
                        {
                            currentCell += 6;
                        }
                        else if (deltaRow==1 && deltaCol==-1)
                        {
                            currentCell -= 6;
                        }

                        if (!field[row, col])
                        {
                            result += currentCell;
                            field[row, col] = true;
                        }   
                    }
                }
            }
            Console.WriteLine(result);
        }

        static bool IsInside(int row, int col, bool[,] matrix)
        {
            bool rowIsInField = 0 <= row && row < matrix.GetLength(0);
            bool colIsInField = 0 <= col && col < matrix.GetLength(1);

            return rowIsInField && colIsInField;
        }
    }
}
