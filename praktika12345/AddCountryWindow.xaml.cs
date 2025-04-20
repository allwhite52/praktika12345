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
    /// Логика взаимодействия для AddCountryWindow.xaml
    /// </summary>
    public partial class AddCountryWindow : Window
    {
        private Country _country;
        private Praktos123Context _context;
        public AddCountryWindow()
        {
            InitializeComponent();
            _context = new Praktos123Context();
            Height += 20;
            Width += 20;
        }
        public AddCountryWindow(Country country) : this()
        {
            _country = country;
            NameCountryBox.Text = _country.CountryName;
            CapitalCountryBox.Text = _country.Capital;
            ContinentCountryBox.Text = _country.Continent;
            PopulationCountryBox.Text = _country.Populations.ToString();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(NameCountryBox.Text)
                || string.IsNullOrEmpty(CapitalCountryBox.Text)
                || string.IsNullOrEmpty(ContinentCountryBox.Text)
                || string.IsNullOrEmpty(PopulationCountryBox.Text))
            {
                MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!long.TryParse(PopulationCountryBox.Text, out long popul) || popul < 0)
            {
                MessageBox.Show("Население должно быть положительным числом!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            using (Praktos123Context _context = new Praktos123Context())
            {

                if (_country == null)
                {
                    // Добавление нового товара
                    _context.Countries.Add(new Country
                    {
                        CountryName = NameCountryBox.Text,
                        Capital = CapitalCountryBox.Text,
                        Continent = ContinentCountryBox.Text,
                        Populations = long.Parse(PopulationCountryBox.Text)
                    });
                }
                else
                {
                    // Редактирование существующего товара
                    _country.CountryName = NameCountryBox.Text;
                    _country.Capital = CapitalCountryBox.Text;
                    _country.Continent = ContinentCountryBox.Text;
                    _country.Populations = long.Parse(PopulationCountryBox.Text);
                    _context.Countries.Update(_country);
                }
                _context.SaveChanges();
            }
            this.Close();
        }
    }
}
