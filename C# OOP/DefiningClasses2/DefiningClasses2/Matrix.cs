using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses2
{
    class Matrix<T> where T : IComparable<T>
    {
        private T[,] matrix;

        public Matrix(int row, int col)
        {
            this.matrix = new T[row, col];
        }

        public T this[int row, int col]
        {
            get
            {
                return this.matrix[row, col];
            }
            set
            {
                this.matrix[row, col] = value;
            }
        }

        public static Matrix<T> operator +(Matrix<T> first, Matrix<T> second)
        {
            if (first.matrix.GetLength(0) != second.matrix.GetLength(0) ||
            first.matrix.GetLength(1) != second.matrix.GetLength(1))
            {
                throw new ArgumentException("Wrong dimensions!");
            }

            var resultMatrix = new Matrix<T>(first.matrix.GetLength(0), first.matrix.GetLength(1));

            for (int row = 0; row < first.matrix.GetLength(0); row++)
            {
                for (int col = 0; col < first.matrix.GetLength(1); col++)
                {
                    resultMatrix[row, col] = (dynamic)first[row, col] + (dynamic)second[row, col];
                }
            }
            return resultMatrix;
        }  

        public static Matrix<T> operator -(Matrix<T> first, Matrix<T> second)
        {
            if (first.matrix.GetLength(0) != second.matrix.GetLength(0) ||
            first.matrix.GetLength(1) != second.matrix.GetLength(1))
            {
                throw new ArgumentException("Wrong dimensions!");
            }

            var result = new Matrix<T>(first.matrix.GetLength(0), first.matrix.GetLength(1));

            for (int row = 0; row < first.matrix.GetLength(0); row++)
            {
                for (int col = 0; col < first.matrix.GetLength(1); col++)
                {
                    T max = first[row, col];
                    T min = second[row, col];

                    if ((dynamic)first[row, col] < (dynamic)second[row, col])
                    {
                        max = second[row, col];
                        min = first[row, col];
                    }
                    result[row, col] = (dynamic)max - (dynamic)min;
                }
            }
            return result;
        }  

        public static Matrix<T> operator *(Matrix<T> first, Matrix<T> second)
        {
            if (first.matrix.GetLength(1) != second.matrix.GetLength(0))
            {
                throw new ArgumentException("Wrong dimensions !");
            }

            var result = new Matrix<T>(first.matrix.GetLength(0), second.matrix.GetLength(1));

            for (int row = 0; row < result.matrix.GetLength(0); row++)
            {
                for (int col = 0; col < result.matrix.GetLength(1); col++)
                {
                    for (int i = 0; i < first.matrix.GetLength(1); i++)
                    {
                        result[row, col] += (dynamic)first[row, i] * (dynamic)second[i, col];
                    }
                }
            }
            return result;
        } 

        public static bool operator true(Matrix<T> matrix)
        {
            bool isTrue = true;

            for (int row = 0; row < matrix.matrix.GetLength(0) && isTrue; row++)
            {
                for (int col = 0; col < matrix.matrix.GetLength(1) && isTrue; col++)
                {
                    if ((dynamic)matrix[row, col] == 0)
                    {
                        isTrue = false;
                    }
                }
            }
            return isTrue;
        }   

        public static bool operator false(Matrix<T> matrix)
        {
            bool isTrue = true;

            for (int row = 0; row < matrix.matrix.GetLength(0) && isTrue; row++)
            {
                for (int col = 0; col < matrix.matrix.GetLength(1) && isTrue; col++)
                {
                    if ((dynamic)matrix[row, col] == 0)
                    {
                        isTrue = false;
                    }
                }
            }
            return !isTrue;
        }       

        public static bool operator !(Matrix<T> matrix)
        {
            if (matrix)
            {
                return false;
            }
            return true;
        }       

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            for (int row = 0; row < this.matrix.GetLength(0); row++)
            {
                for (int col = 0; col < this.matrix.GetLength(1); col++)
                {
                    result.AppendFormat("{0:D2} ", this.matrix[row, col]);
                }
                result.Append("\n");
            }
            return result.ToString();
        }
    }
}
