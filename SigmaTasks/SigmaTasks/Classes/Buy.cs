using System;
using System.Collections.Generic;
using System.Text;

namespace SigmaTasks
{
    class Buy
    {
        private Product[] productsArr;
        public Product[] ProductsArr
        {
            get { return productsArr; }
        }
        private int numberOfProducts;
        public int NumberOfProducts
        {
            get { return numberOfProducts; }
        }
        private double sumOfPrice;
        public double SumOfPrice
        {
            get { return sumOfPrice; }
        }
        private double sumOfWeight;
        public double SumOfWeight
        {
            get { return sumOfWeight; }
        }
        public Buy()
        {
            numberOfProducts = 0;
            sumOfPrice = 0;
            sumOfWeight = 0;
        }
        public Buy(in Product[] products)
        {
            productsArr = new Product[productsArr.Length];

            for (int i = 0; i < productsArr.Length; i++)
            {
                productsArr[i].Name = products[i].Name;
                productsArr[i].Price = products[i].Price;
                productsArr[i].Weight = products[i].Weight;
            }

            for (int i = 0; i < productsArr.Length; i++)
            {
                sumOfPrice += productsArr[i].Price;
                sumOfWeight += productsArr[i].Weight;
            }

            numberOfProducts = productsArr.Length;
        }
        public void AddEl(Product product)
        {
            if (productsArr == null)
            {
                productsArr = new Product[1] { product };
                sumOfPrice = product.Price;
                sumOfWeight = product.Weight;
                numberOfProducts = 1;
            }
            else
            {
                Product[] tempArr = new Product[productsArr.Length + 1];
                for (int i = 0; i < tempArr.Length; i++)
                {
                    tempArr[i] = new Product();
                }

                for (int i = 0; i < productsArr.Length; i++)
                {
                    tempArr[i].Name = productsArr[i].Name;
                    tempArr[i].Price = productsArr[i].Price;
                    tempArr[i].Weight = productsArr[i].Weight;
                }

                tempArr[productsArr.Length].Name = product.Name;
                tempArr[productsArr.Length].Price = product.Price;
                tempArr[productsArr.Length].Weight = product.Weight;

                sumOfPrice += product.Price;
                sumOfWeight += product.Weight;
                numberOfProducts++;

                productsArr = tempArr;
            }
        }
    }
}
