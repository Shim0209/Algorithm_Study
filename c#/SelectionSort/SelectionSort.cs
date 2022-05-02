using System;

/// 선택정렬
/// - 정렬하고자 하는 배열중 가장 작은수를 찾아 앞으로 보내는 정렬이다.
/// - 시간 복잡도 O(n^2)
/// 
/// 장점
/// - 비교적 쉬운 코드로 구현 가능
/// - 정렬이 진행됨에 따라 속도는 빨라짐
/// - 버블 정렬보다 값의 복사와 이동이 적어 비교적 빠름
/// 
/// 단점
/// - 데이터의 크기가 커질수록 효율이 떨어짐
/// - 데이터 정렬 속도가 고정적으로 n의 제곱만큼 걸려 더이상의 정렬 속도를 기대할 수 없음
namespace SelectionSort
{
    class MainApp
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 4, 3, 5, 9, 2, 1, 7, 8, 6, 0 };
            int targetIndex, temp;

            // 배열의 마지막 값은 자연스럽게 정렬 되므로 배열크기 -1 만큼만 반복
            for(int i = 0; i < arr.Length - 1; i++)
            {
                // 시작인덱스 저장
                targetIndex = i;

                // 비교인덱스는 시작인덱스 + 1에서 배열의 마지막까지 반복
                for(int j = i + 1; j < arr.Length; j++)
                {
                    // 시작인덱스 > 비교인덱스 : 오름차순, 시작인덱스 < 비교인덱스 : 내림차순
                    if (arr[i] > arr[j])
                        targetIndex = j;
                }

                if(targetIndex != i)
                {
                    // 시작인덱스와 가장작은 값을 가진 인덱스 교환
                    temp = arr[i];
                    arr[i] = arr[targetIndex];
                    arr[targetIndex] = temp;
                }
            }

            foreach(int i in arr)
                Console.WriteLine(arr[i]);
        }
    }
}

