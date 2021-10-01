using System;

namespace SigmaMagicSquare
{
    class Program
    {
        static void CreateRomb(ref int[,] rmatrix, int nsize)
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

        static void Main(string[] args)
        {
            int nSize = 5;
            int fSize = nSize + nSize - 1;
            int[,] rmatrix = new int[fSize, fSize];
            CreateRomb(ref rmatrix, nSize);

            ///----------------------------------------------Create magic square

            for (int i = 0; i <= (nSize - 1) / 2; i++)
            {
                for (int j = 0; j < rmatrix.GetLength(1); ++j)
                {
                    if (rmatrix[i, j] != 0)
                    {
                        rmatrix[i + nSize, j] = rmatrix[i, j];
                        rmatrix[i, j] = 0;
                    }
                }
            }

            for (int i = rmatrix.GetLength(0) - 1; i >= rmatrix.GetLength(0) - (nSize - 1) / 2; i--)
            {
                for (int j = 0; j < rmatrix.GetLength(1); ++j)
                {
                    if (rmatrix[i, j] != 0)
                    {
                        rmatrix[i - nSize, j] = rmatrix[i, j];
                        rmatrix[i, j] = 0;
                    }
                }
            }

            for (int j = 0; j < (nSize - 1) / 2; j++)
            {
                for (int i = 0; i < rmatrix.GetLength(1); i++)
                {
                    if (rmatrix[i, j] != 0)
                    {
                        rmatrix[i, j + nSize] = rmatrix[i, j];
                        rmatrix[i, j] = 0;
                    }
                }
            }
            for (int j = rmatrix.GetLength(0) - 1; j >= rmatrix.GetLength(0) - (nSize - 1) / 2; j--)
            {
                for (int i = 0; i < rmatrix.GetLength(1); i++)
                {
                    if (rmatrix[i, j] != 0)
                    {
                        rmatrix[i, j - nSize] = rmatrix[i, j];
                        rmatrix[i, j] = 0;
                    }
                }
            }

            int[,] magicSquare = new int[nSize, nSize];
            for (int i = 0; i < nSize; i++)
            {
                for (int j = 0; j < nSize; j++)
                {
                    magicSquare[i, j] = rmatrix[(nSize - 1) / 2 + i, (nSize - 1) / 2 + j];
                }
            }

            for (int i = 0; i < magicSquare.GetLength(0); i++)
            {
                for (int j = 0; j < magicSquare.GetLength(1); j++)
                {
                    Console.Write(String.Format("{0,-3}", magicSquare[i, j]));
                }
                Console.WriteLine();
            }
        }
    }
}
