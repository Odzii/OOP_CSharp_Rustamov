using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Model.Models
{
    
    /// <summary>
    /// Взрослый человек: паспорт, семейное положение, место работы
    /// </summary>
    public class Adult : Person
    {
        /// <summary>
        /// Минимальный возраст взрослого человека.
        /// </summary>
        public const int MinAgeAdult = 18;

        /// <summary>
        /// Возращает true, если <see cref="Adult"/> женат/замужен.
        /// </summary>
        private bool _isMarried
            => Status == MaritalStatus.Married;

        //TODO: RSDN +
        /// <summary>
        /// Регулярное выражение для количества чисел в серии паспорта.
        /// </summary>
        private static string _seriesRegex = 
            String.Format(
                @"^(\d){0}$", 
                "{" + $"{Limits.LengthSeries}" + "}"
            );

        /// <summary>
        /// Паттерн для номера паспорта
        /// </summary>
        private static string _numbersRegex 
            = String.Format(@"^(\d){0}$", 
                "{" + $"{Limits.LenghtNumbers}" + "}"
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

        //TODO: Class and validation
        /// <summary>
        /// Задает серию паспорта.
        /// </summary>
        public string PassportSeries
        {
            get;
            private set;
        }
            = string.Empty;

        //TODO: Class and validation
        /// <summary>
        /// Задает номер паспорта.
        /// </summary>
        public string PassportNumber
        {
            get;
            private set;
        }
            = string.Empty;

        //TODO: Class and validatio
        /// <summary>
        /// Задает место выдачи паспорта.
        /// </summary>
        public string PassportIssuedBy
        {
            get;
            private set;
        }
            = string.Empty;

        //TODO: Class and validatio
        /// <summary>
        /// Задает дату выдачи паспорта
        /// </summary>
        public DateOnly PassportIssueDate
        {
            get;
            private set;
        }
            = default;

        /// <summary>
        /// Задает текущее семейное положение
        /// </summary>
        public MaritalStatus Status
        {
            get;
            private set;
        }
            = MaritalStatus.Single;

        /// <summary>
        /// Место работы
        /// </summary>
        private string _workplaceName = string.Empty;

        // TODO: validation
        /// <summary>
        /// Партнер/супруг(-а)
        /// </summary>
        public Adult? Partner
        {
            get;
            private set;
        }

        //TODO: validation + 
        /// <summary>
        /// Место работы.
        /// </summary>
        public string? WorkplaceName
        {
            get => _workplaceName;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _workplaceName = string.Empty;
                    return;
                }

                _workplaceName = value;
            }
        }

        //TODO: refactor +
        // delete property age and add ovveride
        /// <see cref="ValidateAge(int)"/>
        //TODO: duplication + solve with virtual in Person

        /// <summary>
        /// Создает пустой объект <see cref="Adult"/>
        /// </summary>
        public Adult() : base()
        {

        }

        //TODO: XML
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <param name="age"></param>
        /// <param name="gender"></param>
        public Adult(
            string name,
            string surname,
            int age,
            Gender gender
            ) : base(name, surname, MinAgeAdult, gender)
        {
            Age = age;
        }

        /// <summary>
        /// Взрослый человек с именем и фамилией, основными паспортными данными.
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="surname">Фамилия</param>
        /// <param name="age">Возраст</param>
        /// <param name="gender">Пол</param>
        /// <param name="passportSeries">Серия паспорта</param>
        /// <param name="passportNumber">Номер паспорта</param>
        /// <param name="passportIssuedBy">Кем выдан</param>
        /// <param name="issueDate">Дата выдачи</param>
        /// <param name="workplaceName">Место работы</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public Adult(
            string name,
            string surname,
            int age,
            Gender gender,
            string passportSeries,
            string passportNumber,
            string passportIssuedBy,
            DateOnly issueDate,
            string workplaceName
        ) : this(
                name,
                surname,
                age,
                gender
            )
        {

            SetPassport(
                passportSeries,
                passportNumber,
                passportIssuedBy,
                issueDate
            );

            WorkplaceName = workplaceName;
        }

        // TODO: Refactoring add class
        /// <summary>
        /// Задать основные значения в паспорте. Такие как:
        /// </summary>
        /// <param name="series">Серия</param>
        /// <param name="number">Номер</param>
        /// <param name="issuedBy">Кем выдан</param>
        /// <param name="issueDate">Дата выдачи</param>
        /// <exception cref="ArgumentNullException">Бросает исключение
        /// в случае некорректных данных.
        /// </exception>
        public void SetPassport(
            string series,
            string number,
            string issuedBy,
            DateOnly issueDate
        )
        {
            if (string.IsNullOrWhiteSpace(series) 
                | !_countSeries.IsMatch(series)
            )
            {
                throw new ArgumentException(
                    "Серия паспорта не может быть пустой.",
                    nameof(series)
                );
            }

            if (string.IsNullOrWhiteSpace(number) 
                | !_countNumbers.IsMatch(number)
            )
            {
                throw new ArgumentException(
                    "Номер паспорта не может быть пустым.",
                    nameof(number)
                );
            }

            if (string.IsNullOrWhiteSpace(issuedBy))
            {
                throw new ArgumentException(
                    "Кем выдан паспорт — обязательное поле.",
                    nameof(issuedBy)
                );
            }

            if (issueDate == default)
            {
                throw new ArgumentException(
                    "Дата выдачи паспорта должна быть задана.",
                    nameof(issueDate)
                );
            }
            //TODO: refactor
            PassportSeries = series.Trim();
            PassportNumber = number.Trim();
            PassportIssuedBy = issuedBy.Trim();
            PassportIssueDate = issueDate;
        }

        //TODO: to property + 

        //TODO: remove + 

        //TODO: XML + 
        /// <summary>
        /// Установить брак с партнером <see cref="Adult"/>
        /// противоположного пола.
        /// </summary>
        /// <param name="parhner">
        /// Объект <see cref="Adult"/>
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Если <paramref name="parhner"/> равен null.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// Если <paramref name="parhner"/> уже состоит в браке.
        /// </exception>
        public void Marry(Adult parhner)
        {
            if (parhner is null)
            {
                throw new ArgumentNullException(
                    "Значение не может быть null, партнер должен быть указан.",
                    nameof(parhner)
                    );
            }

            if (ReferenceEquals(this, parhner))
            {
                throw new InvalidOperationException(
                    "Нельзя вступить в брак с самим собой."
                    );
            }

            if (this._isMarried)
            {
                throw new InvalidOperationException(
                    "Этот человек уже состоит в браке.");
            }

            if (parhner._isMarried)
            {
                throw new InvalidOperationException(
                    "Партнер уже состоит в браке."
                    );
            }

            Partner = parhner;
            parhner.Partner = this;

            Status = MaritalStatus.Married;
            parhner.Status = MaritalStatus.Married;
        }

        /// <summary>
        /// Метод позволяет разорвать брак с партнером.
        /// </summary>
        /// <exception cref="InvalidOperationException">Бросает исключение
        /// если <see cref="Adult"/> не состоит в браке.
        /// </exception>
        public void Divorce()
        {
            if (!_isMarried || Partner is null)
            {
                throw new InvalidOperationException(
                    "Развод невозможен: нет зарегистрированного брака."
                );
            }
            //TODO: RSDN + 
            Adult exPartner = Partner;

            Partner = null;
            Status = MaritalStatus.Divorced;

            exPartner.Partner = null;
            exPartner.Status = MaritalStatus.Divorced;
        }

        /// <summary>
        /// Возращает основную иформацию об <see cref="Adult"/>,
        /// в виде строки типа <see cref="String"/>.
        /// </summary>
        /// <returns>Строку.</returns>
        public override string GetInfo()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(base.GetInfo());

            if (Status == MaritalStatus.Married)
            {
                stringBuilder.AppendLine($"Состоит в браке: " +
                    $"{Partner!.ToBaseString()}");
            }
            else
            {
                stringBuilder.AppendLine($"Не состоит в браке.");
            }

            stringBuilder.AppendLine($"Паспорт: " +
                $"{PassportSeries}\t{PassportNumber}");
            stringBuilder.AppendLine($"Кем выдан: " +
                $"{PassportIssuedBy}");
            stringBuilder.AppendLine($"Дата выдачи: " +
                $"{PassportIssueDate:dd.MM.yyyy}");

            stringBuilder.AppendLine(
                string.IsNullOrWhiteSpace(WorkplaceName)
                ? "Безработный"
                : $"Место работы: {WorkplaceName}"
            );

            return stringBuilder.ToString().TrimEnd();
        }

        /// <summary>
        /// Проверка корректного задания возраста <see cref="Adult"/>
        /// </summary>
        /// <param name="value">
        /// Возраст (целочисленный тип)
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Бросает исключение о выходе за пределы.
        /// </exception>
        protected override void ValidateAge(int value)
        {
            base.ValidateAge(value);

            if ( value < MinAgeAdult)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(value),
                    $"Для Adult возраст не должен быть меньше {MinAgeAdult}."
                );
            }
        }
    }
}
