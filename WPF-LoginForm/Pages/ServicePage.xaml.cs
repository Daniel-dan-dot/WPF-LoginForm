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
            NavigationService.Navigate(new DepositPage());
        }

        private void btnCredit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CreditPage());

        }

        private void btnInsurance_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new InsurancePage());

        }

        private void btnInvetment_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new InvestmentPage());

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
