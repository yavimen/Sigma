using System;
using System.Collections.Generic;
using System.IO;

namespace MarketList.Classes
{
    class MyDinner
    {
        private Dictionary<string,(double, double)> products;
        public Dictionary<string, (double, double)> Products { get; set; }

        private string menufilepath;
        public string MenuFilePath 
        {
            get { return menufilepath; }
            set 
            {
                if (!File.Exists(value))
                    throw new FileNotFoundException("Menu file doesn't exist!");
                menufilepath = value;
            }
        }

        private string pricefilepath;
        public string PriceFilePath
        {
            get { return pricefilepath; }
            set
            {
                if (!File.Exists(value))
                    throw new FileNotFoundException("Menu file doesn't exist!");
                pricefilepath = value;
            }
        }

        public MyDinner(string menufilepath, string pricesfilepath) 
        {
            products = new Dictionary<string, (double, double)>();
            MenuFilePath = menufilepath;
            PriceFilePath = pricesfilepath;
            FormingDictionary();
        }

        private void ReadMenuFile() 
        {
            double weight;
            string line;
            string[] val;
            StreamReader file = new StreamReader(@menufilepath);
            if (file == null)
                throw new FileLoadException();
            while (true) 
            {
                if (file.EndOfStream)
                    break;
                line = file.ReadLine();
                if (line == String.Empty)
                    continue;
                val = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (val.Length == 1)
                    continue;
                else if (val.Length == 2 && double.TryParse(val[1], out weight))
                {
                    if (products.ContainsKey(val[0]))
                        products[val[0]] = (weight + products[val[0]].Item1, 0);
                    else
                        products.Add(val[0], (weight, 0));
                }
                else
                    throw new ArgumentException();
            }
        }

        private void ReadPricesFile()
        {
            double price;
            string line;
            string[] val;
            StreamReader file = new StreamReader(@pricefilepath);
            if (file == null)
                throw new FileLoadException();
            while (true)
            {
                if (file.EndOfStream)
                    break;
                line = file.ReadLine();
                if (line == String.Empty)
                    continue;
                val = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (val.Length == 1)
                    continue;
                else if (val.Length == 2 && double.TryParse(val[1], out price))
                {
                    if (!products.ContainsKey(val[0]))
                        throw new Exception("File doesn't contain prices of all needed products");
                    products[val[0]] = (products[val[0]].Item1, price * products[val[0]].Item1);
                }
                else
                    throw new ArgumentException();
            }
        }

        private void FormingDictionary() 
        {
            ReadMenuFile();
            ReadPricesFile();
        }

        public string GetMarketList() 
        {
            string retstr = String.Format("{0,-15}{1,-10}{2,-10}", "Product", "Weight", "Price");
            foreach (var item in products)
            {   
                retstr += "\n";
                retstr += String.Format("{0,-15}{1,-10}{2,-10}", item.Key, Math.Round(item.Value.Item1, 2), Math.Round(item.Value.Item2, 2));
            }
            return retstr;
        }
    }
}
