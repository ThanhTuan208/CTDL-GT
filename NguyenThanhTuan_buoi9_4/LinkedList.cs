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
            this.First = null;
            this.Last = null;
            this.Size = 0;
        }

        public int Size { get => size; set => size = value; }
        internal Node First { get => first; set => first = value; }
        internal Node Last { get => last; set => last = value; }

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
        public Node FindPre(int value)
        {
            for (Node p = first; p.Next != null; p = p.Next) 
            {
                if (p.Next.Data == value)
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
                Node pre = FindPre(net.Data);
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
    }
}
