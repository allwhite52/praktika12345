using Microsoft.EntityFrameworkCore;
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
    /// Логика взаимодействия для AddSquadWindow.xaml
    /// </summary>
    public partial class AddSquadWindow : Window
    {
        private Squad _squad;
        private Praktos123Context _context;
        public AddSquadWindow()
        {
            InitializeComponent();
            _context = new Praktos123Context();
            Height += 20;
            Width += 20;
        }
        public AddSquadWindow(Squad squad) : this()
        {
            _squad = squad;
            CountryIdSquadBox.Text = _squad.CountryId.ToString();
            LanguageIdSquadBox.Text = _squad.LanguageId.ToString();
            SpeakersCountSquadBox.Text = _squad.SpeakersCount.ToString();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(CountryIdSquadBox.Text)
                || string.IsNullOrEmpty(LanguageIdSquadBox.Text)
                || string.IsNullOrEmpty(SpeakersCountSquadBox.Text))
            {
                MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!int.TryParse(CountryIdSquadBox.Text, out int country) || country < 0)
            {
                MessageBox.Show("Код страны должен быть положительным числом!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!int.TryParse(LanguageIdSquadBox.Text, out int lang) || lang < 0)
            {
                MessageBox.Show("Код языка должен быть положительным числом!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!long.TryParse(SpeakersCountSquadBox.Text, out long speakers) || speakers < 0)
            {
                MessageBox.Show("Кол-во говорящих должно быть положительным числом!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            using (Praktos123Context _context = new Praktos123Context())
            {

                if (_squad == null)
                {
                    // Добавление нового товара
                    _context.Squads.Add(new Squad
                    {
                        CountryId = int.Parse(CountryIdSquadBox.Text),
                        LanguageId = int.Parse(LanguageIdSquadBox.Text),
                        SpeakersCount = long.Parse(SpeakersCountSquadBox.Text)
                    });
                }
                else
                {
                    // Редактирование существующего товара
                    _squad.CountryId = int.Parse(CountryIdSquadBox.Text);
                    _squad.LanguageId = int.Parse(LanguageIdSquadBox.Text);
                    _squad.SpeakersCount = long.Parse(SpeakersCountSquadBox.Text);
                    _context.Squads.Update(_squad);
                }
                _context.SaveChanges();
            }
            this.Close();
        }
    
    }
}
