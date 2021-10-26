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
    class Meat : Product
    {
        public delegate void MyDelegate(string line, Meat product, int param);
        static public event MyDelegate UncorrectInput;

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

        public Meat(Meat m) : base(m)
        {
            UncorrectInput = InputCorrecting;
            category = m.category;
            meat = m.meat;
        }

        public Meat(string Name, double Price, double Weight, Category category = Category.SecondSort, KindOfMeat meat = KindOfMeat.Pork, 
            int ExpirationDays, string Made) : base(Name, Price, Weight, ExpirationDays, Made)
        {
            UncorrectInput = InputCorrecting;
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
            return base.ToString() + string.Format("{0, -15}{1,-15}", "Kind:" + meat.ToString(), "Category:" + category.ToString());
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
            int[] isuncorrect = new int[] { 0, 0, 0, 0, 0 };
            string[] temp = s.Split(new char[] {' ', '\r'}, StringSplitOptions.RemoveEmptyEntries);

            if (temp.Length != 7)
                throw new Exception("Wrong delimiter number!!!");

            Name = temp[0];

            int tempexpdays; double tempweight, tempprice; Category cc; KindOfMeat kom;

            if (!double.TryParse(temp[1], out tempprice)){
                isuncorrect[0] = 1;
                UncorrectInput(temp[1], this, 1);
            }
            if (!double.TryParse(temp[2], out tempweight)){
                isuncorrect[1] = 1;
                UncorrectInput(temp[2], this, 2);
            }
            if(!int.TryParse(temp[3], out tempexpdays)){
                isuncorrect[2] = 1;
                UncorrectInput(temp[3], this, 3);
            }
            if (!Category.TryParse(temp[5], out cc)){
                isuncorrect[3] = 1;
                UncorrectInput(temp[5], this, 5);
            }
            if (!KindOfMeat.TryParse(temp[6], out kom)){
                isuncorrect[4] = 1;
                UncorrectInput(temp[6], this, 6);
            }
            if (isuncorrect[0] != 1)Price = tempprice;
            if (isuncorrect[1] != 1) Weight = tempweight;
            if (isuncorrect[2] != 1) ExpirationDays = tempexpdays;
            if (isuncorrect[3] != 1) Category = cc;
            if (isuncorrect[4] != 1) meat = kom;
            Made = temp[4];
        }

        protected void InputCorrecting(string line, Meat product, int param)
        {
            base.InputCorrecting(line, product, param);
            switch (param) 
            {
                case 5:
                    Category ccategory;
                    Console.WriteLine("has uncorrect category!");
                    Console.Write("Enter correct category: ");
                    for (int i = 0; !Category.TryParse(Console.ReadLine(), out ccategory) && i < 10; i++)
                        Console.Write("Enter correct category: ");
                    product.Category = ccategory;
                    break;
                case 6:
                    KindOfMeat kofmeat;
                    Console.WriteLine("has uncorrect category!");
                    Console.Write("Enter correct category: ");
                    for (int i = 0; !KindOfMeat.TryParse(Console.ReadLine(), out kofmeat) && i < 10; i++)
                        Console.Write("Enter correct category: ");
                    product.mMeat = kofmeat;
                    break;
                default:
                    break;
            }
        }
    }
}
