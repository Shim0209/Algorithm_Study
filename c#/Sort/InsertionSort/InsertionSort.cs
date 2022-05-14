using System;
using System.Diagnostics;

/// 삽입정렬
/// - 앞의 숫자가 현재 숫자보다 큰지 비교하면서 클경우 현재 위치에 큰 값을 삽입하는 정렬방식이다.
namespace InsertionSort
{
    class MainApp
    {
        static void Main(string[] args)
        {
            Console.WriteLine("[삽입정렬]");
            Stopwatch watch = Stopwatch.StartNew();

            int[] arr = new int[] { 4, 3, 5, 9, 2, 1, 7, 8, 6, 0 };

            foreach (int i in arr)
                Console.Write($"{i} ");
            Console.WriteLine();

            watch.Start();
            for (int i = 1; i < arr.Length; i++)
            {
                int key = i;
                for(int j = i - 1; j >= 0; j--)
                {
                    if(arr[j] > arr[key])
                    {
                        int temp = arr[j];
                        arr[j] = arr[key];
                        arr[key] = temp;
                        key = j;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            watch.Stop();

            foreach (int i in arr)
                Console.Write($"{i} ");
            Console.WriteLine();

            Console.WriteLine($"코드 실행 시간 : {watch.ElapsedMilliseconds} ms");
        }
    }
}

