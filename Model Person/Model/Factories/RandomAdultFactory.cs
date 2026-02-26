using System;

namespace Model.Factories
{
    //TODO: WTF?
    /// <summary>
    /// Создаёт случайные экземпляры <see cref="Adult"/> 
    /// на основе базового класса <see cref="PersonBase"/>.
    /// </summary>
    public sealed class RandomAdultFactory : IPersonFactory<Adult>
    {
        /// <summary>
        /// Длина серии паспорта
        /// </summary>
        private const int PassportSeriesLength = Passport.LengthSeries;

        /// <summary>
        /// Длина номера паспорта
        /// </summary>
        private const int PassportNumberLength = Passport.LengthNumbers;

        /// <summary>
        /// Вероятность брака
        /// </summary>
        private const double MarriageProbability = 0.6;

        /// <summary>
        /// Вероятность того, что <see cref="Adult"/>
        /// будет иметь работу.
        /// </summary>
        private const double JobProbability = 0.85;

        /// <summary>
        /// Минимальная разница в возрасте партнёра 
        /// относительно исходного взрослого.
        /// </summary>
        /// <remarks>
        /// Используется при генерации случайного партнёра:
        /// партнёр может быть младше
        /// на заданное количество лет.
        /// </remarks>
        private const int PartnerAgeDeltaMin = -10;

        /// <summary>
        /// Верхняя граница (не включительно) разницы в возрасте партнёра
        /// относительно исходного взрослого.
        /// </summary>
        /// <remarks>
        /// Используется в <see cref="Random.Next(int, int)"/> 
        /// как верхняя граница (exclusive),
        /// поэтому значение на 1 больше максимально допустимой разницы.
        /// Например, при значении 11 фактический максимум составляет 10 лет.
        /// </remarks>
        private const int PartnerAgeDeltaMaxExclusive = 11;

        /// <summary>
        /// Инициализация экземпляра класса <see cref="Random"/>.
        /// </summary>
        private readonly Random _random;

        /// <summary>
        /// Путь к файлам с названием места работы и выдачи паспорта. 
        /// </summary>
        private readonly IPersonNameSource _names;

        /// <summary>
        /// Путь к файлам с названием места работы и выдачи паспорта. 
        /// </summary>
        private readonly IAdultDataSource _adultData;

        /// <summary>
        /// Инициализация файла хранящего путь с параметрами, 
        /// которые необходимы для создания случайного экземпляра
        /// класса <see cref="Adult"/>.
        /// </summary>
        /// <param name="adultData">
        /// Расположения данных для <see cref="Adult"/>
        /// </param>
        /// <param name="random">
        /// Инициализация случайного экземпляра класса <see cref="Random"/>
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// В случае, если на вход поданы некорректные данные.
        /// </exception>
        public RandomAdultFactory(
            IPersonNameSource names,
            IAdultDataSource adultData, 
            Random random)
        {
            _names = names 
                ?? throw new ArgumentNullException(nameof(names),
                        "Источник имён не задан."
                    );
            _adultData = 
                adultData 
                ?? throw new ArgumentNullException(
                        nameof(adultData),
                        $"Для {adultData} подан неверный тип данных на вход."
                    );

            _random = 
                random 
                ?? throw new ArgumentNullException(
                        nameof(random),
                        $"Для {random} подан неверный тип данных на вход."
                    );
        }

        /// <summary>
        /// Позволяет создать экземпляр класса Adult с именем, фамилией, 
        /// возрастом от 18 лет (включительно), а также с вероятностью 
        /// <see cref="MarriageProbability"/> состоящим в браке. 
        /// Создается серия и номер паспорта длиной 
        /// <see cref="PassportSeriesLength"/> 
        /// и <see cref="PassportNumberLength"/>.
        /// Также задается случайно выбранное место работы из файла txt.
        /// </summary>
        /// <returns>
        /// Экземпляр класса <see cref="Adult"/>.
        /// </returns>
        public Adult Create()
        {
            Adult adult = CreateSingleAdult();

            if (_random.NextDouble() < MarriageProbability)
            {
                Gender partnerGender = 
                    adult.Gender == Gender.Male
                    ? Gender.Female
                    : Gender.Male;

                Adult partner = CreateSingleAdult(forceGender: partnerGender);

                partner.Age = ClampAdultAge(
                    adult.Age + _random.Next(
                            PartnerAgeDeltaMin, 
                            PartnerAgeDeltaMaxExclusive
                        )
                );

                adult.Marry(partner);
            }

            return adult;
        }

        /// <summary>
        /// Статический метод создания случайного экземпляра класса 
        /// <see cref="Adult"/>
        /// </summary>
        /// <param name="names"></param>
        /// <param name="adultData"></param>
        /// <param name="random"></param>
        /// <returns></returns>
        public static Adult CreateRandom(
            IPersonNameSource names,
            IAdultDataSource adultData,
            Random random
        )
            => new RandomAdultFactory(names, adultData, random).Create();

