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
    /// Логика взаимодействия для InvestmentPage.xaml
    /// </summary>
    public partial class InvestmentPage : Page
    {
        List<BetInvestment> BetInvestmentList = new List<BetInvestment>();
        List<Investment> InvestmentList = new List<Investment>();

        byte BetInvestId;
        public InvestmentPage()
        {
            InitializeComponent();
            AddSave.IsEnabled = false;

            DGinvestment.ItemsSource = DB_BANK4Entities1.GetContext().Investments.ToList();

            InvestmentList = DB_BANK4Entities1.GetContext().Investments.ToList();

            BetInvestmentList = DB_BANK4Entities1.GetContext().BetInvestments.ToList();


            cbTermInvestment.ItemsSource = DB_BANK4Entities1.GetContext().TermInvestments.ToList();
            cbTermInvestment.SelectedValuePath = "Id";
            cbTermInvestment.DisplayMemberPath = "Name";
        }

        private void cbTermInvestment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int id = (cbTermInvestment.SelectedItem as TermInvestment).Id;
            var betTemp = BetInvestmentList.Where(x => x.IdTermInvestment == id).ToList();

            txtBetInvestment.Text = betTemp[0].Bet.ToString();

            BetInvestId = betTemp[0].Id;
        }

        private void AddSave_Click(object sender, RoutedEventArgs e)
        {
            Growl.Success("Договор был успешно оформлен!");
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddContractWindow contractWindow = new AddContractWindow();
            contractWindow.Show();
            AddSave.IsEnabled = true;

        }
    }
}
