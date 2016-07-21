﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _3.BitShiftMatrix
{
    class BitShiftMatrix
    {
        //1. read input
        //2. declare a field/matrix with R and C
        //3. for every move
            //3.1 calculate move coordinates
            //3.2 go to column and collect everything on the way and mark as collected
            //3.3 go to row and collect
            //3.4 do the same fol all moves
        //4. print the resulting sum

        static void Main()
        {
            int rowsCount = int.Parse(Console.ReadLine());
            int colsCount = int.Parse(Console.ReadLine());

            var n = Console.ReadLine();

            var collected = new bool[rowsCount, colsCount];

            var moves = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            BigInteger sum = 0;
            var row = rowsCount - 1;
            var col = 0;
            BigInteger currentCellValue = 1;
            var coeff = Math.Max(rowsCount, colsCount);

            foreach (var move in moves)
            {
                var nextRow = move / coeff;
                var nextCol = move % coeff;

                var deltaCol = col > nextCol ? -1 : 1;
                while (col!=nextCol)
                {
                    if (!collected[row,col])
                    {
                        sum += currentCellValue;
                        collected[row, col] = true;
                    }
                    if (deltaCol==1)
                    {
                        currentCellValue *= 2;
                    }
                    else
                    {
                        currentCellValue /= 2;
                    }
                    col += deltaCol;

                }

                var deltaRow = row > nextRow ? -1 : 1;
                while (row!=nextRow)
                {
                    if (!collected[row, col])
                    {
                        sum += currentCellValue;
                        collected[row, col] = true;
                    }

                    if (deltaRow==1)
                    {
                        currentCellValue /= 2;
                    }
                    else
                    {
                        currentCellValue *= 2;
                    }
                    row += deltaRow;
                }
            }
            if (!collected[row,col])
            {
                sum += currentCellValue;
                collected[row, col] = true;
            }
            
            Console.WriteLine(sum);            
        }
    }
}
