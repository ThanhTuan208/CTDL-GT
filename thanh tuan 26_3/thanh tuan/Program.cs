using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thanh_tuan
{
    class Sach
    {
        public string MaMon;
        public string TenMon;
        public int SoTC;
        public double Diem;
    }
    internal class Chuong2_Bai5
    {
        static void Main(string[] args)
        {
            Console.WriteLine("list books: ");            
            Sach[] arr = DocMangSach("DanhSachMonHoc.txt");           
            XuatMangSach(arr);
            string s = Console.ReadLine();
            changeMaMon(arr);
            

        }
        static void changeMaMon(Sach[] arr)
        {
            Console.WriteLine("ma mon can sua la: ");
            string MaMon = Console.ReadLine();
            int viTri = timTuanTu(arr, MaMon);
            if (viTri != -1)
            {
                Console.WriteLine("nhap ma mon sua:");
                arr[viTri].MaMon = Console.ReadLine();
                Console.WriteLine("ma mon sau khi duoc sua la: ");
                XuatMangSach(arr);
            }
            else
            {
                Console.WriteLine("ko tim diem duoc");
            }
        }
        static int nhiPhan_Diem(Sach[] arr, double Diem)
        {
            int left = 0, mid, right = arr.Length - 1;
            while (left <= right)
            {
                mid = (left + right) / 2;
                if (arr[mid].Diem < Diem)
                {
                    right = mid - 1;
                }
                else if (arr[mid].Diem == Diem)
                {
                    return mid;
                }
                else
                {
                    left = mid + 1;
                }
            }
            return -1;

        }
        static int timTuanTu_TinChi(Sach[] arr, int soTC)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].SoTC == soTC)
                {
                    return i;
                }
                
            }
            return -1;
        }
       static int nhiPhan_TenMon(Sach[] arr,string tenSach)
        {
            int left = 0, mid;
            int right = arr.Length - 1;
            while (left <= right)
            {
                mid = (left + right) / 2;
                if (String.Compare(arr[mid].TenMon, tenSach) < 0)
                {
                    right = left - 1;
                }
                else if (String.Compare(arr[mid].TenMon, tenSach) ==0)
                {
                    return mid;
                }
                else
                {
                    left = mid + 1; 
                }
            }
            return -1;
        }
        static int timTuanTu(Sach[] arr, string key)
        {
            
            for (int i = 0; i < arr.Length; i++)
            {
                if (String.Compare(arr[i].MaMon, key) == 0)  
                {
                    return i;
                }
            }
            return -1;
        }
        static void XuatMangSach(Sach[] arr)
        {
            Console.WriteLine($"{"MaMon",-10}{"TenMon",-10}{"SoTC",-10}{"Diem",-10}");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"{arr[i].MaMon,-10}{arr[i].TenMon,-10}{arr[i].SoTC,-10}{arr[i].Diem,-10}");
            }
        }
        //Ham nhap mang sach:
        static void NhapMangSach(Sach[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = new Sach();
                Console.Write("Nhap MaSach: ");
                arr[i].MaMon = Console.ReadLine();
                Console.Write("Nhap TenSach: ");
                arr[i].TenMon = Console.ReadLine();
                Console.Write("Nhap NamXB: ");
                arr[i].SoTC = int.Parse(Console.ReadLine());
                Console.Write("Nhap GiaBan: ");
                arr[i].Diem = int.Parse(Console.ReadLine());
                Console.WriteLine("---------------------------------------------");
            }
        }

        //Ham doc mang sach tu file
        static Sach[] DocMangSach(string path)
        {
            Sach[] arr = new Sach[100];
            int n = 0;
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    n = int.Parse(sr.ReadLine());
                    arr = new Sach[n];
                    for (int i = 0; i < n; i++)
                    {
                        arr[i] = new Sach();
                        string[] t = sr.ReadLine().Split(',');
                        arr[i].MaMon = t[0];
                        arr[i].TenMon = t[1];
                        arr[i].SoTC = int.Parse(t[2]);
                        arr[i].Diem = double.Parse(t[3]);
                    }
                }
            }
            catch (IOException)
            {
                Console.WriteLine("Doc file that bai: ");
            }
            return arr;
        }


    }

}
