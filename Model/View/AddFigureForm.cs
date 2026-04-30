using Model;
using View.Helper;

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
        //TODO: dupblication +
#if DEBUG
        /// <summary>
        /// Генератор случайных чисел, 
        /// используемый для заполнения формы тестовыми данными.
        /// </summary>
        private readonly Random _random = new();

        /// <summary>
        /// Хранит соответствие между типом фигуры
        /// и действием генерации случайных данных.
        /// </summary>
        private readonly Dictionary<FigureType, Action> _randomDataGenerators;
#endif

        /// <summary>
        /// Хранит соответствие между типом фигуры и действиями,
        /// выполняемыми для этого типа фигуры.
        /// </summary>
        private readonly Dictionary<FigureType, (
            Func<VolumeFigureBase> create,
            Action setVisible,
            Action reset)> _figureMap;

        /// <summary>
        /// Инициализирует новый экземпляр формы <see cref="AddFigureForm"/>.
        /// </summary>
        public AddFigureForm()
        {
            InitializeComponent();

            _figureMap = new Dictionary<FigureType, (
                Func<VolumeFigureBase> create,
                Action setVisible,
                Action reset)>
                {
                    [FigureType.Sphere] = (
                        () => CreateSphere(),
                        () => ShowOnly(SpherePanel),
                        () => ResetTextBoxes(SphereRadiusTextBox)
                    ),

                    [FigureType.Pyramid] = (
                        () => CreatePyramid(),
                        () => ShowOnly(PyramidPanel),
                        () => ResetTextBoxes(
                            PyramidBaseLengthTextBox,
                            PyramidBaseWidthTextBox,
                            PyramidHeightTextBox)
                    ),

                    [FigureType.Parallelepiped] = (
                        () => CreateParallelepiped(),
                        () => ShowOnly(ParallelepipedPanel),
                        () => ResetTextBoxes(
                            ParallelepipedLengthTextBox,
                            ParallelepipedWidthTextBox,
                            ParallelepipedHeightTextBox)
                    )
                };

#if DEBUG
    
            string precision = FormatPrecision.Short;

            _randomDataGenerators = new Dictionary<FigureType, Action>
            {
                [FigureType.Sphere] = () =>
                {
                    SphereRadiusTextBox.Text =
                        NextPositiveDouble(1, 20).ToString(precision);
                },

                [FigureType.Pyramid] = () =>
                {
                    PyramidBaseLengthTextBox.Text =
                        NextPositiveDouble(1, 20).ToString(precision);

                    PyramidBaseWidthTextBox.Text =
                        NextPositiveDouble(1, 20).ToString(precision);

                    PyramidHeightTextBox.Text =
                        NextPositiveDouble(1, 20).ToString(precision);
                },

                [FigureType.Parallelepiped] = () =>
                {
                    ParallelepipedLengthTextBox.Text =
                        NextPositiveDouble(1, 20).ToString(precision);

                    ParallelepipedWidthTextBox.Text =
                        NextPositiveDouble(1, 20).ToString(precision);

                    ParallelepipedHeightTextBox.Text =
                        NextPositiveDouble(1, 20).ToString(precision);
                }
            };

            CreateRandomDataButton.Visible = true;
#else
            CreateRandomDataButton.Visible = false;
#endif

            FigureTypeComboBox.DataSource = Enum
                .GetValues(typeof(FigureType))
                .Cast<FigureType>()
                .Select(x => new { Value = x, Name = x.ToDisplay() })
                .ToList();

            FigureTypeComboBox.DisplayMember = "Name";
            FigureTypeComboBox.ValueMember = "Value";

            FigureTypeComboBox.SelectedIndex = 0;
            UpdatePanelIsVisibility();
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
        /// Отображает только указанную панель ввода параметров фигуры,
        /// скрывая панели остальных типов фигур.
        /// </summary>
        /// <param name="panel">Панель, которую необходимо отобразить.</param>
        private void ShowOnly(Control panel)
        {
            SpherePanel.Visible = false;
            PyramidPanel.Visible = false;
            ParallelepipedPanel.Visible = false;

            panel.Visible = true;
        }

        /// <summary>
        /// Обновляет видимость панелей ввода 
        /// в зависимости от выбранного типа фигуры.
        /// </summary>
        private void UpdatePanelIsVisibility()
        {
            if (FigureTypeComboBox.SelectedValue is FigureType selectedType &&
                _figureMap.TryGetValue(selectedType, out var config))
            {
                config.setVisible();
            }
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
        /// Создаёт фигуру и закрывает форму с <see cref="DialogResult.OK"/>.
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
        /// Создаёт фигуру в зависимости от выбранного в форме типа.
        /// </summary>
        /// <returns>
        /// Экземпляр <see cref="VolumeFigureBase"/>, 
        /// соответствующий выбранному типу фигуры.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Выбрасывается, если тип фигуры не выбран.
        /// </exception>
        private VolumeFigureBase CreateFigureFromForm()
        {
            ResetCurrentFigureTextBoxes();

            if (FigureTypeComboBox.SelectedValue is FigureType selectedType &&
                _figureMap.TryGetValue(selectedType, out var config))
            {
                return config.create();
            }

            throw new InvalidOperationException("Тип фигуры не выбран.");
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
            if (!Validator.TryParsePositiveDouble(
                SphereRadiusTextBox, out double radius))
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
        /// Экземпляр <see cref="Pyramid"/> 
        /// с указанными параметрами основания и высоты.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Выбрасывается, если длина, ширина основания или высота
        /// не являются положительными конечными числами.
        /// </exception>
        private Pyramid CreatePyramid()
        {
            bool isValid = true;

            isValid &= Validator.TryParsePositiveDouble(
                PyramidBaseLengthTextBox, out double baseLength);

            isValid &= Validator.TryParsePositiveDouble(
                PyramidBaseWidthTextBox, out double baseWidth);

            isValid &= Validator.TryParsePositiveDouble(
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
        /// Создаёт экземпляр <see cref="Parallelepiped"/> 
        /// на основе значений длины, ширины и высоты, введённых в форме.
        /// </summary>
        /// <returns>
        /// Экземпляр <see cref="Parallelepiped"/> 
        /// с длиной, шириной и высотой, указанными в полях формы.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Возникает, если в полях длины, ширины или высоты указаны значения,
        /// которые не являются положительными конечными числами.
        /// </exception>
        private Parallelepiped CreateParallelepiped()
        {
            bool isValid = true;

            isValid &= Validator.TryParsePositiveDouble(
                ParallelepipedLengthTextBox, out double length);

            isValid &= Validator.TryParsePositiveDouble(
                ParallelepipedWidthTextBox, out double width);

            isValid &= Validator.TryParsePositiveDouble(
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
        /// Сбрасывает текстовые поля, относящиеся 
        /// к текущему выбранному типу фигуры.
        /// </summary>
        private void ResetCurrentFigureTextBoxes()
        {
            if (FigureTypeComboBox.SelectedValue is FigureType selectedType &&
                _figureMap.TryGetValue(selectedType, out var config))
            {
                config.reset();
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

        /// <summary>
        /// Обрабатывает нажатие кнопки генерации случайных данных.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void CreateRandomDataButton_Click(object sender, EventArgs e)
        {
#if DEBUG
            if (FigureTypeComboBox.SelectedValue is FigureType selectedType &&
                _randomDataGenerators.TryGetValue(
                    selectedType, out Action generateRandom))
            {
                generateRandom();
            }
#endif
        }

#if DEBUG
        /// <summary>
        /// Формирует случайное положительное вещественное число.
        /// </summary>
        /// <param name="min">Минимальное значение.</param>
        /// <param name="max">Максимальное значение.</param>
        /// <returns>
        /// Случайное положительное вещественное число.
        /// </returns>
        private double NextPositiveDouble(double min, double max)
        {
            return min + _random.NextDouble() * (max - min);
        }
#endif
    }
}