using System;
using System.Collections.Generic;
using StorageTask.Classes;
using System.IO;

namespace StorageTask.Classes
{
    class Storage
    {
        public delegate void RemoveExpiredProducts();
        public event RemoveExpiredProducts RemoveExpired;

        public delegate void WrongDataReactionLog(string product, string message);
        static public event WrongDataReactionLog UncorrectInput;
        private List<Product> _prArray;
        private List<Product> PrArray
        {
            get { return _prArray; }
        }

        public Storage()
        {
            _prArray = new List<Product>();
            UncorrectInput = WriteLog;
            RemoveExpired = FindExpiredProducts;
        }

        public override string ToString()
        {
            RemoveExpired();
            string str = "";
            for (int i = 0; i < _prArray.Count; i++)
            {
                if (_prArray[i] is Meat)
                    str += (_prArray[i] as Meat).ToString()+"\n";
                else
                    str += (_prArray[i].ToString()) + "\n";
            }
            return str;
        }

        public Meat[] FindAllMeat()
        {
            int index = 0;
            for (int i = 0; i < _prArray.Count; i++)
            {
                if (_prArray[i] is Meat) index++;
            }

            Meat[] meats = new Meat[index];

            index = 0;
            for (int i = 0; i < _prArray.Count; i++)
            {
                if (_prArray[i] is Meat)
                {
                    meats[index] = new Meat(_prArray[i] as Meat);
                    index++;
                }
            }
            return meats;
        }

        public Product this[int index]
        {
            get { return _prArray[index]; }
        }

        public void ChangePrice(double per)
        {
            for (int i = 0; i < _prArray.Count; i++)
            {
                if (_prArray[i] is Meat)
                    (_prArray[i] as Meat).ChangePrice(per);
                else if (_prArray[i] is Dairy_Products)
                    (_prArray[i] as Dairy_Products).ChangePrice(per);
                else
                    _prArray[i].ChangePrice(per);
            }
        }

        public void RemoveExpiredDairyProducts(string filepath) 
        {
            if (!File.Exists(filepath)) 
                throw new FileNotFoundException();

            StreamWriter file = new StreamWriter(filepath);
            
            DateTime d1; 
            DateTime d2;
            
            for(int i = 0; i < _prArray.Count; ++i) 
            {
                d1 = DateTime.Parse(_prArray[i].Made);
                d1 = d1.AddDays(_prArray[i].ExpirationDays);
                d2 = DateTime.Now;

                if (_prArray[i] is Dairy_Products){
                    if (d1.CompareTo(d2) < 0){ 
                        file.WriteLine(_prArray[i].ToString());
                        _prArray.RemoveAt(_prArray[i]);
                        i--;
                    }
                }
            }

            file.Close();
        }

        public void FillStorageFromFile(string filepath) 
        {
            if (!File.Exists(filepath))
                throw new FileNotFoundException();

            StreamReader file = new StreamReader(filepath);

            string filestr;
            string[] sstr;
            string[] varstr;

            double buf = 0;
            int counter = 0;

            filestr = file.ReadToEnd();

            sstr = filestr.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < sstr.Length; i++)
            {
                varstr = sstr[i].Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (varstr.Length == 6) 
                {
                    if (varstr[0].CompareTo("Product") == 0) 
                    {
                        if (!double.TryParse(varstr[2], out buf))
                            UncorrectInput(sstr[i], "Uncorrect input");

                        if (!double.TryParse(varstr[3], out buf))
                            UncorrectInput(sstr[i], "Uncorrect input");

                        if (!int.TryParse(varstr[4], out int tmp))
                            UncorrectInput(sstr[i], "Uncorrect input");

                        if (!DateTime.TryParse(varstr[5], out DateTime tm))
                            UncorrectInput(sstr[i], "Uncorrect input");

                        _prArray.Add(new Product());
                        _prArray[i-counter].Parse(varstr[1] + " " + varstr[2] + " " + varstr[3] + " " + varstr[4] + " " + varstr[5]);
                    }
                    else if (varstr[0].CompareTo("Dairy_Product") == 0)
                    {
                        if (!double.TryParse(varstr[2], out buf))
                            UncorrectInput(sstr[i], "Uncorrect input");

                        if (!double.TryParse(varstr[3], out buf))
                            UncorrectInput(sstr[i], "Uncorrect input");

                        if (!int.TryParse(varstr[4], out int tmp))
                            UncorrectInput(sstr[i], "Uncorrect input");

                        if (!DateTime.TryParse(varstr[5], out DateTime tm))
                            UncorrectInput(sstr[i], "Uncorrect input");

                        _prArray.Add(new Dairy_Products());
                        _prArray[i-counter].Parse(varstr[1] + " " + varstr[2] + " " + varstr[3] + " " + varstr[4] + " " + varstr[5]);
                    }
                }
                else if (varstr.Length == 8) 
                {
                    if (!double.TryParse(varstr[2], out buf))
                        UncorrectInput(sstr[i], "Uncorrect input");

                    if (!double.TryParse(varstr[3], out buf))
                        UncorrectInput(sstr[i], "Uncorrect input");

                    if (!int.TryParse(varstr[4], out int tmp))
                        UncorrectInput(sstr[i], "Uncorrect input");

                    if (!DateTime.TryParse(varstr[5], out DateTime tm))
                        UncorrectInput(sstr[i], "Uncorrect input");

                    if (!Category.TryParse(varstr[6], out Category category))
                        UncorrectInput(sstr[i], "Uncorrect input");

                    if (!KindOfMeat.TryParse(varstr[7], out KindOfMeat meat))
                        UncorrectInput(sstr[i], "Uncorrect input");

                    _prArray.Add(new Meat());
                    (_prArray[i - counter] as Meat).Parse(varstr[1] + " " + varstr[2] + " " + varstr[3] + " " + varstr[4]+ " "+ varstr[5]+" "+
                        varstr[6]+" "+varstr[7]);
                }
                else
                    throw new ArgumentException("Wrong arguments number in file!!!");
            }
        }

        public void Add(Product product) 
        {
            _prArray.Add(product);
        }

        public void Add(Product[] products) 
        {
            for (int i = 0; i < products.Length; i++)
                _prArray.Add(products[i]);
        }

        public void RemoveAll(string productname) 
        {
            _prArray.RemoveAll(item => item.Name.Equals(productname));
        }

        public Product[] FindAll(Predicate<Product> predicate) 
        {
            return _prArray.FindAll(predicate).ToArray();
        }

        protected void WriteLog(string line, string message) 
        {
            StreamWriter log = new StreamWriter("./Log.txt", true);

            log.WriteLine($"{DateTime.Now}. {message}: {line}");

            log.Close();
        }

        public void FindExpiredProducts()
        {
            DateTime d1;
            DateTime d2;

            for (int i = 0; i < _prArray.Count; ++i)
            {
                d1 = DateTime.Parse(_prArray[i].Made);
                d1 = d1.AddDays(_prArray[i].ExpirationDays);
                d2 = DateTime.Now;
                if (d1.CompareTo(d2) < 0)
                {
                    WriteLog(_prArray[i].ToString(), "Removed because of end of expiration days: ");
                    i--;
                }
            }
        }
    }
}
