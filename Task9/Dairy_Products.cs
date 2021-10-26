using System;
using System.Collections.Generic;
using System.Text;

namespace StorageTask.Classes
{
    class Dairy_Products : Product
    {
        public Dairy_Products(Dairy_Products d) : base(d){}

        public Dairy_Products(string Name, double Price, double Weight, int ExpirationDays, string Made) : base(Name, Price, Weight, ExpirationDays, Made){}

        public override bool Equals(object obj)
        {
            if (!(obj is Dairy_Products)) return false;
            if (Name == (obj as Dairy_Products).Name && (obj as Dairy_Products).ExpirationDays == ExpirationDays)
                return true;
            return false;
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override bool ChangePrice(double aPercent)
        {
            if (ExpirationDays < 5)
                Price = Price + Price * 0.01;
            else if (ExpirationDays < 10)
                Price = Price - Price * 0.03;
            else if (ExpirationDays < 20)
                Price = Price - Price * 0.7;
            else
                Price = 0;
            return base.ChangePrice(aPercent);
        }

        public override void Parse(string s)
        {
            base.Parse(s);
        }
    }
}
