using System;
using System.Collections.Generic;
using System.Text;

namespace SigmaTasks
{
    class Product
    {
        public string Name { get; set; }
        private double price;
        public double Price
        {
            get { return price; }
            set { if (value > 0) price = value; }
        }
        private double weight;
        public double Weight
        {
            get { return weight; }
            set { if (value > 0) weight = value; }
        }
        public Product() { }
        public Product(Product p) 
        {
            this.Name = p.Name;
            this.Price = p.Price;
            this.Weight = p.Weight;
        }
        public Product(string Name, double Price, double Weight)
        {
            this.Name = Name;
            if (Price > 0)
                this.Price = Price;
            if (Weight > 0)
                this.Weight = Weight;
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
            return string.Format("{0, -15}{1,-15}{2,-15}", "Name:"+Name, "Price:" + Price, "Weight:" + Weight);
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
    }
}
