using System;
using System.Collections.Generic;
using System.Text;

namespace SigmaMagicSquare
{
    class MagicSquare
    {
        int nsize;

        public MagicSquare(int size) 
        {
            nsize = size;
        }

        private void CreateRomb(ref int[,] rmatrix)
        {
            int counter = 1;
            for (int i = 0; i < nsize; ++i)
            {
                for (int j = 0; j < nsize; j++)
                {
                    rmatrix[nsize - 1 - j + i, j + i] = counter++;
                }
            }
            return;
        }

        public int[,] CreateMagicSquare() 
        {
            int fSize = nsize + nsize - 1;
            int[,] rmatrix = new int[fSize, fSize];
            CreateRomb(ref rmatrix);


            for (int i = 0; i <= (nsize - 1) / 2; i++)
            {
                for (int j = 0; j < rmatrix.GetLength(1); ++j)
                {
                    if (rmatrix[i, j] != 0)
                    {
                        rmatrix[i + nsize, j] = rmatrix[i, j];
                        rmatrix[i, j] = 0;
                    }
                }
            }

            for (int i = rmatrix.GetLength(0) - 1; i >= rmatrix.GetLength(0) - (nsize - 1) / 2; i--)
            {
                for (int j = 0; j < rmatrix.GetLength(1); ++j)
                {
                    if (rmatrix[i, j] != 0)
                    {
                        rmatrix[i - nsize, j] = rmatrix[i, j];
                        rmatrix[i, j] = 0;
                    }
                }
            }

            for (int j = 0; j < (nsize - 1) / 2; j++)
            {
                for (int i = 0; i < rmatrix.GetLength(1); i++)
                {
                    if (rmatrix[i, j] != 0)
                    {
                        rmatrix[i, j + nsize] = rmatrix[i, j];
                        rmatrix[i, j] = 0;
                    }
                }
            }
            for (int j = rmatrix.GetLength(0) - 1; j >= rmatrix.GetLength(0) - (nsize - 1) / 2; j--)
            {
                for (int i = 0; i < rmatrix.GetLength(1); i++)
                {
                    if (rmatrix[i, j] != 0)
                    {
                        rmatrix[i, j - nsize] = rmatrix[i, j];
                        rmatrix[i, j] = 0;
                    }
                }
            }

            int[,] magicSquare = new int[nsize, nsize];
            for (int i = 0; i < nsize; i++)
            {
                for (int j = 0; j < nsize; j++)
                {
                    magicSquare[i, j] = rmatrix[(nsize - 1) / 2 + i, (nsize - 1) / 2 + j];
                }
            }
            return magicSquare;
        }
    }
}