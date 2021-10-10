using System;
using PolynomialTask.Classes;

namespace PolynomialTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Polynomial p1 = new Polynomial();
            p1.Parse("3+1*x^1+3*x^2");
            Polynomial p2 = new Polynomial();
            p2.Parse("2+1*x^2");

            Console.WriteLine(p1*p2);
        }
    }
}
