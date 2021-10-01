using System;
using SigmaTask3.Classes;
using System.IO;

namespace SigmaTask3
{
    class Program
    {
        static void ReadFile(ref int apartmentsAmount, ref Quarter quarter, ref Apartment[] apartments, string filepath) 
        {
            StreamReader file = new StreamReader(filepath);
            if (file == null)
                throw new FileNotFoundException("Path is wrong!");


            string templine = file.ReadLine();

            string[] selements = templine.Split(" ");

            apartmentsAmount = int.Parse(selements[0]);

            apartments = new Apartment[apartmentsAmount];

            quarter = (Quarter)Enum.GetValues(typeof(Quarter)).GetValue(int.Parse(selements[1])-1);

            for (int i = 0; i < apartmentsAmount; ++i)
            {
                templine = file.ReadLine();
                selements = templine.Split(" ");
                apartments[i] = new Apartment(int.Parse(selements[0]), selements[1], int.Parse(selements[2]), int.Parse(selements[3]),
                    int.Parse(selements[4]), int.Parse(selements[5]), int.Parse(selements[6]), int.Parse(selements[7]));
            }
        }
        static void Main(string[] args)
        {
            string path = "./Apartments.txt";
        }
    }
}
