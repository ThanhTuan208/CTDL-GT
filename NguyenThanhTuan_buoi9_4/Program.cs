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
         
            l.AddFirst(1);
            l.AddFirst(2);
            l.AddFirst(3);
            l.AddFirst(4);     
            l.PrintList();

            //Node p = l.FindPre(21);
            //Console.WriteLine(p.Data);

            Node q = l.Find(4);
            l.AddAfter(q, 400);
            l.PrintList();

            Node w = l.Find(1);
            l.AddBefore(w, 9);
            l.PrintList();
        }
    }
}
