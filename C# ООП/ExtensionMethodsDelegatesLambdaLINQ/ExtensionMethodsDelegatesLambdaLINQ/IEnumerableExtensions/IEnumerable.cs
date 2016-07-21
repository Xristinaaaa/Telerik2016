using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethodsDelegatesLambdaLINQ.IEnumerableExtensions
{
    public static class IEnumerable
    {
        public static double Sum<T>(this IEnumerable<T> list) where T: IConvertible
        {
            var convetToDouble = list.Select(x => Convert.ToDouble(x));

            double result = 0;
            foreach (var item in convetToDouble)
            {
                result += item;
            } 
            return result;
        }
        public static double Product<T>(this IEnumerable<T> list) where T : IConvertible
        {
            var convetToDouble = list.Select(x => Convert.ToDouble(x));

            double result = 1;
            foreach (var item in convetToDouble)
            {
                result *= item;
            }
            return result;
        }
        public static double Min<T>(this IEnumerable<T> list) where T : IConvertible
        {
            var convetToDouble = list.Select(x => Convert.ToDouble(x));
            double min = double.MaxValue;

            foreach (var item in convetToDouble)
            {
                if (item<min)
                {
                    min = item;
                }
            }
            return min;
        }
        public static double Max<T>(this IEnumerable<T> list) where T : IConvertible
        {
            var convetToDouble = list.Select(x => Convert.ToDouble(x));
            double max = double.MinValue;

            foreach (var item in convetToDouble)
            {
                if (item > max)
                {
                    max = item;
                }
            }
            return max;
        }
        public static double Average<T>(this IEnumerable<T> list) where T : IConvertible
        {
            var convetToDouble = list.Select(x => Convert.ToDouble(x));

            double result = 0;
            foreach (var item in convetToDouble)
            {
                result += item;
            }

            double average = result / convetToDouble.Count();
            return average;
        }
    }
}
