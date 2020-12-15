using System;

namespace ConsoleApp1
{
    class Program
    {
        internal class Node
        {
            internal int data;
            internal Node next;

            public Node(int d)
            {
                data = d;
                next = null;
            }
        }

        internal class LinkedListStack
        {
            Node top;

            public LinkedListStack()
            {
                this.top = null;
            }

            internal int pop()
            {

                if (top != null)
                {
                    int retVal = top.data;
                    top = top.next;
                    return retVal;
                }
                //should return null
                else return 0;
                
            }

            internal void push(int data)
            {
                Node newNode = new Node(data);
                newNode.next = top;
                top = newNode;
            }

            internal String toString()
            {
                String retVal = "";
                Node node = top;
                while (node != null)
                {
                    retVal = retVal + " " + node.data.ToString();

                    node = node.next;
                }
                return retVal;
            }
        }

        internal class LinkedListQueue
        {
            // double linked list
            Node first;
            Node last;

            public LinkedListQueue()
            {
                this.first = null;
                this.last = null;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            LinkedListStack stack = new LinkedListStack();
            for (int i = 1; i<100 ;i++) {
                stack.push(i*2);
            }

            Console.WriteLine(stack.toString());
        }
    }
}
