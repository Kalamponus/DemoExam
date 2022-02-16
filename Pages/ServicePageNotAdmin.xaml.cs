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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LanguageSchool.Pages
{
    /// <summary>
    /// Логика взаимодействия для ServicePageNotAdmin.xaml
    /// </summary>
    public partial class ServicePageNotAdmin : Page
    {
        public ServicePageNotAdmin()
        {
            InitializeComponent();
            List<Services> services = DbConnection.SchoolBase.Services.ToList();
            lbServices.ItemsSource = services;
        }

        private void adminBtn_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.MainFrame.Navigate(new adminLogIn());
        }
    }
}
