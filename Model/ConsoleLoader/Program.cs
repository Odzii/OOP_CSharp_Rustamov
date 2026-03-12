using Model;


namespace ConsoleLoader
{
    /// <summary>
    /// Точка входу в программу, 
    /// которая служит для загрузки и демонстрации функциональности классов,
    /// </summary>
    /// </remarks>В данном случае, 
    /// это может включать создание экземпляров классов, 
    /// а также вызов их методов для отображения информации 
    /// о типах фигур и их объёмах. </remarks> 
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    IVolumeFigure figure = CreateFigure();

                    Console.WriteLine();
                    Console.WriteLine($"Тип фигуры: {figure.FigureType}\n");
                    Console.WriteLine($"Объём: {figure.Volume:F2}\n");
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
        static IVolumeFigure CreateFigure()
        {
            Console.WriteLine("Выберите фигуру:");
            Console.WriteLine("1 - Сфера");
            Console.WriteLine("2 - Пирамида");
            Console.WriteLine("3 - Параллелепипед");
            Console.WriteLine("0 - Выход");

            string? choice = Console.ReadLine();

            switch (choice)
            {
                //TODO: {}
                case "1":
                    double radius = ReadPositiveDouble("Введите радиус: ");
                    return new Sphere(radius);

                case "2":
                    double baseLength = ReadPositiveDouble(
                        "Введите длину основания: ");

                    double baseWidth = ReadPositiveDouble(
                        "Введите ширину основания: ");

                    double pyramidHeight = ReadPositiveDouble(
                        "Введите высоту пирамиды: ");

                    return new Pyramid(baseLength, baseWidth, pyramidHeight);

                case "3":
                    double length = ReadPositiveDouble("Введите длину: ");

                    double width = ReadPositiveDouble("Введите ширину: ");

                    double height = ReadPositiveDouble("Введите высоту: ");

                    return new Parallelepiped(length, width, height);

                case "0":
                    Console.WriteLine("Выход из программы.");

                    Environment.Exit(0);

                    return null;

                default:
                    Console.WriteLine("Неверный выбор. Попробуйте снова.");
                    //TODO: refactor
                    return CreateFigure();
            }
        }

        /// <summary>
        /// Валидирует, что введённое значение является положительным числом, 
        /// а также обеспечивает повторный запрос ввода, если это не так.
        /// </summary>
        /// <param name="prompt"></param>
        /// <returns></returns>
        static double ReadPositiveDouble(string prompt)
        {
            //TODO: refactor
            double value;
            do
            {
                Console.Write(prompt);

                string? input = Console.ReadLine();

                if (double.TryParse(input, out value) && value > 0)
                {
                    return value;
                }
                else
                {
                    Console.WriteLine("Пожалуйста, введите положительное число.");
                }
            } while (true);
        }
    }
}
