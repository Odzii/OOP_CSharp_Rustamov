using System.Globalization;

namespace View.Helper
{
    /// <summary>
    /// Методы проверки и преобразования строкового ввода в положительные числа.
    /// </summary>
    internal static class Validation
    {
        /// <summary>
        /// Проверяет обязательное поле на положительное число.
        /// </summary>
        internal static bool TryParsePositiveDouble(
            TextBox textBox,
            out double inputUser)
        {
            textBox.BackColor = SystemColors.Window;
            string normalizedText = textBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(normalizedText))
            {
                textBox.BackColor = Color.MistyRose;
                inputUser = 0;
                return false;
            }

            bool isDouble =
                double.TryParse(
                    normalizedText,
                    NumberStyles.Float,
                    CultureInfo.CurrentCulture,
                    out inputUser)
                || double.TryParse(
                    normalizedText,
                    NumberStyles.Float,
                    CultureInfo.InvariantCulture,
                    out inputUser);

            if (!isDouble || !double.IsFinite(inputUser) || inputUser <= 0)
            {
                textBox.BackColor = Color.MistyRose;
                inputUser = 0;
                return false;
            }

            return true;
        }

        /// <summary>
        /// Проверяет необязательное поле на положительное число.
        /// Пустая строка допустима.
        /// </summary>
        internal static bool TryParseOptionalPositiveDouble(
            TextBox textBox,
            out double? value)
        {
            textBox.BackColor = SystemColors.Window;
            string normalizedText = textBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(normalizedText))
            {
                value = null;
                return true;
            }

            bool isDouble =
                double.TryParse(
                    normalizedText,
                    NumberStyles.Float,
                    CultureInfo.CurrentCulture,
                    out double inputUser)
                || double.TryParse(
                    normalizedText,
                    NumberStyles.Float,
                    CultureInfo.InvariantCulture,
                    out inputUser);

            if (!isDouble || !double.IsFinite(inputUser) || inputUser <= 0)
            {
                textBox.BackColor = Color.MistyRose;
                value = null;
                return false;
            }

            value = inputUser;
            return true;
        }
    }
}