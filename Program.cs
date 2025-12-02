using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введите ваше имя: ");
	var name = Console.ReadLine();
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
	Console.WriteLine($"Привет, {name}");
	
	Console.Write("Введите ваш возраст: ");
	var ageInput = Console.ReadLine();
	if (int.TryParse(ageInput, out int age))
	{
            Console.WriteLine($"Тебе, {age} лет.");
	    if (age < 18) Console.WriteLine("РКН не одобряет");	
	    else Console.WriteLine("РКН одобряет.");
	}
	else
	    Console.WriteLine("Пожалуйста, введите целое число.");

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
}
