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
	
    }
}
