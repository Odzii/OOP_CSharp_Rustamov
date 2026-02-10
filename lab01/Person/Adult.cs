using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LabFirst
{
    /// <summary>
    /// Взрослый человек: паспорт, семейное положение, место работы
    /// </summary>
    public class Adult : Person
    {
        /// <summary>
        /// Минимальный возраст взрослого человека.
        /// </summary>
        private const int _minAge = AgeRules.AdultMinAge;

        /// <summary>
        /// Возращает true, если <see cref="Adult"/> женат/замужен.
        /// </summary>
        private bool IsMarried
            => Status == MaritalStatus.Married;


        /// <summary>
        /// Задает серию паспорта.
        /// </summary>
        public string PassportSeries
        {
            get;
            private set;
        }
            = string.Empty;

        /// <summary>
        /// Задает номер паспорта.
        /// </summary>
        public string PassportNumber
        {
            get;
            private set;
        }
            = string.Empty;

        /// <summary>
        /// Задает место выдачи паспорта.
        /// </summary>
        public string PassportIssuedBy
        {
            get;
            private set;
        }
            = string.Empty;

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
        /// Партнер/супруг(-а)
        /// </summary>
        public Adult? Partner
        {
            get;
            private set;
        }

        /// <summary>
        /// Место работы.
        /// </summary>
        public string? WorkplaceName
        {
            get;
            private set;
        }

        /// <summary>
        /// 
        /// </summary>
        public new int Age
        {
            get => base.Age;
            set
            {
                if (value < _minAge)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(value),
                        $"Для Adult возраст не должен быть меньше {_minAge}.");
                }    

                base.Age = value;
            }
        }

        /// <summary>
        /// Создает пустой объект <see cref="Adult"/>
        /// </summary>
        public Adult()
        {

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
            string workplaceName = ""
        ) : base(name, surname, _minAge, gender)
        {
            Age = age;

            SetPassport(
                passportSeries,
                passportNumber,
                passportIssuedBy,
                issueDate
            );

            if (!string.IsNullOrWhiteSpace(workplaceName))
            {
                SetWorkplace(workplaceName);
            }
        }

        /// TODO: Добавить методы для корректного ввода параметров паспорта.
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
            if (string.IsNullOrWhiteSpace(series))
            {
                throw new ArgumentException(
                    "Серия паспорта не может быть пустой.",
                    nameof(series)
                );
            }

            if (string.IsNullOrWhiteSpace(number))
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

            PassportSeries = series.Trim();
            PassportNumber = number.Trim();
            PassportIssuedBy = issuedBy.Trim();
            PassportIssueDate = issueDate;
        }

        ///TODO: feature
        /// <summary>
        /// Задать место работы. Принимает на вход
        /// место работы.
        /// </summary>
        /// <param name="workplaceName">Место работы</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void SetWorkplace(string workplaceName)
        {
            //if (string.IsNullOrWhiteSpace(workplaceName))
            //{
            //    throw new ArgumentNullException(
            //        "Название места работв не может быть пустым",
            //        nameof(workplaceName)
            //    );
            //}

            WorkplaceName = workplaceName.Trim();
        }

        /// <summary>
        /// Очистить место работу у выбранного <see cref="Adult"/>
        /// </summary>
        public void ClearWorkplace()
            => WorkplaceName = null;

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

            if (this.IsMarried)
            {
                throw new InvalidOperationException(
                    "Этот человек уже состоит в браке.");
            }

            if (parhner.IsMarried)
            {
                throw new InvalidOperationException(
                    "Партнер уже состоит в браке."
                    );
            }

            // Устанавливается симметричная связь между объектами
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
            if (!IsMarried || Partner is null)
            {
                throw new InvalidOperationException(
                    "Развод невозможен: нет зарегистрированного брака."
                );
            }

            Adult ex = Partner;

            Partner = null;
            Status = MaritalStatus.Divorced;

            ex.Partner = null;
            ex.Status = MaritalStatus.Divorced;
        }

        /// <summary>
        /// Получение основных данных паспорта для вывода.
        /// </summary>
        /// <returns>
        /// <see cref="PassportSeries"/>
        /// <see cref="PassportNumber"/>
        /// <see cref="Status"/>
        /// <see cref="WorkplaceName"/>
        /// </returns>
        public override string ToString()
        {
            return base.ToString()
                + $"\tPassport: {PassportSeries} {PassportNumber}"
                + $"\tMarital: {Status}"
                + $"\tWork: {(string.IsNullOrEmpty(WorkplaceName)
                    ? "-"
                    : WorkplaceName)}";
        }

        // TODO: XML
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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
    }
}
