using System;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace LabFirst
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
        /// Минимальный возраст
        /// </summary>
        private const int _minAge = 0;

        /// <summary>
        /// Максимальный возраст
        /// </summary>
        private const int _maxAge = 123;

        private bool _isRussian;

        /// <summary>
        /// Показывает, что имя/фамилия человека заданы на русском языке.
        /// </summary>
        public bool IsRussian => _isRussian;


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
                        nameof(value)
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
                        nameof(value)
                    );

                if (value.Any(char.IsDigit))
                    throw new ArgumentException(
                        "Фамилия не может содержать цифр.",
                        nameof(value)
                    );

                _surname = value;
            }
        }

        /// <summary>
        /// Получает или задаёт возраст человека в полных годах.
        /// </summary>
        /// <value>
        /// Допустимый диапазон: 
        /// <see cref="MinAge"/>–<see cref="MaxAge"/> (включительно).
        /// </value>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Бросается, если значение меньше <see cref="_minAge"/> 
        /// или больше <see cref="_maxAge"/>.
        /// </exception>
        public int Age
        {
            get => _age;
            set
            {
                if (value < _minAge || value > _maxAge)
                    throw new ArgumentOutOfRangeException(
                        nameof(value),
                        $"Возраст должен быть от {_minAge} до {_maxAge}."
                    );

                _age = value;
            }
        }

        /// <summary>
        /// Получает или задаёт пол человека.
        /// </summary>
        /// <value>Допустимые значения: <see cref="Gender.Male"/> 
        /// или <see cref="Gender.Female"/>.</value>
        /// <exception cref="ArgumentException">
        /// Бросается, если установлено значение <see cref="Gender.Unknown"/>.
        /// </exception>
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
        /// <param name="name">Имя</param>
        /// <param name="surname">Фамилия</param>
        /// <param name="age">Возраст</param>
        /// <param name="gender">Гендер</param>
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
        public Person()
        {
        }

        /// <summary>
        /// Считывает из консоли данные о человеке 
        /// (имя, фамилию, возраст и пол),
        /// выполняя валидацию введённых значений, 
        /// и возвращает созданный объект.
        /// </summary>
        /// <returns>Объект Person</returns>
        public static Person ReadFromConsole()
        {
            string language = String.Empty;

            Person person = new Person();

            (person.Name, language) =
                person.ReadValidatedWord("Введите имя: ");

            person._isRussian = language == "russian";

            (person.Surname, _) =
                person.ReadValidatedWord("Введите фамилию: ", language);
            person.Age =
                person.ReadAge();
            person.Gender =
                person.ReadGender();

            Console.WriteLine("Создан экземпляр класса Person:");

            person.Print();

            return person;
        }

        /// <summary>
        /// Чтение пола при использовании ReadFromConsole.
        /// </summary>
        /// <returns>Экземпляр объекта типа Person</returns>
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
                if (listMale.Contains(input)) input = "Male";

                input = CapitalizeFirstLetter(input);

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
                Console.Write($"Введите возраст ({_minAge}-{_maxAge}): ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int age)
                    && age >= _minAge && age <= _maxAge)
                {
                    return age;
                }

                Console.WriteLine("Некорректный возраст. Повторите ввод.");
            }
        }

        /// <summary>
        /// Проверяет ввод слова (рус/англ, допускается одно тире) и приводит к виду: ПерваяБукваЗаглавная.
        /// </summary>
        /// <param name="message">Сообщение, выводимое перед вводом.</param>
        /// <param name="language">
        /// Ограничение языка ("russian"/"english"). Если пусто — язык определяется по первому слову.
        /// </param>
        /// <returns>
        /// Кортеж: (нормализованное слово, определённый язык).
        /// </returns>
        private (string, string) ReadValidatedWord(
            string message,
            string language = ""
        )
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
                        if (language.Equals("")
                            || languageDetected.Equals(language))
                            return (CapitalizeFirstLetter(input),
                                languageDetected);
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
                "Имя: {0}, " +
                "Фамилия: {1}, " +
                "Возраст: {2}, " +
                "Пол: {3}",
                Name,
                Surname,
                Age,
                FormatGender(Gender, IsRussian)
            );
        }

        /// <summary>
        /// Формар вывода Gender в методе Print
        /// </summary>
        /// <param name="gender"> Гендер человека </param>
        /// <param name="isRussian"> 
        /// Булевое значение хранящее тип языка </param>
        /// <returns> Гендер в правильном формате </returns>
        private static string FormatGender(Gender gender, bool isRussian)
        {
            if (isRussian)
                return gender == Gender.Male ? "Мужской" : "Женский";

            return gender == Gender.Male ? "Male" : "Female";
        }

        /// <summary>
        /// Позволяет создать случайного человека
        /// </summary>
        /// <returns>Экземпляр класса Person
        /// со случайными значениями полей</returns>
        public static Person GetRandomPerson()
        {
            Random random = new Random();

            string[] malesNames =
                ReadFile("DataRandomPerson/MalesNames.txt");
            string[] femalesNamesPerson =
                ReadFile("DataRandomPerson/FemalesNamesPerson.txt");
            string[] dataSurnamesPerson =
                ReadFile("DataRandomPerson/DataSurnamesPerson.txt");

            Gender sex = random.Next(1, 3) == 1 ? Gender.Male : Gender.Female;
            string firstName = sex == Gender.Male
                ? malesNames[random.Next(malesNames.Length)]
                : femalesNamesPerson[random.Next(femalesNamesPerson.Length)];

            string lastName =
                dataSurnamesPerson[random.Next(dataSurnamesPerson.Length)];
            if (sex == Gender.Female && !EndsWithRussianVowel(lastName))
            {
                lastName += "а";
            }

            int age = random.Next(_minAge, _maxAge + 1);
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
        /// <param name="path"> Путь к файлу </param>
        /// <returns> Процесс с открытым файлом </returns>
        private static string[] ReadFile(string path)
        {
            if (!File.Exists(path))
                return Array.Empty<string>();

            return File.ReadAllLines(path, Encoding.UTF8)
                .Where(value => !string.IsNullOrWhiteSpace(value))
                .ToArray();
        }

        // TODO выполнен: корректная капитализация составных слов через дефис
        /// <summary>
        /// В верхний регистр первый символ, а также символ после разделителя
        /// "-" в верхний регистр. 
        /// </summary>
        /// <param name="text">Слово</param>
        /// <returns> Слово в правильном регистре </returns>
        private static string CapitalizeFirstLetter(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return text;
            }

            text = text.Trim();

            string[] parts = text.Split('-', 
                StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < parts.Length; i++)
            {
                parts[i] = CapitalizeSingleWord(parts[i]);
            }

            return string.Join("-", parts);
        }

        /// <summary>
        /// Первый симвом в верхний регистр, остальные в нижний
        /// </summary>
        /// <param name="word"> Слово для проверки </param>
        /// <returns> Слово в правильном регистре </returns>
        private static string CapitalizeSingleWord(string word)
        {
            if (string.IsNullOrWhiteSpace(word))
            {
                return word;
            }

            word = word.ToLower();

            if (word.Length == 1)
            {
                return word.ToUpper();
            }

            return char.ToUpper(word[0]) + word.Substring(1);
        }
    }
}
