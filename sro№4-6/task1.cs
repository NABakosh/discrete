using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите элементы множества A через пробел:");
        string inputA = Console.ReadLine();
        Console.WriteLine("Введите элементы множества B через пробел:");
        string inputB = Console.ReadLine();

        HashSet<double> setA = inputA.Split(' ', StringSplitOptions.RemoveEmptyEntries)
        .Select(double.Parse)
        .ToHashSet();

        HashSet<double> setB = inputB.Split(' ', StringSplitOptions.RemoveEmptyEntries)
        .Select(double.Parse) 
        .ToHashSet();

        Console.WriteLine("\nИсходные множества: ");
        Console.WriteLine($"Множество A: {{ {string.Join(", ", setA)} }} ");
        Console.WriteLine($"Множество B: {{ {string.Join(", ", setB)} }} ");

        Console.WriteLine($"\nМощность A = {setA.Count}");
        Console.WriteLine($"Мощность B = {setB.Count}");

        var union = new HashSet<double>(setA);
        union.UnionWith(setB);
        var intersection = new HashSet<double>(setA);
        intersection.IntersectWith(setB);
        var diffAB = new HashSet<double>(setA);
        diffAB.ExceptWith(setB);
        var diffBA = new HashSet<double>(setB);
        diffBA.ExceptWith(setA);
        var diffSym = new HashSet<double>(setA);
        diffSym.SymmetricExceptWith(setB);

        Console.WriteLine($"Объединение А и В: {{ {string.Join(", ", union)} }} ");
        Console.WriteLine($"Пересечение А и В: {{ {string.Join(", ", intersection)} }} ");
        Console.WriteLine($"Разность A - B: {{ {string.Join(", ", diffAB)} }} ");
        Console.WriteLine($"Разность B - A: {{ {string.Join(", ", diffBA)} }} ");
        Console.WriteLine($"Симметрическая разность А и В: {{ {string.Join(", ", diffSym)} }} ");
   
        var dec = new List<string>();
        foreach (var x in setA)
        {
            foreach (var y in setB)
            {
                dec.Add($"({x}, {y})");
            }
        }
        Console.WriteLine($"Декартово произведение А и В: [мощность: {dec.Count}]:");
        Console.WriteLine($"{{ {string.Join(", ", dec)} }} ");
        }
    }
