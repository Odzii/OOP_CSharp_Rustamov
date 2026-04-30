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
#if DEBUG
        /// <summary>
        /// Генератор случайных чисел, 
        /// используемый для заполнения формы тестовыми данными.
        /// </summary>
        private readonly Random _random = new();
#endif

        /// <summary>
        /// Хранит соответствие между типом фигуры и действиями,
        /// выполняемыми для этого типа фигуры.
        /// </summary>
        private readonly Dictionary<FigureType, (
            Func<VolumeFigureBase> create,
            Action setVisible,
            Action reset,
            Action generateRandom)> _figureMap;

        /// <summary>
        /// Инициализирует новый экземпляр формы <see cref="AddFigureForm"/>.
        /// </summary>
        public AddFigureForm()
        {
            InitializeComponent();
            string precision = FormatPrecision.Short;
            _figureMap = new Dictionary<FigureType, (
                Func<VolumeFigureBase>,
                Action,
                Action,
                Action)>
            {
                [FigureType.Sphere] = (
                    () => CreateSphere(),
                    () => ShowOnly(SpherePanel),
                    () => ResetTextBoxes(SphereRadiusTextBox),
                    () => SphereRadiusTextBox.Text 
                        = NextPositiveDouble(1, 20).ToString(precision)
                ),

                [FigureType.Pyramid] = (
                    () => CreatePyramid(),
                    () => ShowOnly(PyramidPanel),
                    () => ResetTextBoxes(
                        PyramidBaseLengthTextBox,
                        PyramidBaseWidthTextBox,
                        PyramidHeightTextBox),
                    () =>
                    {
                        PyramidBaseLengthTextBox.Text 
                            = NextPositiveDouble(1, 20).ToString(precision);
                        PyramidBaseWidthTextBox.Text 
                            = NextPositiveDouble(1, 20).ToString(precision);
                        PyramidHeightTextBox.Text 
                            = NextPositiveDouble(1, 20).ToString(precision);
                    }
                ),

                [FigureType.Parallelepiped] = (
                    () => CreateParallelepiped(),
                    () => ShowOnly(ParallelepipedPanel),
                    () => ResetTextBoxes(
                        ParallelepipedLengthTextBox,
                        ParallelepipedWidthTextBox,
                        ParallelepipedHeightTextBox),
                    () =>
                    {
                        string precision = FormatPrecision.Short;
                        ParallelepipedLengthTextBox.Text 
                            = NextPositiveDouble(1, 20).ToString(precision);
                        ParallelepipedWidthTextBox.Text 
                            = NextPositiveDouble(1, 20).ToString(precision);
                        ParallelepipedHeightTextBox.Text 
                            = NextPositiveDouble(1, 20).ToString(precision);
                    }
                )
            };

            FigureTypeComboBox.DataSource = Enum
                .GetValues(typeof(FigureType))
                .Cast<FigureType>()
                .Select(x => new { Value = x, Name = x.ToDisplay() })
                .ToList();

            FigureTypeComboBox.DisplayMember = "Name";
            FigureTypeComboBox.ValueMember = "Value";

            FigureTypeComboBox.SelectedIndex = 0;
            UpdatePanelIsVisibility();
            
#if DEBUG
            CreateRandomDataButton.Visible = true;
#endif
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
        /// 
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
        /// 
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
        /// Создаёт экземпляр <see cref="Parallelepiped"/> на основе значений длины,
        /// ширины и высоты, введённых в форме.
        /// </summary>
        /// <returns>
        /// Экземпляр <see cref="Parallelepiped"/> с длиной, шириной и высотой,
        /// указанными в полях формы.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Возникает, если в полях длины, ширины или высоты указаны значения,
        /// которые не являются положительными конечными числами.
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



#if DEBUG
        /// <summary>
        /// Формирует случайные положительные вещественные числа типа double.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void CreateRandomDataButton_Click(object sender, EventArgs e)
        {
            var type = (FigureType)FigureTypeComboBox.SelectedValue;

            if (_figureMap.TryGetValue(type, out var handlers))
            {
                handlers.generateRandom();
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

