using System;
using System.Collections.Generic;
using System.Text;

namespace StartingCSharp
{
    class ShadowTask
    {
        private short[,,] matrix;
        public short[,,] Matrix 
        {
            set;
            get;
        }

        private short[,] xyprojection;
        private short[,] yzprojection;
        private short[,] zxprojection;


        int size;

        public ShadowTask(short[,,] figure)
        {
            size = figure.GetLength(0);

            matrix = new short[size, size, size];

            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    for (int z = 0; z < size; z++)
                    {
                        matrix[x, y, z] = figure[x, y, z];
                    }
                }
            }
        }

        private void FindXYProjection() 
        {
            xyprojection = new short[size, size];

            bool shadow = false;
            
            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    for (int z = 0; z < size; z++)
                    {
                        if (matrix[x, y, z] == 1) 
                        {
                            shadow = true;
                            break;
                        }
                    }
                    if (shadow == true) 
                    {
                        xyprojection[x, y] = 1;
                        shadow = false;
                    }
                }
            }
        }
        private void FindYZProjextion() 
        {
            yzprojection = new short[size, size];

            bool shadow = false;

            for (int z = 0; z < size; z++)
            {
                for (int y = 0; y < size; y++)
                {
                    for (int x = 0; x < size; x++)
                    {
                        if (matrix[x, y, z] == 1)
                        {
                            shadow = true;
                            break;
                        }
                    }
                    if (shadow == true)
                    {
                        yzprojection[z, y] = 1;
                        shadow = false;
                    }
                }
            }
        }
        private void FindZXProjextion()
        {
            zxprojection = new short[size, size];

            bool shadow = false;

            for (int x = 0; x < size; x++)
            {
                for (int z = 0; z < size; z++)
                {
                    for (int y = 0; y < size; y++)
                    {
                        if (matrix[x, y, z] == 1)
                        {
                            shadow = true;
                            break;
                        }
                    }
                    if (shadow == true)
                    {
                        zxprojection[x, z] = 1;
                        shadow = false;
                    }
                }
            }
        }

        public void ReturnProjection(out short[,] xypr, out short[,] yzpr, out short[,] zxpr) 
        {
            FindXYProjection();
            FindYZProjextion();
            FindZXProjextion();
            xypr = xyprojection;
            yzpr = yzprojection;
            zxpr = zxprojection;
        }
    }
}
