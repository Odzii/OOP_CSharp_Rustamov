using System;

namespace LabFirst
{
    /// <summary>
    /// Создаёт случайные экземпляры <see cref="Person"/> на основе источника имён.
    /// </summary>
    public sealed class RandomPersonFactory : IPersonFactory
    {
        private const int GenderVariantsCount = 2;
        private const string RussianVowels = "аеёиоуыэюя";

        private readonly INameSource _names;
        private readonly Random _random;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="RandomPersonFactory"/>.
        /// </summary>
        /// <param name="names">Источник имён и фамилий.</param>
        /// <param name="random">Генератор случайных чисел.</param>
        /// <exception cref="ArgumentNullException">
        /// Бросается, если <paramref name="names"/> 
        /// или <paramref name="random"/> равны <see langword="null"/>.
        /// </exception>
        public RandomPersonFactory(INameSource names, Random random)
        {
            _names = names ?? throw new ArgumentNullException(nameof(names));
            _random = random ?? throw new ArgumentNullException(nameof(random));
        }

        /// <summary>
        /// Создаёт случайного человека.
        /// </summary>
        /// <returns>Случайно сгенерированный экземпляр 
        /// <see cref="Person"/>.</returns>
        /// <exception cref="InvalidOperationException">
        /// Бросается, если в <see cref="INameSource"/> 
        /// отсутствуют данные (пустые списки имён/фамилий).
        /// </exception>
        public Person Create()
        {
            Gender gender = CreateRandomGender();

            string name = gender == Gender.Male
                ? GetRandomItem(_names.MaleNames, nameof(_names.MaleNames))
                : GetRandomItem(_names.FemaleNames, nameof(_names.FemaleNames));

            string surname = GetRandomItem(_names.Surnames, nameof(_names.Surnames));

            
            if (gender == Gender.Female 
                && LooksLikeRussianWord(surname) 
                && !EndsWithRussianVowel(surname)
            )
            {
                surname += "а";
            }

            int age = _random.Next(Person.MinAge, Person.MaxAge + 1);

            return new Person(name, surname, age, gender);
        }

        private Gender CreateRandomGender()
        {
            return _random.Next(GenderVariantsCount) == 0
                ? Gender.Male
                : Gender.Female;
        }

        private string GetRandomItem(
            System.Collections.Generic.IReadOnlyList<string> items, 
            string listName
        )
        {
            if (items is null || items.Count == 0)
            {
                throw new InvalidOperationException(
                    $"Источник данных не содержит элементов: {listName}."
                );
            }

            return items[_random.Next(items.Count)];
        }

        private static bool LooksLikeRussianWord(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return false;
            }

            foreach (char ch in text)
            {
                if (IsCyrillicLetter(ch))
                {
                    return true;
                }
            }

            return false;
        }
        private static bool IsCyrillicLetter(char ch)
        {
            ch = char.ToLowerInvariant(ch);
            return ch is >= 'а' and <= 'я' or 'ё';
        }

        private static bool EndsWithRussianVowel(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return false;
            }

            char lastChar = char.ToLowerInvariant(text[^1]);
            return RussianVowels.IndexOf(lastChar) >= 0;
        }
    }
}
