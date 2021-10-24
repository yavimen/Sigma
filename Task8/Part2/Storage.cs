using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace StorageTask.Classes
{
    class Storage
    {
        private List<Product> prArray;
        public List<Product> PrArray
        {
            get { return prArray; }
        }

        public Storage()
        {
            prArray = new List<Product>();
        }
        //public Storage(Product p1, Product p2, Product p3)
        //{
        //    if (p1 is Meat)
        //        prArray.Add(new Meat(p1 as Meat));
        //    else if (p1 is Dairy_Products)
        //        prArray.Add(new Dairy_Products(p1 as Dairy_Products));
        //    else
        //        prArray.Add(new Product(p1));

        //    if (p2 is Meat)
        //        prArray.Add(new Meat(p2 as Meat));
        //    else if (p2 is Dairy_Products)
        //        prArray.Add(new Dairy_Products(p2 as Dairy_Products));
        //    else
        //        prArray.Add(new Product(p2));

        //    if (p3 is Meat)
        //        prArray.Add(new Meat(p3 as Meat));
        //    else if (p3 is Dairy_Products)
        //        prArray.Add(new Dairy_Products(p3 as Dairy_Products));
        //    else
        //        prArray.Add(new Product(p3));
        //}

        public void FillStorage() 
        {
            int typeChoose;
            int size = 0;
            Int16 counter = 0;
            Console.WriteLine("How many new products?: ");
            size = int.Parse(Console.ReadLine());
            if (size < 0)
                throw new ArgumentOutOfRangeException("Number of products less than zero");
            Console.Clear();
            while (counter < size)
            {
                Console.WriteLine("What type?\n1.Meat\n2.Dairy_product\n3.Other");
                typeChoose = int.Parse(Console.ReadLine());
                if (typeChoose == 1)
                {
                    Console.Clear();
                    prArray.Add(new Meat());
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
                    Console.Clear();
                    Console.WriteLine("Expiration date:");
                    prArray[counter].ExpirationDays = int.Parse(Console.ReadLine());
                    Console.Clear();
                    Console.WriteLine("Made:");
                    prArray[counter].Made = Console.ReadLine();
                    counter++;
                    Console.Clear();
                }
                else if (typeChoose == 2)
                {
                    Console.Clear();
                    prArray.Add(new Dairy_Products());
                    Console.Write("Name: ");
                    prArray[counter].Name = Console.ReadLine();
                    Console.Write("Price: ");
                    prArray[counter].Price = double.Parse(Console.ReadLine());
                    Console.Write("Wight: ");
                    prArray[counter].Weight = double.Parse(Console.ReadLine());
                    Console.Clear();
                    Console.WriteLine("Expiration date:");
                    prArray[counter].ExpirationDays = int.Parse(Console.ReadLine());
                    Console.Clear();
                    Console.WriteLine("Made:");
                    prArray[counter].Made = Console.ReadLine();
                    counter++;
                    Console.Clear();
                }
                else
                {
                    Console.Clear();
                    prArray.Add(new Product());
                    Console.Write("Name: ");
                    prArray[counter].Name = Console.ReadLine();
                    Console.Write("Price: ");
                    prArray[counter].Price = double.Parse(Console.ReadLine());
                    Console.Write("Wight: ");
                    prArray[counter].Weight = double.Parse(Console.ReadLine());
                    Console.Clear();
                    Console.WriteLine("Expiration date:");
                    prArray[counter].ExpirationDays = int.Parse(Console.ReadLine());
                    Console.Clear();
                    Console.WriteLine("Made:");
                    prArray[counter].Made = Console.ReadLine();
                    counter++;
                    Console.Clear();
                }
            }
        }

        public override string ToString()
        {
            string str = "";
            for (int i = 0; i < prArray.Count; i++)
            {
                if (prArray[i] is Meat)
                    str += (prArray[i] as Meat).ToString()+"\n";
                else
                    str += (prArray[i].ToString()) + "\n";
            }
            return str;
        }

        public Meat[] FindAllMeat()
        {
            int index = 0;
            for (int i = 0; i < prArray.Count; i++)
            {
                if (prArray[i] is Meat) index++;
            }

            Meat[] meats = new Meat[index];

            index = 0;
            for (int i = 0; i < prArray.Count; i++)
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
            for (int i = 0; i < prArray.Count; i++)
            {
                if (prArray[i] is Meat)
                    (prArray[i] as Meat).ChangePrice(per);
                else if (prArray[i] is Dairy_Products)
                    (prArray[i] as Dairy_Products).ChangePrice(per);
                else
                    prArray[i].ChangePrice(per);
            }
        }

        public void RemoveExpiredDairyProducts(string filepath) 
        {
            if (!File.Exists(filepath)) 
            {
                throw new FileNotFoundException();
            }

            StreamWriter file = new StreamWriter(filepath);
            
            int counter = 0;
            DateTime d1; 
            DateTime d2;
            
            for(int i = 0; i < prArray.Count; ++i) 
            {
                d1 = DateTime.Parse(prArray[i].Made);
                d1 = d1.AddDays(prArray[i].ExpirationDays);
                d2 = DateTime.Now;
                if (prArray[i] is Dairy_Products) 
                {
                    if (d1.CompareTo(d2) < 0)
                    { 
                        counter++;
                        file.WriteLine(prArray[i].ToString());
                    }
                }
            }

            file.Close();

            Product[] tempArray = new Product[prArray.Count - counter];
            int j = 0;
            for (int i = 0; i < prArray.Count; i++)
            {
                d1 = DateTime.Parse(prArray[i].Made);
                d1 = d1.AddDays(prArray[i].ExpirationDays);
                d2 = DateTime.Now;
                while(prArray[i] is Dairy_Products && d1.CompareTo(d2)<0)
                {
                    i++;
                    if (i >= prArray.Count)
                        break;
                    d1 = DateTime.Parse(prArray[i].Made);
                    d1 = d1.AddDays(prArray[i].ExpirationDays);
                    d2 = DateTime.Now;
                }
                if (i >= prArray.Count)
                    break;
                tempArray[j] = prArray[i];
                j++;
            }

            prArray.Clear();
            prArray.AddRange(tempArray);
        }

        public void FillStorageFromFile(string filepath) 
        {
            if (!File.Exists(filepath))
            {
                throw new FileNotFoundException();
            }

            StreamReader file = new StreamReader(filepath);

            string filestr;
            string[] sstr;
            string[] varstr;

            filestr = file.ReadToEnd();

            sstr = filestr.Split("\n", StringSplitOptions.RemoveEmptyEntries);

            prArray = new List<Product>();

            for (int i = 0; i < sstr.Length; i++)
            {
                varstr = sstr[i].Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (varstr.Length == 6) 
                {
                    if (varstr[0].CompareTo("Product") == 0) 
                    {
                        prArray.Add(new Product());
                        prArray[i].Parse(varstr[1] + " " + varstr[2] + " " + varstr[3] + " " + varstr[4] + " " + varstr[5]);
                    }
                    if (varstr[0].CompareTo("Dairy_Product") == 0)
                    {
                        prArray.Add(new Dairy_Products());
                        prArray[i].Parse(varstr[1] + " " + varstr[2] + " " + varstr[3] + " " + varstr[4] + " " + varstr[5]);
                    }
                }
                else if (varstr.Length == 8) 
                {
                    prArray.Add(new Meat());
                    (prArray[i] as Meat).Parse(varstr[1] + " " + varstr[2] + " " + varstr[3] + " " + varstr[4]+ " "+ varstr[5]+" "+
                        varstr[6]+" "+varstr[7]);
                }
                else
                    throw new ArgumentException("Too many arguments in file!!!");
            }
        }
    }
}
