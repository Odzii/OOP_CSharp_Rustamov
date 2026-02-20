namespace Model.Factories
{
    //TODO: XML +
    /// <summary>
    /// Фабрика для создания случайного экземпляра <see cref="Child"/>.
    /// Использует источники данных имён/фамилий, 
    /// данных взрослого человека и данных образования ребёнка.
    /// </summary>
    public sealed class RandomChildFactory : IPersonFactory<Child>
    {
        /// <summary>
        /// Генератор случайных чисел.
        /// </summary>
        private readonly Random _random;

        /// <summary>
        /// Фабрика для генерации базовых данных <see cref="Person"/>.
        /// </summary>
        private readonly IPersonFactory<Person> _personFactory;

        /// <summary>
        /// Фабрика для генерации базовых данных <see cref="Adult"/>.
        /// </summary>
        private readonly IPersonFactory<Adult> _adultFactory;

        /// <summary>
        /// Источник имён и фамилий.
        /// </summary>
        private readonly IPersonNameSource _names;

        /// <summary>
        /// Источник данных для взрослых.
        /// </summary>
        private readonly IAdultDataSource _adultData;

        /// <summary>
        /// Источник данных для образования ребёнка (садик, школа).
        /// </summary>
        private readonly IChildEducationSource _childData;

        /// <summary>
        /// Минимальный возраст для выбора школы.
        /// </summary>
        private const int MinAgeForSchool = 7;

        /// <summary>
        /// Создаёт экземпляр <see cref="RandomChildFactory"/>.
        /// </summary>
        /// <param name="names">
        /// Источник имён и фамилий.
        /// </param>
        /// <param name="adultData">
        /// Источник данных для 
        /// <see cref="Adult"/>.</param>
        /// <param name="childData">Источник образования для 
        /// <see cref="Child"/>.</param>
        /// <param name="random">Генератор случайных чисел.</param>
        /// <exception cref="ArgumentNullException">
        /// Если любой параметр равен <see langword="null"/>.
        /// </exception>
        public RandomChildFactory(
            IPersonNameSource names,
            IAdultDataSource adultData,
            IChildEducationSource childData, 
            Random random)
        {
            _names = names ?? throw new ArgumentNullException(nameof(names)); ;
            _adultData = adultData ?? throw new ArgumentNullException(nameof(adultData));
            _childData = childData ?? throw new ArgumentNullException(nameof(childData));
            _random = random ?? throw new ArgumentNullException(nameof(random));

            // создаём фабрики после проверок
            _personFactory = new RandomPersonFactory(_names, _random);
            _adultFactory = new RandomAdultFactory(_names, _adultData, _random);
        }

        /// <summary>
        /// Создаёт случайного ребёнка <see cref="Child"/>.
        /// </summary>
        /// <returns>
        /// Сгенерированный экземпляр <see cref="Child"/>.
        /// </returns>
        public Child Create()
        {
            Person basePerson = _personFactory.Create();
            Adult baseAdult = _adultFactory.Create();

            var child = new Child
            {
                Gender = basePerson.Gender,
                Name = basePerson.Name,
                Surname = basePerson.Surname
            };

            child.Age = _random.Next(0, Child.MaxAgeChild + 1);

            Adult? mother = baseAdult.Gender == Gender.Female 
                ? baseAdult 
                : baseAdult.Partner;

            Adult? father = baseAdult.Gender == Gender.Male 
                ? baseAdult 
                : baseAdult.Partner;

            child.SetParents(mother, father);

            //TODO: magic (to const) + 
            string education = child.Age < MinAgeForSchool
                ? _random.NextItem(_childData.KinderGardens, 
                    nameof(_childData.KinderGardens))
                : _random.NextItem(_childData.Schools, 
                    nameof(_childData.Schools));

            child.SetEducationPlace(education);

            return child;
        }
    }
}
