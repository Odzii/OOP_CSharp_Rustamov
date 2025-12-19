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


        public static Person ReadFromConsole()
        {
            string language = String.Empty;
            Person person = new Person();
            (person.Name, language) = person.ReadValidatedWord("Введите имя: ");
            (person.Surname, _) = person.ReadValidatedWord("Введите фамилию: ", language);
            person.Age = person.ReadAge();
            person.Gender = person.ReadGender();
            Console.WriteLine("Создан экземпляр класса Person:");
            person.Print();
            return person;
        }

        /// <summary>
        /// Чтение пола при использовании ReadFromConsole.
        /// </summary>
        /// <returns></returns>
        private Gender ReadGender()
        {
            List<string> listFemale = new List<string> { "ж", "женский", "f" };
            List<string> listMale = new List<string> { "м", "мужской", "m" };

            while (true)
            {
                Console.WriteLine("Введите пол, формат входных данных:" +
                    "Male/Female или m/f, Женский/Мужской или ж/м " +
                    "без учета регистра."
                );

                var input = Console.ReadLine().ToLower();

                if (listFemale.Contains(input)) input = "Female";
                else if (listMale.Contains(input)) input = " Male";
                
                CapitalizeFirstLetter(input);

                bool flag = Enum.IsDefined(typeof(Gender), input);

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
        private int ReadAge()
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
        private (string, string) ReadValidatedWord(string message, string language = "")
        {
            while (true)
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
                            return (CapitalizeFirstLetter(input), languageDetected);
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

            string[] malesNames = ReadFile("DataRandomPerson/MalesNames.txt");
            string[] femalesNamesPerson = ReadFile("DataRandomPerson/FemalesNamesPerson.txt");
            string[] dataSurnamesPerson = ReadFile("DataRandomPerson/DataSurnamesPerson.txt");

            Gender sex = random.Next(1, 3) == 1 ? Gender.Male : Gender.Female;
            string firstName = sex == Gender.Male
                ? malesNames[random.Next(malesNames.Length)]
                : femalesNamesPerson[random.Next(femalesNamesPerson.Length)];

            string lastName = dataSurnamesPerson[random.Next(dataSurnamesPerson.Length)];
            if (sex == Gender.Female && !EndsWithRussianVowel(lastName))
            {
                lastName += "а";
            }

            int age = random.Next(minAge, maxAge + 1);
            Person person = new Person(firstName, lastName, age, sex);
            person.Print();
            return person;
        }

        private static bool EndsWithRussianVowel(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return false;
            }

            char lastChar = char.ToLower(text[text.Length - 1]);

            const string vowels = "аеёиоуыэюя";

            return vowels.IndexOf(lastChar) >= 0;
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

        private static string CapitalizeFirstLetter(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return text;
            }

            text = text.ToLower();

            if (text.Length == 1)
            {
                return text.ToUpper();
            }

            return char.ToUpper(text[0]) + text.Substring(1);
        }
    }
}
