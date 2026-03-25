using System.Diagnostics;
using System.Globalization;

using Model;

namespace ConsoleLoader
{
    /// <summary>
    /// Точка входа в программу, 
    /// которая служит для загрузки и демонстрации функциональности классов,
    /// </summary>
    /// </remarks>В данном случае, 
    /// это может включать создание экземпляров классов, 
    /// а также вызов их методов для отображения информации 
    /// о типах фигур и их объёмах. </remarks> 
    internal class Program
    {
        private static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    IVolumeFigure figure = CreateFigure();

                    Console.WriteLine();
                    Console.WriteLine($"Тип фигуры: {figure.FigureType}\n");
                    Console.WriteLine($"Объём: {figure.Volume:G}\n");
                    Console.WriteLine(figure.GetDescription());
                    Console.WriteLine();

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Создаёт экземпляр класса, реализующего интерфейс IVolumeFigure,
        /// </summary>
        /// <returns>Экземпляр класса</returns>
        private static IVolumeFigure CreateFigure()
        {
            Console.WriteLine("Выберите фигуру:");
            Console.WriteLine("1 - Сфера");
            Console.WriteLine("2 - Пирамида");
            Console.WriteLine("3 - Параллелепипед");
            Console.WriteLine("0 - Выход");

            int choice;

            while (true)
            {
                string? input = Console.ReadLine();

                if (int.TryParse(input, out int value)
                    && value >= 0 && value <= 3)
                {
                    choice = value;

                    if (choice <= 3 && choice >= 0)
                    {
                        break;
                    }
                }

                Console.WriteLine("Пожалуйста, введите корректный выбор.");
            }

            switch (choice)
            {
                //TODO: {} +
                case 1:
                    {
                        double radius = ReadPositiveDouble("Введите радиус: ");
                        return new Sphere(radius);
                    }

                case 2:
                    {
                        double baseLength = ReadPositiveDouble(
                            "Введите длину основания: ");

                        double baseWidth = ReadPositiveDouble(
                            "Введите ширину основания: ");

                        double pyramidHeight = ReadPositiveDouble(
                            "Введите высоту пирамиды: ");

                        return new Pyramid(baseLength, baseWidth, pyramidHeight);
                    }

                case 3:
                    {
                        double length = ReadPositiveDouble("Введите длину: ");

                        double width = ReadPositiveDouble("Введите ширину: ");

                        double height = ReadPositiveDouble("Введите высоту: ");

                        return new Parallelepiped(length, width, height);
                    }

                case 0:
                    {
                        Console.WriteLine("Выход из программы.");
                        Environment.Exit(0);
                        throw new UnreachableException();
                    }

                default:
                    {
                        throw new UnreachableException(
                            "Получено недопустимое значение пункта меню.");
                    }
                    //TODO: Refactor +
            }
        }

        /// <summary>
        /// Валидирует, что введённое значение является положительным числом, 
        /// а также не пустым значением, обеспечивает повторный запрос ввода, 
        /// если это не так. 
        /// </summary>
        /// <param name="prompt"></param>
        /// <returns>Возвращает введеное значение.</returns>
        /// </remarks>Введеное значение одинаково обрабатывается 
        /// с введеным разделителем "." или ",".
        /// </remarks>
        private static double ReadPositiveDouble(string prompt)
        {
            //TODO: refactor +
            while (true)
            {
                Console.Write(prompt);

                string? input = Console.ReadLine()?.Trim();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Пустой ввод. Введите число.");
                    continue;
                }

                bool parsed =
                    double.TryParse(
                        input, 
                        NumberStyles.Float, 
                        CultureInfo.CurrentCulture, 
                        out double value) 
                        || double.TryParse(
                        input, 
                        NumberStyles.Float,
                        CultureInfo.InvariantCulture, 
                        out value);

                if (!parsed)
                {
                    Console.WriteLine(
                        "Неверный формат числа. Используйте, " +
                        "например: 12,5 или 12.5");
                    continue;
                }

                if (!double.IsFinite(value))
                {
                    Console.WriteLine("Введите конечное число.");
                    continue;
                }

                if (value <= 0)
                {
                    Console.WriteLine("Введите число больше нуля.");
                    continue;
                }

                return value;
            }
        }
    }
}
