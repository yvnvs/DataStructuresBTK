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

            var charset = new char[] { 'A', 'B', 'C', 'D', 'E' };
            var stack1 = new DataStructures.Stack.Stack<char>();
            var stack2 = new DataStructures.Stack.Stack<char>(StackType.LinkedList);

            foreach (var c in charset)
            {
                Console.WriteLine(c);
                stack1.Push(c);
                stack2.Push(c);
            }

            Console.WriteLine("\nPeek");
            Console.WriteLine($"Stack1: {stack1.Peek()}");
            Console.WriteLine($"Stack2: {stack2.Peek()}");

            Console.WriteLine("\nCount");
            Console.WriteLine($"Stack1: {stack1.Count}");
            Console.WriteLine($"Stack2: {stack2.Count}");

            Console.WriteLine("\nPop");
            Console.WriteLine($"Stack1: {stack1.Pop()} has been removed");
            Console.WriteLine($"Stack2: {stack2.Pop()} has been removed");


            Console.ReadKey();
        }


    }
}
