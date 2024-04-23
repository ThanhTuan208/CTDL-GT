using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NguyenThanhTuan_buoi9_4
{
    internal class LinkedList
    {

        private Node first;
        private Node last;
        private int size;

        public LinkedList()
        {
            first = null;
            last = null;
            this.size = 0;
        }

        //co keu xoa set
        public int Count { get => size;  }
        internal Node First { get => first; }
        internal Node Last { get => last;  }

        // method
        public void PrintList()
        {
            if (first == null)
            {
                Console.WriteLine("linkedlist is empty!!!");
            }
            else
            {
                Console.WriteLine("print linkedlist: ");
                for (Node p = first; p != null; p = p.Next)
                {
                    Console.Write(p.Data + " ");                   
                }
                Console.WriteLine("size = " + size);
            }

        }
        public void AddFirst(int value)
        {
            Node pNew = new Node(value);
            if (first == null)
            {
                first = pNew;
                last = pNew;
            }
            else
            {
                pNew.Next = first;
                first = pNew;
            }
            size++;
        }
        public void AddLast(int value)
        {
            Node pNew = new Node(value);
            if (first == null)
            {
                first = pNew;
                last = pNew;
            }
            else
            {
                last.Next = pNew; last=pNew;
            }
            size++;
        }
        public Node Find(int value)
        {
            for (Node p = first; p != null; p = p.Next)
            {
                if (p.Data == value)
                {
                    return p;
                }
            }
            return null;
        }
        public Node FindPre(Node value)
        {
            for (Node p = first; p.Next != null; p = p.Next) 
            {
                if (p.Next== value)
                {
                    return p;
                }
            }
            return null;
        }
        public void AddAfter(Node pre, int value)
        {
            if (pre != null)
            {
                Node pNew = new Node(value);
                pNew.Next = pre.Next;
                pre.Next = pNew;
                if (last == pre)
                {
                    last = pNew;
                }
                size++;
            }                 
        }
        public void AddBefore(Node net, int value)
        {
            if (net != null)
            {
                Node pNew = new Node(value);
                Node pre = FindPre(net);
                if (pre == null)
                {
                    pNew.Next = first;
                    first = pNew;
                }
                else
                {
                    pNew.Next = pre.Next; pre.Next = pNew;
                }
                size++;
            }
        }
         public void RemoveFirst()
        {
            if (first != null)
            {
                first = first.Next ;
                if (first == null)
                {
                    last = null;
                }
                size--;
            }
        }
        public void RemoveLast()
        {
            if (first != null)
            {
               
                if(first == null)
                {
                    first = null; last = null;
                    size = 0;
                }
                else
                {
                    Node q = first;
                    while (q.Next != null)
                    {
                        q = q.Next;

                    }
                    q.Next = null;
                    last = q;
                    size--;
                }

            }
        }
        public void RemoveAfter(Node pre)
        {
            if (pre != null)
            {
                Node del = pre.Next;
                if (del != null)
                {
                    pre.Next = del.Next;
                    if (del == last)
                    {
                        last = pre;
                    }
                    size--;
                }
            }
        }
        public void Remove(int value)
        {
            if (first != null)
            {
                if (value == first.Data) // xoa dau
                {
                    //RemoveFirst();
                    first = first.Next;
                    if (first == null)
                    {
                        last = null;
                    }
                    size--;
                }
                else // xoa giua or cuoi
                {
                    //Node pre = FindPre(value); neu co san pre
                    Node pre = first;
                    while (pre.Next != null && pre.Next.Data != value)
                    {
                        pre = pre.Next;
                    }
                    Node del = pre.Next;
                    if (del != null)
                    {
                        pre.Next = del.Next;
                        if (del == last)
                        {
                            last = pre;

                        }
                        size--;
                    }

                }
            }
        }
        public void Remove(Node value)
        {
            if (first != null)
            {
                if (value == first) // xoa dau
                {
                    //RemoveFirst();
                    first = first.Next;
                    if (first == null)
                    {
                        last = null;
                    }
                    size--;
                }
                else // xoa giua or cuoi
                {
                    //Node pre = FindPre(value); neu co san pre
                    Node pre = first;
                    while (pre.Next != value)
                    {
                        pre = pre.Next;
                    }
                    Node del = pre.Next;
                    if (del != null)
                    {
                        pre.Next = del.Next;
                        if (del == last)
                        {
                            last = pre;

                        }
                        size--;
                    }

                }
            }
        }
        //swap
        public void Swap(ref int a, ref int b)
        {
            int temp =a; a = b; b = temp;
            
        }
        public void InterchangeSort()
        {
            for (Node p = first; p != last; p = p.Next)
            {
                for (Node q = p.Next; q != null; q =q.Next)
                {
                    if (p.Data > q.Data)
                    {
                        Swap(ref p.Data, ref q.Data);
                    }
                }
            }
        }
        public void SelectionSort()
        {
            Node min = null;
            for (Node p = first; p != last; p = p.Next)
            {
                min = p;
                for (Node q = p.Next; q != null; q = q.Next)
                {
                    if (p.Data > q.Data)
                        min = q;
                    {
                        Swap(ref p.Data, ref min.Data);
                    }
                }
            }
        }
    }
}
