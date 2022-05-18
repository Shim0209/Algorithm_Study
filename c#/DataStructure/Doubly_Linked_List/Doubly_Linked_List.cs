using System;

/// 이중 연결 리스트
/// - 단방향으로 연결된 단일 연결 리스트의 탐색 기능을 개선한 것
/// - 리스트 안의 노드가 이전 노드와 다음 노드를 가리키는 포인터를 모두 가지고 있어 양방향 탐색이 가능한 자료 구조이다.
/// 
/// 구현
/// 1. 노드를 표현하는 노드 클래스 정의
/// 2. 노드를 연결한 리스트인 이중 연결 리스트 클래스 정의
/// 
/// 원형 이중 연결 리스트
/// - 환형 연결 리스트라고도 한다.
/// - 일반 연결 리스트에서 마지막 노드를 처음 노드에 연결시켜 원형으로 만든 구조
namespace Doubly_Linked_List
{
    #region 이중 연결 리스트 노드
    public class DoublyLinkedListNode<T>
    {
        public T Data { get; set; }
        public DoublyLinkedListNode<T> Prev { get; set; }
        public DoublyLinkedListNode<T> Next { get; set; }   
        
        public DoublyLinkedListNode(T data) : this(data, null, null)
        {
        }
        public DoublyLinkedListNode(T data, DoublyLinkedListNode<T> prev, DoublyLinkedListNode<T> next)
        {
            this.Data = data;
            this.Prev = prev;
            this.Next = next;
        }
    }
    #endregion
    #region 이중 연결 리스트
    public class DoublyLinkedList<T>
    {
        private DoublyLinkedListNode<T> head;
        public void Add(DoublyLinkedListNode<T> newNode)
        {
            if(head == null)
            {
                head = newNode;
            }
            else
            {
                var current = head;
                while(current != null && current.Next != null)
                {
                    current = current.Next;
                }

                // 추가할 때 양방향 연결
                current.Next = newNode;
                newNode.Prev = current;
                newNode.Next = null;
            }

        }
        public void AddAfter(DoublyLinkedListNode<T> current, DoublyLinkedListNode<T> newNode)
        {
            if(head == null || current == null || newNode == null)
            {
                throw new InvalidOperationException();
            }

            newNode.Next = current.Next;
            current.Next.Prev = newNode;
            newNode.Prev = current;
            current.Next = newNode;
        }
        public void Remove(DoublyLinkedListNode<T> removeNode)
        {
            if(head == null || removeNode == null)
            {
                return;
            }

            // 삭제 노드가 첫 노드이면
            if(removeNode == head)
            {
                head = head.Next;
                if(head != null)
                {
                    head.Prev = null;
                }
            }
            else // 첫 노드가 아니면, Prev노드와 Next노드를 연결
            {
                removeNode.Prev.Next = removeNode.Next;
                if(removeNode.Next != null)
                {
                    removeNode.Next.Prev = removeNode.Prev;
                }
            }

            //removeNode = null;
        }
        public DoublyLinkedListNode<T> GetNode(int index)
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
                current = current.Next;
                cnt++;
            }

            return cnt;
        }
    }
    #endregion
    #region 원형 이중 연결 리스트
    public class CircularLinkedList<T>
    {
        private DoublyLinkedListNode<T> head;
        public void Add(DoublyLinkedListNode<T> newNode)
        {
            if (head == null) // 리스트가 비어 있으면
            {
                head = newNode;
                head.Next = head;
                head.Prev = head;
            }
            else // 비어 있지 않으면 헤드와 테일 사이에 삽입
            {
                var tail = head.Prev;

                head.Prev = newNode;
                tail.Next = newNode;
                newNode.Prev = tail;
                newNode.Next = head;
            }
        }
        public void AddAfter(DoublyLinkedListNode<T> current, DoublyLinkedListNode<T> newNode)
        {
            if (head == null || current == null || newNode == null)
            {
                throw new InvalidOperationException();
            }

            newNode.Next = current.Next;
            current.Next.Prev = newNode;
            newNode.Prev = current;
            current.Next = newNode;
        }
        public void Remove(DoublyLinkedListNode<T> removeNode)
        {
            if (head == null || removeNode == null)
            {
                return;
            }

            // 삭제할 노드가 헤드 노드이고 노드가 1개이면
            if (removeNode == head && head.Next == head)
            {
                head = null;
            }
            else // 아니면 Prev 노드와 Next 노드를 연결
            {
                removeNode.Prev.Next = removeNode.Next;
                removeNode.Next.Prev = removeNode.Prev;
            }

            //removeNode = null;
        }
        public DoublyLinkedListNode<T> GetNode(int index)
        {
            if (head == null) return null;

            int cnt = 0;
            var current = head;
            while (cnt < index)
            {
                current = current.Next;
                cnt++;
                if (current == head) // index값이 리스트보다 클 경우에 해당됨
                {
                    return null;
                }
            }

            return current;
        }

        public int Count()
        {
            if (head == null) return 0;

            int cnt = 0;
            var current = head;
            do
            {
                cnt++;
                current = current.Next;
            } while (current != head);

            return cnt;
        }
    }
    #endregion

    class MainApp
    {
        static void Main(string[] args)
        {
            // 정수형 이중 연결 리스트 생성
            var list = new DoublyLinkedList<int>();
            var list2 = new CircularLinkedList<int>();

            // 리스트에 0 ~ 4 추가
            for(int i = 0; i < 5; i++)
            {
                list.Add(new DoublyLinkedListNode<int>(i));
                list2.Add(new DoublyLinkedListNode<int>(i));
            }

            // Index가 2인 요소 삭제
            var targetNode = list.GetNode(2);
            list.Remove(targetNode);

            var targetNode2 = list2.GetNode(2);
            list2.Remove(targetNode2);

            // Index가 1인 요소 가져오기
            targetNode = list.GetNode(1);
            targetNode2 = list2.GetNode(1);

            // Index가 1인 요소 뒤에 100 삽입
            list.AddAfter(targetNode, new DoublyLinkedListNode<int>(100));
            list2.AddAfter(targetNode2, new DoublyLinkedListNode<int>(100));

            // 리스트 카운트 체크
            int count = list.Count();
            int count2 = list2.Count();

            // 전체 리스트 출력
            // 결과 : 0 1 100 3 4
            for(int i = 0; i < count; i++)
            {
                var n = list.GetNode(i);
                Console.Write($"{n.Data} ");
            }
            Console.WriteLine();

            // 리스트 역으로 출력
            // 결과 : 4 3 100 1 0
            targetNode = list.GetNode(4);
            for(int i = 0; i < count; i++)
            {
                Console.Write($"{targetNode.Data} ");
                targetNode = targetNode.Prev;
            }
            Console.WriteLine();

            // 원형 리스트 확인 위해 리스트 두배 출력
            // 결과 : 0 1 100 3 4 0 1 100 3 4
            targetNode2 = list2.GetNode(0);
            for(int i = 0; i < (count*2); i++)
            {
                Console.Write($"{targetNode2.Data} ");
                targetNode2 = targetNode2.Next;
            }
            Console.WriteLine();
        }
    }
}

