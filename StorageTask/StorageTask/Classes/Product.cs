using System;
using System.Collections.Generic;
using System.Text;

namespace StorageTask
{
    class Product
    {
        public string Name { get; set; }
        private double price;
        public double Price
        {
            get { return price; }
            set { if (value > 0) price = value;
                else
                    throw new ArgumentOutOfRangeException("Price less than zero"); }
        }
        private double weight;
        public double Weight
        {
            get { return weight; }
            set { if (value > 0) weight = value;
                else
                    throw new ArgumentOutOfRangeException("Weight less than zero");
            }
        }
        private int expirationDays;
        public int ExpirationDays
        {
            get { return expirationDays; }
            set
            {
                if (value > 0)
                {
                    expirationDays = value;
                }
                else
                    throw new ArgumentOutOfRangeException("Expiration days less than zero!!!");
            }
        }
        private string made;
        public string Made
        {
            get { return made; }
            set 
            {
                string[] temp = value.Split(".");
                int day, month, year;
                if (temp.Length != 3)
                    throw new Exception("Wrong delimiter number!!!");
                if (!int.TryParse(temp[0], out day) || !int.TryParse(temp[1], out month) || !int.TryParse(temp[2], out year)) 
                {
                    throw new ArgumentException("Wrong data format");
                }
                if (month >= 1 && month <= 12)
                {
                    switch (month)
                    {
                        case 4:
                        case 6:
                        case 9:
                        case 11:
                            if(day < 1 &&day > 30)
                                throw new ArgumentOutOfRangeException($"Wrong day number for {month} month - {day}");
                            break;
                        case 2:
                            if (DateTime.IsLeapYear(year))
                                if (day < 1 && day > 29) 
                                    throw new ArgumentOutOfRangeException($"Wrong day number for {month} month - {day}");
                            else
                                if (day < 1 && day > 28)
                                    throw new ArgumentOutOfRangeException($"Wrong day number for {month} month - {day}");
                            break;
                        default:
                            if(day < 1 && day > 31)
                                throw new ArgumentOutOfRangeException($"Wrong day number for {month} month - {day}");
                            break;
                    }
                }
                else
                    throw new ArgumentOutOfRangeException($"Wrong month number - {month}");
                if (year < 1800 || year > DateTime.Now.Year) 
                {
                    throw new ArgumentOutOfRangeException($"Wrong year - {year}");
                }
                made = value;
            }
        }
        public Product() 
        {
            price = 0;
            Name = "";
            weight = 0;
            expirationDays = 0;
            made = "";
        }
        public Product(Product p) 
        {
            this.Name = p.Name;
            this.Price = p.Price;
            this.Weight = p.Weight;
            this.ExpirationDays = p.expirationDays;
            this.Made = p.made;
        }
        public Product(string Name, double Price, double Weight, int expirationDays, string made)
        {
            this.Name = Name;
            this.Price = Price;
            this.Weight = Weight;
            this.ExpirationDays = expirationDays;
            this.Made = made;
        }
        public override bool Equals(Object obj)
        {
            if (obj.GetType() != this.GetType()) 
            {
                return false;
            }

            return String.Equals((obj as Product).Name, this.Name);
        }
        public override string ToString()
        {
            return string.Format("{0, -15}{1,-15}{2,-15}{3,-25}{4,-20}", "Name:"+Name, "Price:" + Price, "Weight:" + Weight, 
                "Expiration days:"+ExpirationDays, "Made:"+Made);
        }
        public virtual bool ChangePrice(double aPercent) 
        {
            if (aPercent > 0 && aPercent <= 100) 
            {
                Price = Price + Price * aPercent / 100;
                return true;
            }
            return false;
        }
        /// <summary>
        /// Converting string to object parameters.
        /// Order of parameters: "Name Price Weight ExpirationDays Made" 
        /// </summary>
        /// <param name="s"></param>
        public virtual void Parse(string s) 
        {
            string[] temp = s.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            if (temp.Length != 5) 
            {
                throw new Exception("Wrong delimiter number!!!");
            }
            Name = temp[0];

            int tempexpdays; double tempweight, tempprice;

            if (!double.TryParse(temp[1], out tempprice) || !double.TryParse(temp[2], out tempweight) 
                | !int.TryParse(temp[3], out tempexpdays)) 
            {
                throw new Exception("Wrong data format!!! Read a Product.Parse() description!");
            }
            Price = tempprice;
            Weight = tempweight;
            ExpirationDays = tempexpdays;
            Made = temp[4];
        }
    }
}
