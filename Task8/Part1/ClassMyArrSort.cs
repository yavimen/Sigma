namespace StorageTask
{
     public delegate int CompareObj<T>(T p1, T p2);\

     class ClassMyArrSort
     {
        static public object[] Sort(object[] arr, CompareObj<object> Comp)
        {
            object temp;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 1; j < arr.Length - i; j++)
                {
                    if (Comp(arr[j - 1], arr[j]) > 0)
                    {
                        temp = arr[j - 1];
                        arr[j - 1] = arr[j];
                        arr[j] = temp;
                    }
                }
            }

            return arr;
        }
     }
}
