using System;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
namespace Lab01
{
    /// <summary>
    /// <see cref="Person"/>
    /// Представляет человека с именем и фамилией, возрастом и 
    /// половой принадлежностью.
    /// </summary>

    public class Person
    {
        /// <summary>
        /// Имя
        /// </summary>
        private string _name;

        /// <summary>
        /// Фамилия
        /// </summary>
        private string _surname;

        /// <summary>
        /// Возраст человека
        /// </summary>
        private int _age;

        /// <summary>
        /// Пол
        /// </summary>
        private Gender _gender;

        /// <summary>
        /// 
        /// </summary>
        private const int minAge = 0;

        /// <summary>
        /// 
        /// </summary>
        private const int maxAge = 123;

        /// <summary>
        /// Получает или задает имя человека
        /// </summary>
        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(
                        "Имя не может быть пустым, " +
                        "содержать только пробелы или быть null.",
                        nameof(value)
                    );

                if (value.Any(char.IsDigit))
                    throw new ArgumentException(
                        "Имя не может содержать цифр.",
                        nameof(Name)
                    );

                _name = value;
            }
        }

        /// <summary>
        /// Получает или задает фамилию человека
        /// </summary>
        public string Surname
        {
            get { return _surname; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException(
                        "Фамилия не может быть пустой или Null.",
                        nameof(Surname)
                    );

                if (value.Any(char.IsDigit))
                    throw new ArgumentException(
                        "Фамилия не может содержать цифр.",
                        nameof(Surname)
                    );

                _surname = value;
            }
        }

        /// <summary>
        /// Получает или задает возраст человека в полных годах.
        /// Значение ограничивается диапазоном от 0 до 150 включительно.
        /// </summary>
        public int Age
        {
            get => _age;
            set
            {
                if (value < minAge || value > maxAge)
                    throw new ArgumentOutOfRangeException(
                        nameof(Age),
                        $"Возраст должен быть от {minAge} до {maxAge}."
                    );

                _age = value;
            }
        }

        /// <summary>
        /// Получить или и проверить гендер человека.
        /// </summary>
        public Gender Gender
        {
            get => _gender;
            set
            {
                if (value == Gender.Unknown)
                    throw new ArgumentException(
                        "Пол должен быть явно указан Male или Female.",
                        nameof(value)
                    );
                _gender = value;
            }
        }

        /// <summary>
        /// Инициализация нового экземпляра класс <see cref="Person"/>
        /// </summary>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <param name="age"></param>
        /// <param name="gender"></param>
        public Person(string name, string surname, int age, Gender gender)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Gender = gender;
        }

        /// <summary>
        /// Создает пустой экземпляр класса.
        /// </summary>
        public Person() { }

        public void ReadFromConsole()
        {
            Console.Write("Введите имя: ");
            Name = Console.ReadLine();

            Console.Write("Введите фамилию: ");
            Surname = Console.ReadLine();

            Age = ReadAge();

            Gender = ReadGender();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private Gender ReadGender()
        {
            while (true)
            {
                Console.WriteLine("Введите пол, формат входных данных:" +
                    "m/f или Male/Female."
                );

                var input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Пол не распознан. Повторите ввод.");
                    continue;
                }

                input = input.Trim();

                switch (input.ToLower())
                {
                    case "m":
                        return Gender.Male;
                    case "f":
                        return Gender.Female;
                    case "u":
                        return Gender.Unknown;
                }

                if (Enum.TryParse(input, true, out Gender gender))
                {
                    return gender;
                }

                Console.WriteLine("Пол не распознан. Повторите ввод.");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static int ReadAge()
        {
            while (true)
            {
                Console.Write($"Введите возраст ({minAge}-{maxAge}): ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int age) && age >= minAge && age <= maxAge)
                {
                    return age;
                }

                Console.WriteLine("Некорректный возраст. Повторите ввод.");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Print()
        {
            Console.WriteLine(
                "Имя: {0}, Фамилия: {1}, Возраст: {2}, Пол: {3}",
                Name,
                Surname,
                Age,
                Gender
            );
        }
    }
}
