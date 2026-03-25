using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View
{
    public partial class FindFigureForm : Form
    {
        private readonly List<VolumeFigureBase> _figures;

        public FindFigureForm(List<VolumeFigureBase> figures)
        {
            InitializeComponent();
            _figures = figures;

            figureTypeComboBox.Items.Add("Все");
            figureTypeComboBox.Items.Add("Сфера");
            figureTypeComboBox.Items.Add("Пирамида");
            figureTypeComboBox.Items.Add("Параллелепипед");
            figureTypeComboBox.SelectedIndex = 0;
        }

        private static string FormatVolume(double volume)
        {
            return volume.ToString("F6");
        }

        private static double? ParseOptionalDouble(
            string text,
            string fieldName)
        {
            string normalizedText = text.Trim();

            if (string.IsNullOrWhiteSpace(normalizedText))
            {
                return null;
            }

            bool parsed = double.TryParse(normalizedText, out double value);

            if (!parsed)
            {
                throw new ArgumentException(
                    $"Field \"{fieldName}\" contains an invalid number.");
            }

            if (!double.IsFinite(value))
            {
                throw new ArgumentException(
                    $"Field \"{fieldName}\" must contain a finite number.");
            }

            if (value < 0)
            {
                throw new ArgumentException(
                    $"Field \"{fieldName}\" must not be negative.");
            }

            return value;
        }

        private void RefreshResultsGrid(IEnumerable<VolumeFigureBase> figures)
        {
            resultsDataGridView.Rows.Clear();
            foreach (var figure in figures)
            {
                resultsDataGridView.Rows.Add(
                    figure.FigureType,
                    FormatVolume(figure.Volume),
                    figure.GetDescription());
            }
        }

        private List<VolumeFigureBase> FindFigures()
        {
            string selectedType = figureTypeComboBox.SelectedItem?.ToString()
                ?? "Все";

            double? minVolume = ParseOptionalDouble(
                minVolumeTextBox.Text,
                "Минимальный объем");
            double? maxVolume = ParseOptionalDouble(
                maxVolumeTextBox.Text,
                "Максимальный объем");

            if (minVolume.HasValue
                && maxVolume.HasValue
                && minVolume > maxVolume)
            {
                throw new ArgumentException(
                    "Min volume must not be greater than Max volume.");
            }

            IEnumerable<VolumeFigureBase> query = _figures;

            if (selectedType != "Все")
            {
                query = query.Where(
                    figure => figure.FigureType == selectedType);
            }

            if (minVolume.HasValue)
            {
                query = query.Where(
                    figure => figure.Volume >= minVolume.Value);
            }

            if (maxVolume.HasValue)
            {
                query = query.Where(
                    figure => figure.Volume <= maxVolume.Value);
            }

            return query.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                List<VolumeFigureBase> foundFigures = FindFigures();
                RefreshResultsGrid(foundFigures);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Ошибка поиска",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
