using System;
using System.Linq;

class SortingArray
{
    static int MaxEl(int[] array, int start)
    {
        int maxElement = int.MinValue;
        for (int i = start; i < array.Length; i++)
        {
            if (array[i]>maxElement)
            {
                maxElement = array[i];
            }
        }
        return maxElement;
    }
    static void Sort(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            int temp = array[i];
            int indexOfMaximalElement = Array.LastIndexOf(array, MaxEl(array,i));
            array[i] = MaxEl(array,i);
            array[indexOfMaximalElement] = temp;
        }
        Array.Reverse(array);
    }
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        Sort(arr);
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write(arr[i]+" ");
        }
    }
}
