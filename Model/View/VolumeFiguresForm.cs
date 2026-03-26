using Model;
using View.Serialization;

namespace View
{
    /// <summary>
    /// Представляет главную форму приложения для работы со списком объёмных фигур.
    /// </summary>
    /// <remarks>
    /// Форма отображает список фигур в таблице, позволяет добавлять,
    /// удалять, искать, сохранять и загружать фигуры.
    /// </remarks>
    public partial class VolumeFiguresForm : Form
    {
        /// <summary>
        /// Список фигур, отображаемых на форме.
        /// </summary>
        private readonly List<VolumeFigureBase> _figures = new();

        /// <summary>
        /// Инициализирует новый экземпляр формы <see cref="VolumeFiguresForm"/>.
        /// </summary>
        public VolumeFiguresForm()
        {
            InitializeComponent();
            _figures.Add(new Sphere(3));
            _figures.Add(new Pyramid(2, 4, 6));
            _figures.Add(new Parallelepiped(2, 3, 4));

            RefreshFiguresGrid();
        }

        /// <summary>
        /// Обновляет таблицу фигур в соответствии с текущим содержимым списка.
        /// </summary>
        private void RefreshFiguresGrid()
        {
            figuresDataGridView.Rows.Clear();

            foreach (VolumeFigureBase figure in _figures)
            {
                figuresDataGridView.Rows.Add(
                    figure.FigureType,
                    FormateVolume(figure.Volume),
                    figure.GetDescription());
            }
        }

        /// <summary>
        /// Форматирует объём фигуры для удобного отображения в таблице.
        /// </summary>
        /// <param name="volume">Объём фигуры.</param>
        /// <returns>
        /// Строковое представление объёма с шестью знаками после запятой.
        /// </returns>
        private static string FormateVolume(double volume) =>
            volume.ToString("F6");

        /// <summary>
        /// Обновляет доступность команды сохранения 
        /// в зависимости от наличия фигур в списке.
        /// </summary>
        private void UpdateSaveAvailability()
        {
            saveToolStripMenuItem.Enabled = _figures.Count > 0;
        }

        /// <summary>
        /// Обрабатывает нажатие кнопки удаления выбранной фигуры.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void removeFigureButton_Click(object sender, EventArgs e)
        {
            if (figuresDataGridView.CurrentRow == null)
            {
                MessageBox.Show(
                    this,
                    "Выберите фигуру для удаления.",
                    "Удаление",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            int selectedIndex = figuresDataGridView.CurrentRow.Index;

            if (selectedIndex < 0
                || selectedIndex >= _figures.Count)
            {
                MessageBox.Show(
                    this,
                    "Не удалось определить выбранный объект.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            _figures.RemoveAt(selectedIndex);
            RefreshFiguresGrid();
        }

        /// <summary>
        /// Обрабатывает нажатие кнопки добавления новой фигуры.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void addFigureButton_Click(object sender, EventArgs e)
        {
            using AddFigureForm addFigureForm = new AddFigureForm();

            if (addFigureForm.ShowDialog() == DialogResult.OK
                && addFigureForm.CreatedFigure != null)
            {
                _figures.Add(addFigureForm.CreatedFigure);
                RefreshFiguresGrid();
                UpdateSaveAvailability();
            }
        }

        /// <summary>
        /// Обрабатывает нажатие кнопки поиска фигур.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void findFigureButton_Click(object sender, EventArgs e)
        {
            using FindFigureForm findFigureForm = new FindFigureForm(_figures);
            findFigureForm.ShowDialog();
        }

        /// <summary>
        /// Сохраняет текущий список фигур в файл.
        /// </summary>
        private void SaveFigures()
        {
            if (_figures.Count == 0)
            {
                MessageBox.Show(
                    this,
                    "Список фигур пуст. Нет данных для сохранения.",
                    "Save",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Volume Figures File (*.vfig)|*.vfig";
                saveFileDialog.DefaultExt = "vfig";
                saveFileDialog.AddExtension = true;
                saveFileDialog.FileName = "figures.vfig";

                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                try
                {
                    FigureStorage.Save(saveFileDialog.FileName, _figures);

                    MessageBox.Show(
                        this,
                        "Данные успешно сохранены.",
                        "Сохранение",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        this,
                        ex.Message,
                        "Ошибка сохранения",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Загружает список фигур из файла.
        /// </summary>
        private void LoadFigures()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter 
                    = "Volume Figures File (*.vfig)|*.vfig|All files (*.*)|*.*";

                if (openFileDialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                try
                {
                    List<VolumeFigureBase> loadedFigures 
                        = FigureStorage.Load(openFileDialog.FileName);

                    _figures.Clear();
                    _figures.AddRange(loadedFigures);

                    RefreshFiguresGrid();

                    MessageBox.Show(
                        "Данные успешно загружены.",
                        "Загрузка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        this,
                        ex.Message,
                        "Ошибка загрузки",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Обрабатывает выбор пункта меню сохранения.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFigures();
        }

        /// <summary>
        /// Обрабатывает выбор пункта меню загрузки.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadFigures();
        }

        /// <summary>
        /// Обрабатывает выбор пункта меню загрузки.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
