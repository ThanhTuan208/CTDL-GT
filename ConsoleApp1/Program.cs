using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] arr = new int[5];
            nhapMang(arr);
            //tangDan(arr);
            //xuatMang(arr);
            //bubblesort(arr);
            //xuatMang(arr);
            selectionSort(arr); xuatMang(arr);

        }
        static void xuatMang(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
        }
        static void nhapMang(int[] arr)
        {
            for(int i  = 0; i < arr.Length; i++)
            {
                Console.Write($"array[{i}] = ");
                int.TryParse(Console.ReadLine(), out arr[i]);
            }
        }
        static void tangDan(int[] arr)
        {
            int temp = 0;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] > arr[j])
                    {
                        temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
        }
        static void bubblesort(int[] arr)
        {
            int temp = 0;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = arr.Length-1 ; j > i; j--)
                {
                    if (arr[j - 1] < arr[i])
                    {
                        temp = arr[j - 1];
                        arr[j-1] = arr[i];
                        arr[i] = temp;

                    }
                }
            }
        }
        static void selectionSort(int[] arr)
        {
            int temp, min;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                min = i;
                for (int j = i+1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[min])

                    {
                        min = j;
                    }
                }
                if (min != i)
                {
                    temp = arr[min];
                    arr[min] = arr[i];
                    arr[i] = temp;
                }
            }
         
        }

    }
}
