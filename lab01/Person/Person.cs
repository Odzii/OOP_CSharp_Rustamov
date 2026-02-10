using LabFirst.Helpers;
using System;
using System.Text;
using System.Text.RegularExpressions;

namespace LabFirst
{
    /// <summary>
    /// <see cref="Person"/>
    /// Представляет человека с именем и фамилией, возрастом и полом.
    /// </summary>

    public class Person
    {
        /// <summary>
        /// Имя
        /// </summary>
        private string _name = string.Empty;

        /// <summary>
        /// Фамилия
        /// </summary>
        private string _surname = string.Empty;

        /// <summary>
        /// Пол
        /// </summary>
        private Gender _gender = Gender.Unknown;

        /// <summary>
        /// Возраст человека
        /// </summary>
        private int _age;

        /// <summary>
        /// Минимальный допустимый возраст.
        /// </summary>
        public const int MinAge = AgeRules.PersonMinAge;

        /// <summary>
        /// аксимальный допустимый возраст.
        /// </summary>
        public const int MaxAge = AgeRules.PersonMaxAge;

        /// <summary>
        /// Получает язык, на котором записаны <see cref="Name"/> 
        /// и <see cref="Surname"/>.
        /// </summary>
        /// <remarks>
        /// Значение <see cref="LabFirst.Language.Null"/> означает, 
        /// что имя и фамилия ещё не заданы.
        /// </remarks>
        private Language _language = Language.Null;

        /// <summary>
        /// Возвращает значение, указывающее, что <see cref="Name"/> 
        /// и <see cref="Surname"/>
        /// записаны на русском языке.
        /// </summary>
        public bool IsRussian => _language == Language.Russian;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Person"/>.
        /// </summary>
        /// <remarks>
        /// По умолчанию имя и фамилия пустые, возраст равен 0,
        /// пол равен <see cref="LabFirst.Gender.Unknown"/>, 
        /// язык равен <see cref="LabFirst.Language.Null"/>.
        /// </remarks>
        public Person()
        {

        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Person"/> 
        /// с заданными параметрами.
        /// </summary>
        /// <param name="name">Имя человека.</param>
        /// <param name="surname">Фамилия человека.</param>
        /// <param name="age">Возраст человека в полных годах.</param>
        /// <param name="gender">Пол человека.</param>
        /// <exception cref="ArgumentException">
        /// Бросается, если <paramref name="name"/> 
        /// или <paramref name="surname"/> равны <see langword="null"/>,
        /// состоят только из пробелов, содержат недопустимые символы, 
        /// либо имя и фамилия заданы на разных языках.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Бросается, если <paramref name="age"/> 
        /// выходит за диапазон <see cref="MinAge"/>–<see cref="MaxAge"/>.
        /// </exception>
        public Person(string name, string surname, int age, Gender gender)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Gender = gender;
        }

        /// <summary>
        /// Получает или задаёт имя человека.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Бросается, если значение недопустимо, 
        /// либо имя и фамилия заданы на разных языках.
        /// </exception>
        public string Name
        {
            get => _name;
            set => _name = SetNamePart(value, isName: true);
        }

        /// <summary>
        /// Получает или задаёт фамилию человека.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Бросается, если значение недопустимо, 
        /// либо имя и фамилия заданы на разных языках.
        /// </exception>
        public string Surname
        {
            get => _surname;
            set => _surname = SetNamePart(value, isName: false);
        }

        /// <summary>
        /// Получает или задаёт возраст человека в полных годах.
        /// </summary>
        /// <value>
        /// Допустимый диапазон: <see cref="MinAge"/>–<see cref="MaxAge"/> 
        /// (включительно).
        /// </value>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Бросается, если значение выходит за допустимый диапазон.
        /// </exception>
        public int Age
        {
            get => _age;
            set
            {
                if (value < MinAge || value > MaxAge)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(value),
                        $"Возраст должен быть от {MinAge} до {MaxAge}."
                    );
                }

