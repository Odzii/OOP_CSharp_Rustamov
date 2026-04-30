using System.Globalization;

namespace View.Helper
{
    //TODO: rename+
    /// <summary>
    /// Методы проверки и преобразования строкового ввода в положительные числа.
    /// </summary>
    internal static class Validator
    {
        /// <summary>
        /// Проверяет и разбирает положительное число из текстового поля.
        /// </summary>
        /// <param name="textBox">Поле ввода.</param>
        /// <param name="allowEmpty">
        /// true, если пустая строка допустима; иначе false.
        /// </param>
        /// <param name="value">
        /// Распознанное значение или null, если поле пустое и это допустимо.
        /// </param>
        /// <returns>
        /// true, если ввод корректен; иначе false.
        /// </returns>
        private static bool TryParsePositiveDoubleCore(
            TextBox textBox,
            bool allowEmpty,
            out double? value)
        {
            textBox.BackColor = SystemColors.Window;
            string normalizedText = textBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(normalizedText))
            {
                if (allowEmpty)
                {
                    value = null;
                    return true;
                }

                textBox.BackColor = Color.MistyRose;
                value = null;
                return false;
            }

            bool isParsed =
                double.TryParse(
                    normalizedText,
                    NumberStyles.Float,
                    CultureInfo.CurrentCulture,
                    out double parsedValue)
                || double.TryParse(
                    normalizedText,
                    NumberStyles.Float,
                    CultureInfo.InvariantCulture,
                    out parsedValue);

            if (!isParsed || !double.IsFinite(parsedValue) || parsedValue <= 0)
            {
                textBox.BackColor = Color.MistyRose;
                value = null;
                return false;
            }

            value = parsedValue;
            return true;
        }

        /// <summary>
        /// Проверяет обязательное поле на положительное число.
        /// </summary>
        internal static bool TryParsePositiveDouble(
            TextBox textBox,
            out double value)
        {
            bool isValid = TryParsePositiveDoubleCore(
                textBox,
                allowEmpty: false,
                out double? parsedValue);

            value = isValid ? parsedValue!.Value : 0;
            return isValid;
        }

        /// <summary>
        /// Проверяет необязательное поле на положительное число.
        /// Пустая строка допустима.
        /// </summary>
        internal static bool TryParseOptionalPositiveDouble(
            TextBox textBox,
            out double? value)
        {
            return TryParsePositiveDoubleCore(
                textBox,
                allowEmpty: true,
                out value);
        }
    }
}