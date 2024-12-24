using Microsoft.Win32;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using pr14; 

namespace Practical14
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadConfiguration();
        }
        private void Analyze_Click(object sender, RoutedEventArgs e)
        {
            // Парсинг введенной матрицы
            var matrix = ParseMatrix(InputMatrix.Text);
            if (matrix == null)
            {
                // Проверка на наличие данных для анализа
                MessageBox.Show("Отсутствуют исходные данные для расчета", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Поиск строки с максимальным количеством дубликатов
            int resultRow = MatrixHelper.FindRowWithMaxDuplicates(matrix);
            ResultText.Text = resultRow >= 0 ? $"Номер строки: {resultRow + 1}" : "Нет строк с одинаковыми элементами.";
            statusText.Text = $"Size: {matrix.GetLength(0)} x {matrix.GetLength(1)}, Cell: N/A";
        }

        private int[,] ParseMatrix(string input)
        {
            try
            {
                // Разделение введенной строки на строки матрицы
                var rows = input.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                var matrix = new int[rows.Length, rows[0].Split(' ').Length];

                // Заполнение матрицы значениями
                for (int i = 0; i < rows.Length; i++)
                {
                    var cols = rows[i].Split(' ').Select(int.Parse).ToArray();
                    for (int j = 0; j < cols.Length; j++)
                    {
                        matrix[i, j] = cols[j];
                    }
                }
                return matrix; // Возврат заполненной матрицы
            }
            catch
            {
                // Возврат null в случае ошибки
                return null;
            }
        }

        private void LoadConfiguration()
        {
            try
            {
                // Проверка наличия конфигурационного файла
                if (File.Exists("config.ini"))
                {
                    string sizeSetting = File.ReadAllText("config.ini");
                    // Здесь можно установить размер таблицы на основе конфигурации
                    // Например, можно разбить строку и установить размер матрицы
                }
            }
            catch (IOException ex)
            {
                // Обработка исключения, если файл не найден или не может быть прочитан
                MessageBox.Show($"Ошибка при чтении конфигурации: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            // Создание диалогового окна для открытия файла
            var openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                // Чтение содержимого файла и установка его в TextBox
                InputMatrix.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }

        private void SaveFile_Click(object sender, RoutedEventArgs e)
        {
            // Создание диалогового окна для сохранения файла
            var saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {
                // Сохранение содержимого TextBox в файл
                File.WriteAllText(saveFileDialog.FileName, InputMatrix.Text);
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            // Подтверждение выхода из приложения
            var result = MessageBox.Show("Вы уверены, что хотите выйти?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                this.Close(); // Закрытие окна
            }
        }
        private void About_Click(object sender, RoutedEventArgs e)
        {
            // Информация о программе
            MessageBox.Show("Developer: Fals$h\nPractical: #12\\nMatrix Analyzer v1.0", "О программе", MessageBoxButton.OK);
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            // Открытие окна настроек
            SettingsWindow settingsWindow = new SettingsWindow();
            settingsWindow.Show();
        }
    }
}