using System;

namespace QueueImp
{
    abstract class Queue
    {
        public abstract int Dequeue();
        public abstract void Enqueue(int x);
        public abstract int Head();
        public abstract bool IsEmpty();
        public abstract bool IsFull();
        public abstract void Print();
    }
    class QueueUsingMinus1 : Queue
    {
        private int[] elements;
        private int f;
        private int r;

        public QueueUsingMinus1(int size)
        {
            elements = new int[size];
            f = -1;
            r = -1;
        }

        public override int Dequeue()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Queue is EMPTY!");
                return -1;
            }
            else
            {
                int frontElement = elements[f];
                Console.WriteLine("{0} was dequeued from the queue. ({1},{2})", frontElement, f, r);
                if (r == f)
                {
                    r = -1;
                    f = -1;
                    return frontElement;
                }
                f = (f + 1) % elements.Length;
                return frontElement;
            }
        }

        public override void Enqueue(int x)
        {
            if (IsFull())
            {
                Console.WriteLine("Queue is FULL!");
                Console.WriteLine("{0} wasn't enqueued in the queue.", x);
            }
            else
            {
                if (IsEmpty())
                {
                    f = 0;
                }
                r = (r + 1) % elements.Length;
                elements[r] = x;

                Console.WriteLine("{0} was enqueued in the queue. ({1},{2})", x, f, r);
            }
        }

        public override int Head()
        {
            if (IsEmpty())
            {
                Console.WriteLine("queue is EMPTY!");
                return -1;
            }
            else
            {
                Console.WriteLine("{0} is the head of the queue.", elements[f]);
                return elements[f];

            }
        }

        public override bool IsEmpty()
        {
            return (r == -1 && f == -1);
        }

        public override bool IsFull()
        {
            return (r + 1) % elements.Length == f;
        }

        public override void Print()
        {
            Console.WriteLine("*****************PRINTING*****************");
            if (IsEmpty())
            {
                Console.WriteLine("Cannot print - Queue is empty!");
                Console.WriteLine("*************FINNISH PRINTING*************");
                return;
            }
            //Le for cest pas bon parceque quand f=5 et r=4 ca nimprime rien car f-1=4 et i==r ca rentre memepas dans le for
            //mais le Do While ca marche
            /*for (int i = f - 1; i != r; i = i + 0)
            {
                i = (i + 1) % elements.Length;
                Console.WriteLine("{0} is at index {1}.", elements[i], i);
            }*/
            int i = f - 1;
            do
            {
                i = (i + 1) % elements.Length;
                Console.WriteLine("{0} is at index {1}.", elements[i], i);
            }
            while (i != r);
            Console.WriteLine("*************FINNISH PRINTING*************");
            return;
        }
    }
    class QueueUsingOneMorePlace : Queue
    {
        private int[] elements;
        private int f;
        private int r;
        public QueueUsingOneMorePlace(int size)
        {
            elements = new int[size + 1];
            f = 0;
            r = 0;
        }

        public override int Dequeue()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Queue is EMPTY!");
                return -1;
            }
            else
            {
                int frontElement = elements[f];
                Console.WriteLine("{0} was dequeued from the queue. ({1},{2})", frontElement, f, r);
                f = (f + 1) % elements.Length;
                return frontElement;
            }
        }

        public override void Enqueue(int x)
        {
            if (IsFull())
            {
                Console.WriteLine("Queue is FULL!");
                Console.WriteLine("{0} wasn't enqueued in the queue.", x);
            }
            else
            {
                elements[r] = x;
                r = (r + 1) % elements.Length;
                Console.WriteLine("{0} was enqueued in the queue. ({1},{2})", x, f, r);
            }
        }

        public override int Head()
        {
            if (IsEmpty())
            {
                Console.WriteLine("queue is EMPTY!");
                return -1;
            }
            else
            {
                Console.WriteLine("{0} is the head of the queue.", elements[f]);
                return elements[f];

            }
        }

        public override bool IsEmpty()
        {
            return r == f;
        }

        public override bool IsFull()
        {
            return (r + 1) % elements.Length == f;
        }

        public override void Print()
        {
            Console.WriteLine("*****************PRINTING*****************");
            if (IsEmpty())
            {
                Console.WriteLine("Cannot print - Queue is empty!");
                Console.WriteLine("*************FINNISH PRINTING*************");
                return;
            }
            for (int i = f; i != r; i = (i + 1) % elements.Length)
            {
                Console.WriteLine("{0} is at index {1}.", elements[i], i);
            }
            Console.WriteLine("*************FINNISH PRINTING*************");
            return;
        }
    }
    class QueueUsingCounter : Queue
    {
        private int[] elements;
        private int f;
        private int r;
        private int elementsCounter;

        public QueueUsingCounter(int size)
        {
            elements = new int[size];
            f = 0;
            r = 0; ;
            elementsCounter = 0;
        }

        public override int Dequeue()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Queue is EMPTY!");
                return -1;
            }
            else
            {
                int frontElement = elements[f];
                elementsCounter--;
                Console.WriteLine("{0} was dequeued from the queue. ({1},{2})\nAfter the dequeue operation...\nElements Counter == {3}.", frontElement, f, r, elementsCounter);
                f = (f + 1) % elements.Length;
                return frontElement;
            }
        }

        public override void Enqueue(int x)
        {
            if (IsFull())
            {
                Console.WriteLine("Queue is FULL!");
                Console.WriteLine("{0} wasn't enqueued in the queue.", x);
            }
            else
            {

                elements[r] = x;
                r = (r + 1) % elements.Length;
                elementsCounter++;
                Console.WriteLine("{0} was enqueued in the queue. ({1},{2})\nElements Counter == {3}.", x, f, r, elementsCounter);
            }
        }

        public override int Head()
        {
            if (IsEmpty())
            {
                Console.WriteLine("queue is EMPTY!");
                return -1;
            }
            else
            {
                Console.WriteLine("{0} is the head of the queue.", elements[f]);
                return elements[f];

            }
        }

        public override bool IsEmpty()
        {
            return elementsCounter == 0;
        }

        public override bool IsFull()
        {
            return elementsCounter == elements.Length;
        }

        public override void Print()
        {
            Console.WriteLine("**********************************");
            if (IsEmpty())
            {
                Console.WriteLine("Cannot print - Queue is empty!");
                return;
            }

            for (int i = f; i % elementsCounter != elementsCounter; i++)
            {
                Console.WriteLine("{0} is at index {1}.", elements[i % elements.Length], i % elements.Length);
            }
            Console.WriteLine("**********************************");
            return;
        }
    }

    abstract class QueueFactory
    {
        private static QueueFactory instance;

        protected QueueFactory()
        {

        }
        public static QueueFactory GetInstance()
        {
            if (instance == null)
            {
                int implementation;
                Console.WriteLine("Enter a number to choose the implementation.\n" + "1- QueueUsing_minus_1\n" + "2- QueueUsing_one_more_place\n" + "3- QueueUsing_counter");
                implementation = Convert.ToInt32(Console.ReadLine());
                switch (implementation)
                {
                    case 1: instance = new QueueUsingMinus1Factory(); break;
                    case 2: instance = new QueueUsingOneMorePlaceFactory(); break;
                    case 3: instance = new QueueUsingCounterFactory(); break;
                    default: Console.WriteLine("Your number is invalid."); break;
                }

            }
            return instance;
        }

        public abstract Queue CreateQueue(int size);
    }

    class QueueUsingMinus1Factory : QueueFactory
    {
        public override Queue CreateQueue(int size)
        {
            return new QueueUsingMinus1(size);
        }
    }
    class QueueUsingOneMorePlaceFactory : QueueFactory
    {
        public override Queue CreateQueue(int size)
        {
            return new QueueUsingOneMorePlace(size);
        }
    }
    class QueueUsingCounterFactory : QueueFactory
    {
        public override Queue CreateQueue(int size)
        {
            return new QueueUsingCounter(size);
        }
    }

    class Program
    {
        static void TestProgram()
        {
            Console.WriteLine("*******START OF THE TEST*******");
            QueueFactory queueFactory = QueueFactory.GetInstance();
            Console.WriteLine("Enter the size you want for the queue:");
            Queue q = queueFactory.CreateQueue(Convert.ToInt32(Console.ReadLine()));

            q.Enqueue(4);
            q.Enqueue(4);
            q.Dequeue();
            q.Dequeue();

            q.Print();
            q.Dequeue();

            q.Enqueue(0);
            q.Enqueue(1);
            q.Enqueue(2);
            q.Enqueue(3);
            q.Enqueue(4);
            q.Enqueue(5);
            q.Enqueue(6);
            q.Enqueue(7);
            q.Enqueue(8);

            q.Print();

            q.Enqueue(9);

            q.Dequeue();
            q.Dequeue();
            q.Dequeue();
            q.Dequeue();
            q.Dequeue();

            q.Print();

            q.Enqueue(9);
            q.Enqueue(10);
            q.Enqueue(11);
            q.Enqueue(12);
            q.Enqueue(13);

            q.Print();

            q.Dequeue();
            q.Dequeue();
            q.Dequeue();
            q.Dequeue();

            q.Print();

            q.Enqueue(14);
            q.Enqueue(15);
            q.Enqueue(16);
            q.Enqueue(17);

            q.Print();

            q.Dequeue();

            q.Enqueue(9);
            Console.WriteLine("*******END OF THE TEST*******\n");
        }
        static void Main(string[] args)
        {
            try
            {
                TestProgram();
                bool Continue = true;
                int Operation;

                QueueFactory queueFactory = QueueFactory.GetInstance();
                Console.WriteLine("Enter the size you want for the queue:");
                Queue q = queueFactory.CreateQueue(Convert.ToInt32(Console.ReadLine()));

                do
                {
                    Console.WriteLine("\nEnter a number to choose an operation.\n1- Dequeue.\n2- Enqueue.\n3- Head.\n4- IsFull.\n5- IsEmpty.\n6- Print.\n0- Menu of operation.\n9- Exit");
                    Operation = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("*******************");

                    switch (Operation)
                    {
                        case 1: Console.WriteLine(q.Dequeue()); break;
                        case 2: Console.WriteLine("Enter a number to Enqueue."); q.Enqueue(Convert.ToInt32(Console.ReadLine())); break;
                        case 3: q.Head(); break;
                        case 4: Console.WriteLine(q.IsFull()); break;
                        case 5: Console.WriteLine(q.IsEmpty()); break;
                        case 6: q.Print(); break;
                        case 0: Console.WriteLine("1- Dequeue.\n2- Enqueue.\n3- Head.\n4- IsFull.\n5- IsEmpty.\n6- Print.\n0- Menu of operation."); break;
                        case 9: Continue = false; Console.WriteLine("BYE BYE"); break;
                        default: Console.WriteLine("Your number is invalid."); break;
                    }
                    Console.WriteLine("*******************");
                }
                while (Continue);
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong: " + e.Message);
            }
        }
    }
}
