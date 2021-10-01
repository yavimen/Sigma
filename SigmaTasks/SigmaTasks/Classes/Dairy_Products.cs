using System;
using System.Collections.Generic;
using System.Text;

namespace SigmaTasks.Classes
{
    class Dairy_Products:Product
    {
        private int expirationDate;
        public int ExpirationDate
        {
            get { return expirationDate; }
            set { if (value > 0) expirationDate = value; }
        }
        public Dairy_Products()
        {
            expirationDate = 0;
        }
        public Dairy_Products(Dairy_Products d) : base(d) 
        {
            expirationDate = d.expirationDate;
        }
        public Dairy_Products(string Name, double Price, double Weight, int ExpirationDate):base(Name, Price, Weight)
        {
            if (ExpirationDate > 0) 
            {
                this.expirationDate = ExpirationDate;
            }
        }
        public override bool Equals(object obj)
        {
            if (!(obj is Dairy_Products)) return false;
            if (Name == (obj as Dairy_Products).Name && (obj as Dairy_Products).expirationDate == expirationDate) 
                return true;
            return false;
        }
        public override string ToString()
        {
            return base.ToString()+ string.Format("{0, -15}", "ExDate:"+ExpirationDate);
        }
        public override bool ChangePrice(double aPercent)
        {
            if (expirationDate < 5)
                Price = Price + Price * 0.01;
            else if (expirationDate < 10)
                Price = Price - Price * 0.03;
            else if (expirationDate < 20)
                Price = Price - Price * 0.7;
            else
                Price = 0;
            return base.ChangePrice(aPercent);
        }
    }
}
