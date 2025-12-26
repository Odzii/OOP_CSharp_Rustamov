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

        /// <summary>
        /// Логическая переменная для определения языка
        /// </summary>
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
                {
                    throw new ArgumentException(
                        "Имя не может быть пустым, " +
                        "содержать только пробелы или быть null.",
                        nameof(value)
                    );
                }

                if (value.Any(char.IsDigit))
                {
                    throw new ArgumentException(
                        "Имя не может содержать цифр.",
                        nameof(value)
                    );
                }

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
                {
                    throw new ArgumentException(
                        "Фамилия не может быть пустой или Null.",
                        nameof(value)
                    );
                }

                if (value.Any(char.IsDigit))
                {
                    throw new ArgumentException(
                        "Фамилия не может содержать цифр.",
                        nameof(value)
                    );
                }

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
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(value),
                        $"Возраст должен быть от {_minAge} до {_maxAge}."
                    );
                }

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
                {
                    throw new ArgumentException(
                        "Пол должен быть явно указан Male или Female.",
                        nameof(value)
                    );
                }

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
            Person person = new Person();

            Language language;

            (person.Name, language) =
                person.ReadValidatedWord("Введите имя: ", Language.Null);

            person._isRussian = language == Language.Russian;

            (person.Surname, _) =
                person.ReadValidatedWord("Введите фамилию: ", language);

            person.Age =
                person.ReadAge();
            person.Gender =
                person.ReadGender();

            Console.WriteLine("Создан экземпляр класса Person:");

            return person;
        }

        /// <summary>
        /// Чтение пола при использовании ReadFromConsole.
        /// </summary>
        /// <returns>Экземпляр объекта типа Person</returns>
        private Gender ReadGender()
        {
            List<string> femaleTokens =
                new List<string> { "ж", "женский", "f" };
            List<string> maleTokens =
                new List<string> { "м", "мужской", "m" };

            while (true)
            {
                Console.WriteLine("Введите пол, формат входных данных:" +
                    "Male/Female или m/f, Женский/Мужской или ж/м " +
                    "без учета регистра."
                );

                var input = Console.ReadLine().ToLower();

                if (femaleTokens.Contains(input))
                {
                    input = "Female";
                }

                if (maleTokens.Contains(input))
                {
                    input = "Male";
                }

                input = CapitalizeFirstLetter(input);

                bool isGenderDefined = Enum.IsDefined(typeof(Gender), input);

                if (isGenderDefined)
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
        /// Проверяет ввод слова (рус/англ, допускается одно тире) и приводит 
        /// к виду: ПерваяБукваЗаглавная.
        /// </summary>
        /// <param name="message">Сообщение, выводимое перед вводом.</param>
        /// <param name="language">
        /// Ограничение языка ("russian"/"english"). Если пусто — 
        /// язык определяется по первому слову.
        /// </param>
        /// <returns>
        /// Кортеж: (нормализованное слово, определённый язык).
        /// </returns>
        private (string Word, Language Language) ReadValidatedWord(
            string message,
            Language language = Language.Null
        )
        {
            while (true)
            {
                Console.Write(message);
                string input = (Console.ReadLine() ?? string.Empty).Trim();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Ввод некорректен. Пустая строка.");
                    continue;
                }

                bool isRussian = RussianWordRegex.IsMatch(input);
                bool isEnglish = EnglishWordRegex.IsMatch(input);

                if (language == Language.Null)
                {
                    if (isRussian)
                    {
                        return (CapitalizeFirstLetter(input), Language.Russian);
                    }

                    if (isEnglish)
                    {
                        return (CapitalizeFirstLetter(input), Language.English);
                    }

                    Console.WriteLine("Ввод некорректен. " +
                        "Допустимы только русские или английские буквы (и одно тире).");
                    continue;
                }

                if (language == Language.Russian && isRussian)
                {
                    return (CapitalizeFirstLetter(input), Language.Russian);
                }

                if (language == Language.English && isEnglish)
                {
                    return (CapitalizeFirstLetter(input), Language.English);
                }

                Console.WriteLine("Ввод некорректен. " +
                    "Язык фамилии должен совпадать с языком имени.");
            }
        }

        /// <summary>
        /// Русские символы
        /// </summary>
        private static readonly Regex RussianWordRegex =
            new(@"^[А-Яа-яЁё]+(-[А-Яа-яЁё]+)?$", RegexOptions.Compiled);

        /// <summary>
        /// Английские буквы
        /// </summary>
        private static readonly Regex EnglishWordRegex =
            new(@"^[A-Za-z]+(-[A-Za-z]+)?$", RegexOptions.Compiled);


        /// <summary>
        /// Формар вывода Gender в методе Print
        /// </summary>
        /// <param name="gender"> Гендер человека </param>
        /// <param name="isRussian"> 
        /// Булевое значение хранящее тип языка </param>
        /// <returns> Гендер в правильном формате </returns>
        private static string FormatGender(Gender gender, bool isRussian)
        {
            return isRussian
                ? gender == Gender.Male
                    ? "Мужской"
                    : "Женский"
                : gender == Gender.Male
                    ? "Male"
                    : "Female";
        }

        /// <summary>
        /// Инициализация объекта Random
        /// </summary>
        private static readonly Random _random = new Random();

        /// <summary>
        /// Создание случайного объекта Person
        /// </summary>
        /// <returns>Экземпляр класса Person</returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static Person GetRandomPerson()
        {
            string[] malesNames =
                PersonDataReader.ReadNames("DataRandomPerson/MalesNames.txt");

            string[] femalesNamesPerson =
                PersonDataReader.ReadNames("DataRandomPerson/FemalesNamesPerson.txt");

            string[] dataSurnamesPerson =
                PersonDataReader.ReadNames("DataRandomPerson/DataSurnamesPerson.txt");

            if (malesNames.Length == 0
                || femalesNamesPerson.Length == 0
                || dataSurnamesPerson.Length == 0)
            {
                throw new InvalidOperationException(
                    "Файлы с именами/фамилиями пустые или не найдены."
                );
            }

            Gender sex = _random.Next(0, 2) == 0 ? Gender.Male : Gender.Female;

            string firstName = sex == Gender.Male
                ? malesNames[_random.Next(malesNames.Length)]
                : femalesNamesPerson[_random.Next(femalesNamesPerson.Length)];

            string lastName = dataSurnamesPerson[_random.Next(dataSurnamesPerson.Length)];

            if (sex == Gender.Female && !EndsWithRussianVowel(lastName))
            {
                lastName += "а";
            }

            int age = _random.Next(_minAge, _maxAge + 1);

            return new Person(firstName, lastName, age, sex);
        }

        /// <summary>
        /// Проверяет, оканчивается ли строка русской гласной буквой.
        /// </summary>
        /// <param name="text">Проверяемая строка.</param>
        /// <returns>
        /// <c>true</c>, если строка не пустая и её последний символ — русская гласная буква; иначе <c>false</c>.
        /// </returns>
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
