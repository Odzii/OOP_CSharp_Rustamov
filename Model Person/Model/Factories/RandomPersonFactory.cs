namespace Model.Factories
{
    
    /// <summary>
    /// Создаёт случайный экземпляр класса <see cref="Person"/> 
    /// на основе источника имён.
    /// </summary>
    public sealed class RandomPersonFactory : IPersonFactory<Person>
    {
        /// <summary>
        /// Максимальное число полов
        /// </summary>
        private const int _genderVariantsCount = 2;

        /// <summary>
        /// Путь к файлу с именами и фамилиями.
        /// </summary>
        private readonly IPersonNameSource _names;

        /// <summary>
        /// Инициализация класса <see cref="Random"/>.
        /// </summary>
        private readonly Random _random;

        /// <summary>
        /// Инициализация файла хранящего путь с параметрами, 
        /// которые необходимы для создания случайного экземпляра
        /// класса <see cref="Person"/>.
        /// </summary>
        /// <param name="names">Имя, фамилия.</param>
        /// <param name="random">
        /// Экземпляр класса <see cref="Random"/>.
        /// </param>
        /// <exception cref="ArgumentNullException"></exception>
        public RandomPersonFactory(IPersonNameSource names, Random random)
        {
            _names = names ?? throw new ArgumentNullException(nameof(names));
            _random = random ?? throw new ArgumentNullException(nameof(random));
        }

        /// <summary>
        /// Создаёт случайного человека.
        /// </summary>
        /// <returns>
        /// Случайно сгенерированный экземпляр <see cref="Person"/>
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Бросается, если в <see cref="IPersonNameSource"/> отсутствуют данные
        /// (пустые списки имён/фамилий).
        /// </exception>
        public Person Create()
        {
            Gender gender = CreateRandomGender();

            string name = gender == Gender.Male
                ? _random.NextItem(_names.MaleNames, nameof(_names.MaleNames))
                : _random.NextItem(_names.FemaleNames, nameof(_names.FemaleNames));

            string surname = _random.NextItem(_names.Surnames, nameof(_names.Surnames));
            surname = RussianVowelsHelper.FixFemaleRussianSurname(surname, gender);

            int age = _random.Next(Person.MinAgePerson, Person.MaxAgePerson + 1);

            return age < Adult.MinAgeAdult
                ? new Child(name, surname, age, gender)
                : new Adult(name, surname, age, gender);
        }

        /// <summary>
        /// Выбор <see cref="Gender"/>, из числа доступных.
        /// </summary>
        /// <returns></returns>
        private Gender CreateRandomGender()
        {
            return _random.Next(_genderVariantsCount) == 0
                ? Gender.Male
                : Gender.Female;
        }
    }
}
