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
    /// Логика взаимодействия для AddLanguageWindow.xaml
    /// </summary>
    public partial class AddLanguageWindow : Window
    {
        private Language _language;
        private Praktos123Context _context;
        public AddLanguageWindow()
        {
            InitializeComponent();
            _context = new Praktos123Context();
            Height += 20;
            Width += 20;
        }
        public AddLanguageWindow(Language language) : this()
        {
            _language = language;
            NameLanguageBox.Text = _language.LanguageName;
            GroupLanguageBox.Text = _language.LanguageGroup;
            SystemLanguageBox.Text = _language.LanguageSystem;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(NameLanguageBox.Text)
                || string.IsNullOrEmpty(GroupLanguageBox.Text)
                || string.IsNullOrEmpty(SystemLanguageBox.Text))
            {
                MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            

            using (Praktos123Context _context = new Praktos123Context())
            {

                if (_language == null)
                {
                    // Добавление нового товара
                    _context.Languages.Add(new Language
                    {
                        LanguageName = NameLanguageBox.Text,
                        LanguageGroup = GroupLanguageBox.Text,
                        LanguageSystem = SystemLanguageBox.Text,
                    });
                }
                else
                {
                    // Редактирование существующего товара
                    _language.LanguageName = NameLanguageBox.Text;
                    _language.LanguageGroup = GroupLanguageBox.Text;
                    _language.LanguageSystem = SystemLanguageBox.Text;
                    _context.Languages.Update(_language);
                }
                _context.SaveChanges();
            }
            this.Close();
        }
    }
}
