using System;

namespace Polynom.Classes
{
    class Monomial
    {
        private int power;
        public int Power 
        {
            set 
            {
                if (value >= 0)
                {
                    power = value;
                }
                else
                    throw new ArgumentOutOfRangeException("Power less than zero!");
            }
            get 
            {
                return power;
            }
        }
        private double coef;
        public double Coefficient
        {
            get { return coef; }
            set {
                if (value != 0)
                    coef = value;
                else
                    throw new ArgumentOutOfRangeException("Coeficient = 0!!");
            }
        }
        public Monomial(Monomial obj)
        {
            Power = obj.Power;
            Coefficient = obj.Coefficient;
        }
        public Monomial(int power, double coefficint) 
        {
            this.Power = power;
            this.Coefficient = coefficint;
        }
        public override bool Equals(Object obj)
        {
            if (!(obj is Monomial)) 
            {
                return false;
            }

            return Power == (obj as Monomial).Power;
        }
        public override string ToString()
        {
            if (Power == 0) 
            {
                return Coefficient.ToString();
            }
            if (Coefficient > 0)
            {
                return  (Coefficient == 1 ? "*x^" + Power : Coefficient + "*x^" + Power);
            }
            return Coefficient == -1 ? "-*x^" + Power : Coefficient + "*x^" + Power;
        }
        public static bool operator > (Monomial m1, Monomial m2) 
        {
            return m1.Power > m2.Power;
        }
        public static bool operator < (Monomial m1, Monomial m2)
        {
            return m1.Power < m2.Power;
        }
    }
}
