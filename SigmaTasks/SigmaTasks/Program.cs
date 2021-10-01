using System;
using SigmaTasks.Classes;

namespace SigmaTasks
{
    //class MyCheck : Check 
    //{
    //}
    class Program
    {
        static void Main(string[] args)
        {
            Storage storage = new Storage(new Meat("Meat",10,10,Category.FirstSort,KindOfMeat.Pork), 
                new Dairy_Products("DairProd",20,20,10),new Product("Product",30,30));

            storage.Print();

            storage.ChangePrice(10);

            Console.WriteLine(); Console.WriteLine("==================================");
            storage.Print();

            Console.WriteLine(); Console.WriteLine("==================================");
            Console.WriteLine((storage[1] as Dairy_Products).ToString());

            Console.WriteLine(); Console.WriteLine("==================================");
            Meat[] meats = storage.FindAllMeat();
            Console.WriteLine(meats[0].ToString());


            Product pr1 = new Product("Toothpast", 12, 0.25);
            Product pr2 = new Product("Juice", 30, 1);
            Product pr3 = new Product("Cheese", 50, 0.6);
            Product pr4 = new Product("Aplles", 10, 2);

            Buy buy = new Buy();
            buy.AddEl(pr1);
            buy.AddEl(pr2);
            buy.AddEl(pr3);
            buy.AddEl(pr4);

            Console.WriteLine(Check.ShowCheck(buy));
        }
    }
}
