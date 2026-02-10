using System;
using LabFirst.Helpers;

namespace LabFirst
{
    /// <summary>
    /// Создаёт случайные экземпляры <see cref="Person"/> на основе источника имён.
    /// </summary>
    public sealed class RandomPersonFactory : IPersonFactory<Person>
    {
        private const int GenderVariantsCount = 2;

        private readonly IPersonNameSource _names;
        private readonly Random _random;

        public RandomPersonFactory(IPersonNameSource names, Random random)
        {
            _names = names ?? throw new ArgumentNullException(nameof(names));
            _random = random ?? throw new ArgumentNullException(nameof(random));
        }

        /// <summary>
        /// Создаёт случайного человека.
        /// </summary>
        /// <returns>Случайно сгенерированный экземпляр <see cref="Person"/>.</returns>
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

            int age = _random.Next(Person.MinAge, Person.MaxAge + 1);

            return new Person(name, surname, age, gender);
        }

        private Gender CreateRandomGender()
        {
            return _random.Next(GenderVariantsCount) == 0
                ? Gender.Male
                : Gender.Female;
        }
    }
}
