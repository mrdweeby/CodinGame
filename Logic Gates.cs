using System;
using System.Collections.Generic;

class Solution
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int m = int.Parse(Console.ReadLine());
        Dictionary<string, string> signals = new Dictionary<string, string>();
        
        for (int i = 0; i < n; i++)
        {
            string[] inputLine = Console.ReadLine().Split(' ');
            string inputName = inputLine[0];
            string inputSignal = inputLine[1]
                .Replace('_', '0')
                .Replace('-', '1');
            signals[inputName] = inputSignal;
        }
        
        for (int i = 0; i < m; i++)
        {
            string[] operation = Console.ReadLine().Split(' ');
            string outputName = operation[0];
            string gateType = operation[1];
            string input1 = operation[2];
            string input2 = operation[3];
            string signal1 = signals[input1];
            string signal2 = signals[input2];
            string outputSignal = "";

            for (int j = 0; j < signal1.Length; j++)
            {
                char a = signal1[j];
                char b = signal2[j];
                switch (gateType)
                {
                    case "AND":
                        outputSignal += (a == '1' && b == '1') ? '1' : '0';
                        break;
                    case "OR":
                        outputSignal += (a == '1' || b == '1') ? '1' : '0';
                        break;
                    case "XOR":
                        outputSignal += (a != b) ? '1' : '0';
                        break;
                    case "NAND":
                        outputSignal += !(a == '1' && b == '1') ? '1' : '0';
                        break;
                    case "NOR":
                        outputSignal += !(a == '1' || b == '1') ? '1' : '0';
                        break;
                    case "NXOR":
                        outputSignal += (a == b) ? '1' : '0';
                        break;
                }
            }
            
            Console.WriteLine($"{outputName} {outputSignal
            .Replace('0', '_').Replace('1', '-')}");
        }
    }
}
