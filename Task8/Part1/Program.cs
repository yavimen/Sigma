using System;
using StorageTask.Classes;
using System.Collections.Generic;

namespace StorageTask
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>();
            products.Add(new Product("Name3", 2, 2, 2, "22.10.2021"));
            products.Add(new Product("Name1", 4, 4, 4, "24.10.2021"));
            products.Add(new Product("Name2", 3, 3, 3, "23.10.2021"));
            products.Add(new Product("Name4", 1, 1, 1, "21.10.2021"));

            object[] arr = ClassMyArrSort.Sort(products.ToArray(),
                (object p1, object p2) => (p1 as Product).Price.CompareTo((p2 as Product).Price));//Сортування за ціною продукту

            for (int i = 0; i < arr.Length; i++)
            {
                products[i] = arr[i] as Product;
            }

            foreach (var item in products)
            {
                Console.WriteLine(item+"\n");
            }

            Console.WriteLine();

            arr = ClassMyArrSort.Sort(products.ToArray(),
                (object p1, object p2) => (p1 as Product).Name.CompareTo((p2 as Product).Name));//Сортування за назвою продукту

            for (int i = 0; i < arr.Length; i++)
            {
                products[i] = arr[i] as Product;
            }

            foreach (var item in products)
            {
                Console.WriteLine(item + "\n");
            }
        }
    }
}
