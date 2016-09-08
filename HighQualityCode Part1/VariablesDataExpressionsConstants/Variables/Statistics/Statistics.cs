using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statistics
{
    class Statistics
    {
        public void PrintStatistics(double[] arr, int count)
        {
            double maxValue = double.MinValue;

            for (int i = 0; i < count; i++)
            {
                if (arr[i] > maxValue)
                {
                    maxValue = arr[i];
                }
            }

            PrintMax(maxValue);

            
            double minValue = double.MaxValue;

            for (int i = 0; i < count; i++)
            {
                if (arr[i] < minValue)
                {
                    minValue = arr[i];
                }
            }

            PrintMin(minValue);


            double sum = 0;
            
            for (int i = 0; i < count; i++)
            {
                sum += arr[i];
            }

            PrintAvg(sum / count);
        }

        public void PrintMax(double maximum)
        {
            Console.WriteLine("Max value: " + maximum);
        }

        public void PrintMin(double minimum)
        {
            Console.WriteLine("Min value: " + minimum);
        }

        public void PrintAvg(double average)
        {
            Console.WriteLine("Average: " + average);
        }
    }
}
