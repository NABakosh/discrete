using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("Проверка эквивалентности двух выражений (операторы: &, |, ->, =, !)");
        Console.Write("Введите 1-е выражение (например: ! & A B): ");
        string expr1 = Console.ReadLine();

        Console.Write("Введите 2-е выражение (например: | ! A ! B): ");
        string expr2 = Console.ReadLine();

        bool areEquivalent = true;
        bool[] values = { false, true };

        Console.WriteLine("\nA | B | F1 | F2");
        Console.WriteLine("----------------");

        foreach (bool A in values)
        {
            foreach (bool B in values)
            {
                bool res1 = Calculate(expr1, A, B);
                bool res2 = Calculate(expr2, A, B);

                int valA = A ? 1 : 0;
                int valB = B ? 1 : 0;
                int v1 = res1 ? 1 : 0;
                int v2 = res2 ? 1 : 0;

                Console.WriteLine($"{valA} | {valB} |  {v1} |  {v2}");

                if (res1 != res2)
                {
                    areEquivalent = false;
                }
            }
        }

        Console.WriteLine("----------------");
        if (areEquivalent)
            Console.WriteLine("Вывод: Выражения ЭКВИВАЛЕНТНЫ");
        else
            Console.WriteLine("Вывод: Выражения НЕ ЭКВИВАЛЕНТНЫ");
    }

    static bool Calculate(string text, bool A, bool B)
    {
        string[] tokens = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        int index = 0;
        return Parse(tokens, ref index, A, B);
    }

    static bool Parse(string[] tokens, ref int index, bool A, bool B)
    {
        if (index >= tokens.Length) return false;

        string token = tokens[index++];

        if (token == "A") return A;
        if (token == "B") return B;

        if (token == "!")
        {
            return !Parse(tokens, ref index, A, B);
        }

        if (token.StartsWith("!") && token.Length > 1)
        {
            string varName = token.Substring(1);
            bool val = varName == "A" ? A : (varName == "B" ? B : false);
            return !val;
        }

        bool left = Parse(tokens, ref index, A, B);
        bool right = Parse(tokens, ref index, A, B);

        return token switch
        {
            "&"  => left && right,
            "|"  => left || right,
            "->" => !left || right,
            "="  => left == right,
            _    => false
        };
    }
}