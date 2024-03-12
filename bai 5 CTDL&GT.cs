using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai_5_CTDL_GT
{

    struct Sach
    {
        public string MaSach;
        public string TuaSach;
        public int NamXB;
        public int GiaBan;

    }
    internal class Program
    {      
        static void Main(string[] args)
        {
           
            Sach[] arr = new Sach[1]; 
            nhapMangSach(arr);
            xuatMangSach(arr);
            cau2b(arr);
            arr = cau2c(arr);
            xuatMangSach(arr);

        }
        //bai5 cau 2c
        static Sach[] cau2c(Sach[] arr)
        {
            Console.WriteLine("nhap ma sach can xoa: ");
            string maSach = Console.ReadLine();
            int viTri = timNhiPhan(arr, maSach);

            if (viTri == -1)
            {
                Console.WriteLine("ko tim thay sach de xoa");
                return arr;

            }
            else
            {
                for (int i = viTri; i < arr.Length - 1; i++)
                {
                    arr[i] = arr[i + 1];
                }
                Array.Resize(ref arr, arr.Length - 1);
                return arr; 
            }
            
        }

        //bai 5 cau 2b
        static void cau2b(Sach[] arr)
        {
            Console.WriteLine("nhap tua sach can tim de sua gia ban: ");
            string tuaSach = Console.ReadLine();
            int viTri = timTuanTu(arr, tuaSach);
            
            if (viTri == -1)
            {
                Console.WriteLine("ko tim thay de sua");

            }
            else
            {
                Console.WriteLine("nhap gia tri gia ban moi: ");
                int.TryParse(Console.ReadLine(), out arr[viTri].GiaBan);
                Console.WriteLine("gia ban moi la: ");
                xuatMangSach(arr);
            }
        }
        // ham nhi phan theo ma sach
        static int timNhiPhan(Sach[] arr, string maSach)
        {
            int left = 0, right = arr.Length - 1, mid;
            while (left <= right)
            {
                mid = (left + right) / 2;
                if (maSach == arr[mid].MaSach)
                {
                    return mid;
                }
                else if (String.Compare(maSach, arr[mid].MaSach) == -1)
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }     
            }
            return -1;

        }
        // ham tim tuan tu theo ma sach
        static int timTuanTu(Sach[] arr, string tuaSach)
        {
            for(int i =0; i < arr.Length; i++)
            {
                if (arr[i].TuaSach == tuaSach)
                {
                    return i;
                }
            }
            return -1;
        }

        // ham xuat mang sach
        static void xuatMangSach(Sach[] arr)
        {
            Console.WriteLine($"{ "MaSach", -10}{"TuaSach", -20} {"NamXB", -10}{"GiaBan"}");
           for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"{arr[i].MaSach, -10}{arr[i].TuaSach, -20} {arr[i].NamXB, -10}{arr[i].GiaBan}");
            }
        }
        //ham nhap mang sach
        static void nhapMangSach(Sach[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"nhap thong tin cho sach thu {i+1}: ");
                Console.Write("nhap ma sach: ");
                arr[i].MaSach = Console.ReadLine();

                Console.Write("tua sach: ");
                arr[i].TuaSach = Console.ReadLine();

                Console.Write("Nhap namXB: ");
                int.TryParse(Console.ReadLine(), out arr[i].NamXB);

                Console.Write("nhap GiaBan: ");
                int.TryParse(Console.ReadLine(), out arr[i].GiaBan);
            }
        }
    }
}
