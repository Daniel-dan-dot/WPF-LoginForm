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
            CreditList = DB_BANK4Entities1.GetContext().Credits.ToList();

            cbTermCredit.ItemsSource = DB_BANK4Entities1.GetContext().TermCredits.ToList();
            cbTermCredit.SelectedValuePath = "Id";
            cbTermCredit.DisplayMemberPath = "Name";


            CreditName1.Text += CreditList[0].Name.ToString();
            CreditSumm1.Text += CreditList[0].MinimalSumm.ToString();
            CreditContiditions1.Text += CreditList[0].Conditions.ToString();

            CreditName2.Text += CreditList[1].Name.ToString();
            CreditSumm2.Text += CreditList[1].MinimalSumm.ToString();
            CreditContiditions2.Text += CreditList[1].Conditions.ToString();

            CreditName3.Text += CreditList[2].Name.ToString();
            CreditSumm3.Text += CreditList[2].MinimalSumm.ToString();
            CreditContiditions3.Text += CreditList[2].Conditions.ToString();

            CreditName4.Text += CreditList[3].Name.ToString();
            CreditSumm4.Text += CreditList[3].MinimalSumm.ToString();
            CreditContiditions4.Text += CreditList[3].Conditions.ToString();




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
