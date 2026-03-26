using Model;

namespace View
{
    /// <summary>
    /// Представляет форму добавления новой объёмной фигуры.
    /// </summary>
    /// <remarks>
    /// Форма позволяет пользователю выбрать тип фигуры, ввести её параметры,
    /// сгенерировать случайные данные для отладки и создать объект модели.
    /// После успешного подтверждения созданная фигура сохраняется в свойстве
    /// <see cref="CreatedFigure"/>.
    /// </remarks>
    public partial class AddFigureForm : Form
    {
        /// <summary>
        /// Генератор случайных чисел, 
        /// используемый для заполнения формы тестовыми данными.
        /// </summary>
        private readonly Random _random = new();

        /// <summary>
        /// Инициализирует новый экземпляр формы <see cref="AddFigureForm"/>.
        /// </summary>
        public AddFigureForm()
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

        /// <summary>
        /// Получает созданную фигуру после успешного подтверждения формы.
        /// </summary>
        /// <value>
        /// Экземпляр <see cref="VolumeFigureBase"/>, 
        /// если пользователь корректно ввёл данные
        /// и нажал кнопку <c>OK</c>; иначе <see langword="null"/>.
        /// </value>
        public VolumeFigureBase? CreatedFigure 
        {   
            get; 
            private set; 
        }

        /// <summary>
        /// Обновляет видимость панелей ввода 
        /// в зависимости от выбранного типа фигуры.
        /// </summary>
        private void UpdatePanelIsVisibility()
        {
            string selectedType = figureTypeComboBox.SelectedItem?.ToString()
                ?? string.Empty;

            spherePanel.Visible = selectedType == "Сфера";
            pyramidPanel.Visible = selectedType == "Пирамида";
            parallelepipedPanel.Visible = selectedType == "Параллелепипед";
        }

        /// <summary>
        /// Обрабатывает изменение выбранного типа фигуры в выпадающем списке.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void figureTypeComboBox_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            UpdatePanelIsVisibility();
        }

        /// <summary>
        /// Обрабатывает изменение выбранного типа фигуры в выпадающем списке.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
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

        /// <summary>
        /// Обрабатывает нажатие кнопки <c>OK</c>, 
        /// создаёт фигуру по введённым данным
        /// и закрывает форму при успешном завершении.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private static double ParsePositiveDouble(string text, string fieldName)
        {
            string normalizedText = text.Trim();

            bool parsed =
                double.TryParse(normalizedText, out double value);

            if (!parsed)
            {
                throw new ArgumentException(
                    $"Поле \"{fieldName}\" содержит некорректное число.");
            }

            if (!double.IsFinite(value))
            {
                throw new ArgumentException(
                    $"Поле \"{fieldName}\" должно содержать конечное число.");
            }

            if (value <= 0)
            {
                throw new ArgumentException(
                    $"Поле \"{fieldName}\" должно быть больше нуля.");
            }

            return value;
        }

        /// <summary>
        /// Создаёт объект фигуры на основе выбранного типа 
        /// и введённых пользователем параметров.
        /// </summary>
        /// <returns>Созданный экземпляр фигуры, 
        /// наследуемой от <see cref="VolumeFigureBase"/>.</returns>
        /// <exception cref="InvalidOperationException">
        /// Выбрасывается, если тип фигуры не выбран или не поддерживается.
        /// </exception>
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
                            "Радиус");

                        return new Sphere(radius);
                    }

                case "Пирамида":
                    {
                        double baseLength = ParsePositiveDouble(
                            pyramidBaseLengthTextBox.Text,
                            "Длина основания");

                        double baseWidth = ParsePositiveDouble(
                            pyramidBaseWidthTextBox.Text,
                            "Ширина основания");

                        double height = ParsePositiveDouble(
                            pyramidHeightTextBox.Text,
                            "Высота");

                        return new Pyramid(baseLength, baseWidth, height);
                    }

                case "Параллелепипед":
                    {
                        double length = ParsePositiveDouble(
                            parallelepipedLengthTextBox.Text,
                            "Длина");

                        double width = ParsePositiveDouble(
                            parallelepipedWidthTextBox.Text,
                            "Ширина");

                        double height = ParsePositiveDouble(
                            parallelepipedHeightTextBox.Text,
                            "Высота");

                        return new Parallelepiped(length, width, height);
                    }

                default:
                    {
                        throw new InvalidOperationException(
                            "Тип фигуры не выбран");
                    }
            }
        }

        /// <summary>
        /// Обрабатывает событие загрузки формы.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void createRandomDataButton_Click(object sender, EventArgs e)
        {
            string selectedType 
                = figureTypeComboBox.SelectedItem?.ToString() ?? string.Empty;

            switch (selectedType)
            {
                case "Сфера":
                    {
                        sphereRadiusTextBox.Text 
                            = NextPositiveDouble(1, 20).ToString("F2");
                        break;
                    }

                case "Пирамида":
                    {
                        pyramidBaseLengthTextBox.Text 
                            = NextPositiveDouble(1, 20).ToString("F2");
                        pyramidBaseWidthTextBox.Text 
                            = NextPositiveDouble(1, 20).ToString("F2");
                        pyramidHeightTextBox.Text 
                            = NextPositiveDouble(1, 20).ToString("F2");
                        break;
                    }

                case "Параллелепипед":
                    {
                        parallelepipedLengthTextBox.Text 
                            = NextPositiveDouble(1, 20).ToString("F2");
                        parallelepipedWidthTextBox.Text 
                            = NextPositiveDouble(1, 20).ToString("F2");
                        parallelepipedHeightTextBox.Text 
                            = NextPositiveDouble(1, 20).ToString("F2");
                        break;
                    }
            }
        }

        /// <summary>
        /// Обрабатывает нажатие кнопки генерации случайных данных
        /// и заполняет поля формы корректными тестовыми значениями.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private double NextPositiveDouble(double min, double max)
        {
            return min + _random.NextDouble() * (max - min);
        }
    }

}

