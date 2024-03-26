using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

class Sach
{
    public string MaSach;
    public string TenSach;
    public int NamXB;
    public int GiaBan;
}
internal class Chuong2_Bai5
{
    static void Main(string[] args)
    {
        Console.WriteLine("list books: ");
        Sach[] arr = DocMangSach("Input.txt");
        XuatMangSach(arr);
        //Sach[] arr1 = new Sach[4];
        //Console.WriteLine("ds tang dan namXB:");
        //tangdan(arr); //XuatMangSach(arr);
        //Console.WriteLine("ds giam dan maSach:");
        //giamDan(arr); //XuatMangSach(arr);
        //Console.WriteLine("ds tang kieu bubblesort: ");
        //bubblesort(arr); //XuatMangSach(arr);
        //Console.WriteLine("ds giam dan selectionSort:");
        //selectionSort(arr); XuatMangSach(arr);
        //Console.WriteLine("tang dan gia ban");
        //selectionSortgiaBan(arr); XuatMangSach(arr);
        //insertionSort_TangGiaBan(arr); XuatMangSach(arr);
        //insertionSort_GiamMaSach(arr); XuatMangSach(arr);
        //Console.WriteLine("ma sach tang dan");
        //quickSort(arr, 0, arr.Length - 1); XuatMangSach(arr);
        TimXoa(arr); XuatMangSach(arr);
    }
    static void quickSort(Sach[] arr, int left, int right)
    {
        
        if (left >= right) return;
        {
                 int i = left, j = right;
                Sach mid = arr[(left + right) / 2];
            Sach temp; 
            while (i <= j)
            {
                while (arr[i].NamXB < mid.NamXB) i++;
                while (arr[j].NamXB > mid.NamXB) j--;
                if (i <= j)
                {
                    //hoan vi arr j va arr i
                    temp = arr[j];
                    arr[j] = arr[i];
                    arr[i] = temp;
                    i++; j--;
                }
            }
            quickSort(arr, left, j);
            quickSort(arr, i, right);

        }
    }
    static void insertionSort_GiamMaSach(Sach[] arr)
    {
        int i, pos;
        Sach v;
        for (i = 1; i < arr.Length; i++)
        {
            v = arr[i];
            pos = i - 1;
            while (String.Compare(v.MaSach, arr[pos].MaSach) > 0)
            {
                arr[pos + 1] = arr[pos];
                pos--;
            }
            arr[pos + 1] = v;
        }
    }
    static void insertionSort_TangGiaBan(Sach[] arr)
    {
        int i, pos;
        Sach v;
        for (i = 1; i < arr.Length; i++)
        {
            v = arr[i];
            pos = i - 1;
            while (pos >= 0 && v.GiaBan < arr[pos].GiaBan)
            {
                arr[pos + 1] = arr[pos];
                pos--;
            }
            arr[pos+1] = v;

        }
    }
    static void selectionSortgiaBan(Sach[] arr)
    {
        Sach temp;
        int min;
        for (int i = 0; i < arr.Length - 1; i++)
        {
            min = i;
            for (int j = i + 1; j < arr.Length; j++)
            {
                if (arr[j].GiaBan < arr[min].GiaBan)
                {
                    temp = arr[j];
                    arr[j] = arr[min];
                    arr[min] = temp;
                }
            }
        }

    }
    static void selectionSort(Sach[] arr)
    {
        Sach temp;
        int max;
        for (int i = 0; i < arr.Length -1; i++)
        {
            max = i;
            for (int j = i + 1; j < arr.Length; j++)
            {
                if (String.Compare(arr[j].MaSach, arr[max].MaSach) > 0)
                {
                    temp = arr[j];
                    arr[j] = arr[max];
                    arr[max] = temp;
                }
            }          
        }
    }
    static void bubblesort(Sach[] arr)
    {
        Sach temp;
        for (int i = 0; i < arr.Length - 1; i++)
        {
            for (int j = arr.Length - 1; j > i; j--)
            {
                if (String.Compare(arr[j-1].TenSach, arr[i].TenSach) < 0)
                {
                    temp = arr[j - 1];
                    arr[j - 1] = arr[i];
                    arr[i] = temp;

                }
            }
        }
    }
    static void giamDan(Sach[] arr)
    {
        Sach temp;
        for (int i = 0; i < arr.Length - 1; i++)
        {
            for (int j = i + 1; j < arr.Length; j++)
            {
                if (String.Compare(arr[i].MaSach, arr[j].MaSach) < 0)
                {
                    temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }

        }
    }
    static void tangdan(Sach[] arr)
    {
        Sach temp;
        for (int i = 0; i < arr.Length- 1; i++)
        {
            for (int j = i + 1; j < arr.Length; j++)
            {
                if (arr[i].NamXB > arr[j].NamXB)
                {
                    temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }

        }
    }
    static Sach[] TimXoa(Sach[] arr)
    {
        Console.Write("Nhap ma sach can xoa: ");
        string maSach = Console.ReadLine();
        int kq = TimNhiPhan(arr, maSach);
        if (kq != -1)
        {
            for (int i = kq; i < arr.Length - 1; i++)
            {
                arr[i] = arr[i + 1];
            }
            Array.Resize(ref arr, arr.Length - 1);
        }
        return arr;
    }
    //Tim nhi phan theo ma sach:
    static int TimNhiPhan(Sach[] arr, string maSach)
    {
        int left = 0, right = arr.Length, mid;
        while (left <= right)
        {
            mid = (left + right) / 2;
            if (arr[mid].MaSach == maSach)
            {
                return mid;
            }
            else if (String.Compare(arr[mid].MaSach,maSach) < 0)
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
    //Ham cau 2b:
    static void TimSua(Sach[] arr)
    {
        Console.Write("Nhap vao ten sach muon sua gia ban: ");
        string tenSach = Console.ReadLine();
        int kq = TimTuanTu(arr, tenSach);
        if (kq == -1)
        {
            Console.WriteLine("Khong sua dc vi k tim thay!");
        }
        else
        {
            Console.Write("Nhap gia ban moi: ");
            arr[kq].GiaBan = int.Parse(Console.ReadLine());
            Console.WriteLine("Danh sach sau khi sua gia ban: ");
            XuatMangSach(arr);
        }
    }
    //Ham tim tuan tu theo tuaSach:
    static int TimTuanTu(Sach[] arr, string tuaSach)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (tuaSach == arr[i].TenSach)
            {
                return i;
            }
        }
        return -1;
    }
    //Ham xuat mang sach:
    static void XuatMangSach(Sach[] arr)
    {
        Console.WriteLine($"{"MaSach",-10}{"TenSach",-10}{"NamXB",-10}{"GiaBan",-10}");
        for (int i = 0; i < arr.Length; i++)
        {
            Console.WriteLine($"{arr[i].MaSach,-10}{arr[i].TenSach,-10}{arr[i].NamXB,-10}{arr[i].GiaBan,-10}");
        }
    }
    //Ham nhap mang sach:
    static void NhapMangSach(Sach[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = new Sach();
            Console.Write("Nhap MaSach: ");
            arr[i].MaSach = Console.ReadLine();
            Console.Write("Nhap TenSach: ");
            arr[i].TenSach = Console.ReadLine();
            Console.Write("Nhap NamXB: ");
            arr[i].NamXB = int.Parse(Console.ReadLine());
            Console.Write("Nhap GiaBan: ");
            arr[i].GiaBan = int.Parse(Console.ReadLine());
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
                    arr[i].MaSach = t[0];
                    arr[i].TenSach = t[1];
                    arr[i].NamXB = int.Parse(t[2]);
                    arr[i].GiaBan = int.Parse(t[3]);
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
