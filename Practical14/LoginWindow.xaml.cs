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

namespace Practical14
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            //проверка веденного пароля
            if (PasswordBox.Password == "123")
            {
                //Если пароль верный открываем окно и закрываем окно авторизации
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            else
            {
                //Если пароль неверный, выводим сообщение об ошибке
                MessageBox.Show("Неверный пароль", "Ошибка ввода пароля", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
