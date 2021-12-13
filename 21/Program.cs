using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _21
{
    class Program
    {
        private static int[,] garden;
        private static int length;
        private static int width;

        static void Main()
        {
            length = Convert.ToInt32(Console.ReadLine());
            width = Convert.ToInt32(Console.ReadLine());
            garden = new int[width, length];
            ThreadStart threadStart = new ThreadStart(Gardener2);
            Thread tread = new Thread(threadStart);
            tread.Start();
            Gardener1();           
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    Console.Write(garden[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
        private static void Gardener1()
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (garden[i, j] == 0)
                        garden[i, j] = 1;
                    Thread.Sleep(1);
                }
            }
        }
        private static void Gardener2()
        {
            for (int i = length - 1; i > 0; i--)
            {
                for (int j = width - 1; j > 0; j--)
                {
                    if (garden[j, i] == 0)
                        garden[j, i] = 2;
                    Thread.Sleep(1);
                }
            }
        }
    }
}
