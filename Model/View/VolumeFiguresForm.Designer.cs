namespace View
{
    partial class VolumeFiguresForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VolumeFiguresForm));
            figuresGroupBox = new GroupBox();
            figuresDataGridView = new DataGridView();
            figureVolumeColumn = new DataGridViewTextBoxColumn();
            figureTypeColumn = new DataGridViewTextBoxColumn();
            figureDescriptionColumn = new DataGridViewTextBoxColumn();
            removeFigureButton = new Button();
            addFigureButton = new Button();
            findFigureButton = new Button();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            loadToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            figuresGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)figuresDataGridView).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // figuresGroupBox
            // 
            figuresGroupBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            figuresGroupBox.Controls.Add(figuresDataGridView);
            figuresGroupBox.Location = new Point(15, 43);
            figuresGroupBox.Name = "figuresGroupBox";
            figuresGroupBox.Size = new Size(940, 431);
            figuresGroupBox.TabIndex = 0;
            figuresGroupBox.TabStop = false;
            figuresGroupBox.Text = "Список фигур";
            // 
            // figuresDataGridView
            // 
            figuresDataGridView.AllowUserToAddRows = false;
            figuresDataGridView.AllowUserToDeleteRows = false;
            figuresDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            figuresDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            figuresDataGridView.Columns.AddRange(new DataGridViewColumn[] { figureVolumeColumn, figureTypeColumn, figureDescriptionColumn });
            figuresDataGridView.Dock = DockStyle.Fill;
            figuresDataGridView.Location = new Point(3, 19);
            figuresDataGridView.MultiSelect = false;
            figuresDataGridView.Name = "figuresDataGridView";
            figuresDataGridView.ReadOnly = true;
            figuresDataGridView.RowHeadersVisible = false;
            figuresDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            figuresDataGridView.Size = new Size(934, 409);
            figuresDataGridView.TabIndex = 0;
            // 
            // figureVolumeColumn
            // 
            figureVolumeColumn.HeaderText = "Тип";
            figureVolumeColumn.Name = "figureVolumeColumn";
            figureVolumeColumn.ReadOnly = true;
            // 
            // figureTypeColumn
            // 
            figureTypeColumn.HeaderText = "Объем";
            figureTypeColumn.Name = "figureTypeColumn";
            figureTypeColumn.ReadOnly = true;
            // 
            // figureDescriptionColumn
            // 
            figureDescriptionColumn.HeaderText = "Описание";
            figureDescriptionColumn.Name = "figureDescriptionColumn";
            figureDescriptionColumn.ReadOnly = true;
            // 
            // removeFigureButton
            // 
            removeFigureButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            removeFigureButton.Location = new Point(152, 503);
            removeFigureButton.Name = "removeFigureButton";
            removeFigureButton.Size = new Size(131, 23);
            removeFigureButton.TabIndex = 1;
            removeFigureButton.Text = "Удалить фигуру";
            removeFigureButton.UseVisualStyleBackColor = true;
            removeFigureButton.Click += removeFigureButton_Click;
            // 
            // addFigureButton
            // 
            addFigureButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            addFigureButton.Location = new Point(15, 503);
            addFigureButton.Name = "addFigureButton";
            addFigureButton.Size = new Size(131, 23);
            addFigureButton.TabIndex = 2;
            addFigureButton.Text = "Добавить фигуру";
            addFigureButton.UseVisualStyleBackColor = true;
            addFigureButton.Click += addFigureButton_Click;
            // 
            // findFigureButton
            // 
            findFigureButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            findFigureButton.Location = new Point(289, 503);
            findFigureButton.Name = "findFigureButton";
            findFigureButton.Size = new Size(131, 23);
            findFigureButton.TabIndex = 3;
            findFigureButton.Text = "Поиск";
            findFigureButton.UseVisualStyleBackColor = true;
            findFigureButton.Click += findFigureButton_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(984, 24);
            menuStrip1.TabIndex = 4;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { saveToolStripMenuItem, loadToolStripMenuItem, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(48, 20);
            fileToolStripMenuItem.Text = "Файл";
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(180, 22);
            saveToolStripMenuItem.Text = "Сохранить";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // loadToolStripMenuItem
            // 
            loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            loadToolStripMenuItem.Size = new Size(180, 22);
            loadToolStripMenuItem.Text = "Загрузить";
            loadToolStripMenuItem.Click += loadToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(180, 22);
            exitToolStripMenuItem.Text = "Выход";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // VolumeFiguresForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 561);
            Controls.Add(findFigureButton);
            Controls.Add(addFigureButton);
            Controls.Add(removeFigureButton);
            Controls.Add(figuresGroupBox);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(1000, 600);
            Name = "VolumeFiguresForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RusWin3 Volume edition";
            figuresGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)figuresDataGridView).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox figuresGroupBox;
        private DataGridView figuresDataGridView;
        private Button removeFigureButton;
        private Button addFigureButton;
        private DataGridViewTextBoxColumn figureVolumeColumn;
        private DataGridViewTextBoxColumn figureTypeColumn;
        private DataGridViewTextBoxColumn figureDescriptionColumn;
        private Button findFigureButton;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem loadToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
    }
}
