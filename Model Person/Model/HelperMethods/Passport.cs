using System;
using System.Text.RegularExpressions;

namespace Model.HelperMethods
{
    /// <summary>
    /// Служебный класс для <see cref="Adult"/>, который
    /// содержит шаблон паспорта с параметрами:
    /// серия, номер, место и дата выдачи.
    /// </summary>
    internal sealed class Passport
    {
        /// <summary>
        /// Длина номера паспорта РФ
        /// </summary>
        public const int LengthNumbers = 6;

        /// <summary>
        /// Длина серии паспорта РФ
        /// </summary>
        public const int LengthSeries = 4;

        /// <summary>
        /// Серия паспорта
        /// </summary>
        private string _series = string.Empty;

        /// <summary>
        /// Номер паспорта
        /// </summary>
        private string _numbers = string.Empty;

        ///<summary>
        /// Место выдачи паспорта
        /// </summary>
        private string _issuedBy = string.Empty;

        /// <summary>
        /// Дата выдачи паспорта
        /// </summary>
        private DateOnly _issueDate = default;

        /// <summary>
        /// Задает серию паспорта.
        /// </summary>
        public string Series
        {
            get => _series;
            set
            {
                //TODO: refactor regex +
                Regex seriesRegex = ValidationPassport(LengthSeries);

                if (string.IsNullOrWhiteSpace(value) 
                    || !seriesRegex.IsMatch(value))
                {
                    throw new ArgumentException(
                        $"Серия паспорта " +
                        $"должна состоять из {LengthSeries} цифр.",
                        nameof(value));
                }

                _series = value.Trim();
            }
        }

        /// <summary>
        /// Задает номер паспорта.
        /// </summary>
        public string Number
        {
            get => _numbers;
            set
            {
                //TODO: refactor regex + 
                Regex numbersRegex = ValidationPassport(LengthNumbers);

                if (string.IsNullOrWhiteSpace(value) 
                    || !numbersRegex.IsMatch(value))
                {
                    throw new ArgumentException(
                        $"Номер паспорта " +
                        $"должен состоять из {LengthNumbers} цифр.",
                        nameof(value));
                }

                _numbers = value.Trim();
            }
        }

        /// <summary>
        /// Задает место выдачи паспорта.
        /// </summary>
        public string IssuedBy
        {
            get => _issuedBy;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(
                        "Кем выдан паспорт — обязательное поле.",
                        nameof(value));
                }

                _issuedBy = value.Trim();
            }
        }

        /// <summary>
        /// Задает дату выдачи паспорта
        /// </summary>
        public DateOnly IssueDate
        {
            get => _issueDate;
            set
            {
                if (value == default)
                {
                    throw new ArgumentException(
                        "Дата выдачи паспорта должна быть задана.",
                        nameof(value));
                }

                _issueDate = value;
            }
        }

        /// <summary>
        /// Создает экземпляр класса <see cref="Passport"/>
        /// </summary>
        /// <param name="series"> 
        /// Серия паспорта 
        /// </param>
        /// <param name="number"> 
        /// Номер паспорта 
        /// </param>
        /// <param name="issuedBy"> 
        /// Место выдачи паспорта
        /// </param>
        /// <param name="issueDate"> 
        /// Дата выдачи паспорта 
        /// </param>
        public Passport(
            string series, 
            string number, 
            string issuedBy, 
            DateOnly issueDate)
        {
            Series = series;
            Number = number;
            IssuedBy = issuedBy;
            IssueDate = issueDate;
        }

        /// <summary>
        /// Проверка на количество цифр по длине
        /// </summary>
        /// <param name="length"> Длина</param>
        /// <returns> Возвращает <see langword="Regex"/></returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Бросает исключение, если длина равна или меньше нуля.
        /// </exception>
        private static Regex ValidationPassport(int length)
        {
            if (length <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(length));
            }

            string pattern = $@"^\d{{{length}}}$";

            return new Regex(
                pattern,
                RegexOptions.Compiled | RegexOptions.CultureInvariant);
        }
    }
}
