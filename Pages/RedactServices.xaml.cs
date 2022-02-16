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
    /// Логика взаимодействия для RedactServices.xaml
    /// </summary>
    public partial class RedactServices : Page
    {
        Services service;
        public RedactServices(object ind)
        {
            InitializeComponent();
            int indx = Convert.ToInt32(ind);
            service = DbConnection.SchoolBase.Services.FirstOrDefault(x => x.serviceId == indx);
            servName.Text = service.serviceName;
            servImg.Text = service.mainImg;
            servCost.Text = service.cost.ToString();
            servDuration.Text = service.duration.ToString();
            servDiscount.Text = service.discount.ToString();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            service.serviceName = servName.Text;
            service.mainImg = servImg.Text;
            service.cost = Convert.ToDouble(servCost.Text);
            service.duration = Convert.ToInt32(servDuration.Text);
            service.discount = Convert.ToDouble(servDiscount.Text);
            DbConnection.SchoolBase.SaveChanges();
            PageFrame.MainFrame.GoBack();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.MainFrame.GoBack();
        }
    }
}
