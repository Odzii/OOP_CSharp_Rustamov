using Model.HelperMethods;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        /// <summary>
        /// Паспорт <see cref="Passport"/>
        /// </summary>
        private Passport _passport;

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

        /// <summary>
        /// Конструктор класса, в котором инициализируются 
        /// объект <see cref="Adult"/> с именем, фамилией
        /// возрастор и полом.
        /// </summary>
        /// <param name="name"> имя</param>
        /// <param name="surname"> фамилия </param>
        /// <param name="age"> возраст </param>
        /// <param name="gender"> пол</param>
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
            Passport passport = new Passport(series, number, issuedBy, issueDate);
            _passport = passport;
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

            if (_passport is not null)
            {
                stringBuilder.AppendLine($"Паспорт: " +
                $"{_passport.Series}\t{_passport.Number}");
                stringBuilder.AppendLine($"Кем выдан: " +
                    $"{_passport.IssuedBy}");
                stringBuilder.AppendLine($"Дата выдачи: " +
                    $"{_passport.IssueDate:dd.MM.yyyy}");
            }
            else 
            {
                stringBuilder.AppendLine("Пасспорт: данные отсутвуют");
            }

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
