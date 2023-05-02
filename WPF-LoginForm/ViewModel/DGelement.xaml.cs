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
using WPF_LoginForm.Model;

namespace WPF_LoginForm.ViewModel
{
    /// <summary>
    /// Логика взаимодействия для DGelement.xaml
    /// </summary>
    public partial class DGelement : UserControl
    {
        public DGelement()
        {
            InitializeComponent();
            DGclients.ItemsSource = DB_BANK3Entities.GetContext().Employee.ToList();

        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
