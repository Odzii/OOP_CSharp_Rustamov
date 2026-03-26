namespace View
{
    partial class FindFigureForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
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
            // figureTypeLabel
            // 
            FigureTypeLabel.Location = new Point(29, 9);
            FigureTypeLabel.Name = "figureTypeLabel";
            FigureTypeLabel.Size = new Size(73, 15);
            FigureTypeLabel.TabIndex = 0;
            FigureTypeLabel.Text = "Тип фигуры";
            // 
            // maxVolumeLabel
            // 
            MaxVolumeLabel.Location = new Point(441, 9);
            MaxVolumeLabel.Name = "maxVolumeLabel";
            MaxVolumeLabel.Size = new Size(133, 15);
            MaxVolumeLabel.TabIndex = 4;
            MaxVolumeLabel.Text = "Максимальный объем";
            // 
            // maxVolumeTextBox
            // 
            MaxVolumeTextBox.Location = new Point(441, 36);
            MaxVolumeTextBox.Name = "maxVolumeTextBox";
            MaxVolumeTextBox.Size = new Size(179, 23);
            MaxVolumeTextBox.TabIndex = 2;
            // 
            // searchButton
            // 
            SearchButton.Location = new Point(636, 35);
            SearchButton.Name = "searchButton";
            SearchButton.Size = new Size(75, 23);
            SearchButton.TabIndex = 3;
            SearchButton.Text = "Поиск";
            SearchButton.UseVisualStyleBackColor = true;
            SearchButton.Click += SearchButtonClick;
            // 
            // button2
            // 
            CloseButton.DialogResult = DialogResult.Cancel;
            CloseButton.Location = new Point(717, 35);
            CloseButton.Name = "button2";
            CloseButton.Size = new Size(75, 23);
            CloseButton.TabIndex = 4;
            CloseButton.Text = "Закрыть";
            CloseButton.UseVisualStyleBackColor = true;
            // 
            // minVolumeTextBox
            // 
            MinVolumeTextBox.Location = new Point(242, 36);
            MinVolumeTextBox.Name = "minVolumeTextBox";
            MinVolumeTextBox.Size = new Size(179, 23);
            MinVolumeTextBox.TabIndex = 1;
            // 
            // minVolumeLabel
            // 
            MinVolumeLabel.Location = new Point(242, 9);
            MinVolumeLabel.Name = "minVolumeLabel";
            MinVolumeLabel.Size = new Size(129, 15);
            MinVolumeLabel.TabIndex = 9;
            MinVolumeLabel.Text = "Минимальный объем";
            // 
            // figureTypeComboBox
            // 
            FigureTypeComboBox.FormattingEnabled = true;
            FigureTypeComboBox.Location = new Point(29, 36);
            FigureTypeComboBox.Name = "figureTypeComboBox";
            FigureTypeComboBox.Size = new Size(179, 23);
            FigureTypeComboBox.TabIndex = 0;
            // 
            // resultsDataGridView
            // 
            ResultsDataGridView.AllowUserToAddRows = false;
            ResultsDataGridView.AllowUserToDeleteRows = false;
            ResultsDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ResultsDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ResultsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ResultsDataGridView.Columns.AddRange(new DataGridViewColumn[] { ResultTyoeColumn, ResultVolumeColumn, ResultDescriptionColumn });
            ResultsDataGridView.Location = new Point(29, 81);
            ResultsDataGridView.MultiSelect = false;
            ResultsDataGridView.Name = "resultsDataGridView";
            ResultsDataGridView.ReadOnly = true;
            ResultsDataGridView.RowHeadersVisible = false;
            ResultsDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ResultsDataGridView.Size = new Size(763, 181);
            ResultsDataGridView.TabIndex = 5;
            // 
            // resultTyoeColumn
            // 
            ResultTyoeColumn.HeaderText = "Тип";
            ResultTyoeColumn.Name = "resultTyoeColumn";
            ResultTyoeColumn.ReadOnly = true;
            // 
            // resultVolumeColumn
            // 
            ResultVolumeColumn.HeaderText = "Объем";
            ResultVolumeColumn.Name = "resultVolumeColumn";
            ResultVolumeColumn.ReadOnly = true;
            // 
            // resultDescriptionColumn
            // 
            ResultDescriptionColumn.HeaderText = "Описание";
            ResultDescriptionColumn.Name = "resultDescriptionColumn";
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
            Name = "FindFigureForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Поиск фигуры";
            ((System.ComponentModel.ISupportInitialize)ResultsDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label FigureTypeLabel;
        private Label MaxVolumeLabel;
        private TextBox MaxVolumeTextBox;
        private Button SearchButton;
        private Button CloseButton;
        private TextBox MinVolumeTextBox;
        private Label MinVolumeLabel;
        private ComboBox FigureTypeComboBox;
        private DataGridView ResultsDataGridView;
        private DataGridViewTextBoxColumn ResultTyoeColumn;
        private DataGridViewTextBoxColumn ResultVolumeColumn;
        private DataGridViewTextBoxColumn ResultDescriptionColumn;
    }
}