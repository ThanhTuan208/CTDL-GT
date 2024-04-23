using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NguyenThanhTuan_buoi9_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LinkedList l = new LinkedList();

            #region 
            //l.AddFirst(1);
            //l.AddFirst(2);
            //l.AddFirst(3);
            //l.AddFirst(4);     
            //l.PrintList();

            //Node p = l.FindPre(21);
            //Console.WriteLine(p.Data);

            //Node q = l.Find(4);
            //l.AddAfter(q, 400);
            //l.PrintList();

            //Node w = l.Find(1);
            //l.AddBefore(w, 9);
            //l.PrintList();

            #region remove first
            //  l.AddLast(1);
            //  l.AddLast(2);
            //  l.AddLast(3);
            //  l.AddLast(4);
            //  l.AddLast(5);
            //l.PrintList();

            //  l.RemoveFirst();
            //  l.PrintList();
            #endregion
            #region remove last
            //for(int i =1; i<6; i++)
            // {
            //     l.AddLast(i);   
            // }
            //l.PrintList();
            // l.RemoveLast();
            // l.PrintList();
            #endregion
            #region remove after
            //for (int i = 1; i < 6; i++)
            //{
            //    l.AddLast(i);
            //}
            //l.PrintList();
            //Node pre = l.Find(3);
            //l.RemoveAfter(pre);
            //l.PrintList();
            #endregion
            #region remove1
            //for (int i = 1; i < 6; i++)
            //{
            //    l.AddLast(i);
            //}
            //l.PrintList();
            //l.Remove(1);
            //l.PrintList();
            #endregion
            #region remove2
            //for (int i = 1; i < 6; i++)
            //{
            //    l.AddLast(i);
            //}
            //l.PrintList();
            //Node value = l.Find(5);
            //l.Remove(value);
            //l.PrintList();
            #endregion
            #region interchangeSort
            //Random rd = new Random();
            //for (int i = 1; i < 10; i++)
            //{
            //    l.AddLast(rd.Next(0, 10));

            //}
            //l.PrintList();
            //Console.WriteLine("linkedList sorted: ");
            //l.InterchangeSort();
            //l.PrintList();
            #endregion
            #region selectionSort
            //Random r = new Random();
            //for (int i = 1; i < 10; i++)
            //{
            //    l.AddLast(r.Next(0, 10));
            //}
            //l.PrintList();
            //Console.WriteLine("linkedList sorted: ");
            //l.SelectionSort();
            //l.PrintList();
            #endregion
            #endregion

            Console.WriteLine("nhap num: ");
            int n = Convert.ToInt32(Console.ReadLine());
            NhapList(l, n);
            l.PrintList();

            soNguyenTo(l);

            Console.WriteLine("diem trung binh cong: " + DTB(l));

            Console.WriteLine("phan tu nho nhat: " + PTuNN(l).Data);

            Node q = l.Find(PTuNN(l).Data);
            l.AddAfter(q, 4);
            l.PrintList();

            Console.WriteLine("so luong can tim dem duoc la: " + demSN(l));


            Console.WriteLine("so chinh phuong cuoi: " + SCPCuoi(l).Data);

            Console.WriteLine("nhap phan tu k: ");
            int k = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("phan tu K: " + PtuK(l,k).Data);

        }
        static Node PtuK(LinkedList l, int x)
        {
            if (l.Count < x || x <= 0) 
                return null;
            Node p = l.First;
            for (int i = 0; i < x; i++)
            {
                p = p.Next;
            }
            return p;
        }
        static bool ktraSPC(int x)
        {
            if (x <= 0) return false;
            double canBac2 = Math.Sqrt(x);
            return canBac2 == (int)canBac2;
        }
        static Node SCPCuoi(LinkedList l)
        {
            Node xepCuoi = null;
            for (Node p = l.First; p != null; p = p.Next)
            {
                if (ktraSPC(p.Data))
                {
                    xepCuoi = p;               
                }
            }
            return xepCuoi;
        }
        static Node PTuNN(LinkedList l)
        {
            Node min = l.First;
            for (Node p = l.First; p != null; p = p.Next)
            {
                if (min.Data > p.Data)
                {
                    min = p;
                }
            }
            return min;
        }
        static int demSN(LinkedList l)
        {
            Console.WriteLine("nhap so can tim: ");
            int x = Convert.ToInt32(Console.ReadLine());
            int count = 0;
            for (Node p = l.First; p != null; p = p.Next)
            {
                if (p.Data == x)
                {
                    count++;
                }
            }
            return count;
        }
        static double DTB(LinkedList l)
        {
            int count = 0;
            double average = 0;
            for (Node p = l.First; p != null; p = p.Next)
            {
                average += p.Data;
                count++;
            }
            return average / count;
        }
        static bool ktraSNT(int n)
        {
            if (n < 2) return false;
            if (n == 2) return true;
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % 2 == 0) return false;
            }
            return true;
        }
        static void soNguyenTo(LinkedList l)
        {
            for (Node p = l.First; p != null; p = p.Next)
            {
                if (ktraSNT(p.Data))
                {
                    Console.Write($"SNT: {p.Data,3} ");
                }
            }

        }
        static void NhapList(LinkedList l, int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write($"nhap phan tu {i+1}: ");
                int index = Convert.ToInt32(Console.ReadLine());
                l.AddLast(index);
            }
        }
    }
}
