using System;

namespace Model.Factories
{
    //TODO: WTF?
    /// <summary>
    /// Создаёт случайный экземпляр класса <see cref="PersonBase"/> 
    /// на основе источника имён.
    /// </summary>
    public sealed class RandomPersonFactory : IPersonFactory<PersonBase>
    {
        /// <summary>
        /// Количество возможных значений пола, используемых при генерации.
        /// </summary>
        private const int GenderVariantsCount = 2;

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
        /// класса <see cref="PersonBase"/>.
        /// </summary>
        /// <param name="names">Имя, фамилия.</param>
        /// <param name="random">
        /// Экземпляр класса <see cref="Random"/>.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Бросается, если <paramref name="names"/> 
        /// или <paramref name="random"/> равны <see langword="null"/>.
        /// </exception>
        public RandomPersonFactory(IPersonNameSource names, Random random)
        {
            _names = names 
                ?? throw new ArgumentNullException(nameof(names));

            _random = random 
                ?? throw new ArgumentNullException(nameof(random));
        }

        /// <summary>
        /// Создаёт случайного человека.
        /// </summary>
        /// <returns>
        /// Случайно сгенерированный экземпляр <see cref="PersonBase"/>
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Бросается, если в <see cref="IPersonNameSource"/> отсутствуют данные
        /// (пустые списки имён/фамилий).
        /// </exception>
        public PersonBase Create()
        {
            Gender gender = CreateRandomGender();

            string name = gender == Gender.Male
                ? _random.NextItem(
                        _names.MaleNames, 
                        nameof(_names.MaleNames)
                    )
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

            int age = _random.Next(
                    PersonBase.MinAgePerson, 
                    PersonBase.MaxAgePerson + 1
                );

            return age < Adult.MinAgeAdult
                ? new Child(name, surname, age, gender)
                : new Adult(name, surname, age, gender);
        }

        /// <summary>
        /// Выбор <see cref="Gender"/>, из числа доступных.
        /// </summary>
        /// <returns>Случайно выбранный пол.</returns>
        private Gender CreateRandomGender()
        {
            return _random.Next(GenderVariantsCount) == 0
                ? Gender.Male
                : Gender.Female;
        }
    }
}
