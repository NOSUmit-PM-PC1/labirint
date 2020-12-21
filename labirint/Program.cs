using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace labirint
{
    class Program
    { 
        static string[] readLabirint(string fileName)
        {
            StreamReader sr = new StreamReader(fileName);
            string[] temp = sr.ReadLine().Split();
            int n = Convert.ToInt32(temp[0]) + 2;
            int m = Convert.ToInt32(temp[1]) + 2;
            string[] labirint = new string[n];
            string s = "";
            for (int i = 0; i < m; i++)
            {
                s += "1";
            }
            labirint[0] = s;
            labirint[n - 1] = s;
            for (int i = 1; i < n - 1; i++)
            {
                labirint[i] = "1"+sr.ReadLine()+"1";
            }
            sr.Close();

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(labirint[i]);
            }
            return labirint;
        }

        static bool checkCell(int[,] map, int i, int j, string[] mas, int di, int dj, bool change)
        {
            if (mas[di][dj] == '.' && map[di, dj] == 0)
            {
                map[di, dj] = map[i, j] + 1;
                return true;
            }
            return change;
        }

        static int waveAlgorithm(string[] mas)
        {
            int n = mas.Length;
            int m = mas[0].Length;
            int[,] map = new int[mas.Length, mas[0].Length];
            map[1, 1] = 1;
            bool change = true;
            int k = 1;
            while (change)
            {
                change = false;
                for (int i = 1; i < n - 1; i++)
                {
                    for (int j = 1; j < m - 1; j++)
                    {
                        if (map[i, j] == k)
                        {
                            // up
                            change = checkCell(map, i, j, mas, i - 1, j, change);
                            //down
                            change = checkCell(map, i, j, mas, i + 1, j, change);
                            //left
                            change = checkCell(map, i, j, mas, i, j - 1, change);
                            //right
                            change = checkCell(map, i, j, mas, i, j + 1, change);
                        }
                    }
                }
                k++;
            }
            writeMatr(map);
            return k - 1;
        }

        static void writeMatr(int[,] matr)
        {
            for (int i = 0; i < matr.GetLength(0); i++)
            {
                for (int j = 0; j < matr.GetLength(1); j++)
                {
                    Console.Write(matr[i, j]);
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            string[] map = readLabirint("labirint4_4.txt");
            Console.WriteLine(waveAlgorithm(map));
        }
    }
}
