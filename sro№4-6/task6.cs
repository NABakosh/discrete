using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int[] truthTable = new int[4];

        Console.WriteLine("Введите значения функции (0 или 1) для комбинаций:");
        Console.Write("A=0, B=0: ");
        truthTable[0] = int.Parse(Console.ReadLine());
        Console.Write("A=0, B=1: ");
        truthTable[1] = int.Parse(Console.ReadLine());
        Console.Write("A=1, B=0: ");
        truthTable[2] = int.Parse(Console.ReadLine());
        Console.Write("A=1, B=1: ");
        truthTable[3] = int.Parse(Console.ReadLine());

        List<string> sdnfTerms = new List<string>();
        List<string> sknfTerms = new List<string>();

        int index = 0;
        for (int a = 0; a <= 1; a++)
        {
            for (int b = 0; b <= 1; b++)
            {
                int value = truthTable[index];

                if (value == 1)
                {
                    string termA = (a == 1) ? "A" : "!A";
                    string termB = (b == 1) ? "B" : "!B";
                    sdnfTerms.Add($"({termA} && {termB})");
                }
                else
                {
                    string termA = (a == 0) ? "A" : "!A";
                    string termB = (b == 0) ? "B" : "!B";
                    sknfTerms.Add($"({termA} || {termB})");
                }

                index++;
            }
        }

        string sdnf = sdnfTerms.Count > 0 ? string.Join(" || ", sdnfTerms) : "отсутствует";
        string sknf = sknfTerms.Count > 0 ? string.Join(" && ", sknfTerms) : "отсутствует";

        Console.WriteLine("\nСДНФ: " + sdnf);
        Console.WriteLine("СКНФ: " + sknf);

        string minimized = MinimizeTwoVar(truthTable);
        Console.WriteLine("Минимизированная форма: " + minimized);
    }

    static string MinimizeTwoVar(int[] table)
    {
        if (table[0] == 0 && table[1] == 0 && table[2] == 0 && table[3] == 0) return "0";
        if (table[0] == 1 && table[1] == 1 && table[2] == 1 && table[3] == 1) return "1";

        List<string> terms = new List<string>();

        if (table[2] == 1 && table[3] == 1) terms.Add("A");
        if (table[1] == 1 && table[3] == 1) terms.Add("B");
        if (table[0] == 1 && table[1] == 1) terms.Add("!A");
        if (table[0] == 1 && table[2] == 1) terms.Add("!B");

        if (terms.Count > 0)
        {
            return string.Join(" || ", terms);
        }

        List<string> minterms = new List<string>();
        if (table[0] == 1) minterms.Add("(!A && !B)");
        if (table[1] == 1) minterms.Add("(!A && B)");
        if (table[2] == 1) minterms.Add("(A && !B)");
        if (table[3] == 1) minterms.Add("(A && B)");

        return string.Join(" || ", minterms);
    }
}