using praktika12345.Models;
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

namespace praktika12345
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private Praktos123Context _context;
        public LoginWindow()
        {
            InitializeComponent();
            _context = new Praktos123Context();
        }
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            // Проверяем наличие пользователя в базе данных
            var user = _context.Users.Where(u => u.UserLogin == username && u.UserPassword == password)
                               .FirstOrDefault();

            if (user != null)
            {
                // Получение роли пользователя
                var role = user.UserRole;

                // Открытие основного окна в зависимости от роли
                MainWindow mainWindow = new MainWindow(user);
                mainWindow.Show();
                this.Close();
            }
            else
            {
                // Если авторизация не удалась, показываем ошибку
                ErrorTextBlock.Text = "Неверный логин или пароль";
            }
        }
    }
}
