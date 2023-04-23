using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericListImp
{
    class Node<T>
    {
        public T value;
        public Node<T> next;

        public Node(T v)
        {
            value = v;
            next = null;
        }
    }

    class List<T>
    {
        public Node<T> head = null;
        public string name = "no name";

        public List(string sname)
        {
            name = sname;
        }

        public bool InsertAfter(T val1, T val2)
        {
            for (Node<T> curr = head; curr != null; curr = curr.next)
            {
                if (curr.value.Equals(val2))
                {
                    Node<T> temp = new Node<T>(val1);
                    temp.next = curr.next;
                    curr.next = temp;
                    return true;
                }
            }
            return false;
        }

        public bool InsertBefore(T val1, T val2)//testing the next value & using InsertAtHead
        {
            if (head != null && head.value.Equals(val2))
            {
                return InsertAtHead(val1);
            }
            for (Node<T> curr = head; curr != null; curr = curr.next)
            {
                if (curr.next != null && curr.next.value.Equals(val2))
                {
                    Node<T> temp = new Node<T>(val1);
                    temp.next = curr.next;
                    curr.next = temp;
                    return true;
                }
            }
            return false;
        }

        public bool InsertBefore1(T val1, T val2)//testing the current value
        {
            for (Node<T> curr = head; curr != null; curr = curr.next)
            {
                if (curr.value.Equals(val2))
                {
                    Node<T> temp = new Node<T>(val2);
                    temp.next = curr.next;
                    curr.next = temp;
                    curr.value = val1;
                    return true;
                }
            }
            return false;
        }

        public bool InsertBefore2(T val1, T val2)//using while prev and curr
        {
            Node<T> curr = head;
            Node<T> prev = null;

            while (curr != null)
            {
                if (curr.value.Equals(val2))
                {
                    Node<T> temp = new Node<T>(val1);
                    if (prev != null)
                    {
                        temp.next = curr;//temp.next=prev.next;
                        prev.next = temp;
                        return true;
                    }
                    //prev==null   curr==head
                    temp.next = head;
                    head = temp;
                    return true;
                }
                //curr.value!= val2 ===> search next
                prev = curr;
                curr = curr.next;
            }
            return false;
        }

        public bool InsertAtHead(T val)
        {
            Node<T> temp = new Node<T>(val);
            temp.next = head;
            head = temp;
            return true;
        }

        public bool InsertAtEnd(T val)
        {
            for (Node<T> curr = head; curr != null; curr = curr.next)
            {
                if (curr.next == null)
                {
                    curr.next = new Node<T>(val);
                    return true;
                }
            }
            head = new Node<T>(val);
            return true;
        }

        public bool DeleteAfter(T val)
        {
            for (Node<T> curr = head; curr != null; curr = curr.next)
            {
                if (curr.value.Equals(val))//found the node which we want to delete its next.
                {
                    if (curr.next != null)//the item to delete is indeed != null
                    {
                        curr.next = curr.next.next;
                        return true;
                    }
                    return false;
                }
            }
            return false;
        }

        public bool Delete(T val)//testing the next value & using DeleteHead
        {
            if (head != null && head.value.Equals(val))
            {
                return DeleteHead();
            }
            for (Node<T> curr = head; curr != null; curr = curr.next)
            {
                if (curr.next != null && curr.next.value.Equals(val))
                {
                    curr.next = curr.next.next;
                    return true;
                }
            }
            return false;
        }

        public bool Delete1(T val)//testing the current value & using DeleteEnd 
        {
            for (Node<T> curr = head; curr != null; curr = curr.next)
            {
                if (curr.value.Equals(val))
                {
                    if (curr.next != null)
                    {
                        curr.value = curr.next.value;
                        curr.next = curr.next.next;
                        return true;
                    }
                    else //val is the last node :( start again, bad complexity
                    {
                        return DeleteEnd();
                    }
                }
            }
            return false;
        }

        public bool Delete2(T val)//using while prev and curr
        {
            Node<T> curr = head;
            Node<T> prev = null;

            while (curr != null)
            {
                if (curr.value.Equals(val))
                {
                    if (prev != null)
                    {
                        prev.next = curr.next;
                        return true;
                    }
                    //prev==null   curr==head
                    head = head.next;
                    return true;
                }
                //curr.value!= val2 ===> search next
                prev = curr;
                curr = curr.next;
            }
            return false;
        }

        public bool DeleteHead()
        {
            if (IsListEmpty())
            {
                return false;
            }
            head = head.next;
            return true;
        }

        public bool DeleteEnd()
        {
            if (head != null && head.next == null)
            {
                head = null;
                return true;
            }
            for (Node<T> curr = head; curr != null; curr = curr.next)
            {
                if ((curr.next).next == null)
                {
                    curr.next = null;
                    return true;
                }
            }
            return false;
        }

        private int FindIndexOf(T x)
        {
            int index = 0;
            for (Node<T> curr = head; curr != null; curr = curr.next)
            {
                if (curr.value.Equals(x))
                {
                    Console.WriteLine("The index of {0} is{1}.", x, index);
                    return index;
                }
                index++;
            }
            return -1;
        }

        public T FindPreviousValOf_X(T x)
        {
            for (Node<T> curr = head; curr != null; curr = curr.next)
            {
                if (curr.next != null && curr.next.value.Equals(x))
                {
                    Console.WriteLine("The previous value of {0} is {1}.", x, curr.value);
                    return curr.value;
                }
            }
            return default(T);
        }

        private bool IsListEmpty()
        {
            return head == null;
        }

        public void Print()
        {
            for (Node<T> curr = head; curr != null; curr = curr.next)
            {
                Console.Write(curr.value + "--->");
            }
            Console.Write("null\n");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                bool Continue = true;
                int Operation;

                List<int> l1 = new List<int>("l1");
                int value;
                int place;

                do
                {
                    Console.WriteLine("\nEnter a number to choose an operation.\n1- Insert.\n2- Insert at Head.\n3- Insert at End.\n4- Delete.\n5- Delete Head.\n6- Delete End.\n7- Print.\n0- Menu of operation.\n9- Exit");
                    Operation = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("*******************");

                    switch (Operation)
                    {
                        case 1:
                            Console.WriteLine("Enter a number to Insert.");
                            value = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter the value which you want to insert after.");
                            place = Convert.ToInt32(Console.ReadLine());
                            l1.InsertBefore(value, place);
                            break;
                        case 2:
                            Console.WriteLine("Enter a number to Insert.");
                            value = Convert.ToInt32(Console.ReadLine());
                            l1.InsertAtHead(value);
                            break;
                        case 3:
                            Console.WriteLine("Enter a number to Insert.");
                            value = Convert.ToInt32(Console.ReadLine());
                            l1.InsertAtEnd(value);
                            break;
                        case 4:
                            Console.WriteLine("Enter the value which you want to delete.");
                            value = Convert.ToInt32(Console.ReadLine());
                            l1.DeleteAfter(value);
                            break;
                        case 5:
                            l1.DeleteHead();
                            break;
                        case 6:
                            l1.DeleteEnd();
                            break;
                        case 7:
                            l1.Print();
                            break;
                        case 0:
                            Console.WriteLine("1- Insert.\n2- Insert at Head.\n3- Insert at End.\n4- Delete.\n5- Delete Head.\n6- Delete End.\n7- Print.\n0- Menu of operation.\n9- Exit");
                            break;
                        case 9:
                            Continue = false;
                            break;
                        default:
                            Console.WriteLine("Your number is invalid.");
                            break;
                    }
                    Console.WriteLine("*******************");
                }
                while (Continue);
                Console.WriteLine("Good Bye.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong: {0}", e.Message);
            }
        }
    }
}

