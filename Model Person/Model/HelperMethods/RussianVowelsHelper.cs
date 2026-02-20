namespace Model.Helpers
{
    //TODO: XML +
    /// <summary>
    /// Вспомогательные методы для работы с русскими словами
    /// и отображением пола в русскоязычном виде.
    /// </summary>
    internal static class RussianVowelsHelper
    {
        /// <summary>
        /// Набор русских гласных букв в нижнем регистре.
        /// Используется для проверки окончания слова.
        /// </summary>
        private const string RussianVowels = "аеёиоуыэюя";

        /// <summary>
        /// Корректирует русскую фамилию для женского пола.
        /// Если фамилия похожа на русское слово 
        /// и не оканчивается на русскую гласную,
        /// то для женского пола добавляется буква «а» на конце.
        /// </summary>
        /// <param name="surname">
        /// Фамилия (исходное значение).
        /// </param>
        /// <param name="gender">Пол человека.</param>
        /// <returns>
        /// Исправленная фамилия (для женского пола), 
        /// либо исходная фамилия без изменений.
        /// </returns>
        /// <remarks>
        /// Если <paramref name="surname"/> пустая или состоит только из пробелов, 
        /// возвращается исходное значение.
        /// </remarks>
        public static string FixFemaleRussianSurname(
            string surname, 
            Gender gender
        )
        {
            if (string.IsNullOrWhiteSpace(surname))
            {
                return surname;
            }

            if (gender == Gender.Female
                && LooksLikeRussianWord(surname)
                && !EndsWithRussianVowel(surname))
            {
                return surname + "а";
            }

            return surname;
        }

        /// <summary>
        /// Проверяет, похожа ли строка на русское слово:
        /// возвращает <see langword="true"/>, 
        /// если в строке есть хотя бы одна кириллическая буква.
        /// </summary>
        /// <param name="text">Проверяемый текст.</param>
        /// <returns>
        /// <see langword="true"/>, если строка содержит кириллические буквы;
        /// иначе <see langword="false"/>.
        /// </returns>
        private static bool LooksLikeRussianWord(string text)
        {
            foreach (char ch in text)
            {
                if (IsCyrillicLetter(ch))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Определяет, является ли символ кириллической буквой (включая «ё»).
        /// </summary>
        /// <param name="ch">Проверяемый символ.</param>
        /// <returns>
        /// <see langword="true"/>, если символ — кириллическая буква; 
        /// иначе <see langword="false"/>.
        /// </returns>
        private static bool IsCyrillicLetter(char ch)
        {
            ch = char.ToLowerInvariant(ch);
            return ch is >= 'а' and <= 'я' or 'ё';
        }

        /// <summary>
        /// Проверяет, оканчивается ли строка на русскую гласную букву.
        /// </summary>
        /// <param name="text">
        /// Проверяемый текст.
        /// </param>
        /// <returns>
        /// <see langword="true"/>, если последний символ строки русская гласная
        /// иначе <see langword="false"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Может возникнуть при передаче пустой строки.
        /// </exception>
        private static bool EndsWithRussianVowel(string text)
        {
            char lastChar = char.ToLowerInvariant(text[^1]);
            return RussianVowels.IndexOf(lastChar) >= 0;
        }

        /// <summary>
        /// Возвращает текстовое представление пола человека.
        /// Для русскоязычных людей возвращается «Мужской» или «Женский»,
        /// иначе — строковое представление перечисления <see cref="Gender"/>.
        /// </summary>
        /// <param name="person">Человек, 
        /// для которого нужно получить текст пола.</param>
        /// <returns>Строка с представлением пола.</returns>
        /// <exception cref="ArgumentNullException">
        /// Бросается, если <paramref name="person"/> 
        /// равен <see langword="null"/>.
        /// </exception>
        public static string GetGenderText(Person person)
        {
            bool isRussian = person.IsRussian;

            if (!isRussian)
                return person.Gender.ToString();

            return person.Gender == Gender.Male 
                ? "Мужской" 
                : "Женский";
        }
    }
}
