using System;

namespace StackImp
{
    class StackUsingArray
    {
        private int[] elements;
        private int top;

        public StackUsingArray(int size)
        {
            elements = new int[size];
            top = -1;
        }

        public void Push(int x)
        {
            if (IsFull())
            {
                Console.WriteLine("Stack is FULL!");
                Console.WriteLine("{0} wasn't pushed in the stack ", x);
            }
            else
            {
                ++top;
                elements[top] = x;
                Console.WriteLine("{0} was pushed in the stack ", x);
            }
        }

        public int Pop()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Stack is empty!");
                return -1;
            }
            else
            {
                Console.WriteLine("{0} popped from stack ", elements[top]);
                return elements[top--];
            }
        }

        public int Top()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Stack is empty!");
                return -1;
            }
            else
            {
                Console.WriteLine("{0} is the top of the stack ", elements[top]);
                return elements[top];
            }
        }

        public void PrintStack()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Stack is empty!");
            }
            else
            {
                for (int i = 0; i <= top; i++)
                {
                    Console.WriteLine("item number {0} is: {1}", i, elements[i]);
                }
            }
        }

        public bool IsEmpty()
        {
            return (top == -1);
        }

        public bool IsFull()
        {
            return (top == elements.Length - 1);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            StackUsingArray s = new StackUsingArray(9);

            s.Push(0);
            s.Push(1);
            s.Push(2);
            s.Push(3);
            s.Push(4);
            s.Push(5);
            s.Push(6);
            s.Push(7);
            s.Push(8);
            s.Push(9);

            Console.WriteLine("State of the stack:");
            s.PrintStack();

            s.Pop();
            s.Pop();
            s.Pop();
            s.Pop();

            Console.WriteLine("State of the stack:");
            s.PrintStack();

            Console.WriteLine("Is the stack empty? : " + s.IsEmpty());
            s.Top();

            s.Pop();
            s.Pop();
            s.Pop();
            s.Pop();
            s.Pop();
            s.Pop();

            s.Push(9);
        }
    }
}
