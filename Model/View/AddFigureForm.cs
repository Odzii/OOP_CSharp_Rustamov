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
    public partial class addFigureForm : Form
    {
        private readonly Random _random = new();

        public addFigureForm()
        {
            InitializeComponent();

            figureTypeComboBox.Items.Add("Сфера");
            figureTypeComboBox.Items.Add("Пирамида");
            figureTypeComboBox.Items.Add("Параллелепипед");
            figureTypeComboBox.SelectedIndex = 0;

            UpdatePanelIsVisibility();

#if !DEBUG
            createRandomDataButton.Visible = false;
#endif
        }

        public VolumeFigureBase? CreatedFigure { get; private set; }

        private void UpdatePanelIsVisibility()
        {
            string selectedType = figureTypeComboBox.SelectedItem?.ToString()
                ?? string.Empty;

            spherePanel.Visible = true;
            pyramidPanel.Visible = selectedType == "Пирамида";
            parallelepipedPanel.Visible = selectedType == "Параллелепипед";
        }

        private void figureTypeComboBox_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            UpdatePanelIsVisibility();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            try
            {
                CreatedFigure = CreateFigureFromForm();
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Ошибочный ввод",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                DialogResult = DialogResult.None;
            }
        }

        private static double ParsePositiveDouble(string text, string fieldName)
        {
            string normalizedText = text.Trim();

            bool parsed =
                double.TryParse(normalizedText, out double value);

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

            if (value <= 0)
            {
                throw new ArgumentException(
                    $"Field \"{fieldName}\" must be greater than zero.");
            }

            return value;
        }

        private VolumeFigureBase CreateFigureFromForm()
        {
            string selectedType = figureTypeComboBox.SelectedItem?.ToString()
                ?? string.Empty;

            switch (selectedType)
            {
                case "Сфера":
                    {
                        double radius = ParsePositiveDouble(
                            sphereRadiusTextBox.Text,
                            "Radius");

                        return new Sphere(radius);
                    }

                case "Пирамида":
                    {
                        double baseLength = ParsePositiveDouble(
                            pyramidBaseLengthTextBox.Text,
                            "Base length");

                        double baseWidth = ParsePositiveDouble(
                            pyramidBaseWidthTextBox.Text,
                            "Base width");

                        double height = ParsePositiveDouble(
                            pyramidHeightTextBox.Text,
                            "Height");

                        return new Pyramid(baseLength, baseWidth, height);
                    }

                case "Параллелепипед":
                    {
                        double length = ParsePositiveDouble(
                            parallelepipedLengthTextBox.Text,
                            "Length");

                        double width = ParsePositiveDouble(
                            parallelepipedWidthTextBox.Text,
                            "Width");

                        double height = ParsePositiveDouble(
                            parallelepipedHeightTextBox.Text,
                            "Height");

                        return new Parallelepiped(length, width, height);
                    }

                default:
                    {
                        throw new InvalidOperationException(
                            "Figure type is not selected.");
                    }
            }
        }

        private void spherePanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void addFigureForm_Load(object sender, EventArgs e)
        {

        }

        private void createRandomDataButton_Click(object sender, EventArgs e)
        {
            string selectedType = figureTypeComboBox.SelectedItem?.ToString() ?? string.Empty;

            switch (selectedType)
            {
                case "Сфера":
                    {
                        sphereRadiusTextBox.Text = NextPositiveDouble(1, 20).ToString("F2");
                        break;
                    }

                case "Пирамида":
                    {
                        pyramidBaseLengthTextBox.Text = NextPositiveDouble(1, 20).ToString("F2");
                        pyramidBaseWidthTextBox.Text = NextPositiveDouble(1, 20).ToString("F2");
                        pyramidHeightTextBox.Text = NextPositiveDouble(1, 20).ToString("F2");
                        break;
                    }

                case "Параллелепипед":
                    {
                        parallelepipedLengthTextBox.Text = NextPositiveDouble(1, 20).ToString("F2");
                        parallelepipedWidthTextBox.Text = NextPositiveDouble(1, 20).ToString("F2");
                        parallelepipedHeightTextBox.Text = NextPositiveDouble(1, 20).ToString("F2");
                        break;
                    }
            }
        }

        private double NextPositiveDouble(double min, double max)
        {
            return min + _random.NextDouble() * (max - min);
        }



    }

}

