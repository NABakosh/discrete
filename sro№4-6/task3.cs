using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите элементы множества A через пробел: ");
        string[] setA = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        int n = setA.Length;

        int[,] matrix = new int[n, n];
        Console.WriteLine($"\nВведите матрицу {n}x{n} по строкам (0 или 1 через пробел):");

        for (int i = 0; i < n; i++)
        {
            Console.Write($"Строка {i + 1} ({setA[i]}): ");
            string[] row = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            for (int j = 0; j < n; j++)
            {
                matrix[i, j] = int.Parse(row[j]);
            }
        }

        // проверка на рефлексивность 
        bool isReflexive = true;
        for (int i = 0; i < n; i++)
        {
            if (matrix[i, i] != 1) isReflexive = false;
        }

        // проверка на симметричность
        bool isSymmetric = true;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (matrix[i, j] != matrix[j, i]) isSymmetric = false;
            }
        }

        // проверка на антисимметричность 
        bool isAntisymmetric = true;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (i != j && matrix[i, j] == 1 && matrix[j, i] == 1) isAntisymmetric = false;
            }
        }

        // проверка на транзитивность 
        bool isTransitive = true;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                for (int k = 0; k < n; k++)
                {
                    if (matrix[i, j] == 1 && matrix[j, k] == 1 && matrix[i, k] != 1)
                    {
                        isTransitive = false;
                    }
                }
            }
        }

        Console.WriteLine($"\nРефлексивность: {(isReflexive ? "Да" : "Нет")}");
        Console.WriteLine($"Симметричность: {(isSymmetric ? "Да" : "Нет")}");
        Console.WriteLine($"Антисимметричность: {(isAntisymmetric ? "Да" : "Нет")}");
        Console.WriteLine($"Транзитивность: {(isTransitive ? "Да" : "Нет")}");
    }
}