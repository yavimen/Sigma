using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MyMatrix
{
    class Matrix: IEnumerable
    {
        private double[,] array2d;
        public double[,] Array2D 
        {
            set 
            {
                if (value == null)
                    throw new ArgumentNullException();
                array2d = (double[,])value.Clone();
            }
            get 
            {
                return (double[,])array2d.Clone();
            }
        }

        public Matrix() => array2d = null;

        public Matrix(double[,] matrix) => array2d = matrix;

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public Enumerator GetEnumerator() 
        {
            return new Enumerator(this);
        }


        public class Enumerator : IEnumerator
        {
            double[,] marray2d;

            int i = - 1;
            int j = -1;

            public Enumerator(Matrix m) 
            {
                marray2d = m.Array2D;
                i = marray2d.GetLength(0) - 1;
                j = marray2d.GetLength(1);
            }
            public double Current => marray2d[i,j];

            object IEnumerator.Current => marray2d[i, j];

            public bool MoveNext()
            {
                j--;
                if (j < 0) 
                {
                    j = marray2d.GetLength(1) - 1;
                    i--;
                }
                return i >= 0;
            }

            public void Reset()
            {
                i = marray2d.GetLength(0) - 1;
                j = marray2d.GetLength(1);
            }
        }
    }
}
