using System;

namespace SigmaTask3.Classes
{
    class Apartment
    {
        private int numberOfApartment;
        public int NumberOfApartment 
        {
            get { return numberOfApartment; }
            set 
            {
                if (value > 0)
                    numberOfApartment = value;
                else
                    throw new ArgumentOutOfRangeException("Number of apartment should be greated than zero!");
            }
        }
        
        private string owner;
        public  string Owner
        {
            get { return owner; }
            set { owner = value; }
        }

        private (int, int)[] elUsing;
        public (int, int)[] ElUsing 
        {
            get { return elUsing; }
            set 
            {
                if (value != null && value.Length == 3)
                {
                    elUsing = new (int, int)[3];
                    for (int i = 0; i < 3; i++)
                    {
                        elUsing[i].Item1 = value[i].Item1;
                        elUsing[i].Item2 = value[i].Item2;
                    }
                }
                else
                    throw new ArgumentOutOfRangeException("Wrong argument!"); 
            }
        }

        public Apartment() 
        {
            numberOfApartment = 0; owner = ""; elUsing = null;
        }

        public Apartment(Apartment apartment) 
        {
            this.NumberOfApartment = apartment.numberOfApartment;
            Owner = apartment.owner;
            elUsing = new (int, int)[3];
            ElUsing = apartment.ElUsing;    
        }

        public Apartment(int numberOfApartment, string owner, int mon1var1,
            int mon1var2, int mon2var1, int mon2var2, int mon3var1, int mon3var2) 
        {
            NumberOfApartment = numberOfApartment;
            Owner = owner;
            elUsing = new []{ (mon1var1, mon1var2), (mon2var1, mon2var2), (mon3var1, mon3var2) };
        }

        public int GetAmountOfUsedElectricity()
        {
            if (elUsing != null)
            {
                int amount = 0;
                for (int i = 0; i < elUsing.Length; i++)
                {
                    amount += elUsing[i].Item2 - elUsing[i].Item1;
                }
                return amount;
            }
            else 
            {
                throw new ArgumentNullException("elUsing is null!");
            }
        }

        public override string ToString() 
        {
            if (elUsing != null)
                return String.Format("{0,-10}{1,-20}{2,-10}{3,-10}{4,-10}{5,-10}{6,-10}{7,-10}", numberOfApartment.ToString(),
                    owner, elUsing[0].Item1.ToString(), elUsing[0].Item2.ToString(), elUsing[1].Item1.ToString(), elUsing[1].Item2.ToString(),
                    elUsing[2].Item1.ToString(), elUsing[2].Item2.ToString());
            else
                throw new ArgumentNullException("Arguments not filled!");
        }
    }
}
