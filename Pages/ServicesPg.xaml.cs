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
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class ServicesPg : Page
    {
        Classes.LoadServices loadServices = new Classes.LoadServices();
        public ServicesPg()
        {
            InitializeComponent();
            List<Services> services = DbConnection.SchoolBase.Services.ToList();
            lbServices.ItemsSource = services;
        }
        
        private void dbRedact_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;          
            PageFrame.MainFrame.Navigate(new RedactServices(btn.Tag));
            lbServices.Items.Refresh();
        }
        private void buttResetSettings_Click(object sender, RoutedEventArgs e)
        {
            loadServices.ResetFilter();
        }
        private void dbDelete_Click(object sender, RoutedEventArgs e)
        {        
            if (lbServices.SelectedIndex == -1)
                MessageBox.Show("Выберите услугу");
            else
            {
                Button btn = sender as Button;
                int indx = Convert.ToInt32(btn.Tag);
                Services services = DbConnection.SchoolBase.Services.First(x => x.serviceId == indx);
                DbConnection.SchoolBase.Services.Remove(services);
                DbConnection.SchoolBase.SaveChanges();
                lbServices.Items.Refresh();
            }
        }

        private void appointAdd_Click(object sender, RoutedEventArgs e)
        {
            int index = lbServices.SelectedIndex;
            if (index == -1)
                MessageBox.Show("Выберите услугу");
            else
            {
                PageFrame.MainFrame.Navigate(new AddAppoint(loadServices.Services[index].serviceId));
            }
        }

        private void appointNear_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.MainFrame.Navigate(new LatestAppointments());
        }
    }
}
