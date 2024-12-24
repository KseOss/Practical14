using System.Configuration;
using System.Data;
using System.Windows;

namespace Practical14
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            // Открытие окна авторизации при запуске приложения
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
        }
    }

}
