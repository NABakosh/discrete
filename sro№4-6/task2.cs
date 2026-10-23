using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.Write("Введите элементы множества A через пробел: ");
        string[] setA = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

        Console.Write("Введите элементы множества B через пробел: ");
        string[] setB = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

        // ввод функции 
        string[] f = new string[setA.Length];
        Console.WriteLine("\nЗадайте функцию f:");
        for (int i = 0; i < setA.Length; i++)
        {
            Console.Write($"f({setA[i]}) = ");
            f[i] = Console.ReadLine();
        }

        // проверка на инъективность 
        bool isInjective = true;
        for (int i = 0; i < f.Length; i++)
        {
            for (int j = i + 1; j < f.Length; j++)
            {
                if (f[i] == f[j]) isInjective = false;
            }
        }

        // проверка на сюръективность 
        bool isSurjective = true;
        foreach (var b in setB)
        {
            bool found = false;
            foreach (var val in f)
            {
                if (val == b) found = true;
            }
            if (!found) isSurjective = false;
        }

        // проверка на биективность
        bool isBijective = isInjective && isSurjective;

        Console.WriteLine($"\nИнъективная: {(isInjective ? "Да" : "Нет")}");
        Console.WriteLine($"Сюръективная: {(isSurjective ? "Да" : "Нет")}");
        Console.WriteLine($"Биективная: {(isBijective ? "Да" : "Нет")}");

        // композиция функций 
        Console.Write("\nВведите элементы множества C через пробел: ");
        string[] setC = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

        string[] g = new string[setB.Length];
        Console.WriteLine("\nЗадайте функцию g:");
        for (int i = 0; i < setB.Length; i++)
        {
            Console.Write($"g({setB[i]}) = ");
            g[i] = Console.ReadLine();
        }

        Console.WriteLine("\nКомпозиция (g ∘ f):");
        for (int i = 0; i < setA.Length; i++)
        {
            string y = f[i];
            string z = "";

            // нахождение значения g
            for (int j = 0; j < setB.Length; j++)
            {
                if (setB[j] == y) z = g[j];
            }

            Console.WriteLine($"(g ∘ f)({setA[i]}) = {z}");
        }
    }
}