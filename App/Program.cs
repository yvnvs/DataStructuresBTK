using System;
using System.Collections;
using DataStructures;
using DataStructures.LinkedList.DoublyLinkedList;
using DataStructures.LinkedList.SinglyLinkedList;

namespace Apps
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new DoublyLinkedList<int>(new int[] {23, 44 ,55 ,61});

            list.Remove(55);

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }


    }
}
