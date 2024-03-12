using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTDL_GT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("num = ");
            int num = int.Parse(Console.ReadLine());

            int[] arr = new int[num];
            nhapMang(arr);
            xuatMang(arr);
            timTuanTu(arr, num);
            nhiPhan(arr,num);
        }
        static void nhiPhan(int[] arr, int key)
        {
            int left = 0;
            int right = arr.Length -1;
            int count =0;

            int mid;
            while (left <= right)
            {
                mid = (left + right) / 2;
                count++;
                Console.WriteLine($"lan {count}: key = {key} nam trong doan [{left}...{right}] \\ mid {mid}");
                if (arr[mid] == key)
                {
                    break;
                }
                else if (key < arr[mid])
                {
                    right = mid - 1;
                }
                else
                {

                    left = mid + 1;
                }
                Console.WriteLine($"so la chia doi la: {count} ");
            }

        }
        static int timTuanTu(int[] arr, int key)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == key)
                {
                    return i;
                }
            }
            return -1;
        }
        static void xuatMang(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i] + " ");
            }
        }
        static void nhapMang(int[] arr)
        {
            for(int i = 0; i < arr.Length; i++)
            {
                Console.Write($"array[{i}] = ");
                int.TryParse(Console.ReadLine(), out arr[i]);

            }
        }
    }
}
