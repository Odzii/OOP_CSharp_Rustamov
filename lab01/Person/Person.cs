using System;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
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
            string language = String.Empty;
            (Name, language) = ReadValidatedWord("Введите имя: ");
            (Surname, language) = ReadValidatedWord("Введите фамилию: ", language);
            Age = ReadAge();
            Gender = ReadGender();
        }

        //TODO: добавить больше вариантов выбора пола
        /// <summary>
        /// Чтение пола при использовании ReadFromConsole.
        /// </summary>
        /// <returns></returns>
        private Gender ReadGender()
        {
            while (true)
            {
                Console.WriteLine("Введите пол, формат входных данных:" +
                    "Male/Female."
                );

                var input = Console.ReadLine();
                bool flag = Enum.IsDefined(typeof(Gender), input);

                //if (string.IsNullOrWhiteSpace(input))
                //{
                //    Console.WriteLine("Пол не может быть null. Повторите ввод.");
                //    continue;
                //}

                //input = input.Trim();

                //switch (input.ToLower())
                //{
                //    case "m":
                //        return Gender.Male;
                //    case "f":
                //        return Gender.Female;
                //    case "u":
                //        return Gender.Unknown;
                //}

                if (flag)
                {
                    return (Gender)Enum.Parse(typeof(Gender), input, true);
                }

                Console.WriteLine("Пол не распознан. Повторите ввод.");
            }
        }

        /// <summary>
        /// Чтение возраста при использовании ReadFromConsole.
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
        /// Проверка слова на содержание только заданных символов
        /// и преобразование слова, где первая буква верхнем регистре,
        /// а другие в нижнем регистре
        /// </summary>
        /// <param name="message"></param>Сообщение при вводе.
        /// <returns></returns>Возвращает слово 
        /// в котором первая буква в верхнем регистре, остальные в нижнем.
        private (string, string) ReadValidatedWord(string message, string language="") 
        {
            while(true)
            {
                string languageDetected = "";

                Console.Write(message);
                var input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Пустая строка. Повторите ввод.");
                    continue;
                }
                else
                {
                    if (Regex.IsMatch(input, 
                        @"^[А-Яа-яЁё]+(?:-[А-Яа-яЁё]+)?$"))
                    {
                        languageDetected = "russian";
                    }
                    else if (Regex.IsMatch(input, 
                        @"^[A-Za-z]+(?:-[A-Za-z]+)?$"))
                    {
                        languageDetected = "english";
                    }
                    else 
                    {
                        Console.WriteLine("Ввод некорректен, " +
                            "повторите попытку.");
                    }
                    if (!languageDetected.Equals(""))
                    {
                        if (language.Equals("") || languageDetected.Equals(language))
                            return (input, languageDetected);
                        else 
                        {
                            Console.WriteLine("Ввод некорректен, " +
                            "повторите попытку.");
                            languageDetected = "";
                        }
                    }
                }
            }

        }

        private static readonly Regex Ru = new(
            @"^[А-Яа-яЁё]+(?:-[А-Яа-яЁё]+)?$",
            RegexOptions.Compiled);

        private static readonly Regex En = new(
        @"^[A-Za-z]+(?:-[A-Za-z]+)?$",
        RegexOptions.Compiled);

        /// <summary>
        /// Вывод имени, фамилии, возраста и пола для объекта Person
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

        // TODO: [HIGH] добавить проверку, если слово оканчивается на гласную 
        /// <summary>
        /// Позволяет создать случайного человека
        /// </summary>
        /// <returns>Экземпляр класса Person
        /// со случайными значениями полей</returns>
        public static Person GetRandomPerson()
        {
            Random random = new Random();

            string[] MalesNames = ReadFile("DataRandomPerson/MalesNames.txt");
            string[] FemalesNamesPerson = ReadFile("DataRandomPerson/FemalesNamesPerson.txt");
            string[] DataSurnamesPerson = ReadFile("DataRandomPerson/DataSurnamesPerson.txt");

            Gender sex = random.Next(1,3) == 1 ? Gender.Male : Gender.Female;
            string firstName = sex == Gender.Male
                ? MalesNames[random.Next(MalesNames.Length)]
                : FemalesNamesPerson[random.Next(FemalesNamesPerson.Length)];

            string lastName = DataSurnamesPerson[random.Next(DataSurnamesPerson.Length)];
            if (sex == Gender.Female)
            {
                lastName += "а";
            }

            int age = random.Next(minAge, maxAge + 1);

            return new Person(firstName, lastName, age, sex);
        }

        /// <summary>
        /// Метод чтения строк в файле
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private static string[] ReadFile(string path)
        {
            if (!File.Exists(path))
                return Array.Empty<string>();

            return File.ReadAllLines(path, Encoding.UTF8)
                .Where(value => !string.IsNullOrWhiteSpace(value))
                .ToArray();
        }
    }
}
