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
    /// Логика взаимодействия для ServiceAdd.xaml
    /// </summary>
    public partial class ServiceAdd : Page
    {
        public ServiceAdd()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Services service = new Services();
            service.serviceName = servName.Text;
            service.mainImg = servImg.Text;
            service.cost = Convert.ToDouble(servCost.Text);
            service.duration = Convert.ToInt32(servDuration.Text);
            service.discount = Convert.ToDouble(servDiscount.Text);
            DbConnection.SchoolBase.Services.Add(service);
        }
    }
}
