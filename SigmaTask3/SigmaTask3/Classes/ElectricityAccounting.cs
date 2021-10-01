using System;
using SigmaTask3.Classes;

namespace SigmaTask3
{
    enum Quarter{FirstQuarter, SecondQuarter, ThirdQuarter, FourthQuarter };
    class ElectricityAccounting
    {
        private Apartment[] apartments;
        private Apartment[] Apartments
        {
            set
            {
                if (value != null)
                {
                    apartments = new Apartment[value.Length];
                    for (int i = 0; i < value.Length; i++)
                    {
                        apartments[i] = new Apartment(value[i]);
                    }
                }
                else
                    throw new ArgumentNullException("Null argument!");
            }
        }
        private Quarter quarter;
        private Quarter Quarter
        { get; set; }
        private int apartmentsAmount;
        private int ApartmentsAmount
        {
            get { return apartmentsAmount; }
            set
            {
                if (value >= 0)
                {
                    apartmentsAmount = value;
                }
                else
                    throw new ArgumentOutOfRangeException("Apatrments amount < 0!");
            }
        }
        public ElectricityAccounting(int apartmentsAmount, Quarter quarter, Apartment[] apartments)
        {
            this.ApartmentsAmount = apartmentsAmount;
            this.quarter = quarter;
            this.Apartments = apartments;
        }
        public override string ToString()
        {
            string ret = String.Format("{0, -10}{1, -20}", "Number", "Owner");
            switch (quarter)
            {
                case Quarter.FirstQuarter:
                    ret += String.Format("{0,11}{3,9}{1,11}{3,9}{2,9}{3,11}", "January", "February", "March", " ");
                    break;
                case Quarter.SecondQuarter:
                    ret += String.Format("{0,9}{3,11}{1,8}{3,12}{2,9}{3,17}", "April", "May", "June", " ");
                    break;
                case Quarter.ThirdQuarter:
                    ret += String.Format("{0,9}{3,11}{1,10}{3,10}{2,11}{3,9}", "July", "August", "September", " ");
                    break;
                case Quarter.FourthQuarter:
                    ret += String.Format("{0,10}{3,10}{1,11}{3,9}{2,11}{3,9}", "October", "November", "December", " ");
                    break;
            }
            for (int i = 0; i < ApartmentsAmount; ++i)
            {
                ret += "\n";
                ret += apartments[i].ToString();
            }
            return ret;
        }
        public string PrintApartmentInfo(int index)
        {
            if (index - 1 <= apartmentsAmount)
            {
                string ret = String.Format("{0, -10}{1, -20}", "Number", "Owner");
                switch (quarter)
                {
                    case Quarter.FirstQuarter:
                        ret += String.Format("{0,11}{3,9}{1,11}{3,9}{2,9}{3,11}", "January", "February", "March", " ");
                        break;
                    case Quarter.SecondQuarter:
                        ret += String.Format("{0,9}{3,11}{1,8}{3,12}{2,9}{3,17}", "April", "May", "June", " ");
                        break;
                    case Quarter.ThirdQuarter:
                        ret += String.Format("{0,9}{3,11}{1,10}{3,10}{2,11}{3,9}", "July", "August", "September", " ");
                        break;
                    case Quarter.FourthQuarter:
                        ret += String.Format("{0,10}{3,10}{1,11}{3,9}{2,11}{3,9}", "October", "November", "December", " ");
                        break;
                }
                ret += "\n";
                ret += apartments[index - 1].ToString();
                return ret;
            }
            else
                throw new ArgumentOutOfRangeException("Index > Apartments amount");
        }
        public string FindBiggestPaymentDebtor()
        {
            int biggestdebt = apartments[0].GetAmountOfUsedElectricity();
            string surname = apartments[0].Owner;
            for (int i = 0; i < apartmentsAmount; ++i)
            {
                if (apartments[i].GetAmountOfUsedElectricity() > biggestdebt)
                {
                    surname = apartments[i].Owner;
                    biggestdebt = apartments[i].GetAmountOfUsedElectricity();
                }
            }
            return surname;
        }
        public int FindApartmentWithoutUsingEl() 
        {
            for (int i = 0; i < apartmentsAmount; i++)
            {
                if (apartments[i].GetAmountOfUsedElectricity() == 0)
                    return apartments[i].NumberOfApartment;
            }
            return -1;
        } 
    }
}
