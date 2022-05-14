using System;

/// 단일 연결 리스트
/// - 단방향으로 노드들을 연결한 간단한 자료 구조이다.
/// 
/// 구현
/// 1. 노드를 표현하는 노드 클래스 정의
///     - 데이터 필드
///     - 다음 노드를 가리키는 포인터
/// 2. 노드를 연결한 리스트인 링크드리스트 클래스 정의
namespace Singly_Linked_List
{
    public class SinglyLinkedListNode<T>
    {
        public T Data { get; set; }
        public SinglyLinkedListNode<T> Next { get; set; }
        public SinglyLinkedListNode(T data)
        {
            this.Data = data;
            this.Next = null;
        }
    }
    public class SinglyLinkedList<T>
    {
        private SinglyLinkedListNode<T> head;
        public void Add(SinglyLinkedListNode<T> newNode)
        {
            // 리스트가 비어 있으면
            if(head == null)
            {
                head = newNode;
            }
            else // 비어 있지 않으면
            {
                var current = head;
                // 마지막 노드로 이동하여 추가
                while(current != null & current.Next != null)
                {
                    current = current.Next;
                }

                current.Next = newNode;
            }
        }
        public void AddAfter(SinglyLinkedListNode<T> current, SinglyLinkedListNode<T> newNode)
        {
            if(head == null || current == null || newNode == null)
            {
                throw new InvalidOperationException();
            }

            newNode.Next = current.Next;
            current.Next = newNode;
        }
        public void Remove(SinglyLinkedListNode<T> removeNode)
        {
            if(head == null || removeNode == null)
            {
                return;
            }

            // 삭제할 노드가 첫 노드이면
            if(removeNode == head)
            {
                head = head.Next;
                //removeNode = null;
            }
            else // 첫 노드가 아니면, 해당 노드를 검색하여 삭제
            {
                var current = head;

                // 단방향이므로 삭제할 노드의 바로 이전 노드를 검색
                while(current != null && current.Next != removeNode)
                {
                    current = current.Next;
                }

                if(current != null)
                {
                    current.Next = removeNode.Next;
                    //removeNode = null;
                }
            }
        }
        public SinglyLinkedListNode<T> GetNode(int index)
        {
            var current = head;

            for(int i = 0; i < index && current != null; i++)
            {
                current = current.Next;
            }

            // 만약 index가 리스트 카운트보다 크면 null 반환
            return current;
        }
        public int Count()
        {
            int cnt = 0;

            var current = head;
            while(current != null)
            {
                cnt++;
                current = current.Next;
            }

            return cnt;
        }
    }
    class MainApp
    {
        static void Main(string[] args)
        {
            // 정수형 단일 연결 리스트 생성
            var list = new SinglyLinkedList<int>();

            // 리스트에 0 ~ 4추가
            for(int i = 0; i<5; i++)
            {
                list.Add(new SinglyLinkedListNode<int>(i));
            }

            // Index가 2인 요소 삭제
            var node = list.GetNode(2);
            list.Remove(node);

            // Index가 1인 요소 가져오기
            node = list.GetNode(1);

            // Index가 1인 요소 뒤에 100삽입
            list.AddAfter(node, new SinglyLinkedListNode<int>(100));

            // 리스트 카운트 체크
            int count = list.Count();

            // 전체 리스트 출력
            // 예상 결과 : 0 1 100 3 4
            for(int i = 0; i < count; i++)
            {
                var n = list.GetNode(i);
                Console.Write($"{n.Data} ");
            }
        }
    }
}

