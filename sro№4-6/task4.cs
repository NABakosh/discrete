using System;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("ПОСТРОЕНИЕ ТАБЛИЦЫ ИСТИННОСТИ");
        Console.WriteLine("Введите формулу с переменными A и B (Операторы перед переменными):");
        Console.WriteLine("  &  - Конъюнкция (И)      ->  Пример: & A B");
        Console.WriteLine("  |  - Дизъюнкция (ИЛИ)   ->  Пример: | A B");
        Console.WriteLine("  -> - Импликация         ->  Пример: -> A B");
        Console.WriteLine("  =  - Эквивалентность    ->  Пример: = A B");
        Console.WriteLine("  !  - Отрицание (НЕ)     ->  Пример: ! A\n");

        Console.Write("Введите выражение: ");
        string input = Console.ReadLine();

        Console.WriteLine("\nТаблица истинности:");
        Console.WriteLine("-------------------");
        Console.WriteLine(" A | B | Результат ");
        Console.WriteLine("-------------------");

        int trueCount = 0;
        bool[] values = { false, true };

        foreach (bool A in values)
        {
            foreach (bool B in values)
            {

                bool result = Calculate(input, A, B);

                if (result) trueCount++;

                int valA = A ? 1 : 0;
                int valB = B ? 1 : 0;
                int valRes = result ? 1 : 0;

                Console.WriteLine($" {valA} | {valB} |     {valRes}     ");
            }
        }

        Console.WriteLine("-------------------");

        if (trueCount == 4)
            Console.WriteLine("\nВывод: ТАВТОЛОГИЯ (все результаты = 1)");
        else if (trueCount == 0)
            Console.WriteLine("\nВывод: ПРОТИВОРЕЧИЕ (все результаты = 0)");
        else
            Console.WriteLine($"\nВывод: ВЫПОЛНИМАЯ ФОРМУЛА (истинна в {trueCount} из 4 случаев)");
    }

    static bool Calculate(string text, bool A, bool B)
    {
        text = text.Trim();

        if (text == "A") return A;
        if (text == "B") return B;

        if (text.StartsWith("!"))
        {
            string part = text.Substring(1).Trim();
            return !Calculate(part, A, B);
        }

        string[] parts = text.Split(' ', 3);
        if (parts.Length < 3) return false;

        string op = parts[0];
        bool left = Calculate(parts[1], A, B);
        bool right = Calculate(parts[2], A, B);

        return op switch
        {
            "&"  => left && right,   
            "|"  => left || right,  
            "->" => !left || right,  
            "="  => left == right,   
            _    => false
        };
    }
}