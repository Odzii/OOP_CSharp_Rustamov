using System.Globalization;

namespace View.Helper
{
    //TODO: XML
    internal static class Validation
    {
        internal static double ParseRequiredPositiveDouble(
            string text,
            string fieldName)
        {
            return ParsePositiveDouble(text, fieldName, allowEmpty: false).Value;
        }

        internal static double? ParseOptionalPositiveDouble(
            string text,
            string fieldName)
        {
            return ParsePositiveDouble(text, fieldName, allowEmpty: true);
        }

        private static double? ParsePositiveDouble(
            string text,
            string fieldName,
            bool allowEmpty)
        {
            string normalizedText = text.Trim();

            if (string.IsNullOrWhiteSpace(normalizedText))
            {
                if (allowEmpty)
                {
                    return null;
                }

                throw new ArgumentException(
                    $"Поле \"{fieldName}\" обязательно для заполнения");
            }

            bool isValidNumber = 
                double.TryParse(normalizedText, NumberStyles.Float,
                    CultureInfo.CurrentCulture, out double value)
                || double.TryParse(normalizedText, NumberStyles.Float,
                    CultureInfo.InvariantCulture, out value);

            if (!isValidNumber)
            {
                throw new ArgumentException(
                    $"Поле \"{fieldName}\" содержит неверный формат числа. " +
                    $"Введите, например, 10,5 или 10.5.");
            }

            if (!double.IsFinite(value))
            {
                throw new NotFiniteNumberException(
                    $"Поле \"{fieldName}\" должно содержать конечное число.");
            }

            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(
                    fieldName,
                    $"Поле \"{fieldName}\" должно быть больше нуля.");
            }

            return value;
        }
    }
}
