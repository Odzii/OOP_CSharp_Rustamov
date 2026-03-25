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
            figureTypeLabel = new Label();
            maxVolumeLabel = new Label();
            maxVolumeTextBox = new TextBox();
            button1 = new Button();
            button2 = new Button();
            minVolumeTextBox = new TextBox();
            minVolumeLabel = new Label();
            figureTypeComboBox = new ComboBox();
            resultsDataGridView = new DataGridView();
            resultTyoeColumn = new DataGridViewTextBoxColumn();
            resultVolumeColumn = new DataGridViewTextBoxColumn();
            resultDescriptionColumn = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)resultsDataGridView).BeginInit();
            SuspendLayout();
            // 
            // figureTypeLabel
            // 
            figureTypeLabel.Location = new Point(29, 9);
            figureTypeLabel.Name = "figureTypeLabel";
            figureTypeLabel.Size = new Size(73, 15);
            figureTypeLabel.TabIndex = 0;
            figureTypeLabel.Text = "Тип фигуры";
            // 
            // maxVolumeLabel
            // 
            maxVolumeLabel.Location = new Point(441, 9);
            maxVolumeLabel.Name = "maxVolumeLabel";
            maxVolumeLabel.Size = new Size(133, 15);
            maxVolumeLabel.TabIndex = 4;
            maxVolumeLabel.Text = "Максимальный объем";
            // 
            // maxVolumeTextBox
            // 
            maxVolumeTextBox.Location = new Point(441, 36);
            maxVolumeTextBox.Name = "maxVolumeTextBox";
            maxVolumeTextBox.Size = new Size(179, 23);
            maxVolumeTextBox.TabIndex = 5;
            // 
            // button1
            // 
            button1.Location = new Point(636, 35);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 6;
            button1.Text = "Поиск";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.DialogResult = DialogResult.Cancel;
            button2.Location = new Point(717, 35);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 7;
            button2.Text = "Закрыть";
            button2.UseVisualStyleBackColor = true;
            // 
            // minVolumeTextBox
            // 
            minVolumeTextBox.Location = new Point(242, 36);
            minVolumeTextBox.Name = "minVolumeTextBox";
            minVolumeTextBox.Size = new Size(179, 23);
            minVolumeTextBox.TabIndex = 8;
            // 
            // minVolumeLabel
            // 
            minVolumeLabel.Location = new Point(242, 9);
            minVolumeLabel.Name = "minVolumeLabel";
            minVolumeLabel.Size = new Size(129, 15);
            minVolumeLabel.TabIndex = 9;
            minVolumeLabel.Text = "Минимальный объем";
            // 
            // figureTypeComboBox
            // 
            figureTypeComboBox.FormattingEnabled = true;
            figureTypeComboBox.Location = new Point(29, 36);
            figureTypeComboBox.Name = "figureTypeComboBox";
            figureTypeComboBox.Size = new Size(179, 23);
            figureTypeComboBox.TabIndex = 10;
            // 
            // resultsDataGridView
            // 
            resultsDataGridView.AllowUserToAddRows = false;
            resultsDataGridView.AllowUserToDeleteRows = false;
            resultsDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            resultsDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            resultsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resultsDataGridView.Columns.AddRange(new DataGridViewColumn[] { resultTyoeColumn, resultVolumeColumn, resultDescriptionColumn });
            resultsDataGridView.Location = new Point(29, 81);
            resultsDataGridView.MultiSelect = false;
            resultsDataGridView.Name = "resultsDataGridView";
            resultsDataGridView.ReadOnly = true;
            resultsDataGridView.RowHeadersVisible = false;
            resultsDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            resultsDataGridView.Size = new Size(763, 181);
            resultsDataGridView.TabIndex = 11;
            // 
            // resultTyoeColumn
            // 
            resultTyoeColumn.HeaderText = "Тип";
            resultTyoeColumn.Name = "resultTyoeColumn";
            resultTyoeColumn.ReadOnly = true;
            // 
            // resultVolumeColumn
            // 
            resultVolumeColumn.HeaderText = "Объем";
            resultVolumeColumn.Name = "resultVolumeColumn";
            resultVolumeColumn.ReadOnly = true;
            // 
            // resultDescriptionColumn
            // 
            resultDescriptionColumn.HeaderText = "Описание";
            resultDescriptionColumn.Name = "resultDescriptionColumn";
            resultDescriptionColumn.ReadOnly = true;
            // 
            // FindFigureForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(812, 277);
            Controls.Add(resultsDataGridView);
            Controls.Add(figureTypeComboBox);
            Controls.Add(minVolumeLabel);
            Controls.Add(minVolumeTextBox);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(maxVolumeTextBox);
            Controls.Add(maxVolumeLabel);
            Controls.Add(figureTypeLabel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FindFigureForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Поиск фигуры";
            ((System.ComponentModel.ISupportInitialize)resultsDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label figureTypeLabel;
        private ComboBox comboBox1;
        private Label label2;
        private TextBox textBox1;
        private Label maxVolumeLabel;
        private TextBox maxVolumeTextBox;
        private Button button1;
        private Button button2;
        private TextBox minVolumeTextBox;
        private Label minVolumeLabel;
        private ComboBox figureTypeComboBox;
        private DataGridView resultsDataGridView;
        private DataGridViewTextBoxColumn resultTyoeColumn;
        private DataGridViewTextBoxColumn resultVolumeColumn;
        private DataGridViewTextBoxColumn resultDescriptionColumn;
    }
}