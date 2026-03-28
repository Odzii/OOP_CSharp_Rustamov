using System.Globalization;

namespace View.Helper
{
    /// <summary>
    /// Предоставляет методы для проверки и преобразования строкового ввода в
    /// положительные вещественные числа.
    /// </summary>
    /// </remarks> Содержит методы по обработке double и Nullable<double>.</remarks>
    internal static class Validation
    {
        /// <summary>
        /// Преобразует обязательное строковое значение в положительное число 
        /// типа <see cref="double"/>.
        /// </summary>
        /// <param name="text">Строка содержащая числовое значение.</param>
        /// <param name="fieldName">Отображаемое имя поля, 
        /// используемое в тексте ошибок.</param>
        /// <returns>Положительное конечное число типа <see cref="double"/>
        /// </returns>
        internal static double ParseRequiredPositiveDouble(
            string text,
            string fieldName)
        {
            return ParsePositiveDouble(text, fieldName, allowEmpty: false).Value;
        }

        /// <summary>
        /// Преобразует необязательное строковое значение в положительное число
        /// или в случае пустой строки допускает <see cref="Nullable\"double"\"/>
        /// типа <see cref="double"/>.
        /// </summary>
        /// <param name="text">Строка, содержащая числовое значение.</param>
        /// <param name="fieldName">Отображаемое имя поля, используемое в тексте ошибок.</param>
        /// <returns>Положительное конечное число типа <see cref="double"/>,
        /// либо <see langword="null"/>, если ввод пустой.</returns>
        internal static double? ParseOptionalPositiveDouble(
            string text,
            string fieldName)
        {
            return ParsePositiveDouble(text, fieldName, allowEmpty: true);
        }

        /// <summary>
        /// Выполняет общую проверку и преобразование строкового значения
        /// в положительное число типа <see cref="double"/>.
        /// </summary>
        /// <param name="text">Строка, содержащая числовое значение.</param>
        /// <param name="fieldName">Отображаемое имя поля, 
        /// используемое в тексте ошибок.</param>
        /// <param name="allowEmpty">
        /// Флаг, указывающий, допускается ли пустое значение.
        /// </param>
        /// <returns>Положительное конечное число типа <see cref="double"/>,
        /// либо <see langword="null"/>, если пустой ввод допустим.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Возникает, если обязательное поле не заполнено
        /// или если значение имеет некорректный формат.
        /// </exception>
        /// <exception cref="NotFiniteNumberException">
        /// Возникает, если введённое значение не является конечным числом.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Возникает, если введённое значение меньше или равно нулю.
        /// </exception>
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
