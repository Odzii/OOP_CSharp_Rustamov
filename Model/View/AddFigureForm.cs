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

            FigureTypeComboBox.Items.Add("Сфера");
            FigureTypeComboBox.Items.Add("Пирамида");
            FigureTypeComboBox.Items.Add("Параллелепипед");
            FigureTypeComboBox.SelectedIndex = 0;

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
            string selectedType = FigureTypeComboBox.SelectedItem?.ToString()
                ?? string.Empty;

            SpherePanel.Visible = selectedType == "Сфера";
            PyramidPanel.Visible = selectedType == "Пирамида";
            ParallelepipedPanel.Visible = selectedType == "Параллелепипед";
        }

        /// <summary>
        /// Обрабатывает изменение выбранного типа фигуры в выпадающем списке.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void FigureTypeComboBox_SelectedIndexChanged(
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
        private void OkButton_Click(object sender, EventArgs e)
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
                    this,
                    ex.Message,
                    "Ошибочный ввод",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                DialogResult = DialogResult.None;
            }
        }

        //TODO: duplication
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
            string selectedType = FigureTypeComboBox.SelectedItem?.ToString()
                ?? string.Empty;

            switch (selectedType)
            {
                //TODО: отступы
                case "Сфера":
                    {
                        double radius = ParsePositiveDouble(
                            SphereRadiusTextBox.Text,
                            "Радиус");

                        return new Sphere(radius);
                    }

                case "Пирамида":
                    {
                        double baseLength = ParsePositiveDouble(
                            PyramidBaseLengthTextBox.Text,
                            "Длина основания");

                        double baseWidth = ParsePositiveDouble(
                            PyramidBaseWidthTextBox.Text,
                            "Ширина основания");

                        double height = ParsePositiveDouble(
                            PyramidHeightTextBox.Text,
                            "Высота");

                        return new Pyramid(baseLength, baseWidth, height);
                    }

                case "Параллелепипед":
                    {
                        double length = ParsePositiveDouble(
                            ParallelepipedLengthTextBox.Text,
                            "Длина");

                        double width = ParsePositiveDouble(
                            ParallelepipedWidthTextBox.Text,
                            "Ширина");

                        double height = ParsePositiveDouble(
                            ParallelepipedHeightTextBox.Text,
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

        //TODO: условная компиляция
        /// <summary>
        /// Обрабатывает событие загрузки формы.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void CreateRandomDataButton_Click(object sender, EventArgs e)
        {
            string selectedType
                = FigureTypeComboBox.SelectedItem?.ToString() ?? string.Empty;

            switch (selectedType)
            {
                //TODО: отступы
                case "Сфера":
                    {
                        SphereRadiusTextBox.Text
                            = NextPositiveDouble(1, 20).ToString("F2");
                        break;
                    }

                case "Пирамида":
                    {
                        PyramidBaseLengthTextBox.Text
                            = NextPositiveDouble(1, 20).ToString("F2");
                        PyramidBaseWidthTextBox.Text
                            = NextPositiveDouble(1, 20).ToString("F2");
                        PyramidHeightTextBox.Text
                            = NextPositiveDouble(1, 20).ToString("F2");
                        break;
                    }

                case "Параллелепипед":
                    {
                        ParallelepipedLengthTextBox.Text
                            = NextPositiveDouble(1, 20).ToString("F2");
                        ParallelepipedWidthTextBox.Text
                            = NextPositiveDouble(1, 20).ToString("F2");
                        ParallelepipedHeightTextBox.Text
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

