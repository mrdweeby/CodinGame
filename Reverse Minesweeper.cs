using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Solution
{
    static void Main(string[] args)
    {
        int w = int.Parse(Console.ReadLine());
        int h = int.Parse(Console.ReadLine());
        char[,] grid = new char[h, w];
        for (int i = 0; i < h; i++)
        {
            string line = Console.ReadLine();
            for (int j = 0; j < w; j++)
            {
                grid[i, j] = line[j];
            }
        }

        for (int i = 0; i < h; i++)
        {
            StringBuilder sb = new StringBuilder();
            for (int j = 0; j < w; j++)
            {
                if (grid[i,j] == 'x')
                {
                    sb.Append('.');
                }
                else
                {
                    int mineCount = CountMines(grid, h, w, i, j);
                    if (mineCount == 0)
                    {
                        sb.Append('.');
                    }
                    else
                    {
                        sb.Append(mineCount);
                    }
                }
            }
            Console.WriteLine(sb.ToString());
        }
        
    }

    static int CountMines(char[,] grid, int h, int w, int i, int j)
    {
        int mineCount = 0;
        int[] directions = { -1, 0, 1 };
        foreach (var dx in directions)
        {
            foreach (var dy in directions)
            {
                if (dx == 0 && dy == 0) continue;

                int newI = i + dx;
                int newJ = j + dy;
                if (newI >= 0 && newI < h && newJ >= 0 && newJ < w)
                {
                    if (grid[newI, newJ] == 'x')
                    {
                        mineCount++;
                    }
                }
            }
        }
        return mineCount;
    }
}
