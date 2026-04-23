using Model;
using System.Data;
using System.Linq;
using View.Helper;

namespace View
{
    /// <summary>
    /// Представляет форму поиска фигур по общим критериям.
    /// </summary>
    /// <remarks>
    /// Форма позволяет выполнять поиск по типу фигуры и диапазону объёма,
    /// а затем отображать найденные результаты в таблице.
    /// </remarks>
    public partial class FindFigureForm : Form
    {
        /// <summary>
        /// Список фигур, среди которых выполняется поиск.
        /// </summary>
        private readonly List<VolumeFigureBase> _figures;

        /// <summary>
        /// Инициализирует новый экземпляр формы <see cref="FindFigureForm"/>.
        /// </summary>
        /// <param name="figures">Список фигур, 
        /// переданный с главной формы.</param>
        public FindFigureForm(List<VolumeFigureBase> figures)
        {
            InitializeComponent();
            _figures = figures;
            //TODO: duplication
            FigureTypeComboBox.Items.Add("Все");
            FigureTypeComboBox.Items.Add("Сфера");
            FigureTypeComboBox.Items.Add("Пирамида");
            FigureTypeComboBox.Items.Add("Параллелепипед");
            FigureTypeComboBox.SelectedIndex = 0;
        }

        /// <summary>
        /// Форматирует объём фигуры для удобного отображения в таблице.
        /// </summary>
        /// <param name="volume">Объём фигуры.</param>
        /// <returns>
        /// Строковое представление объёма с шестью знаками после запятой.
        /// </returns>
        private static string FormatVolume(double volume)
        {
            //TODO: duplication
            return volume.ToString("F6");
        }


        /// <summary>
        /// Обновляет таблицу результатов поиска.
        /// </summary>
        /// <param name="figures">
        /// Коллекция фигур, которые нужно отобразить.
        /// </param>
        private void RefreshResultsGrid(IEnumerable<VolumeFigureBase> figures)
        {
            ResultsDataGridView.Rows.Clear();
            foreach (var figure in figures)
            {
                ResultsDataGridView.Rows.Add(
                    figure.FigureType,
                    FormatVolume(figure.Volume),
                    figure.GetDescription());
            }
        }

        /// <summary>
        /// Выполняет поиск фигур по выбранному типу и диапазону объёма.
        /// </summary>
        /// <returns>
        /// Список фигур, соответствующих выбранному типу и заданным ограничениям
        /// по минимальному и максимальному объёму.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Выбрасывается, если минимальный или максимальный объём
        /// не является положительным конечным числом,
        /// либо если минимальный объём больше максимального.</exception>
        private List<VolumeFigureBase> FindFigures()
        {
            string selectedType = FigureTypeComboBox.SelectedItem?.ToString()
                ?? "Все";

            bool isMinValid = Validation.TryParseOptionalPositiveDouble(
                MinVolumeTextBox,
                out double? minVolume);

            bool isMaxValid = Validation.TryParseOptionalPositiveDouble(
                MaxVolumeTextBox,
                out double? maxVolume);

            if (!isMinValid || !isMaxValid)
            {
                throw new ArgumentException(
                    "Минимальный и максимальный объём должны быть " +
                    "положительными и конечными числами.");
            }

            if (minVolume.HasValue && maxVolume.HasValue && minVolume > maxVolume)
            {
                throw new ArgumentException(
                    "Минимальный объём не должен быть больше максимального.");
            }

            IEnumerable<VolumeFigureBase> query = _figures;

            if (selectedType != "Все")
            {
                query = query.Where(figure => figure.FigureType == selectedType);
            }

            if (minVolume.HasValue)
            {
                query = query.Where(figure => figure.Volume >= minVolume.Value);
            }

            if (maxVolume.HasValue)
            {
                query = query.Where(figure => figure.Volume <= maxVolume.Value);
            }

            return query.ToList();
        }

        /// <summary>
        /// Обрабатывает нажатие кнопки поиска,
        /// выполняет поиск и выводит найденные результаты в таблицу.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void SearchButtonClick(object sender, EventArgs e)
        {
            try
            {
                List<VolumeFigureBase> foundFigures = FindFigures();
                RefreshResultsGrid(foundFigures);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    this,
                    ex.Message,
                    "Ошибка поиска",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
