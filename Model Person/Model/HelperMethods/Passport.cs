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
        public const int LenghtNumbers = 6;

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

        //TODO: RSDN +
        /// <summary>
        /// Регулярное выражение для количества чисел в серии паспорта.
        /// </summary>
        private static string _seriesRegex =
            string.Format(
                @"^(\d){0}$",
                "{" + $"{LengthSeries}" + "}"
            );

        /// <summary>
        /// Паттерн для номера паспорта
        /// </summary>
        private static string _numbersRegex
            = string.Format(@"^(\d){0}$",
                "{" + $"{LenghtNumbers}" + "}"
            );

        /// <summary>
        /// Паттерн для серии паспорта
        /// </summary>
        private static readonly Regex _countSeries =
            new(pattern: _seriesRegex,
                RegexOptions.Compiled
            );

        /// <summary>
        /// Регулярное выражение для количества чисел в серии паспорта.
        /// </summary>
        private static readonly Regex _countNumbers =
            new(pattern: _numbersRegex,
                RegexOptions.Compiled
            );

        /// <summary>
        /// Задает серию паспорта.
        /// </summary>
        public string Series
        {
            get => _series;
            set
            {
                if (string.IsNullOrWhiteSpace(value)
                    | !_countSeries.IsMatch(value)
)
                {
                    throw new ArgumentException(
                        "Серия паспорта не может быть пустой.",
                        nameof(value)
                    );
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
                if (string.IsNullOrWhiteSpace(value)
                | !_countNumbers.IsMatch(value)
            )
                {
                    throw new ArgumentException(
                        "Номер паспорта не может быть пустым.",
                        nameof(value)
                    );
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
                        nameof(value)
                    );
                }

                _issuedBy = value;
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
                        nameof(value)
                    );
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
            DateOnly issueDate
        )
        {
            Series = series;
            Number = number;
            IssuedBy = issuedBy;
            IssueDate = issueDate;
        }
    }
}
