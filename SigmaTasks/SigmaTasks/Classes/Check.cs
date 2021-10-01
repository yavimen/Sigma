using System;
using System.Collections.Generic;
using System.Text;

namespace SigmaTasks
{
    sealed class Check
    {
        static public string ShowCheck(Buy element)
        {
            string checkStr = "";
            checkStr+=String.Format("{0,-15}{1,-15}{2,-15}", "Name", "Price", "Weight");

            for (int i = 0; i < element.NumberOfProducts; i++)
            {
                checkStr += String.Format("{0,-15}{1,-15}{2,-15}", element.ProductsArr[i].Name, element.ProductsArr[i].Price,
                    element.ProductsArr[i].Weight);
                checkStr += "\n";
            }

            checkStr += ($"Total sum: {element.SumOfPrice}\n");
            checkStr += ($"Total weight: {element.SumOfWeight}\n");
            checkStr += ($"Number of products: {element.NumberOfProducts}\n");

            return checkStr;
        }
    }
}
