using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace YouAreTheFather
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string mother = Console.ReadLine();
            string motherGenes = GetGenes(mother);
            string child = Console.ReadLine();
            string childGenes = GetGenes(child);
            string fatherGenesMustHave = Difference(motherGenes, childGenes);
            int numOfPossibleFathers = int.Parse(Console.ReadLine());

            for (int i = 0; i < numOfPossibleFathers; i++)
            {
                string aPossibleFather = Console.ReadLine();
                string aPossibleFatherGenes = GetGenes(aPossibleFather);
                if (IsFather(aPossibleFatherGenes, fatherGenesMustHave, childGenes))
                {
                    Console.WriteLine($"{aPossibleFather.Split(':')[0]}, you are the father!");
                }
            }
        }

        static string GetGenes(string input)
        {
            var match = Regex.Match(input, "^[^:]+:(.*)$");
            return match.Groups[1].Value.Replace(" ", "");
        }

        static string Difference(string mother, string child)
        {
            HashSet<char> mustHaveGenes = new HashSet<char>();

            for (int i = 0; i < mother.Length; i += 2)
            {
                char motherGene1 = mother[i];
                char motherGene2 = mother[i + 1];
                char childGene1 = child[i];
                char childGene2 = child[i + 1];

                if (!(motherGene1 == childGene1 || motherGene2 == childGene1))
                {
                    mustHaveGenes.Add(childGene1);
                }
                if (!(motherGene1 == childGene2 || motherGene2 == childGene2))
                {
                    mustHaveGenes.Add(childGene2);
                }
            }

            return new string(mustHaveGenes.ToArray());
        }

        static bool IsFather(string fatherGenes, string mustHaveGenes, string childGenes)
        {
            HashSet<char> mustHaveGenesSet = new HashSet<char>(mustHaveGenes);

            for (int i = 0; i < childGenes.Length; i += 2)
            {
                char childGene1 = childGenes[i];
                char childGene2 = childGenes[i + 1];

                if (!(fatherGenes[i] == childGene1 || fatherGenes[i + 1] == childGene1 ||
                      fatherGenes[i] == childGene2 || fatherGenes[i + 1] == childGene2))
                {
                    return false;
                }
            }

            foreach (char gene in mustHaveGenesSet)
            {
                if (!fatherGenes.Contains(gene))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
