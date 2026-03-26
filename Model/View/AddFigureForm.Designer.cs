namespace View
{
    partial class AddFigureForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddFigureForm));
            figureTypeLabel = new Label();
            figureTypeComboBox = new ComboBox();
            spherePanel = new Panel();
            sphereRadiusTextBox = new TextBox();
            radiusLabel = new Label();
            pyramidPanel = new Panel();
            pyramidBaseWidthTextBox = new TextBox();
            pyramidHeightTextBox = new TextBox();
            label3 = new Label();
            label2 = new Label();
            pyramidBaseLengthTextBox = new TextBox();
            label1 = new Label();
            parallelepipedPanel = new Panel();
            parallelepipedHeightTextBox = new TextBox();
            parallelepipedWidthTextBox = new TextBox();
            label6 = new Label();
            label5 = new Label();
            parallelepipedLengthTextBox = new TextBox();
            label4 = new Label();
            okButton = new Button();
            cancelButton = new Button();
            createRandomDataButton = new Button();
            spherePanel.SuspendLayout();
            pyramidPanel.SuspendLayout();
            parallelepipedPanel.SuspendLayout();
            SuspendLayout();
            // 
            // figureTypeLabel
            // 
            figureTypeLabel.AutoSize = true;
            figureTypeLabel.Location = new Point(41, 33);
            figureTypeLabel.Name = "figureTypeLabel";
            figureTypeLabel.RightToLeft = RightToLeft.No;
            figureTypeLabel.Size = new Size(91, 20);
            figureTypeLabel.TabIndex = 0;
            figureTypeLabel.Text = "Тип фигуры";
            // 
            // figureTypeComboBox
            // 
            figureTypeComboBox.FormattingEnabled = true;
            figureTypeComboBox.Location = new Point(192, 28);
            figureTypeComboBox.Margin = new Padding(3, 4, 3, 4);
            figureTypeComboBox.Name = "figureTypeComboBox";
            figureTypeComboBox.RightToLeft = RightToLeft.No;
            figureTypeComboBox.Size = new Size(195, 28);
            figureTypeComboBox.TabIndex = 0;
            figureTypeComboBox.Text = "Выберите фигуру";
            figureTypeComboBox.SelectedIndexChanged += figureTypeComboBox_SelectedIndexChanged;
            // 
            // spherePanel
            // 
            spherePanel.Controls.Add(sphereRadiusTextBox);
            spherePanel.Controls.Add(radiusLabel);
            spherePanel.Location = new Point(27, 81);
            spherePanel.Margin = new Padding(3, 4, 3, 4);
            spherePanel.Name = "spherePanel";
            spherePanel.RightToLeft = RightToLeft.No;
            spherePanel.Size = new Size(376, 132);
            spherePanel.TabIndex = 2;
            // 
            // sphereRadiusTextBox
            // 
            sphereRadiusTextBox.Location = new Point(165, 7);
            sphereRadiusTextBox.Margin = new Padding(3, 4, 3, 4);
            sphereRadiusTextBox.Name = "sphereRadiusTextBox";
            sphereRadiusTextBox.Size = new Size(195, 27);
            sphereRadiusTextBox.TabIndex = 1;
            // 
            // radiusLabel
            // 
            radiusLabel.AutoSize = true;
            radiusLabel.Location = new Point(14, 10);
            radiusLabel.Name = "radiusLabel";
            radiusLabel.Size = new Size(59, 20);
            radiusLabel.TabIndex = 0;
            radiusLabel.Text = "Радиус:";
            // 
            // pyramidPanel
            // 
            pyramidPanel.Controls.Add(pyramidBaseWidthTextBox);
            pyramidPanel.Controls.Add(pyramidHeightTextBox);
            pyramidPanel.Controls.Add(label3);
            pyramidPanel.Controls.Add(label2);
            pyramidPanel.Controls.Add(pyramidBaseLengthTextBox);
            pyramidPanel.Controls.Add(label1);
            pyramidPanel.Location = new Point(27, 81);
            pyramidPanel.Margin = new Padding(3, 4, 3, 4);
            pyramidPanel.Name = "pyramidPanel";
            pyramidPanel.RightToLeft = RightToLeft.No;
            pyramidPanel.Size = new Size(376, 132);
            pyramidPanel.TabIndex = 3;
            // 
            // pyramidBaseWidthTextBox
            // 
            pyramidBaseWidthTextBox.Location = new Point(165, 48);
            pyramidBaseWidthTextBox.Margin = new Padding(3, 4, 3, 4);
            pyramidBaseWidthTextBox.Name = "pyramidBaseWidthTextBox";
            pyramidBaseWidthTextBox.Size = new Size(195, 27);
            pyramidBaseWidthTextBox.TabIndex = 2;
            // 
            // pyramidHeightTextBox
            // 
            pyramidHeightTextBox.Location = new Point(165, 89);
            pyramidHeightTextBox.Margin = new Padding(3, 4, 3, 4);
            pyramidHeightTextBox.Name = "pyramidHeightTextBox";
            pyramidHeightTextBox.Size = new Size(195, 27);
            pyramidHeightTextBox.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(14, 93);
            label3.Name = "label3";
            label3.Size = new Size(62, 20);
            label3.TabIndex = 4;
            label3.Text = "Высота:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 52);
            label2.Name = "label2";
            label2.Size = new Size(150, 20);
            label2.TabIndex = 2;
            label2.Text = "Ширина основания:";
            label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // pyramidBaseLengthTextBox
            // 
            pyramidBaseLengthTextBox.Location = new Point(165, 7);
            pyramidBaseLengthTextBox.Margin = new Padding(3, 4, 3, 4);
            pyramidBaseLengthTextBox.Name = "pyramidBaseLengthTextBox";
            pyramidBaseLengthTextBox.Size = new Size(195, 27);
            pyramidBaseLengthTextBox.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 7);
            label1.Name = "label1";
            label1.Size = new Size(136, 20);
            label1.TabIndex = 0;
            label1.Text = "Длина основания:";
            // 
            // parallelepipedPanel
            // 
            parallelepipedPanel.Controls.Add(parallelepipedHeightTextBox);
            parallelepipedPanel.Controls.Add(parallelepipedWidthTextBox);
            parallelepipedPanel.Controls.Add(label6);
            parallelepipedPanel.Controls.Add(label5);
            parallelepipedPanel.Controls.Add(parallelepipedLengthTextBox);
            parallelepipedPanel.Controls.Add(label4);
            parallelepipedPanel.Location = new Point(27, 81);
            parallelepipedPanel.Margin = new Padding(3, 4, 3, 4);
            parallelepipedPanel.Name = "parallelepipedPanel";
            parallelepipedPanel.RightToLeft = RightToLeft.No;
            parallelepipedPanel.Size = new Size(376, 132);
            parallelepipedPanel.TabIndex = 4;
            // 
            // parallelepipedHeightTextBox
            // 
            parallelepipedHeightTextBox.Location = new Point(165, 89);
            parallelepipedHeightTextBox.Margin = new Padding(3, 4, 3, 4);
            parallelepipedHeightTextBox.Name = "parallelepipedHeightTextBox";
            parallelepipedHeightTextBox.Size = new Size(195, 27);
            parallelepipedHeightTextBox.TabIndex = 6;
            // 
            // parallelepipedWidthTextBox
            // 
            parallelepipedWidthTextBox.Location = new Point(165, 48);
            parallelepipedWidthTextBox.Margin = new Padding(3, 4, 3, 4);
            parallelepipedWidthTextBox.Name = "parallelepipedWidthTextBox";
            parallelepipedWidthTextBox.Size = new Size(195, 27);
            parallelepipedWidthTextBox.TabIndex = 5;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(14, 93);
            label6.Name = "label6";
            label6.Size = new Size(62, 20);
            label6.TabIndex = 4;
            label6.Text = "Высота:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(14, 52);
            label5.Name = "label5";
            label5.Size = new Size(70, 20);
            label5.TabIndex = 2;
            label5.Text = "Ширина:";
            // 
            // parallelepipedLengthTextBox
            // 
            parallelepipedLengthTextBox.Location = new Point(165, 7);
            parallelepipedLengthTextBox.Margin = new Padding(3, 4, 3, 4);
            parallelepipedLengthTextBox.Name = "parallelepipedLengthTextBox";
            parallelepipedLengthTextBox.Size = new Size(195, 27);
            parallelepipedLengthTextBox.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(14, 11);
            label4.Name = "label4";
            label4.Size = new Size(56, 20);
            label4.TabIndex = 0;
            label4.Text = "Длина:";
            // 
            // okButton
            // 
            okButton.DialogResult = DialogResult.OK;
            okButton.Location = new Point(203, 230);
            okButton.Margin = new Padding(3, 4, 3, 4);
            okButton.Name = "okButton";
            okButton.Size = new Size(86, 31);
            okButton.TabIndex = 5;
            okButton.Text = "Ок";
            okButton.UseVisualStyleBackColor = true;
            okButton.Click += okButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.DialogResult = DialogResult.Cancel;
            cancelButton.Location = new Point(301, 230);
            cancelButton.Margin = new Padding(3, 4, 3, 4);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(86, 31);
            cancelButton.TabIndex = 6;
            cancelButton.Text = "Отмена";
            cancelButton.UseVisualStyleBackColor = true;
            // 
            // createRandomDataButton
            // 
            createRandomDataButton.Location = new Point(41, 230);
            createRandomDataButton.Margin = new Padding(3, 4, 3, 4);
            createRandomDataButton.Name = "createRandomDataButton";
            createRandomDataButton.RightToLeft = RightToLeft.No;
            createRandomDataButton.Size = new Size(150, 31);
            createRandomDataButton.TabIndex = 4;
            createRandomDataButton.Text = "Случайно";
            createRandomDataButton.UseVisualStyleBackColor = true;
            createRandomDataButton.Click += createRandomDataButton_Click;
            // 
            // AddFigureForm
            // 
            AcceptButton = okButton;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = cancelButton;
            ClientSize = new Size(432, 271);
            Controls.Add(pyramidPanel);
            Controls.Add(createRandomDataButton);
            Controls.Add(cancelButton);
            Controls.Add(okButton);
            Controls.Add(figureTypeComboBox);
            Controls.Add(figureTypeLabel);
            Controls.Add(parallelepipedPanel);
            Controls.Add(spherePanel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddFigureForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Добавить фигуру";
            spherePanel.ResumeLayout(false);
            spherePanel.PerformLayout();
            pyramidPanel.ResumeLayout(false);
            pyramidPanel.PerformLayout();
            parallelepipedPanel.ResumeLayout(false);
            parallelepipedPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label figureTypeLabel;
        private ComboBox figureTypeComboBox;
        private Panel spherePanel;
        private TextBox sphereRadiusTextBox;
        private Label radiusLabel;
        private Panel pyramidPanel;
        private Label label3;
        private Label label2;
        private TextBox pyramidBaseLengthTextBox;
        private Label label1;
        private Panel parallelepipedPanel;
        private TextBox pyramidHeightTextBox;
        private TextBox textBox3;
        private Label label6;
        private TextBox textBox2;
        private Label label5;
        private TextBox parallelepipedLengthTextBox;
        private Label label4;
        private TextBox pyramidBaseWidthTextBox;
        private TextBox parallelepipedHeightTextBox;
        private TextBox parallelepipedWidthTextBox;
        private Button okButton;
        private Button cancelButton;
        private Button createRandomDataButton;
    }
}