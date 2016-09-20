using System;

class BinarySearch
{
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        int[] arr = new int[N];
        for (int i = 0; i < N; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
        }
        Array.Sort(arr);
        int X = int.Parse(Console.ReadLine());

        int index=0;
        int left = 0;
        int right = N;

        while (left<=right)
        {
            int mid = (left + right) / 2;
            if (X == arr[mid])
            {
                index = mid;
                Console.WriteLine(index);
                return;
            }
            else if (X > arr[mid])
            {
                left = mid + 1;
            }
            else if (X < arr[mid])
            {
                right = mid - 1;
            }
        }

        if (index==0)
        {
            Console.WriteLine("-1");
        }
    }
}