        /// <summary>
        /// В зависимости от типа <see cref="Gender"/>, 
        /// происходит создание случайного экземпляра класса <see cref="Adult"/>.
        /// В случае, если подано <see cref="null"/>, 
        /// то создается случайный экземпляр класса <see cref="Adult"/>,
        /// если подан конкретное значение <see cref="Gender"/>, 
        /// то создается случайный экземпляр класса <see cref="Adult"/>
        /// противоположного пола.
        /// </summary>
        /// <param name="forceGender">
        /// <see cref="Gender"/> может быть <see langword="null"/>
        /// </param>
        /// <returns>Экземпляр класса <see cref="Adult"/>.</returns>
        private Adult CreateSingleAdult(Gender? forceGender = null)
        {
            Adult adult = new Adult();

            Gender gender = forceGender 
                ?? (_random.Next(2) == 0 
                ? Gender.Male 
                : Gender.Female);

            adult.Gender = gender;

            adult.Name = gender == Gender.Male
                ? _random.NextItem(
                        _names.MaleNames, 
                        nameof(_names.MaleNames))
                : _random.NextItem(
                        _names.FemaleNames, 
                        nameof(_names.FemaleNames)
                    );

            string surname = _random.NextItem(
                    _names.Surnames, 
                    nameof(_names.Surnames)
                );

            surname = RussianVowelsHelper.FixFemaleRussianSurname(
                surname, 
                gender
            );

            adult.Surname = surname;

            adult.Age = _random.Next(Adult.MinAgeAdult, PersonBase.MaxAgePerson + 1);

            string series = _random.Next(0, Pow10(PassportSeriesLength))
                .ToString($"D{PassportSeriesLength}");

            string number = _random.Next(0, Pow10(PassportNumberLength))
                .ToString($"D{PassportNumberLength}");

            string issuedBy = _random.NextItem(
                _adultData.PassportsIssuedBy,
                nameof(_adultData.PassportsIssuedBy)
            );

            DateOnly issueDate = CreateRandomIssueDate(_random, adult.Age);

            adult.SetPassport(series, number, issuedBy, issueDate);

            if (_random.NextDouble() < JobProbability)
            {
                string work = _random.NextItem(
                        _adultData.WorkplaceNames,
                        nameof(_adultData.WorkplaceNames)
                    );

                adult.WorkplaceName = work;
            }
            else
            {
                adult.WorkplaceName = string.Empty;
            }

            return adult;
        }

        /// <summary>
        /// Валидация возраста
        /// </summary>
        /// <param name="age"></param>
        /// <returns></returns>
        private static int ClampAdultAge(int age)
        {
            if (age < Adult.MinAgeAdult)
            {
                return Adult.MinAgeAdult;
            }

            if (age > PersonBase.MaxAgePerson)
            {
                return PersonBase.MaxAgePerson;
            }

            return age;
        }

        /// <summary>
        /// Формирует случайный день выдачи паспорта 
        /// </summary>
        /// <param name="random"></param>
        /// <param name="fromInclusive"></param>
        /// <param name="toInclusive"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        private static DateOnly NextDate(
            Random random, 
            DateOnly fromInclusive, 
            DateOnly toInclusive
        )
        {
            if (fromInclusive > toInclusive)
            {
                throw new ArgumentException("Неверный диапазон дат.");
            }    

            int from = fromInclusive.DayNumber;
            int to = toInclusive.DayNumber;

            int dayNumber = random.Next(from, to + 1);
            return DateOnly.FromDayNumber(dayNumber);
        }

        /// <summary>
        /// Создает случайную дату выдачи паспорта с валидацией данных
        /// </summary>
        /// <param name="random"></param>
        /// <param name="age"></param>
        /// <returns></returns>
        private static DateOnly CreateRandomIssueDate(Random random, int age)
        {
            DateOnly today = DateOnly.FromDateTime(DateTime.Today);

            DateOnly birthFrom = today.AddYears(-age - 1).AddDays(1);

            DateOnly birthTo = today.AddYears(-age);

            DateOnly birthDate = NextDate(random, birthFrom, birthTo);

            DateOnly issueFrom = birthDate.AddYears(Adult.MinAgeAdult);

            if (issueFrom > today)
            {
                issueFrom = today;
            }

            return NextDate(random, issueFrom, today);
        }

        /// <summary>
        /// Вспомогательный метод вычисления значения для выражения вида
        /// 10^n степени
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        private static int Pow10(int n)
        {
            int x = 1;
            for (int i = 0; i < n; i++)
            {
                x *= 10;
            }
            return x;
        }
    }
}
