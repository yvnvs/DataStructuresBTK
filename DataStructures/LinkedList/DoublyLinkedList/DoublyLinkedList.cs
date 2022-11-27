using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.LinkedList.DoublyLinkedList
{
    public class DoublyLinkedList<T>: IEnumerable
    {
        public DoublyLinkedListNode<T> Head { get; set; }
        public DoublyLinkedListNode<T> Tail { get; set; }

        private bool isHeadNull => Head == null;
        private bool isTailNull => Tail == null;
        public DoublyLinkedList()
        {

        }

        public DoublyLinkedList(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                AddLast(item);
            }
        }
        public void AddFirst(T value)
        {
            var newNode = new DoublyLinkedListNode<T>(value);
            if (Head != null)
            {
                Head.Prev = newNode;
            }

            newNode.Next = Head;
            newNode.Prev = null;
            Head = newNode;

            if (Tail == null)
            {
                Tail = Head;
            }
        }
        public void AddLast(T value)
        {

            if (Tail == null)
            {
                AddFirst(value);
                return;
            }
            var newNode = new DoublyLinkedListNode<T>(value);
            Tail.Next = newNode;
            newNode.Next = null;
            newNode.Prev = Tail;

            Tail = newNode;
            return;
        }
        public void AddAfter(DoublyLinkedListNode<T> refNode, DoublyLinkedListNode<T> newNode)
        {
            if (refNode == null)
            {
                throw new ArgumentNullException();

            }

            if (refNode == Head && refNode == Tail)
            {
                refNode.Next = Head;
                refNode.Prev = null;

                newNode.Prev = refNode;
                newNode.Next = null;

                Head = refNode;
                Tail = newNode;

            }

            if (refNode != Tail)
            {
                newNode.Prev = refNode;
                newNode.Next = refNode.Next;

                refNode.Next.Prev = newNode;
                refNode.Next = newNode;
            }
            else
            {
                newNode.Prev = refNode;
                newNode.Next = null;

                refNode.Next = newNode;
                Tail = newNode;
            }
        }


        public void AddBefore(DoublyLinkedListNode<T> refNode, DoublyLinkedListNode<T> newNode)
        {
            if (refNode == null)
            {
                throw new ArgumentNullException();

            }

            if (refNode == Head && refNode == Tail)
            {
                newNode.Next = Head;
                Head = newNode;

            }

            if (refNode != Tail)
            {
                if (refNode.Prev == null)
                {
                    refNode.Prev = newNode;
                    newNode.Next = refNode;
                    newNode.Prev = null;
                    Head = newNode;
                }
                newNode.Prev = refNode.Prev;
                newNode.Prev.Next = newNode;
                newNode.Next = refNode;
                refNode.Prev = newNode;


            }
            else
            {
                newNode.Prev = refNode.Prev;
                newNode.Next = refNode;

                refNode.Prev = newNode;

            }
        }

        private List<DoublyLinkedListNode<T>> GetAllNodes()
        {
            var list = new List<DoublyLinkedListNode<T>>();
            var current = Head;

            while (current != null)
            {
                list.Add(current);
                current = current.Next;
            }

            return list;
        }
        public T RemoveFirst()
        {
            if (isHeadNull)
            {
                throw new ArgumentNullException();

            }

            var temp = Head.Value;

            if (Head == Tail)
            {
                Head = null;
                Tail = null;
            }
            else
            {
                Head = Head.Next;
                Head.Prev = null;

            }


            return temp;

        }

        public T RemoveLast()
        {
            if (isTailNull)
            {
                throw new ArgumentNullException();

            }

            var temp = Tail;
            if (Tail == Head)
            {
                Head = null;
                Tail = null;
            }
            else
            {
                Tail.Prev.Next = null;
                Tail = Tail.Prev;
            }

            return temp.Value;



        }

        public void Remove(T value)
        {
            if (isHeadNull)
            {
                throw new ArgumentNullException();

            }
            // tek eleman
            if (Head == Tail)
            {
                if (Head.Value.Equals(value))
                {
                    RemoveFirst();
                }
                return;
            }

            var current = Head;

            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    // current -> ilk eleman
                    if (current.Prev == null)
                    {
                        current.Next.Prev = null;
                        Head = current.Next;

                    }
                    // current -> son eleman
                    else if (current.Next == null)
                    {
                        current.Prev.Next = null;
                        Tail = current.Prev;
                    }
                    //current -> arada bir pozisyonda
                    else
                    {
                        current.Prev.Next = current.Next;
                        current.Next.Prev = current.Prev;
                    }
                    break;
                }
                current = current.Next;
            }
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAllNodes().GetEnumerator();
        }
    }
}
