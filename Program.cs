using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введите ваше имя: ");
	var name = Console.ReadLine();
	Console.WriteLine($"Привет, {name}");
    }
}
