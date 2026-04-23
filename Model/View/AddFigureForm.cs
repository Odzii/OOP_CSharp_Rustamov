using Model;
using View.Helper;
using static System.Net.Mime.MediaTypeNames;

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
#if DEBUG
        /// <summary>
        /// Генератор случайных чисел, 
        /// используемый для заполнения формы тестовыми данными.
        /// </summary>
        private readonly Random _random = new();
#endif

        /// <summary>
        /// Инициализирует новый экземпляр формы <see cref="AddFigureForm"/>.
        /// </summary>
        public AddFigureForm()
        {
            InitializeComponent();
            
            //TODO: duplication
            FigureTypeComboBox.Items.Add("Сфера");
            FigureTypeComboBox.Items.Add("Пирамида");
            FigureTypeComboBox.Items.Add("Параллелепипед");
            FigureTypeComboBox.SelectedIndex = 0;

            UpdatePanelIsVisibility();

#if DEBUG
            CreateRandomDataButton.Visible = true;
#endif
        }

        /// <summary>
        /// Хранит созданную фигуру после успешного подтверждения формы.
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

            //TODO: duplication
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
        /// Обработчик нажатия кнопки <c>OK</c>.
        /// Создаёт фигуру и закрывает форму с <see cref="DialogResult.OK"/> ,
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

        /// <summary>
        /// Создает фигуру в зависимости от выбранного в форме типа
        /// </summary>
        /// <returns>
        /// Экземпляр <see cref="VolumeFigureBase"/>, соответствующий выбранному типу фигуры
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Выбрасывается, если тип фигуры не выбран</exception>
        private VolumeFigureBase CreateFigureFromForm()
        {
            ResetCurrentFigureTextBoxes();

            string selectedType = FigureTypeComboBox.SelectedItem?.ToString() ?? string.Empty;

            return selectedType switch
            {
                //TODO: duplication
                "Сфера" => CreateSphere(),
                "Пирамида" => CreatePyramid(),
                "Параллелепипед" => CreateParallelepiped(),
                _ => throw new InvalidOperationException("Тип фигуры не выбран.")
            };
        }
        /// <summary>
        /// Создаёт объект сферы на основе значения радиуса, введённого в форме.
        /// </summary>
        /// <returns>
        /// Экземпляр <see cref="Sphere"/> с указанным радиусом.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Выбрасывается, если радиус не является положительным конечным числом.
        /// </exception>
        private Sphere CreateSphere()
        {
            if (!Validation.TryParsePositiveDouble(SphereRadiusTextBox, out double radius))
            {
                throw new ArgumentException(
                    "Радиус должен быть положительным и конечным числом.");
            }

            return new Sphere(radius);
        }
        /// <summary>
        /// Создаёт объект пирамиды на основе значений 
        /// длины, ширины основания и высоты, введённых в форме.
        /// </summary>
        /// <returns>
        /// Экземпляр <see cref="Pyramid"/> с указанными параметрами основания и высоты.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Выбрасывается, если длина, ширина основания или высота
        /// не являются положительными конечными числами.
        /// </exception>
        private Pyramid CreatePyramid()
        {
            bool isValid = true;

            isValid &= Validation.TryParsePositiveDouble(
                PyramidBaseLengthTextBox, out double baseLength);
            isValid &= Validation.TryParsePositiveDouble(
                PyramidBaseWidthTextBox, out double baseWidth);
            isValid &= Validation.TryParsePositiveDouble(
                PyramidHeightTextBox, out double height);

            if (!isValid)
            {
                throw new ArgumentException(
                    "Длина, ширина и высота должны быть положительными " +
                    "и конечными числами.");
            }

            return new Pyramid(baseLength, baseWidth, height);
        }

        /// <summary>
        /// Создаёт объект параллелепипеда на основе значений длины, ширины и высоты,
        /// введённых в форме.
        /// </summary>
        /// //TODO: RSDN
        /// <returns>Экземпляр <see cref="Parallelepiped"/> с указанными длиной, шириной и высотой.</returns>
        /// <exception cref="ArgumentException">
        /// Выбрасывается, если длина, ширина или высота
        /// не являются положительными конечными числами.
        /// </exception>
        private Parallelepiped CreateParallelepiped()
        {
            bool isValid = true;

            isValid &= Validation.TryParsePositiveDouble(
                ParallelepipedLengthTextBox, out double length);
            isValid &= Validation.TryParsePositiveDouble(
                ParallelepipedWidthTextBox, out double width);
            isValid &= Validation.TryParsePositiveDouble(
                ParallelepipedHeightTextBox, out double height);

            if (!isValid)
            {
                throw new ArgumentException(
                    "Длина, ширина и высота должны быть положительными " +
                    "и конечными числами.");
            }

            return new Parallelepiped(length, width, height);
        }


        /// <summary>
        /// Сбрасывает текстовые поля, относящиеся к текущему выбранному типу фигуры.
        /// </summary>
        private void ResetCurrentFigureTextBoxes()
        {
            string selectedType = FigureTypeComboBox.SelectedItem?.ToString() ?? string.Empty;

            switch (selectedType)
            {
                //TODO: duplication
                case "Сфера":
                {
                    ResetTextBoxes(SphereRadiusTextBox);
                    break;
                }

                case "Пирамида":
                {
                    ResetTextBoxes(
                    PyramidBaseLengthTextBox,
                    PyramidBaseWidthTextBox,
                    PyramidHeightTextBox);
                    break;
                }

                case "Параллелепипед":
                {
                        //TODО: отступы
                    ResetTextBoxes(
                    ParallelepipedLengthTextBox,
                    ParallelepipedWidthTextBox,
                    ParallelepipedHeightTextBox);
                    break;
                }
            }
        }

        /// <summary>
        /// Сбрасывает цвет фона указанных текстовых полей 
        /// к стандартному системному значению.
        /// </summary>
        /// <param name="textBoxes">
        /// Массив текстовых полей, для которых необходимо сбросить цвет фона.
        /// </param>
        private void ResetTextBoxes(params TextBox[] textBoxes)
        {
            foreach (TextBox textBox in textBoxes)
            {
                textBox.BackColor = SystemColors.Window;
            }
        }



#if DEBUG
        /// <summary>
        /// Формирует случайные положительные вещественные числа типа double.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void CreateRandomDataButton_Click(object sender, EventArgs e)
        {
            string selectedType
                = FigureTypeComboBox.SelectedItem?.ToString() ?? string.Empty;

            switch (selectedType)
            {
                //TODO: duplication
                case "Сфера":
                {
                    SphereRadiusTextBox.Text
                            //TODO: to const
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
#endif
    }

}

