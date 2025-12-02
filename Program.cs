using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введите ваше имя: ");
	var name = Console.ReadLine();
	Console.WriteLine($"Привет, {name}");
	
	Console.Write("Введите ваш возраст: ");
	var ageInput = Console.ReadLine();
	if (int.TryParse(ageInput, out int age))
            Console.WriteLine($"Тебе, {age} лет.");
	else
	    Console.WriteLine("Пожалуйста, введите целое число.");
    }
}
