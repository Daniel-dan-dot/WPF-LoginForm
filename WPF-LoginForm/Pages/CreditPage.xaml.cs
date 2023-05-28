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

namespace WPF_LoginForm.Pages
{
    /// <summary>
    /// Логика взаимодействия для CreditPage.xaml
    /// </summary>
    public partial class CreditPage : Page
    {
        List<Credit> CreditList = new List<Credit>();
        List<BetCredit> BetCreditList = new List<BetCredit>();
        public CreditPage()
        {
            InitializeComponent();

            cbTermCredit.ItemsSource = DB_BANK4Entities1.GetContext().TermCredits.ToList();
            cbTermCredit.SelectedValuePath = "Id";
            cbTermCredit.DisplayMemberPath = "Name";


            DGcredit.ItemsSource = DB_BANK4Entities1.GetContext().Credits.ToList();



        }

        private void Credit1_Click(object sender, RoutedEventArgs e)
        {
            var _db = DB_BANK4Entities1.GetContext();

            int id = (cbTermCredit.SelectedValue as TermDeposit).Id;

            //txtBetDeposit.Text = BetDepositList[id].Bet.ToString() + " %";
        }

        private void Credit2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Credit3_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Credit4_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