                _age = value;
            }
        }

        /// <summary>
        /// Получает или задаёт пол человека.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Бросается, если установлено неизвестное значение перечисления.
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
        /// Возвращает строковое представление объекта.
        /// </summary>
        /// <returns>
        /// Строка в формате: "{Name}\t{Surname}\t{Age}\t{Gender}".
        /// </returns>
        public string ToBaseString()
        {
           string Gender = RussianVowelsHelper.GetGenderText(this);
            return $"{Name}\t{Surname}\t{Age}\t{Gender}";
        }

        /// <summary>
        /// Регулярное выражение для проверки слова на русском языке.
        /// </summary>
        private static readonly Regex RussianWordRegex =
            new(@"^[А-Яа-яЁё]+(-[А-Яа-яЁё]+)?$",
                RegexOptions.Compiled
                | RegexOptions.CultureInvariant);

        /// <summary>
        /// Регулярное выражение для проверки слова на английском языке.
        /// </summary>
        private static readonly Regex EnglishWordRegex =
            new(@"^[A-Za-z]+(-[A-Za-z]+)?$",
                RegexOptions.Compiled
                | RegexOptions.CultureInvariant);

        /// <summary>
        /// Нормализует имя или фамилию, проверяет допустимые символы 
        /// и согласованность языка с уже заданной частью.
        /// </summary>
        /// <param name="value">Исходное значение имени или фамилии.</param>
        /// <param name="isName">
        /// Признак того, что обрабатывается имя. Если <see langword="false"/>, 
        /// обрабатывается фамилия.
        /// </param>
        /// <returns>Нормализованная строка
        /// (с приведением регистра и обработкой дефиса).</returns>
        /// <exception cref="ArgumentException">
        /// Бросается, если <paramref name="value"/> 
        /// пустое/пробельное, содержит недопустимые символы,
        /// либо язык имени и фамилии не совпадает.
        /// </exception>
        private string SetNamePart(string value, bool isName)
        {
            string paramName = isName
                ? nameof(Name)
                : nameof(Surname);

            var (normalized, language) =
                NormalizeAndDetectLanguage(
                    value,
                    paramName
                );

            string otherPart = isName
                ? _surname
                : _name;

            Language otherLanguage = DetectLanguage(otherPart);

            if (otherLanguage != Language.Null && otherLanguage != language)
            {
                throw new ArgumentException(
                    "Имя и фамилия должны быть написаны на одном языке (рус/англ).",
                    paramName
                );
            }

            _language = language;
            return normalized;
        }

        /// <summary>
        /// Нормализует строку и определяет язык (русский или английский).
        /// </summary>
        /// <param name="value">Исходное значение.</param>
        /// <param name="paramName">Имя параметра 
        /// для формирования исключения.</param>
        /// <returns>
        /// Кортеж: нормализованная строка и определённый язык.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Бросается, если значение пустое/пробельное 
        /// или не соответствует ожидаемому формату.
        /// </exception>
        private static (string Normalized, Language Language)
            NormalizeAndDetectLanguage(
                string value,
                string paramName
            )
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(
                    "Значение не может быть пустым, " +
                    "состоять только из пробелов или быть null.",
                    paramName
                );
            }

            string input = value.Trim();

            bool isRussian = RussianWordRegex.IsMatch(input);
            bool isEnglish = EnglishWordRegex.IsMatch(input);

            if (!isRussian && !isEnglish)
            {
                throw new ArgumentException(
                    "Допустимы только русские или английские буквы и одно тире.",
                    paramName
                );
            }

            Language language = isRussian
                ? Language.Russian
                : Language.English;
            return (CapitalizeHyphenated(input), language);
        }

        /// <summary>
        /// Пытается определить язык строки по поддерживаемым шаблонам.
        /// </summary>
        /// <param name="value">Значение для анализа.</param>
        /// <returns>
        /// <see cref="LabFirst.Language.Russian"/> 
        /// или <see cref="LabFirst.Language.English"/>, если язык распознан;
        /// иначе <see cref="LabFirst.Language.Null"/>.
        /// </returns>
        private static Language DetectLanguage(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return Language.Null;
            }

            string input = value.Trim();

            if (RussianWordRegex.IsMatch(input))
            {
                return Language.Russian;
            }

            if (EnglishWordRegex.IsMatch(input))
            {
                return Language.English;
            }

            return Language.Null;
        }

        /// <summary>
        /// Приводит строку (включая части через дефис) к нормализованному регистру.
        /// </summary>
        /// <param name="text">Исходное значение.</param>
        /// <returns>Нормализованное значение, 
        /// где каждая часть через дефис капитализирована.</returns>
        private static string CapitalizeHyphenated(string text)
        {
            text = text.Trim();

            string[] parts = text.Split('-', StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < parts.Length; i++)
            {
                parts[i] = CapitalizeSingleWord(parts[i]);
            }

            return string.Join("-", parts);
        }

        /// <summary>
        /// Приводит слово к виду: первая буква — в верхний регистр, 
        /// остальные — в нижний.
        /// </summary>
        /// <param name="word">Слово для преобразования.</param>
        /// <returns>Слово в нормализованном регистре.</returns>
        private static string CapitalizeSingleWord(string word)
        {
            if (string.IsNullOrWhiteSpace(word))
            {
                return word;
            }

            string lower = word.ToLowerInvariant();

            if (lower.Length == 1)
            {
                return lower.ToUpperInvariant();
            }

            return char.ToUpperInvariant(lower[0]) + lower.Substring(1);
        }

        // TODO: XML
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual string GetInfo()
        {
            var stringBuilder = new StringBuilder();

            string Gender = RussianVowelsHelper.GetGenderText(this);

            stringBuilder.AppendLine($"Имя: {Name}");
            stringBuilder.AppendLine($"Фамилия: {Surname}");
            stringBuilder.AppendLine($"Возраст: {Age}");
            stringBuilder.AppendLine($"Пол: {Gender}");

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
