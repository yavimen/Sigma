using System;
using System.Collections.Generic;
using System.Text;

namespace SigmaTasks.Classes
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
        public Meat()
        {

        }
        public Meat(Meat m) : base(m) 
        {
            category = m.category;
            meat = m.meat;
        }
        public Meat(string Name, double Price, double Weight, Category category, KindOfMeat meat):base(Name, Price, Weight)
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
            return string.Format("{0, -15}{1,-15}{2,-15}{3,-15}{4,-15}", "Name:"+Name, "Price:"+Price, "Weight:"+Weight, "Kind:"+meat.ToString(), "Category:"+category.ToString());
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
    }
}
