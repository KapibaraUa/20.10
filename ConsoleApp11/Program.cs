using System;

namespace HomeworkOperators;

internal class Program
{
    static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("=== Завдання 1: Співробітник ===");
            Employee emp1 = new Employee("Іван Петренко", "Розробник", 15000);
            Employee emp2 = new Employee("Олена Коваленко", "Тестувальник", 12000);

            Console.WriteLine(emp1);
            Console.WriteLine(emp2);

            emp1 = emp1 + 2000;
            Console.WriteLine("Після +2000: " + emp1);

            emp2 = emp2 - 1000;
            Console.WriteLine("Після -1000: " + emp2);

            emp1++;
            Console.WriteLine("Після ++: " + emp1);

            Employee intern = new Employee("Максим", "Стажер", 300);
            intern--;
            Console.WriteLine("Стажер після -- (не в мінус): " + intern);

            Console.WriteLine($"emp1 > emp2: {emp1 > emp2}");
            Console.WriteLine($"emp1 < emp2: {emp1 < emp2}");
            Console.WriteLine($"emp1 == emp2: {emp1 == emp2}");
            Console.WriteLine($"emp1 != emp2: {emp1 != emp2}");
            Console.WriteLine($"emp1.Equals(emp2): {emp1.Equals(emp2)}");

            Console.WriteLine("\n=== Завдання 2: Матриця ===");
            Matrix m1 = new Matrix(2, 2);
            m1[0, 0] = 1;
            m1[0, 1] = 2;
            m1[1, 0] = 3;
            m1[1, 1] = 4;

            Matrix m2 = new Matrix(2, 2);
            m2[0, 0] = 5;
            m2[0, 1] = 6;
            m2[1, 0] = 7;
            m2[1, 1] = 8;

            Console.WriteLine("Матриця 1:\n" + m1);
            Console.WriteLine("Матриця 2:\n" + m2);

            Console.WriteLine("m1 + m2:\n" + (m1 + m2));
            Console.WriteLine("m2 - m1:\n" + (m2 - m1));
            Console.WriteLine("m1 * 3:\n" + (m1 * 3));
            Console.WriteLine("m1 * m2:\n" + (m1 * m2));

            Console.WriteLine($"m1 == m2: {m1 == m2}");
            Console.WriteLine($"m1 != m2: {m1 != m2}");
            Console.WriteLine($"m1.Equals(m2): {m1.Equals(m2)}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Помилка: " + ex.Message);
        }
    }
}