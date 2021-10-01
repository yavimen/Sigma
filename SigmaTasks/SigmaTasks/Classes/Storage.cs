using System;
using System.Collections.Generic;
using System.Text;

namespace SigmaTasks.Classes
{
    class Storage
    {
        private Product[] prArray;
        public Product[] PrArray
        {
            get { return prArray; }
        }
        public Storage()
        {
            int typeChoose;
            int size = 0;
            int protector = 0;
            Int16 counter = 0;
            do
            {
                if (protector == 0)
                {

                    Console.WriteLine("How many new products?: ");
                    size = int.Parse(Console.ReadLine());
                    if (size < 0) break;
                    Console.Clear();
                
                    prArray = new Product[size];
                    protector = 1;
                }

                Console.WriteLine("What type?\n1.Meat\n2.Dairy_product\n3.Other");
                typeChoose = int.Parse(Console.ReadLine());

                if (typeChoose == 1)
                {
                    Console.Clear();
                    prArray[counter] = new Meat();
                    Console.Write("Name: ");
                    prArray[counter].Name = Console.ReadLine();
                    Console.Write("Price: ");
                    prArray[counter].Price = double.Parse(Console.ReadLine());
                    Console.Write("Wight: ");
                    prArray[counter].Weight = double.Parse(Console.ReadLine());
                    Console.Clear();
                    Console.WriteLine("Category?\n1.HigherSort\n2.FirstSort\n3.SecondSort");
                    switch (int.Parse(Console.ReadLine()))
                    {
                        case 1:
                            (prArray[counter] as Meat).Category = Category.HigherSort;
                            break;
                        case 2:
                            (prArray[counter] as Meat).Category = Category.FirstSort;
                            break;
                        case 3:
                            (prArray[counter] as Meat).Category = Category.SecondSort;
                            break;
                        default:
                            break;
                    }
                    Console.Clear();
                    Console.WriteLine("Kind of meat?\n1.Mutton\n2.Veal\n3.Pork\n4.Chicken");
                    switch (int.Parse(Console.ReadLine()))
                    {
                        case 1:
                            (prArray[counter] as Meat).mMeat = KindOfMeat.Mutton;
                            break;
                        case 2:
                            (prArray[counter] as Meat).mMeat = KindOfMeat.Veal;
                            break;
                        case 3:
                            (prArray[counter] as Meat).mMeat = KindOfMeat.Pork;
                            break;
                        case 4:
                            (prArray[counter] as Meat).mMeat = KindOfMeat.Chicken;
                            break;
                        default:
                            break;
                    }
                    counter++;
                    Console.Clear();
                }
                else if (typeChoose == 2)
                {
                    Console.Clear();
                    prArray[counter] = new Dairy_Products();
                    Console.Write("Name: ");
                    prArray[counter].Name = Console.ReadLine();
                    Console.Write("Price: ");
                    prArray[counter].Price = double.Parse(Console.ReadLine());
                    Console.Write("Wight: ");
                    prArray[counter].Weight = double.Parse(Console.ReadLine());
                    Console.Clear();
                    Console.WriteLine("Expiration date:");
                    (prArray[counter] as Dairy_Products).ExpirationDate = int.Parse(Console.ReadLine());
                    counter++;
                    Console.Clear();
                }
                else
                {
                    Console.Clear();
                    prArray[counter] = new Product();
                    Console.Write("Name: ");
                    prArray[counter].Name = Console.ReadLine();
                    Console.Write("Price: ");
                    prArray[counter].Price = double.Parse(Console.ReadLine());
                    Console.Write("Wight: ");
                    prArray[counter].Weight = double.Parse(Console.ReadLine());
                    counter++;
                    Console.Clear();
                }
            } while (counter<size);
        }
        public Storage(Product p1, Product p2, Product p3) 
        {
            prArray = new Product[3];
            if (p1 is Meat)
                prArray[0] = new Meat(p1 as Meat);
            else if (p1 is Dairy_Products)
                prArray[0] = new Dairy_Products(p1 as Dairy_Products);
            else
                prArray[0] = new Product(p1);

            if (p2 is Meat)
                prArray[1] = new Meat(p2 as Meat);
            else if (p2 is Dairy_Products)
                prArray[1] = new Dairy_Products(p2 as Dairy_Products);
            else
                prArray[1] = new Product(p2);

            if (p3 is Meat)
                prArray[2] = new Meat(p3 as Meat);
            else if (p3 is Dairy_Products)
                prArray[2] = new Dairy_Products(p3 as Dairy_Products);
            else
                prArray[2] = new Product(p3);
        }
        public void Print() 
        {
            for (int i = 0; i < prArray.Length; i++)
            {
                if (prArray[i] is Meat)
                    Console.WriteLine((prArray[i] as Meat).ToString());
                else if (prArray[i] is Dairy_Products)
                    Console.WriteLine((prArray[i] as Dairy_Products).ToString());
                else
                    Console.WriteLine(prArray[i].ToString());
            }
        }
        public Meat[] FindAllMeat() 
        {
            int index = 0;
            for (int i = 0; i < prArray.Length; i++)
            {
                if (prArray[i] is Meat) index++;
            }

            Meat[] meats = new Meat[index];

            index = 0;
            for (int i = 0; i < prArray.Length; i++)
            {
                if (prArray[i] is Meat) 
                {
                    meats[index] = new Meat(prArray[i] as Meat);
                    index++;
                }
            }
            return meats;
        }
        public Product this[int index]
        {
            get { return prArray[index]; }
        }
        public void ChangePrice(double per) 
        {
            for (int i = 0; i < prArray.Length; i++)
            {
                if (prArray[i] is Meat)
                    (prArray[i] as Meat).ChangePrice(per);
                else if (prArray[i] is Dairy_Products)
                    (prArray[i] as Dairy_Products).ChangePrice(per);
                else
                    prArray[i].ChangePrice(per);
            }
        }
    }
}
