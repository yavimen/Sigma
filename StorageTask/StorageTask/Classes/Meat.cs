using System;

namespace StorageTask.Classes
{
    enum Category
    {
        HigherSort = 1,
        FirstSort,
        SecondSort
    }
    enum KindOfMeat 
    {
        Mutton = 1,
        Veal,
        Pork,
        Chicken
    }
    class Meat: Product
    {
        private Category category;
        public Category Category 
        {
            get { return category; }
            set { category = value; }
        }
        private KindOfMeat meat;
        public KindOfMeat mMeat
        {
            get { return meat; }
            set { meat = value; }

        }
        public Meat():base()
        {

        }
        public Meat(Meat m) : base(m) 
        {
            category = m.category;
            meat = m.meat;
        }
        public Meat(string Name, double Price, double Weight, Category category, KindOfMeat meat, int ExpirationDays, string Made):base(Name, Price, Weight, ExpirationDays, Made)
        {
            this.category = category;
            this.meat = meat;
        }
        public override bool Equals(object obj)
        {
            if (!(obj is Meat)) return false;

            if (category == (obj as Meat).Category && meat == (obj as Meat).mMeat && Name == (obj as Meat).Name)
                return true;
            return false;
        }
        public override string ToString()
        {
            return base.ToString()+string.Format("{0, -15}{1,-15}", "Kind:"+meat.ToString(), "Category:"+category.ToString());
        }
        public override bool ChangePrice(double aPercent)
        {
            switch (category)
            {
                case Category.HigherSort:
                    Price = Price + Price * 0.05;
                    break;
                case Category.FirstSort:
                    Price = Price + Price * 0.1;
                    break;
                case Category.SecondSort:
                    Price = Price + Price * 0.15;
                    break;
            }

            return base.ChangePrice(aPercent);
        }
        /// <summary>
        /// Converting string to object parameters.
        /// Order of parameters: "Name Price Weight ExpirationDays Made Category KindOfMeat" 
        /// </summary>
        /// <param name="s"></param>
        public override void Parse(string s)
        {
            string[] temp = s.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            if (temp.Length != 7)
            {
                throw new Exception("Wrong delimiter number!!!");
            }
            Name = temp[0];

            int tempexpdays; double tempweight, tempprice;

            if (!double.TryParse(temp[1], out tempprice) || !double.TryParse(temp[2], out tempweight)
                || !int.TryParse(temp[3], out tempexpdays))
            {
                throw new Exception("Wrong data format!!! Read a Product.Parse() description!");
            }
            Price = tempprice;
            Weight = tempweight;
            ExpirationDays = tempexpdays;
            Made = temp[4];

            switch (temp[6].Length) 
            {
                case 5:
                    temp[6] = temp[6].Remove(4);
                    break;
                case 7:
                    temp[6] = temp[6].Remove(6);
                    break;
                case 8:
                    temp[6] = temp[6].Remove(7);
                    break;

            }
            Category = (Category)Enum.Parse(typeof(Category), temp[5]);
            meat = (KindOfMeat)Enum.Parse(typeof(KindOfMeat), temp[6]);
        }
    }
}
