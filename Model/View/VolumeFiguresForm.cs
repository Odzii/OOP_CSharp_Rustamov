using Model;
using View.Serialization;

namespace View
{
    public partial class VolumeFiguresForm : Form
    {
        private readonly List<VolumeFigureBase> _figures = new();

        public VolumeFiguresForm()
        {
            InitializeComponent();
            _figures.Add(new Sphere(3));
            _figures.Add(new Pyramid(2, 4, 6));
            _figures.Add(new Parallelepiped(2, 3, 4));

            RefreshFiguresGrid();
        }

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

        private static string FormateVolume(double volume) =>
            volume.ToString("F6");

        private void removeFigureButton_Click(object sender, EventArgs e)
        {
            if (figuresDataGridView.CurrentRow == null)
            {
                MessageBox.Show(
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
                    "Не удалось определить выбранный объект.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            _figures.RemoveAt(selectedIndex);
            RefreshFiguresGrid();
        }

        private void addFigureButton_Click(object sender, EventArgs e)
        {
            using addFigureForm addFigureForm = new addFigureForm();

            if (addFigureForm.ShowDialog() == DialogResult.OK
                && addFigureForm.CreateControl != null)
            {
                _figures.Add(addFigureForm?.CreatedFigure);
                RefreshFiguresGrid();

            }
        }

        private void findFigureButton_Click(object sender, EventArgs e)
        {
            using FindFigureForm findFigureForm = new FindFigureForm(_figures);
            findFigureForm.ShowDialog();
        }

        private void SaveFigures()
        {
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
                        "Данные успешно сохранены.",
                        "Save",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        ex.Message,
                        "Ошибка сохранения",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void LoadFigures()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Volume Figures File (*.vfig)|*.vfig|All files (*.*)|*.*";

                if (openFileDialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                try
                {
                    List<VolumeFigureBase> loadedFigures = FigureStorage.Load(openFileDialog.FileName);

                    _figures.Clear();
                    _figures.AddRange(loadedFigures);

                    RefreshFiguresGrid();

                    MessageBox.Show(
                        "Данные успешно загружены.",
                        "Load",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        ex.Message,
                        "Load error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFigures();
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadFigures();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
