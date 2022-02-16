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
    /// Логика взаимодействия для adminLogIn.xaml
    /// </summary>
    public partial class adminLogIn : Page
    {
        public adminLogIn()
        {
            InitializeComponent();
        }
        private void adminLogInBtn_Click(object sender, RoutedEventArgs e)
        {
            if (adminCode.Text.GetHashCode().Equals(Classes.AdminPassword.password.GetHashCode()))
            {
                MessageBox.Show("Вы вошли как администратор");
                CurrUser.IsAdministrator = true;
                PageFrame.MainFrame.Navigate(new ServicesPg());
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.MainFrame.GoBack();
        }
    }
}
