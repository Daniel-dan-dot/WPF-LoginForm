using HandyControl.Controls;
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
using WPF_LoginForm.View;

namespace WPF_LoginForm.Pages
{
    /// <summary>
    /// Логика взаимодействия для CreditPage.xaml
    /// </summary>
    public partial class CreditPage : Page
    {
        List<Credit> CreditList = new List<Credit>();
        List<BetCredit> BetCreditList = new List<BetCredit>();
        byte BetCrId;

        public CreditPage()
        {
            InitializeComponent();

            CreditList = DB_BANK4Entities1.GetContext().Credits.ToList();

            BetCreditList = DB_BANK4Entities1.GetContext().BetCredits.ToList();


            cbTermCredit.ItemsSource = DB_BANK4Entities1.GetContext().TermCredits.ToList();
            cbTermCredit.SelectedValuePath = "Id";
            cbTermCredit.DisplayMemberPath = "Name";

            cbSummCredit.ItemsSource = DB_BANK4Entities1.GetContext().SummCredits.ToList();
            cbSummCredit.SelectedValuePath = "Id";
            cbSummCredit.DisplayMemberPath = "Sum";


            CreditName1.Text += CreditList[0].Name.ToString();
            MinSumm1.Text += CreditList[0].MinimalSumm.ToString();
            Book1.ToolTip += CreditList[0].Conditions.ToString();

            CreditName2.Text += CreditList[1].Name.ToString();
            MinSumm2.Text += CreditList[1].MinimalSumm.ToString();
            Book2.ToolTip += CreditList[1].Conditions.ToString();

            CreditName3.Text += CreditList[2].Name.ToString();
            MinSumm3.Text += CreditList[2].MinimalSumm.ToString();
            Book3.ToolTip += CreditList[2].Conditions.ToString();

            CreditName4.Text += CreditList[3].Name.ToString();
            MinSumm4.Text += CreditList[3].MinimalSumm.ToString();
            Book4.ToolTip+= CreditList[3].Conditions.ToString();


            //DGcredit.ItemsSource = DB_BANK4Entities1.GetContext().Credits.ToList();



        }

        private void Credit1_Click(object sender, RoutedEventArgs e)
        {
            var _db = DB_BANK4Entities1.GetContext();

            int id = (cbTermCredit.SelectedValue as TermCredit).Id;

            //txtBetDeposit.Text = BetDepositList[id].Bet.ToString() + " %";
        }

        private void cbTermCredit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
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

        private void cbSummCredit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            int id = (cbTermCredit.SelectedItem as TermCredit).Id;
            int id2 = (cbSummCredit.SelectedItem as SummCredit).Id;
            var betTemp = BetCreditList.Where(x => x.IdTermCredit == id && x.IdSummCredit == id2).ToList();

            txtBetCredit.Text = betTemp[0].Bet.ToString();

            BetCrId = betTemp[0].Id;

        }

        private void AddSave_Click(object sender, RoutedEventArgs e)
        {
            Growl.Success("Договор был успешно оформлен!");
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddContractWindow contractWindow = new AddContractWindow();
            contractWindow.Show();
        }
    }
}
