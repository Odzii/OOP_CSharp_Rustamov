namespace View
{
    /// <summary>
    /// Класс, который содиржит объекты формы связанные 
    /// с поиском фигур в отдельной форме,
    /// содержит фильтры по типу фигуры, верхней и нижней границы объема.
    /// </summary>
    partial class FindFigureForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FindFigureForm));
            FigureTypeLabel = new Label();
            MaxVolumeLabel = new Label();
            MaxVolumeTextBox = new TextBox();
            SearchButton = new Button();
            CloseButton = new Button();
            MinVolumeTextBox = new TextBox();
            MinVolumeLabel = new Label();
            FigureTypeComboBox = new ComboBox();
            ResultsDataGridView = new DataGridView();
            ResultTyoeColumn = new DataGridViewTextBoxColumn();
            ResultVolumeColumn = new DataGridViewTextBoxColumn();
            ResultDescriptionColumn = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)ResultsDataGridView).BeginInit();
            SuspendLayout();
            // 
            // FigureTypeLabel
            // 
            FigureTypeLabel.Location = new Point(29, 9);
            FigureTypeLabel.Name = "FigureTypeLabel";
            FigureTypeLabel.Size = new Size(73, 15);
            FigureTypeLabel.TabIndex = 0;
            FigureTypeLabel.Text = "Тип фигуры";
            // 
            // MaxVolumeLabel
            // 
            MaxVolumeLabel.Location = new Point(441, 9);
            MaxVolumeLabel.Name = "MaxVolumeLabel";
            MaxVolumeLabel.Size = new Size(133, 15);
            MaxVolumeLabel.TabIndex = 4;
            MaxVolumeLabel.Text = "Максимальный объем";
            // 
            // MaxVolumeTextBox
            // 
            MaxVolumeTextBox.Location = new Point(441, 36);
            MaxVolumeTextBox.Name = "MaxVolumeTextBox";
            MaxVolumeTextBox.Size = new Size(179, 23);
            MaxVolumeTextBox.TabIndex = 2;
            // 
            // SearchButton
            // 
            SearchButton.Location = new Point(636, 35);
            SearchButton.Name = "SearchButton";
            SearchButton.Size = new Size(75, 23);
            SearchButton.TabIndex = 3;
            SearchButton.Text = "Поиск";
            SearchButton.UseVisualStyleBackColor = true;
            SearchButton.Click += SearchButtonClick;
            // 
            // CloseButton
            // 
            CloseButton.DialogResult = DialogResult.Cancel;
            CloseButton.Location = new Point(717, 35);
            CloseButton.Name = "CloseButton";
            CloseButton.Size = new Size(75, 23);
            CloseButton.TabIndex = 4;
            CloseButton.Text = "Закрыть";
            CloseButton.UseVisualStyleBackColor = true;
            // 
            // MinVolumeTextBox
            // 
            MinVolumeTextBox.Location = new Point(242, 36);
            MinVolumeTextBox.Name = "MinVolumeTextBox";
            MinVolumeTextBox.Size = new Size(179, 23);
            MinVolumeTextBox.TabIndex = 1;
            // 
            // MinVolumeLabel
            // 
            MinVolumeLabel.Location = new Point(242, 9);
            MinVolumeLabel.Name = "MinVolumeLabel";
            MinVolumeLabel.Size = new Size(129, 15);
            MinVolumeLabel.TabIndex = 9;
            MinVolumeLabel.Text = "Минимальный объем";
            // 
            // FigureTypeComboBox
            // 
            FigureTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            FigureTypeComboBox.FormattingEnabled = true;
            FigureTypeComboBox.Location = new Point(29, 36);
            FigureTypeComboBox.Name = "FigureTypeComboBox";
            FigureTypeComboBox.Size = new Size(179, 23);
            FigureTypeComboBox.TabIndex = 0;
            // 
            // ResultsDataGridView
            // 
            ResultsDataGridView.AllowUserToAddRows = false;
            ResultsDataGridView.AllowUserToDeleteRows = false;
            ResultsDataGridView.AllowUserToResizeRows = false;
            ResultsDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ResultsDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ResultsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ResultsDataGridView.Columns.AddRange(new DataGridViewColumn[] { ResultTyoeColumn, ResultVolumeColumn, ResultDescriptionColumn });
            ResultsDataGridView.Location = new Point(29, 81);
            ResultsDataGridView.MultiSelect = false;
            ResultsDataGridView.Name = "ResultsDataGridView";
            ResultsDataGridView.ReadOnly = true;
            ResultsDataGridView.RowHeadersVisible = false;
            ResultsDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ResultsDataGridView.Size = new Size(763, 181);
            ResultsDataGridView.TabIndex = 5;
            // 
            // ResultTyoeColumn
            // 
            ResultTyoeColumn.HeaderText = "Тип";
            ResultTyoeColumn.Name = "ResultTyoeColumn";
            ResultTyoeColumn.ReadOnly = true;
            // 
            // ResultVolumeColumn
            // 
            ResultVolumeColumn.HeaderText = "Объем";
            ResultVolumeColumn.Name = "ResultVolumeColumn";
            ResultVolumeColumn.ReadOnly = true;
            // 
            // ResultDescriptionColumn
            // 
            ResultDescriptionColumn.HeaderText = "Описание";
            ResultDescriptionColumn.Name = "ResultDescriptionColumn";
            ResultDescriptionColumn.ReadOnly = true;
            // 
            // FindFigureForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(812, 277);
            Controls.Add(ResultsDataGridView);
            Controls.Add(FigureTypeComboBox);
            Controls.Add(MinVolumeLabel);
            Controls.Add(MinVolumeTextBox);
            Controls.Add(CloseButton);
            Controls.Add(SearchButton);
            Controls.Add(MaxVolumeTextBox);
            Controls.Add(MaxVolumeLabel);
            Controls.Add(FigureTypeLabel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(828, 316);
            Name = "FindFigureForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Поиск фигуры";
            ((System.ComponentModel.ISupportInitialize)ResultsDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        /// <summary>
        /// Ярлык для выбора типа фигуры.
        /// </summary>
        private Label FigureTypeLabel;

        /// <summary>
        /// Ярлык для поля максимального объёма.
        /// </summary>
        private Label MaxVolumeLabel;

        /// <summary>
        /// Текстовое поле для ввода максимального объёма.
        /// </summary>
        private TextBox MaxVolumeTextBox;

        /// <summary>
        /// Кнопка запуска поиска.
        /// </summary>
        private Button SearchButton;

        /// <summary>
        /// Кнопка закрытия формы.
        /// </summary>
        private Button CloseButton;

        /// <summary>
        /// Текстовое поле для ввода минимального объёма.
        /// </summary>
        private TextBox MinVolumeTextBox;

        /// <summary>
        /// Ярлык для поля минимального объёма.
        /// </summary>
        private Label MinVolumeLabel;

        /// <summary>
        /// Выпадающий список для выбора типа фигуры.
        /// </summary>
        private ComboBox FigureTypeComboBox;

        /// <summary>
        /// Таблица для отображения результатов поиска.
        /// </summary>
        private DataGridView ResultsDataGridView;

        /// <summary>
        /// Столбец таблицы с типом фигуры.
        /// </summary>
        private DataGridViewTextBoxColumn ResultTyoeColumn;

        /// <summary>
        /// Столбец таблицы с объёмом фигуры.
        /// </summary>
        private DataGridViewTextBoxColumn ResultVolumeColumn;

        /// <summary>
        /// Столбец таблицы с описанием фигуры.
        /// </summary>
        private DataGridViewTextBoxColumn ResultDescriptionColumn;
    }
}