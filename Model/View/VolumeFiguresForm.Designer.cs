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
            FiguresGroupBox = new GroupBox();
            FiguresDataGridView = new DataGridView();
            FigureVolumeColumn = new DataGridViewTextBoxColumn();
            FigureTypeColumn = new DataGridViewTextBoxColumn();
            FigureDescriptionColumn = new DataGridViewTextBoxColumn();
            RemoveFigureButton = new Button();
            AddFigureButton = new Button();
            FindFigureButton = new Button();
            MenuStrip1 = new MenuStrip();
            FileToolStripMenuItem = new ToolStripMenuItem();
            SaveToolStripMenuItem = new ToolStripMenuItem();
            LoadToolStripMenuItem = new ToolStripMenuItem();
            ExitToolStripMenuItem = new ToolStripMenuItem();
            FiguresGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)FiguresDataGridView).BeginInit();
            MenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // FiguresGroupBox
            // 
            FiguresGroupBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            FiguresGroupBox.Controls.Add(FiguresDataGridView);
            FiguresGroupBox.Location = new Point(15, 43);
            FiguresGroupBox.Name = "FiguresGroupBox";
            FiguresGroupBox.Size = new Size(940, 431);
            FiguresGroupBox.TabIndex = 0;
            FiguresGroupBox.TabStop = false;
            FiguresGroupBox.Text = "Список фигур";
            // 
            // FiguresDataGridView
            // 
            FiguresDataGridView.AllowUserToAddRows = false;
            FiguresDataGridView.AllowUserToDeleteRows = false;
            FiguresDataGridView.AllowUserToResizeRows = false;
            FiguresDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            FiguresDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            FiguresDataGridView.Columns.AddRange(new DataGridViewColumn[] { FigureVolumeColumn, FigureTypeColumn, FigureDescriptionColumn });
            FiguresDataGridView.Dock = DockStyle.Fill;
            FiguresDataGridView.Location = new Point(3, 19);
            FiguresDataGridView.Name = "FiguresDataGridView";
            FiguresDataGridView.ReadOnly = true;
            FiguresDataGridView.RowHeadersVisible = false;
            FiguresDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            FiguresDataGridView.Size = new Size(934, 409);
            FiguresDataGridView.TabIndex = 1;
            // 
            // FigureVolumeColumn
            // 
            FigureVolumeColumn.HeaderText = "Тип";
            FigureVolumeColumn.Name = "FigureVolumeColumn";
            FigureVolumeColumn.ReadOnly = true;
            // 
            // FigureTypeColumn
            // 
            FigureTypeColumn.HeaderText = "Объем";
            FigureTypeColumn.Name = "FigureTypeColumn";
            FigureTypeColumn.ReadOnly = true;
            // 
            // FigureDescriptionColumn
            // 
            FigureDescriptionColumn.HeaderText = "Описание";
            FigureDescriptionColumn.Name = "FigureDescriptionColumn";
            FigureDescriptionColumn.ReadOnly = true;
            // 
            // RemoveFigureButton
            // 
            RemoveFigureButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            RemoveFigureButton.Location = new Point(152, 503);
            RemoveFigureButton.Name = "RemoveFigureButton";
            RemoveFigureButton.Size = new Size(131, 23);
            RemoveFigureButton.TabIndex = 3;
            RemoveFigureButton.Text = "Удалить фигуру";
            RemoveFigureButton.UseVisualStyleBackColor = true;
            RemoveFigureButton.Click += RemoveFigureButton_Click;
            // 
            // AddFigureButton
            // 
            AddFigureButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            AddFigureButton.Location = new Point(15, 503);
            AddFigureButton.Name = "AddFigureButton";
            AddFigureButton.Size = new Size(131, 23);
            AddFigureButton.TabIndex = 2;
            AddFigureButton.Text = "Добавить фигуру";
            AddFigureButton.UseVisualStyleBackColor = true;
            AddFigureButton.Click += AddFigureButton_Click;
            // 
            // FindFigureButton
            // 
            FindFigureButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            FindFigureButton.Location = new Point(289, 503);
            FindFigureButton.Name = "FindFigureButton";
            FindFigureButton.Size = new Size(131, 23);
            FindFigureButton.TabIndex = 4;
            FindFigureButton.Text = "Поиск";
            FindFigureButton.UseVisualStyleBackColor = true;
            FindFigureButton.Click += FindFigureButton_Click;
            // 
            // MenuStrip1
            // 
            MenuStrip1.Items.AddRange(new ToolStripItem[] { FileToolStripMenuItem });
            MenuStrip1.Location = new Point(0, 0);
            MenuStrip1.Name = "MenuStrip1";
            MenuStrip1.Size = new Size(984, 24);
            MenuStrip1.TabIndex = 0;
            MenuStrip1.Text = "menuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            FileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { SaveToolStripMenuItem, LoadToolStripMenuItem, ExitToolStripMenuItem });
            FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            FileToolStripMenuItem.Size = new Size(48, 20);
            FileToolStripMenuItem.Text = "Файл";
            // 
            // SaveToolStripMenuItem
            // 
            SaveToolStripMenuItem.Name = "SaveToolStripMenuItem";
            SaveToolStripMenuItem.Size = new Size(133, 22);
            SaveToolStripMenuItem.Text = "Сохранить";
            SaveToolStripMenuItem.Click += SaveToolStripMenuItem_Click;
            // 
            // LoadToolStripMenuItem
            // 
            LoadToolStripMenuItem.Name = "LoadToolStripMenuItem";
            LoadToolStripMenuItem.Size = new Size(133, 22);
            LoadToolStripMenuItem.Text = "Загрузить";
            LoadToolStripMenuItem.Click += LoadToolStripMenuItem_Click;
            // 
            // ExitToolStripMenuItem
            // 
            ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            ExitToolStripMenuItem.Size = new Size(133, 22);
            ExitToolStripMenuItem.Text = "Выход";
            ExitToolStripMenuItem.Click += ExitToolStripMenuItem_Click;
            // 
            // VolumeFiguresForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 561);
            Controls.Add(FindFigureButton);
            Controls.Add(AddFigureButton);
            Controls.Add(RemoveFigureButton);
            Controls.Add(FiguresGroupBox);
            Controls.Add(MenuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = MenuStrip1;
            MinimumSize = new Size(1000, 600);
            Name = "VolumeFiguresForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RusWin3 Volume edition";
            FiguresGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)FiguresDataGridView).EndInit();
            MenuStrip1.ResumeLayout(false);
            MenuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox FiguresGroupBox;
        private DataGridView FiguresDataGridView;
        private Button RemoveFigureButton;
        private Button AddFigureButton;
        private DataGridViewTextBoxColumn FigureVolumeColumn;
        private DataGridViewTextBoxColumn FigureTypeColumn;
        private DataGridViewTextBoxColumn FigureDescriptionColumn;
        private Button FindFigureButton;
        private MenuStrip MenuStrip1;
        private ToolStripMenuItem FileToolStripMenuItem;
        private ToolStripMenuItem SaveToolStripMenuItem;
        private ToolStripMenuItem LoadToolStripMenuItem;
        private ToolStripMenuItem ExitToolStripMenuItem;
    }
}
