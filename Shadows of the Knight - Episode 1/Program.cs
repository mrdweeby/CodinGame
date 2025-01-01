using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

class Player
{
    static void Main(string[] args)
    {
        string[] inputs;
        inputs = Console.ReadLine().Split(' ');
        int W = int.Parse(inputs[0]);
        int H = int.Parse(inputs[1]);
        int N = int.Parse(Console.ReadLine());
        inputs = Console.ReadLine().Split(' ');
        int X0 = int.Parse(inputs[0]);
        int Y0 = int.Parse(inputs[1]);

        int minX = 0;
        int minY = 0;
        int maxX = W - 1;
        int maxY = H - 1;

        while (true)
        {
            string bombDir = Console.ReadLine();
            if (bombDir.Contains("U"))
            {
                maxY = Y0 - 1;
            }
            if (bombDir.Contains("D"))
            {
                minY = Y0 + 1;
            }
            if (bombDir.Contains("L"))
            {
                maxX = X0 - 1;
            }
            if (bombDir.Contains("R"))
            {
                minX = X0 + 1;
            }
            X0 = minX + (maxX - minX) / 2;
            Y0 = minY + (maxY - minY) / 2;
            Console.WriteLine($"{X0} {Y0}");
        }
    }
}
