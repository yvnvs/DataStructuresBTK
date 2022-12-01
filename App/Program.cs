using System;
using DataStructures.LinkedList.DoublyLinkedList;
using DataStructures.LinkedList.SinglyLinkedList;
using DataStructures.Stack;

namespace Apps
{
    class Program
    {
        static void Main(string[] args)
        {
            var number = new int[] { 1, 2, 3, };
            var queue1 = new DataStructures.Queue.Queue<int>();
            var queue2 = new DataStructures.Queue.Queue<int>(DataStructures.Queue.QueueType.LinkedList);

            foreach (var item in number)
            {
                Console.WriteLine(item);
                queue1.EnQueue(item);
                queue2.EnQueue(item);
            }

            Console.WriteLine($"queue1 count: {queue1.Count}" );
            Console.WriteLine($"queue2 count: {queue2.Count}" );


            Console.ReadKey();
        }


    }
}
