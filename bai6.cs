using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class MonHoc
    {
        public string MaMH, TenHP;
        public int STC;
        public double Diem;

    }
    class SinhVien
    {
        public string MaSV, HoTen;
        public DateTime NgaySinh;
        public int SoHP;
        public MonHoc[] arrHP;
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            SinhVien[] arr = new SinhVien[1];
            nhapMangSV(arr);
            xuatMang(arr);
            cau2c(arr);
            arr = cau2d(arr);
            xuatMang(arr);
            SinhVien sv = timMaxDTB(arr);
            Console.WriteLine($"nhan vien co DTB cao nhat la: " + sv.MaSV + ", " + sv.HoTen);
        }
        // nhap mang sv
        static void nhapMangSV(SinhVien[] arrSV)
        {
            for(int i = 0; i < arrSV.Length; i++)
            {
                arrSV[i] = new SinhVien();
                Console.WriteLine($"nhap thong tin cho sinh vien thu {i + 1}: ");

                Console.Write("nhap MaSV: ");
                arrSV[i].MaSV = Console.ReadLine();

                Console.Write("nhap HoTen: ");
                arrSV[i].HoTen = Console.ReadLine();

                // nhap theo dong ho may tinh
                Console.Write("nhap ngay sinh: ");
                DateTime.TryParse(Console.ReadLine(), out arrSV[i].NgaySinh);

                Console.Write("nhap so tin chi: ");
                int.TryParse(Console.ReadLine(), out arrSV[i].SoHP);

                //cap phat 1 mang hoc phan
                arrSV[i].arrHP = new MonHoc[arrSV[i].SoHP];

                // nhap danh sach cac mon hoc
                for (int j = 0; j < arrSV[i].arrHP.Length; j++)
                {
                    arrSV[i].arrHP[j] = new MonHoc();
                    Console.Write("\t nhap MaMH: ");
                    arrSV[i].arrHP[j].MaMH = Console.ReadLine();

                    Console.Write("\t nhap tenHP: ");
                    arrSV[i].arrHP[j].TenHP = Console.ReadLine();

                    Console.Write("\t nhap so tin chi: ");
                    int.TryParse(Console.ReadLine(), out arrSV[i].arrHP[j].STC);

                    Console.Write("\t nhap diem: ");
                    double.TryParse(Console.ReadLine(), out arrSV[i].arrHP[j].Diem);
                }
            }
        }
        static void xuatMang(SinhVien[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"{"MaSV: ",-15}{arr[i].MaSV}");
                Console.WriteLine($"{"HoTen: ",-15}{arr[i].HoTen}");
                Console.WriteLine($"{"NgaySinh: ",-15}{arr[i].NgaySinh.ToString()}");
                Console.WriteLine($"Danh sach: {arr[i].SoHP} mon hoc da hoc la: ");
                Console.WriteLine($"{"MaHP: ",-10}{"tenHP",-10} {"SoTC",-10} {"Diem"}");
                for(int j =0; j < arr[i].arrHP.Length; j++)
                {
                    Console.WriteLine($"{arr[i].arrHP[j].MaMH,-10} {arr[i].arrHP[j].TenHP,-10} {arr[i].arrHP[j].STC,-10}{arr[i].arrHP[j].Diem}");
                }
                Console.WriteLine("-------------------------------------");
            }
        }
        static void cau2c(SinhVien[] arr)
        {
            Console.WriteLine("nhap ma sv can sua: ");
            string maSV = Console.ReadLine();
            int viTri = timTuanTu(arr, maSV);

            if (viTri == -1)
            {
                Console.WriteLine("ko tim ra vi tri can sua");
            }
            else
            {
                Console.WriteLine("thay doi ten cua sv: ");
                arr[viTri].HoTen = Console.ReadLine();
                Console.WriteLine("ho ten vua thay doi cua sv do la: ");
                xuatMang(arr);
                
            }
        }
        static int timTuanTu(SinhVien[] arr, string maSV)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].MaSV == maSV)
                {
                    return i;
                }
            }
            return -1;
        }
        static SinhVien[] cau2d(SinhVien[] arr)
        {
            Console.WriteLine("nhap sv can xoa: ");
            string maSV = Console.ReadLine();
            int viTri = timNhiPhan(arr, maSV);

            if (viTri == -1)
            {
                Console.WriteLine("ko tim thay masv de xoa");
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
        static int timNhiPhan(SinhVien[] arr, string maSach)
        {
            int left = 0, right = arr.Length - 1, mid;
            while (left <= right)
            {
                mid = (left + right) / 2;
                if (maSach == arr[mid].HoTen)
                {
                    return mid;
                }
                else if (String.Compare(maSach, arr[mid].HoTen) == -1)
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
        static SinhVien timMaxDTB(SinhVien[] arr)
        {
            SinhVien max = arr[0];
            for(int i =1; i < arr.Length; i++)
            {
                if (tinhTBC(max) < tinhTBC(arr[i]))
                {
                    max = arr[i];
                }
            }
            return max;
        }
        static double tinhTBC(SinhVien sinhVien)
        {
            double tongDiem = 0;
            int tongTC = 0;
            for(int i =0; i < sinhVien.arrHP.Length; i++)
            {
                tongDiem = sinhVien.arrHP[i].Diem + sinhVien.arrHP[i].STC;
                tongTC += sinhVien.arrHP[i].STC;
            }
            return tongDiem / tongTC;
        }
    }
}
