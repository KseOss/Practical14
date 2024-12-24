using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;

namespace Practical14
{
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            InitializeComponent();
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Сохранение введенного размера в конфигурационный файл
                File.WriteAllText("config.ini", SizeTextBox.Text);
                MessageBox.Show("Настройки сохранены", "Успех", MessageBoxButton.OK);
                this.Close(); // Закрытие окна настроек
            }
            catch (IOException ex)
            {
                // Обработка исключения при сохранении настроек
                MessageBox.Show($"Ошибка при сохранении настроек: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
