using praktika12345.Models;
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

namespace praktika12345
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private User _currentUser;
        private Praktos123Context _context;
        public MainWindow(User user)
        {
            InitializeComponent();
            _currentUser = user;
            SetPermissions();
            LoadDB();
        }
        
        private void SetPermissions()
        {
            switch (_currentUser.UserRole)
            {
                case "Admin":
                    // Администратор может делать все
                    break;

                case "Manager":
                    // Менеджер может добавлять и редактировать, но не удалять
                    DeleteButtonLanguages.IsEnabled = false;
                    DeleteButtonSquads.IsEnabled = false;
                    DeleteButtonCountries.IsEnabled = false;
                    break;

                case "User":
                    // Клиент может только просматривать
                    DeleteButtonLanguages.IsEnabled = false;
                    DeleteButtonSquads.IsEnabled = false;
                    DeleteButtonCountries.IsEnabled = false;
                    AddButtonLanguages.IsEnabled = false;
                    AddButtonSquads.IsEnabled = false;
                    AddButtonCountries.IsEnabled = false;
                    EditButtonLanguages.IsEnabled = false;
                    EditButtonSquads.IsEnabled = false;
                    EditButtonCountries.IsEnabled = false;
                    break;
            }
        }

        public void LoadDB()
        {
            using (Praktos123Context _context = new Praktos123Context())
            {
                LanguageView.ItemsSource = _context.Languages.ToList();
                CountryView.ItemsSource = _context.Countries.ToList();
                SquadsView.ItemsSource = _context.Squads.ToList();
            }
        }

        private void AddButtonSquads_Click(object sender, RoutedEventArgs e)
        {
            var addSquadWindow = new AddSquadWindow()
            {
                Title = "Добавить запись"
            };
            addSquadWindow.ShowDialog();
            LoadDB();
        }

        private void EditButtonSquads_Click(object sender, RoutedEventArgs e)
        {
            if (SquadsView.SelectedItem is Squad selectedOrder)
            {
                var addSquadWindow = new AddSquadWindow(selectedOrder)
                {
                    Title = "Редактировать запись"
                };
                addSquadWindow.ShowDialog();
                LoadDB();
            }
        }

        private void DeleteButtonSquads_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result;
            result = MessageBox.Show("Удалить запись?", "Удаление записи.", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    Squad row = (Squad)SquadsView.SelectedItem;
                    if (row != null)
                    {
                        using (Praktos123Context _context = new Praktos123Context())
                        {
                            _context.Squads.Remove(row);
                            _context.SaveChanges();
                        }
                        LoadDB();
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка.", "Ошибка удаления.", MessageBoxButton.OKCancel, MessageBoxImage.Error);
                }
            }
            else
            {
                SquadsView.Focus();
            }
        }

        private void AddButtonLanguages_Click(object sender, RoutedEventArgs e)
        {
            var addLanguageWindow = new AddLanguageWindow()
            {
                Title = "Добавить запись"
            };
            addLanguageWindow.ShowDialog();
            LoadDB();
        }

        private void EditButtonLanguages_Click(object sender, RoutedEventArgs e)
        {
            if (LanguageView.SelectedItem is Language selectedOrder)
            {
                var addLanguageWindow = new AddLanguageWindow(selectedOrder)
                {
                    Title = "Редактировать запись"
                };
                addLanguageWindow.ShowDialog();
                LoadDB();
            }
        }

        private void DeleteButtonLanguages_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result;
            result = MessageBox.Show("Удалить запись?", "Удаление записи.", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    Language row = (Language)LanguageView.SelectedItem;
                    if (row != null)
                    {
                        using (Praktos123Context _context = new Praktos123Context())
                        {
                            _context.Languages.Remove(row);
                            _context.SaveChanges();
                        }
                        LoadDB();
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка.", "Ошибка удаления.", MessageBoxButton.OKCancel, MessageBoxImage.Error);
                }
            }
            else
            {
                LanguageView.Focus();
            }
        }

        private void AddButtonCountries_Click(object sender, RoutedEventArgs e)
        {
            var addCountryWindow = new AddCountryWindow()
            {
                Title = "Добавить запись"
            };
            addCountryWindow.ShowDialog();
            LoadDB();
        }

        private void EditButtonCountries_Click(object sender, RoutedEventArgs e)
        {
            if (CountryView.SelectedItem is Country selectedOrder)
            {
                var addCountryWindow = new AddCountryWindow(selectedOrder)
                {
                    Title = "Редактировать запись"
                };
                addCountryWindow.ShowDialog();
                LoadDB();
            }
        }

        private void DeleteButtonCountries_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result;
            result = MessageBox.Show("Удалить запись?", "Удаление записи.", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    Country row = (Country)CountryView.SelectedItem;
                    if (row != null)
                    {
                        using (Praktos123Context _context = new Praktos123Context())
                        {
                            _context.Countries.Remove(row);
                            _context.SaveChanges();
                        }
                        LoadDB();
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка.", "Ошибка удаления.", MessageBoxButton.OKCancel, MessageBoxImage.Error);
                }
            }
            else
            {
                CountryView.Focus();
            }
        }
    }
}