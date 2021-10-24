using System;
using StorageTask.OtherClasses;
using StorageTask.Classes;
using System.Collections.Generic;

namespace StorageTask
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Storage storage1 = new Storage();
            Storage storage2 = new Storage();
            storage1.FillStorageFromFile("./Products.txt");
            storage2.FillStorageFromFile("./Products.txt");
            storage1.PrArray.Add(new Product("Cucumber", 12, 1, 20, "24.10.2021"));
            storage2.PrArray.Add(new Product("Pineapple", 40, 2, 30, "20.10.2021"));

            Console.WriteLine(storage1);
            Console.WriteLine();
            Console.WriteLine(storage2);

            ClassFindArrayElements<Product> cfae = new ClassFindArrayElements<Product>((Product p1, Product p2) => p1.Equals(p2));// маю перевантажений Equals у класі Product
            Console.WriteLine();
            Product[] products = cfae.AllSameElemets(storage1.PrArray.ToArray(), storage2.PrArray.ToArray());// PrArray - це List<Product>
            foreach (var item in products)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            products = cfae.AllElementsInCol1ThatDifferentFromCol2(storage1.PrArray.ToArray(), storage2.PrArray.ToArray());
            foreach (var item in products)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            products = cfae.AllDifferentElements(storage1.PrArray.ToArray(), storage2.PrArray.ToArray());
            foreach (var item in products)
            {
                Console.WriteLine(item);
            }
        }
    }
}
 