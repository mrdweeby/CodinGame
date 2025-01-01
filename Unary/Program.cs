using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unary_Puzzle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string MESSAGE = Console.ReadLine();
            int ascii = 0;
            string binary = "";
            foreach (char c in MESSAGE)
            {
                ascii = System.Convert.ToInt32(c);
                string binaryOfDec = Convert.ToString(ascii, 2);
                string decToBinary = "";
                for (int i = 0; i < 7 - binaryOfDec.Length; i++)
                {
                    decToBinary += "0";
                }
                decToBinary += binaryOfDec;
                binary += decToBinary;
            }
            string unary = "";
            char currentChar = binary[0];
            int count = 0;

            for (int i = 0; i < binary.Length; i++)
            {
                if (binary[i] == currentChar)
                {
                    count++;
                }
                else
                {
                    unary += (currentChar == '1' ? "0 " : "00 ") + new string('0', count) + " ";
                    currentChar = binary[i];
                    count = 1;
                }
            }
            unary += (currentChar == '1' ? "0 " : "00 ") + new string('0', count);
            unary = unary.Trim();

            Console.WriteLine(unary);
        }
    }
}
