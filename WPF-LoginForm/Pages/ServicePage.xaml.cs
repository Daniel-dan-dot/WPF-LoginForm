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
using WPF_LoginForm.View;

namespace WPF_LoginForm.Pages
{
    /// <summary>
    /// Логика взаимодействия для ServicePage.xaml
    /// </summary>
    public partial class ServicePage : Page
    {

        public ServicePage()
        {
            InitializeComponent();
        }

        private void btnDeposit_Click(object sender, RoutedEventArgs e)
        {
            //ServicePage sp = new ServicePage();
            //NavigationService.GetNavigationService(new ServicePage());
        }

        //private void Prev_Click(object sender, RoutedEventArgs e)
        //{
        //    step.Prev();
        //}

        //private void Next_Click(object sender, RoutedEventArgs e)
        //{
        //    step.Next();
        //}
    }
}
