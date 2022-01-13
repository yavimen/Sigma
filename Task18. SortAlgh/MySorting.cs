using System;

delegate bool AddCond<T>(T x);

namespace MySorting
{
    class MySorting
    {
        #region Quick_Sort
        //за допомогою статичного поля перевіряю на стабільість. при однакових значеннях масиву алгоритм швидкого сортування переставляє елементи місцями, отже не є стабільним 
        static public int qs_swap_number { get; protected set; }
        static void Swap<T>(ref T val1, ref T val2, T[] arr)
        {
            T temp = val1;
            val1 = val2;
            val2 = temp;
        }
        static void Quicksort<T>(T[] arr, int left, int right, Comparison<T> comparison)
        {
            if (left < 0 || right > arr.Length)
                return;

            if (left > right)
                throw new Exception("left index must be less than right");

            int i = left, j = right;


            T curEl = arr[i];

            while (i <= j)
            {
                while (comparison.Invoke(arr[i], curEl) < 0 )
                {
                    i++;
                }
                while (comparison.Invoke(arr[j], curEl) > 0 )
                {
                    j--;
                }

                if (i <= j)
                {
                    Swap(ref arr[i], ref arr[j], arr);
                    qs_swap_number++;
                    j--;
                    i++;
                }
            }

            if (i < right)
            {
                Quicksort(arr, i, right, comparison);
            }
            if (j > left)
            {
                Quicksort(arr, left, j, comparison);
            }
        }
        public static void QuickSort<T>(T[] arr, int left, int right, Comparison<T> comparison)
        {
            qs_swap_number = 0;
            Quicksort(arr, left, right, comparison);
        }
        static void Quicksort<T>(T[] arr, int left, int right, Comparison<T> comparison, AddCond<T> condition)
        {
            if (left < 0 || right > arr.Length)
                return;

            if (left > right)
                throw new Exception("left index must be less than right");

            int i = left, j = right;

            while (i < right && !condition(arr[i]))
                i++;
            if (i >= right)
                return;

            T curEl = arr[i];

            while (i <= j)
            {
                while ((comparison.Invoke(arr[i], curEl) < 0 || !condition(arr[i])) && i < right)
                {
                    i++;
                }
                while ((comparison.Invoke(arr[j], curEl) > 0 || !condition(arr[j]))&&j > left)
                {
                    j--;
                }

                if (i <= j)
                {
                    if (condition(arr[i]) && condition(arr[j]))
                    {
                        Swap(ref arr[i], ref arr[j], arr);
                        qs_swap_number++;
                    }
                    j--;
                    i++;
                }
            }

            if (i < right)
            {
                Quicksort(arr, i, right, comparison, condition);
            }
            if (j > left)
            {
                Quicksort(arr, left, j, comparison, condition);
            }
        }
        public static void QuickSort<T>(T[] arr, int left, int right, Comparison<T> comparison, AddCond<T> condition)
        {
            qs_swap_number = 0;
            Quicksort(arr, left, right, comparison, condition);
        }
        #endregion

        #region Heap_Sort
        //при однакових значеннях масиву алгоритм пірамідального сортування не переставляє елементи місцями, отже є стабільним 
        static public int hs_swap_number { get; protected set; }
        static public void HeapSort(int[] arr) 
        {
            hs_swap_number = 0;
            Heapsort(arr);
        }
        static void Heapsort(int[] arr)
        {
            int n = arr.Length;

            for (int i = n / 2 - 1; i >= 0; i--)
                Heapify(arr, n, i);

            for (int i = n - 1; i > 0; i--)
            {
                int temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;

                Heapify(arr, i, 0);
            }
        }
        static void Heapify(int[] arr, int n, int i)
        {
            int largest = i; 
            int l = 2 * i + 1; 
            int r = 2 * i + 2; 

            if (l < n && arr[l] > arr[largest])
                largest = l;

            if (r < n && arr[r] > arr[largest])
                largest = r;

            if (largest != i)
            {
                int swap = arr[i];
                arr[i] = arr[largest];
                arr[largest] = swap;

                Heapify(arr, n, largest);
            }
        }
        #endregion

    }
}
