using System;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Write("Введите ваше имя (или для любителей Vi :q / пусто для выхода): ");
            var name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name) ||
                string.Equals(name, ":q", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Выход из программы...");
                break;
            }

            Console.Write("Сколько раз поприветствовать вас? ");
            string countInput = Console.ReadLine();

            if (!int.TryParse(countInput, out int count) || count <= 0)
            {
                Console.WriteLine("Введено некорректное число. Буду приветствовать один раз.");
                count = 1;
            }

            for (int i = 1; i <= count; i++)
            {
                Console.WriteLine($"Привет, {name}!");
            }
            Console.WriteLine($"Привет, {name}!");

            Console.Write("Введите ваш возраст: ");
            var ageInput = Console.ReadLine();
            if (int.TryParse(ageInput, out int age))
            {
                Console.WriteLine($"Тебе, {age} лет.");
                if (age < 18) Console.WriteLine("РКН не одобряет");
                else if (age >= 18 && age <= 121) Console.WriteLine("РКН одобряет.");
                else
                {
                    Console.WriteLine("Доступ в интернет ограничен, нельзя обманывать РКН.");
                    break;
                }     
            }
            else
            {
                Console.WriteLine("Пожалуйста, введите целое число.");
            }

            Console.WriteLine(); // пустая строка между циклами
        }

        Console.WriteLine("Программа завершена.");
    }
    static string GetAgeCategory(int age)
    {
        if (age < 7)
            return "дошкольник";
        if (age < 18)
            return "школьник";
        if (age < 60)
            return "взрослый";
        return "пенсионер";
    }
}
