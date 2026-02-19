namespace Model.Factories
{
    /// <summary>
    /// Создаёт случайные экземпляры <see cref="Adult"/> 
    /// на основе базового класса <see cref="Person"/>.
    /// </summary>
    public sealed class RandomAdultFactory : IPersonFactory<Adult>
    {
        /// <summary>
        /// Инициализация экземпляра класса <see cref="Random"/>.
        /// </summary>
        private readonly Random _random;
        /// <summary>
        /// Путь к файлам с названием места работы и выдачи паспорта. 
        /// </summary>
        private readonly FileDataSource _adultData;
        /// <summary>
        /// Длина серии паспорта
        /// </summary>
        private const int PassportSeriesLength = Limits.LengthSeries;
        /// <summary>
        /// Длмна номера паспорта
        /// </summary>
        private const int PassportNumberLength = Limits.LenghtNumbers;
        /// <summary>
        /// Вероятность брака
        /// </summary>
        private const double MarriageProbability = 0.6;

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
        public RandomAdultFactory(FileDataSource adultData, Random random)
        {
            _adultData = 
                adultData 
                ?? throw new ArgumentNullException(
                    nameof(adultData),
                    $"Для {adultData} поданы неверный тип данных на вход."
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
        /// <see cref="PassportSeriesLength"/> и <see cref="PassportNumberLength"/>.
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

                partner.Age = ClampAdultAge(adult.Age + _random.Next(-10, 11));

                adult.Marry(partner);
            }

            return adult;
        }

        /// <summary>
        /// Взависимости от типа <see cref="Gender"/>, поданого на вход метода
        /// происходит создание случайного экземпляра класса <see cref="Adult"/>.
        /// В случае, если подано <see cref="null"/>, 
        /// то создается случайный экземпляр класса <see cref="Adult"/>,
        /// если подан конкретное значение <see cref="Gender"/>, 
        /// то создается случайный экземпляр класса <see cref="Adult"/>
        /// противоположного пола.
        /// </summary>
        /// <param name="forceGender">
        /// <see cref="Gender"/> может быть <see cref="null"/>
        /// </param>
        /// <returns>
        /// Экземпляр класса <see cref="Adult"/>
        /// </see></returns>
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
                    _adultData.MaleNames, 
                    nameof(_adultData.MaleNames))
                : _random.NextItem(
                    _adultData.FemaleNames, 
                    nameof(_adultData.FemaleNames)
                );

            string surname = _random.NextItem(
                _adultData.Surnames, 
                nameof(_adultData.Surnames)
            );

            surname = RussianVowelsHelper.FixFemaleRussianSurname(
                surname, 
                gender
            );

            adult.Surname = surname;

            adult.Age = _random.Next(Limits.AdultMinAge, Limits.PersonMaxAge + 1);

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

            //TODO: magic (to const)
            if (_random.NextDouble() < 0.85)
            {
                string work = _random.NextItem(
                    _adultData.WorkplaceNames,
                    nameof(_adultData.WorkplaceNames)
                );

                adult.SetWorkplace(work);
            }
            else
            {
                adult.ClearWorkplace();
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
            if (age < Limits.AdultMinAge)
            {
                return Limits.AdultMinAge;
            }

            if (age > Limits.PersonMaxAge)
            {
                return Limits.PersonMaxAge;
            }

            return age;
        }

        /// <summary>
        /// Формирует соучайный день выдачи паспорта 
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
                throw new ArgumentException("Неверный диапазон дат.");

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

            DateOnly issueFrom = birthDate.AddYears(Limits.AdultMinAge);
            if (issueFrom > today) issueFrom = today;

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
            //TODO: {}
            for (int i = 0; i < n; i++) x *= 10;
            return x;
        }
    }
}
