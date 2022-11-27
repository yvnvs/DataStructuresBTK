using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataStructures.LinkedList.SinglyLinkedList
{
    public class SingleLinkedList<T>: IEnumerable<T>
    {




        public SinglyLinkedListNode<T> Head { get; set; }
        private bool isHeadNull => Head == null;
        public SingleLinkedList(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                this.AddFirst(item);
            }
        }

        public void AddFirst(T value)
        {
            var newNode = new SinglyLinkedListNode<T>(value);
            newNode.Next = Head;
            Head = newNode;
        }

        public void AddLast(T value)
        {
            var newNode = new SinglyLinkedListNode<T>(value);
            var current = Head;

            if (isHeadNull)
            {
                Head = newNode;
                return;
            }

            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newNode;
        }

        public void AddAfter(SinglyLinkedListNode<T> node, T value)
        {
            if (node == null)
            {
                throw new ArgumentNullException();
            }

            if (isHeadNull)
            {
                AddFirst(value);
                return;
            }

            var newNode = new SinglyLinkedListNode<T>(value);
            var current = Head;

            while (current.Next != null)
            {
                if (current.Equals(node))
                {
                    newNode.Next = current.Next;
                    current.Next = newNode;
                    return;
                }

                current = current.Next;
            }

            throw new ArgumentException("The reference node is not in this list.");
        }


        public void AddBefore(SinglyLinkedListNode<T> node, T value)
        {
            if (node == null)
            {
                throw new ArgumentNullException();
            }

            if (isHeadNull)
            {
                AddFirst(value);
                return;
            }

            var newNode = new SinglyLinkedListNode<T>(value);
            var current = Head;

            while (current != null)
            {
                if (current.Equals(node))
                {
                    newNode.Next = current.Next;
                    current.Next = newNode;
                    return;
                }

                current = current.Next;
            }
        }


        public T RemoveFirst()
        {
            if (isHeadNull)
                throw new Exception("Nothing to remove!");

            var firsValue = Head.Value;

            Head = Head.Next;

            return firsValue;
        }

        public T RemoveLast()
        {
            var current = Head;
            SinglyLinkedListNode<T> prev = null;

            while (current.Next != null)
            {
                prev = current;
                current = current.Next; 
            }
            var lastValue = prev.Next.Value;
            prev.Next = null;
            return lastValue;

        }

        public void Remove(T value)
        {
            if (isHeadNull)
            {
                throw new Exception("Nothing to remove");
            }

            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            var current = Head;
            SinglyLinkedListNode<T> prev = null;

            do
            {
                if (current.Value.Equals(value))
                {
                    // son eleman mı?
                    if (current.Next == null)
                    {
                        // ilk eleman-head
                        if (prev == null)
                        {
                            Head = null;
                            return;
                        }
                        // son eleman
                        else
                        {
                            prev.Next = null;
                            return;
                        }
                    }
                    else
                    {
                        //head
                        if (prev == null)
                        {
                            Head = Head.Next;
                            return;
                        }
                        // ara eleman
                        else
                        {
                            prev.Next = current.Next;
                            return;
                        }
                    }
                }

                prev = current;
                current= current.Next;
            } while (current != null);

            throw new ArgumentException("The value could not be found in the list!");
        }
        public IEnumerator<T> GetEnumerator()
        {
            return new SinglyLinkedListEnumerator<T>(Head);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
