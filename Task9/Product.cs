using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using StorageTask.Classes;

namespace StorageTask
{
    class Product
    {
        public delegate void MyDelegate(string line, Product product, int param);
        static public event MyDelegate UncorrectInput;

        public string Name { get; set; }

        private double price;
        public double Price
        {
            get { return price; }
            set { if (value > 0) price = value;
                else
                    UncorrectInput.Invoke(value.ToString(), this, 1); }
        }

        private double weight;
        public double Weight
        {
            get { return weight; }
            set { if (value > 0) weight = value;
                else
                    UncorrectInput.Invoke(value.ToString(), this, 2); 
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
                    UncorrectInput.Invoke(value.ToString(), this, 3);
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
                if (temp.Length != 3 | !int.TryParse(temp[0], out day) | !int.TryParse(temp[1], out month)
                    | !int.TryParse(temp[2], out year))
                {
                    UncorrectInput.Invoke(value, this, 4);
                }
                else
                {
                    if (month >= 1 && month <= 12)
                    {
                        switch (month)
                        {
                            case 4:
                            case 6:
                            case 9:
                            case 11:
                                if (day < 1 && day > 30)
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
                                if (day < 1 && day > 31)
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
        }

        public Product(Product p)
        {
            UncorrectInput = InputCorrecting;
            this.Name = p.Name;
            this.Price = p.Price;
            this.Weight = p.Weight;
            this.ExpirationDays = p.expirationDays;
            this.Made = p.made;
        }

        public Product(string Name = "", double Price = 1, double Weight = 1, int expirationDays = 1, string made = "22.04.2021")
        {
            UncorrectInput = InputCorrecting;
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
            return string.Format("{0, -15}{1,-15}{2,-15}{3,-25}{4,-20}", "Name:" + Name, "Price:" + Price, "Weight:" + Weight,
                "Expiration days:" + ExpirationDays, "Made:" + Made);
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
            int []isuncorrect = new int[] {0,0,0};
            string[] temp = s.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            if (temp.Length != 5)
            {
                throw new Exception("Wrong delimiter number!!!");
            }
            Name = temp[0];

            int tempexpdays; double tempweight, tempprice;

            if (!double.TryParse(temp[1], out tempprice))  
            {
                isuncorrect[0] = 1;
                UncorrectInput.Invoke(temp[1], this, 1);
            }
            if (!double.TryParse(temp[2], out tempweight))
            {
                isuncorrect[1] = 1;
                UncorrectInput.Invoke(temp[2], this, 2);
            }
            if(!int.TryParse(temp[3], out tempexpdays))
            {
                isuncorrect[2] = 1;
                UncorrectInput.Invoke(temp[3], this, 3);
            }
            if (isuncorrect[0] != 1)Price = tempprice;
            if (isuncorrect[1] != 1)Weight = tempweight;
            if (isuncorrect[2] != 1) ExpirationDays = tempexpdays;
            Made = temp[4];
        }

        protected void InputCorrecting(string line, Product product, int param)
        {
            Console.Write(product.Name+" ");
            switch (param)
            {
                case 1:
                    double cprice;
                    Console.WriteLine("has uncorrect price!");
                    Console.Write("Enter correct price: ");
                    for(int i = 0; !double.TryParse(Console.ReadLine(), out cprice) && i < 10; i++)
                       Console.Write("Enter correct price: ");
                    product.Price = cprice;
                    break;
                case 2:
                    double cweight;
                    Console.WriteLine("has uncorrect weight!");
                    Console.Write("Enter correct weight: ");
                    for (int i = 0; !double.TryParse(Console.ReadLine(), out cweight) && i < 10; i++)
                        Console.Write("Enter correct weight: ");
                    product.Weight = cweight;
                    break;
                case 3:
                    int expdays;
                    Console.WriteLine("has uncorrect expiration days!");
                    Console.Write("Enter correct expiration days: ");
                    for (int i = 0; !int.TryParse(Console.ReadLine(), out expdays) && i < 10; i++)
                        Console.Write("Enter correct expiration days: ");
                    product.ExpirationDays = expdays;
                    break;
                case 4:
                    DateTime date;
                    Console.WriteLine("has uncorrect date!");
                    Console.Write("Enter correct date: ");
                    for (int i = 0; !DateTime.TryParse(Console.ReadLine(), out date) && i < 10; i++)
                        Console.Write("Enter correct date: ");
                    product.Made = date.Day.ToString()+"."+ date.Month.ToString() + "." + date.Year.ToString();
                    break;
                default:
                    break;
            }
        }
    }
}
