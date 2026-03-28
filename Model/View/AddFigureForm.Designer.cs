namespace View
{
    /// <summary>
    /// Класс, который содиржит объекты формы связанные 
    /// с добавлением параметров и выбора типа фигур в отдельной форме,
    /// которые вызываются с использованием кнопки "добавить".
    /// </summary>
    partial class AddFigureForm
    {
        /// <summary>
        /// Контейнер, содержащий компоненты формы.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освобождает ресурсы, используемые формой.
        /// </summary>
        /// <param name="disposing">
        /// Значение <c>true</c>, если нужно освободить управляемые ресурсы;
        /// иначе — <c>false</c>.
        /// </param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Инициализирует компоненты формы 
        /// и задаёт начальные значения их свойств.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddFigureForm));
            FigureTypeLabel = new Label();
            FigureTypeComboBox = new ComboBox();
            SpherePanel = new Panel();
            SphereRadiusTextBox = new TextBox();
            RadiusLabel = new Label();
            PyramidPanel = new Panel();
            PyramidBaseWidthTextBox = new TextBox();
            PyramidHeightTextBox = new TextBox();
            HeightPyramidLabel = new Label();
            WidthBasePyramidLabel = new Label();
            PyramidBaseLengthTextBox = new TextBox();
            LengthBasePyramidLabel = new Label();
            ParallelepipedPanel = new Panel();
            ParallelepipedHeightTextBox = new TextBox();
            ParallelepipedWidthTextBox = new TextBox();
            HeightParallelepipedLabel = new Label();
            WidthParallelepipedLabel = new Label();
            ParallelepipedLengthTextBox = new TextBox();
            LengthParallelepipedLabel = new Label();
            OkButton = new Button();
            CancelButton = new Button();
            CreateRandomDataButton = new Button();
            SpherePanel.SuspendLayout();
            PyramidPanel.SuspendLayout();
            ParallelepipedPanel.SuspendLayout();
            SuspendLayout();
            // 
            // FigureTypeLabel
            // 
            FigureTypeLabel.AutoSize = true;
            FigureTypeLabel.Location = new Point(36, 25);
            FigureTypeLabel.Name = "FigureTypeLabel";
            FigureTypeLabel.RightToLeft = RightToLeft.No;
            FigureTypeLabel.Size = new Size(73, 15);
            FigureTypeLabel.TabIndex = 0;
            FigureTypeLabel.Text = "Тип фигуры";
            // 
            // FigureTypeComboBox
            // 
            FigureTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            FigureTypeComboBox.FormattingEnabled = true;
            FigureTypeComboBox.Location = new Point(168, 21);
            FigureTypeComboBox.Name = "FigureTypeComboBox";
            FigureTypeComboBox.RightToLeft = RightToLeft.No;
            FigureTypeComboBox.Size = new Size(171, 23);
            FigureTypeComboBox.TabIndex = 0;
            FigureTypeComboBox.SelectedIndexChanged += FigureTypeComboBox_SelectedIndexChanged;
            // 
            // SpherePanel
            // 
            SpherePanel.Controls.Add(SphereRadiusTextBox);
            SpherePanel.Controls.Add(RadiusLabel);
            SpherePanel.Location = new Point(24, 61);
            SpherePanel.Name = "SpherePanel";
            SpherePanel.RightToLeft = RightToLeft.No;
            SpherePanel.Size = new Size(329, 99);
            SpherePanel.TabIndex = 2;
            // 
            // SphereRadiusTextBox
            // 
            SphereRadiusTextBox.Location = new Point(144, 8);
            SphereRadiusTextBox.Name = "SphereRadiusTextBox";
            SphereRadiusTextBox.Size = new Size(171, 23);
            SphereRadiusTextBox.TabIndex = 1;
            // 
            // RadiusLabel
            // 
            RadiusLabel.AutoSize = true;
            RadiusLabel.Location = new Point(12, 12);
            RadiusLabel.Name = "RadiusLabel";
            RadiusLabel.Size = new Size(48, 15);
            RadiusLabel.TabIndex = 0;
            RadiusLabel.Text = "Радиус:";
            // 
            // PyramidPanel
            // 
            PyramidPanel.Controls.Add(PyramidBaseWidthTextBox);
            PyramidPanel.Controls.Add(PyramidHeightTextBox);
            PyramidPanel.Controls.Add(HeightPyramidLabel);
            PyramidPanel.Controls.Add(WidthBasePyramidLabel);
            PyramidPanel.Controls.Add(PyramidBaseLengthTextBox);
            PyramidPanel.Controls.Add(LengthBasePyramidLabel);
            PyramidPanel.Location = new Point(24, 61);
            PyramidPanel.Name = "PyramidPanel";
            PyramidPanel.RightToLeft = RightToLeft.No;
            PyramidPanel.Size = new Size(329, 99);
            PyramidPanel.TabIndex = 3;
            // 
            // PyramidBaseWidthTextBox
            // 
            PyramidBaseWidthTextBox.Location = new Point(144, 38);
            PyramidBaseWidthTextBox.Name = "PyramidBaseWidthTextBox";
            PyramidBaseWidthTextBox.Size = new Size(171, 23);
            PyramidBaseWidthTextBox.TabIndex = 2;
            // 
            // PyramidHeightTextBox
            // 
            PyramidHeightTextBox.Location = new Point(144, 68);
            PyramidHeightTextBox.Name = "PyramidHeightTextBox";
            PyramidHeightTextBox.Size = new Size(171, 23);
            PyramidHeightTextBox.TabIndex = 3;
            // 
            // HeightPyramidLabel
            // 
            HeightPyramidLabel.AutoSize = true;
            HeightPyramidLabel.Location = new Point(12, 72);
            HeightPyramidLabel.Name = "HeightPyramidLabel";
            HeightPyramidLabel.Size = new Size(50, 15);
            HeightPyramidLabel.TabIndex = 4;
            HeightPyramidLabel.Text = "Высота:";
            // 
            // WidthBasePyramidLabel
            // 
            WidthBasePyramidLabel.AutoSize = true;
            WidthBasePyramidLabel.Location = new Point(12, 42);
            WidthBasePyramidLabel.Name = "WidthBasePyramidLabel";
            WidthBasePyramidLabel.Size = new Size(117, 15);
            WidthBasePyramidLabel.TabIndex = 2;
            WidthBasePyramidLabel.Text = "Ширина основания:";
            WidthBasePyramidLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // PyramidBaseLengthTextBox
            // 
            PyramidBaseLengthTextBox.Location = new Point(144, 8);
            PyramidBaseLengthTextBox.Name = "PyramidBaseLengthTextBox";
            PyramidBaseLengthTextBox.Size = new Size(171, 23);
            PyramidBaseLengthTextBox.TabIndex = 1;
            // 
            // LengthBasePyramidLabel
            // 
            LengthBasePyramidLabel.AutoSize = true;
            LengthBasePyramidLabel.Location = new Point(12, 12);
            LengthBasePyramidLabel.Name = "LengthBasePyramidLabel";
            LengthBasePyramidLabel.Size = new Size(107, 15);
            LengthBasePyramidLabel.TabIndex = 0;
            LengthBasePyramidLabel.Text = "Длина основания:";
            // 
            // ParallelepipedPanel
            // 
            ParallelepipedPanel.Controls.Add(ParallelepipedHeightTextBox);
            ParallelepipedPanel.Controls.Add(ParallelepipedWidthTextBox);
            ParallelepipedPanel.Controls.Add(HeightParallelepipedLabel);
            ParallelepipedPanel.Controls.Add(WidthParallelepipedLabel);
            ParallelepipedPanel.Controls.Add(ParallelepipedLengthTextBox);
            ParallelepipedPanel.Controls.Add(LengthParallelepipedLabel);
            ParallelepipedPanel.Location = new Point(24, 61);
            ParallelepipedPanel.Name = "ParallelepipedPanel";
            ParallelepipedPanel.RightToLeft = RightToLeft.No;
            ParallelepipedPanel.Size = new Size(329, 99);
            ParallelepipedPanel.TabIndex = 4;
            // 
            // ParallelepipedHeightTextBox
            // 
            ParallelepipedHeightTextBox.Location = new Point(144, 68);
            ParallelepipedHeightTextBox.Name = "ParallelepipedHeightTextBox";
            ParallelepipedHeightTextBox.Size = new Size(171, 23);
            ParallelepipedHeightTextBox.TabIndex = 6;
            // 
            // ParallelepipedWidthTextBox
            // 
            ParallelepipedWidthTextBox.Location = new Point(144, 38);
            ParallelepipedWidthTextBox.Name = "ParallelepipedWidthTextBox";
            ParallelepipedWidthTextBox.Size = new Size(171, 23);
            ParallelepipedWidthTextBox.TabIndex = 5;
            // 
            // HeightParallelepipedLabel
            // 
            HeightParallelepipedLabel.AutoSize = true;
            HeightParallelepipedLabel.Location = new Point(12, 72);
            HeightParallelepipedLabel.Name = "HeightParallelepipedLabel";
            HeightParallelepipedLabel.Size = new Size(50, 15);
            HeightParallelepipedLabel.TabIndex = 4;
            HeightParallelepipedLabel.Text = "Высота:";
            // 
            // WidthParallelepipedLabel
            // 
            WidthParallelepipedLabel.AutoSize = true;
            WidthParallelepipedLabel.Location = new Point(12, 42);
            WidthParallelepipedLabel.Name = "WidthParallelepipedLabel";
            WidthParallelepipedLabel.Size = new Size(55, 15);
            WidthParallelepipedLabel.TabIndex = 2;
            WidthParallelepipedLabel.Text = "Ширина:";
            // 
            // ParallelepipedLengthTextBox
            // 
            ParallelepipedLengthTextBox.Location = new Point(144, 8);
            ParallelepipedLengthTextBox.Name = "ParallelepipedLengthTextBox";
            ParallelepipedLengthTextBox.Size = new Size(171, 23);
            ParallelepipedLengthTextBox.TabIndex = 1;
            // 
            // LengthParallelepipedLabel
            // 
            LengthParallelepipedLabel.AutoSize = true;
            LengthParallelepipedLabel.Location = new Point(12, 12);
            LengthParallelepipedLabel.Name = "LengthParallelepipedLabel";
            LengthParallelepipedLabel.Size = new Size(45, 15);
            LengthParallelepipedLabel.TabIndex = 0;
            LengthParallelepipedLabel.Text = "Длина:";
            // 
            // OkButton
            // 
            OkButton.DialogResult = DialogResult.OK;
            OkButton.Location = new Point(178, 180);
            OkButton.Name = "OkButton";
            OkButton.Size = new Size(75, 23);
            OkButton.TabIndex = 5;
            OkButton.Text = "Ок";
            OkButton.UseVisualStyleBackColor = true;
            OkButton.Click += OkButton_Click;
            // 
            // CancelButton
            // 
            CancelButton.DialogResult = DialogResult.Cancel;
            CancelButton.Location = new Point(263, 180);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(75, 23);
            CancelButton.TabIndex = 6;
            CancelButton.Text = "Отмена";
            CancelButton.UseVisualStyleBackColor = true;
            // 
            // CreateRandomDataButton
            // 
            CreateRandomDataButton.Location = new Point(36, 180);
            CreateRandomDataButton.Name = "CreateRandomDataButton";
            CreateRandomDataButton.RightToLeft = RightToLeft.No;
            CreateRandomDataButton.Size = new Size(131, 23);
            CreateRandomDataButton.TabIndex = 4;
            CreateRandomDataButton.Text = "Случайно";
            CreateRandomDataButton.UseVisualStyleBackColor = true;
            CreateRandomDataButton.Click += CreateRandomDataButton_Click;
            // 
            // AddFigureForm
            // 
            AcceptButton = OkButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(372, 220);
            Controls.Add(PyramidPanel);
            Controls.Add(CreateRandomDataButton);
            Controls.Add(CancelButton);
            Controls.Add(OkButton);
            Controls.Add(FigureTypeComboBox);
            Controls.Add(FigureTypeLabel);
            Controls.Add(ParallelepipedPanel);
            Controls.Add(SpherePanel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddFigureForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Добавить фигуру";
            SpherePanel.ResumeLayout(false);
            SpherePanel.PerformLayout();
            PyramidPanel.ResumeLayout(false);
            PyramidPanel.PerformLayout();
            ParallelepipedPanel.ResumeLayout(false);
            ParallelepipedPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        /// <summary>
        /// Ярлык для выбора типа фигуры.
        /// </summary>
        private Label FigureTypeLabel;

        /// <summary>
        /// Выпадающий список с доступными типами фигур.
        /// </summary>
        private ComboBox FigureTypeComboBox;

        /// <summary>
        /// Панель с параметрами сферы.
        /// </summary>
        private Panel SpherePanel;

        /// <summary>
        /// Текстовое поле для ввода радиуса сферы.
        /// </summary>
        private TextBox SphereRadiusTextBox;

        /// <summary>
        /// Ярлык для поля радиуса.
        /// </summary>
        private Label RadiusLabel;

        /// <summary>
        /// Панель с параметрами пирамиды.
        /// </summary>
        private Panel PyramidPanel;

        /// <summary>
        /// Ярлык для поля высоты пирамиды.
        /// </summary>
        private Label HeightPyramidLabel;

        /// <summary>
        /// Ярлык для поля ширины основания пирамиды.
        /// </summary>
        private Label WidthBasePyramidLabel;

        /// <summary>
        /// Текстовое поле для ввода длины основания пирамиды.
        /// </summary>
        private TextBox PyramidBaseLengthTextBox;

        /// <summary>
        /// Ярлык для поля длины основания пирамиды.
        /// </summary>
        private Label LengthBasePyramidLabel;

        /// <summary>
        /// Панель с параметрами параллелепипеда.
        /// </summary>
        private Panel ParallelepipedPanel;

        /// <summary>
        /// Текстовое поле для ввода высоты пирамиды.
        /// </summary>
        private TextBox PyramidHeightTextBox;

        /// <summary>
        /// Ярлык для поля высоты параллелепипеда.
        /// </summary>
        private Label HeightParallelepipedLabel;

        /// <summary>
        /// Ярлык для поля ширины параллелепипеда.
        /// </summary>
        private Label WidthParallelepipedLabel;

        /// <summary>
        /// Текстовое поле для ввода длины параллелепипеда.
        /// </summary>
        private TextBox ParallelepipedLengthTextBox;

        /// <summary>
        /// Ярлык для поля длины параллелепипеда.
        /// </summary>
        private Label LengthParallelepipedLabel;

        /// <summary>
        /// Текстовое поле для ввода ширины основания пирамиды.
        /// </summary>
        private TextBox PyramidBaseWidthTextBox;

        /// <summary>
        /// Текстовое поле для ввода высоты параллелепипеда.
        /// </summary>
        private TextBox ParallelepipedHeightTextBox;

        /// <summary>
        /// Текстовое поле для ввода ширины параллелепипеда.
        /// </summary>
        private TextBox ParallelepipedWidthTextBox;

        /// <summary>
        /// Кнопка подтверждения действия.
        /// </summary>
        private Button OkButton;

        /// <summary>
        /// Кнопка отмены действия.
        /// </summary>
        private Button CancelButton;

        /// <summary>
        /// Кнопка для автоматического заполнения полей случайными данными.
        /// </summary>
        private Button CreateRandomDataButton;
    }
}