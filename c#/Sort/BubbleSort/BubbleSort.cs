using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// 버블정렬
/// - 버블정렬은 인접한 두 값을 비교하여 정렬하는 방법이다.
/// - 시간 복잡도 O(n^2)
/// - 최선의 경우 : 이미 정렬이 되어있는 경우 (시간 복잡도 O(n^2))
/// - 최악의 경우 : 예상되는 정렬 결과와 완전 반대인 경우 (시간 복잡도 O(n^2))
namespace BubbleSort
{
    class MainApp
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] {21, 4, 15, 8, 6, 9};
            int temp = 0;

            for(int i = 0; i < arr.Length; i++)
            {
                for(int j = 1 + i; j < arr.Length; j++)
                {
                    if(arr[i] > arr[j])
                    {
                        temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }

            for(int i = 0; i < arr.Length; i++)
                Console.WriteLine(arr[i]);
        }
    }
}

