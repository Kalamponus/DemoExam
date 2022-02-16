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

namespace LanguageSchool.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddAppoint.xaml
    /// </summary>
    public partial class AddAppoint : Page
    {
        Classes.LoadServiceToClients loadService;
        public AddAppoint(int serviceId)
        {
            InitializeComponent();
            loadService = new Classes.LoadServiceToClients(serviceId);
            DataContext = loadService;
        }

        private void buttSave_Click(object sender, RoutedEventArgs e)
        {
            if (loadService.SaveData())
                MessageBox.Show("Сохранено успешно");
            else
                MessageBox.Show("Какая-то ошибка");
        }

        private void buttExit_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.MainFrame.GoBack();
        }
    }
}
