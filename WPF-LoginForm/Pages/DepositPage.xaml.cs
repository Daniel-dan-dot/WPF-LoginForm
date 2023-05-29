using HandyControl.Controls;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
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
using WPF_LoginForm.Short;
using WPF_LoginForm.View;

namespace WPF_LoginForm.Pages
{
    /// <summary>
    /// Логика взаимодействия для DepositPage.xaml
    /// </summary>
    public partial class DepositPage : Page
    {
        List<Deposit> DepositList = new List<Deposit>();
        List<BetDeposit> BetDepositList = new List<BetDeposit>();

        byte BetDepId;

        public DepositPage()
        {
            InitializeComponent();
            DepositList = DB_BANK4Entities1.GetContext().Deposits.ToList();

            BetDepositList = DB_BANK4Entities1.GetContext().BetDeposits.ToList();


            cbTermDeposit.ItemsSource = DB_BANK4Entities1.GetContext().TermDeposits.ToList();
            cbTermDeposit.SelectedValuePath = "Id";
            cbTermDeposit.DisplayMemberPath = "Name";


            DepName1.Text += DepositList[0].Name.ToString();
            DepSumm1.Text += DepositList[0].MinimalSumm.ToString();
            if (DepositList[0].PossibilityOfReplenishment == true)
                DepPR1.Text += "✓";
            else
                DepPR1.Text += "—";

            if (DepositList[0].PossibilityOfWithdrawal == true)

                DepPW1.Text += "✓";
            else
                DepPW1.Text += "—";



            DepName2.Text += DepositList[1].Name.ToString();
            DepSumm2.Text += DepositList[1].MinimalSumm.ToString();
            if (DepositList[1].PossibilityOfReplenishment == true)
                DepPR2.Text += "✓";
            else
                DepPR2.Text += "—";

            if (DepositList[1].PossibilityOfWithdrawal == true)

                DepPW2.Text += "✓";
            else
                DepPW2.Text += "—";


            DepName3.Text += DepositList[2].Name.ToString();
            DepSumm3.Text += DepositList[2].MinimalSumm.ToString();
            if (DepositList[2].PossibilityOfReplenishment == true)
                DepPR3.Text += "✓";
            else
                DepPR3.Text += "—";

            if (DepositList[2].PossibilityOfWithdrawal == true)

                DepPW3.Text += "✓";
            else
                DepPW3.Text += "—";


            DepName4.Text += DepositList[3].Name.ToString();
            DepSumm4.Text += DepositList[3].MinimalSumm.ToString();
            if (DepositList[4].PossibilityOfReplenishment == true)
                DepPR4.Text += "✓";
            else
                DepPR4.Text += "—";

            if (DepositList[3].PossibilityOfWithdrawal == true)

                DepPW4.Text += "✓";
            else
                DepPW4.Text += "—";

            DepName5.Text += DepositList[4].Name.ToString();
            DepSumm5.Text += DepositList[4].MinimalSumm.ToString();
            if (DepositList[4].PossibilityOfReplenishment == true)
                DepPR5.Text += "✓";
            else
                DepPR5.Text += "—";

            if (DepositList[4].PossibilityOfWithdrawal == true)

                DepPW5.Text += "✓";
            else
                DepPW5.Text += "—";

            DepName6.Text += DepositList[5].Name.ToString();
            DepSumm6.Text += DepositList[5].MinimalSumm.ToString();
            if (DepositList[5].PossibilityOfReplenishment == true)
                DepPR6.Text += "✓";
            else
                DepPR6.Text += "—";

            if (DepositList[5].PossibilityOfWithdrawal == true)

                DepPW6.Text += "✓";
            else
                DepPW6.Text += "—";


        }

        private void Deposit1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Deposit2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Deposit3_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Deposit4_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Deposit5_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Deposit6_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cbTermDeposit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            int id = (cbTermDeposit.SelectedItem as TermDeposit).Id;
            var betTemp = BetDepositList.Where(x => x.IdTermDeposit == id).ToList();

            txtBetDeposit.Text = betTemp[0].Bet.ToString();

            BetDepId = betTemp[0].Id;
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
