using System;

namespace LabFirst.Helpers
{
    internal static class RussianVowelsHelper
    {
        private const string RussianVowels = "аеёиоуыэюя";

        public static string FixFemaleRussianSurname(string surname, Gender gender)
        {
            if (string.IsNullOrWhiteSpace(surname))
                return surname;

            if (gender == Gender.Female
                && LooksLikeRussianWord(surname)
                && !EndsWithRussianVowel(surname))
            {
                return surname + "а";
            }

            return surname;
        }

        private static bool LooksLikeRussianWord(string text)
        {
            foreach (char ch in text)
            {
                if (IsCyrillicLetter(ch))
                    return true;
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
            char lastChar = char.ToLowerInvariant(text[^1]);
            return RussianVowels.IndexOf(lastChar) >= 0;
        }

        public static string GetGenderText(Person person)
        {
            bool isRussian = person.IsRussian;

            if (!isRussian)
                return person.Gender.ToString();

            return person.Gender == Gender.Male ? "Мужской" : "Женский";
        }
    }
}
