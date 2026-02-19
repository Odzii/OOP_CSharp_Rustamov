namespace Model.Factories
{
    public sealed class RandomChildFactory : IPersonFactory<Child>
    {
        private readonly Random _random;
        private readonly IPersonFactory<Person> _personFactory;
        private readonly IPersonFactory<Adult> _adultFactory;
        private readonly FileDataSource _childData;

        public RandomChildFactory(FileDataSource childData, Random random)
        {
            _childData = childData ?? throw new ArgumentNullException(nameof(childData));
            _random = random ?? throw new ArgumentNullException(nameof(random));

            // создаём фабрики после проверок
            _personFactory = new RandomPersonFactory(_childData, _random);
            _adultFactory = new RandomAdultFactory(_childData, _random);
        }

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

            child.Age = _random.Next(0, Limits.ChildMaxAge + 1);

            Adult? mother = baseAdult.Gender == Gender.Female 
                ? baseAdult 
                : baseAdult.Partner;

            Adult? father = baseAdult.Gender == Gender.Male 
                ? baseAdult 
                : baseAdult.Partner;

            child.SetParents(mother, father);

            string education = child.Age < 7
                ? _random.NextItem(_childData.KinderGardens, 
                    nameof(_childData.KinderGardens))
                : _random.NextItem(_childData.Schools, 
                    nameof(_childData.Schools));

            child.SetEducationPlace(education);

            return child;
        }
    }
}
