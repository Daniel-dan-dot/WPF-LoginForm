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
using WPF_LoginForm.Short;
using WPF_LoginForm.View;

namespace WPF_LoginForm.Pages
{
    /// <summary>
    /// Логика взаимодействия для ContractPage.xaml
    /// </summary>
    public partial class ContractPage : Page
    {
        List<Contract> dataGridList = new List<Contract>();
        List<DepositContract> dataGridListDeposit = new List<DepositContract>();
        List<CreditContract> dataGridListCredit = new List<CreditContract>();
        List<InvestmentContract> dataGridListInvestment = new List<InvestmentContract>();
        List<InsuranceContract> dataGridListInsurance = new List<InsuranceContract>();

        List<ContractShort> ContractList = new List<ContractShort>();
        List<DepositContractShort> ContractListDeposit = new List<DepositContractShort>();
        List<CreditContractShort> ContractListCredit = new List<CreditContractShort>();
        List<InvestmentContractShort> ContractListInvestment = new List<InvestmentContractShort>();
        List<InsuranceContractShort> ContractListInsurance = new List<InsuranceContractShort>();

        public ContractPage()
        {
            InitializeComponent();

            //TODO ДОГОВОРЫ

            dataGridList = DB_BANK4Entities1.GetContext().Contracts.ToList();
            ContractList = dataGridList.Select(s => new ContractShort()
            {
                id = s.Id,
                numberContract = s.NumberContract,
                FIOClient = $"{s.Client.LastName} {s.Client.FirstName[0]}.{s.Client.Patronymic[0]}.",
                date = s.Date.ToString("D"),
                city = s.City,
                score = s.Score.NumberScore,
            }).OrderByDescending(s => s.id).ToList();

            DGcontract.ItemsSource = ContractList.Take(6).ToList();
            pagGrid.MaxPageCount = (int)Math.Ceiling(ContractList.Count / 6.0);

            txtCount.Text = "Найдено записей: ";
            txtCount.Text += ContractList.Count().ToString();

            //TODO ВКЛАДЫ

            dataGridListDeposit = DB_BANK4Entities1.GetContext().DepositContracts.ToList();
            ContractListDeposit = dataGridListDeposit.Select(s => new DepositContractShort()
            {
                id = s.Id,
                numberContract = s.Contract.NumberContract,
                FIOClient = $"{s.Contract.Client.LastName} {s.Contract.Client.FirstName[0]}.{s.Contract.Client.Patronymic[0]}.",
                date = s.Contract.Date.ToString("D"),
                city = s.Contract.City,
                score = s.Contract.Score.NumberScore,
            }).OrderByDescending(s => s.id).ToList();

            DGcontractDeposit.ItemsSource = ContractListDeposit.Take(6).ToList();
            pagGridDeposit.MaxPageCount = (int)Math.Ceiling(ContractListDeposit.Count / 6.0);

            txtCountDeposit.Text = "Найдено записей: ";
            txtCountDeposit.Text += ContractListDeposit.Count().ToString();

            //TODO КРЕДИТЫ

            dataGridListCredit = DB_BANK4Entities1.GetContext().CreditContracts.ToList();
            ContractListCredit = dataGridListCredit.Select(s => new CreditContractShort()
            {
                id = s.Id,
                numberContract = s.Contract.NumberContract,
                FIOClient = $"{s.Contract.Client.LastName} {s.Contract.Client.FirstName[0]}.{s.Contract.Client.Patronymic[0]}.",
                date = s.Contract.Date.ToString("D"),
                city = s.Contract.City,
                score = s.Contract.Score.NumberScore,
            }).OrderByDescending(s => s.id).ToList();

            DGcontractCredit.ItemsSource = ContractListCredit.Take(6).ToList();
            pagGridCredit.MaxPageCount = (int)Math.Ceiling(ContractListCredit.Count / 6.0);

            txtCountCredit.Text = "Найдено записей: ";
            txtCountCredit.Text += ContractListCredit.Count().ToString();


            //TODO ИВЕСТИЦИИ

            dataGridListInvestment = DB_BANK4Entities1.GetContext().InvestmentContracts.ToList();
            ContractListInvestment = dataGridListInvestment.Select(s => new InvestmentContractShort()
            {
                id = s.Id,
                numberContract = s.Contract.NumberContract,
                FIOClient = $"{s.Contract.Client.LastName} {s.Contract.Client.FirstName[0]}.{s.Contract.Client.Patronymic[0]}.",
                date = s.Contract.Date.ToString("D"),
                city = s.Contract.City,
                score = s.Contract.Score.NumberScore,
            }).OrderByDescending(s => s.id).ToList();

            DGcontractInvestment.ItemsSource = ContractListInvestment.Take(6).ToList();
            pagGridInvestment.MaxPageCount = (int)Math.Ceiling(ContractListInvestment.Count / 6.0);

            txtCountInvestment.Text = "Найдено записей: ";
            txtCountInvestment.Text += ContractListInvestment.Count().ToString();


            //TODO СТРАХОВАНИЕ

            dataGridListInsurance = DB_BANK4Entities1.GetContext().InsuranceContracts.ToList();
            ContractListInsurance = dataGridListInsurance.Select(s => new InsuranceContractShort()
            {
                id = s.Id,
                numberContract = s.Contract.NumberContract,
                FIOClient = $"{s.Contract.Client.LastName} {s.Contract.Client.FirstName[0]}.{s.Contract.Client.Patronymic[0]}.",
                date = s.Contract.Date.ToString("D"),
                city = s.Contract.City,
                score = s.Contract.Score.NumberScore,
            }).OrderByDescending(s => s.id).ToList();

            DGcontractInsurance.ItemsSource = ContractListInsurance.Take(6).ToList();
            pagGridInsurance.MaxPageCount = (int)Math.Ceiling(ContractListInsurance.Count / 6.0);

            txtCountInsurance.Text = "Найдено записей: ";
            txtCountInsurance.Text += ContractListInsurance.Count().ToString();


        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void pagGrid_PageUpdated(object sender, HandyControl.Data.FunctionEventArgs<int> e)
        {
            DGcontract.ItemsSource = ContractList.Skip((e.Info - 1) * 6).Take(6).ToList();

        }


        private void btnInfoScore_Click(object sender, RoutedEventArgs e)
        {
            InfoScoreWindow infoScoreWindow = new InfoScoreWindow();
            infoScoreWindow.Show();
        }

        private void btnInfoContractDeposit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnInfoClient_Click(object sender, RoutedEventArgs e)
        {
            ClientInfoWindow clientInfoWindow = new ClientInfoWindow();
            clientInfoWindow.Show();
        }

        private void btnEditContractDeposit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDeleteContractDeposit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEditContractCredit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDeleteContractCredit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEditContractInvestment_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDeleteContractInvestment_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDeleteContractInsurance_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEditContractInsurance_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddButtonCredit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDeleteContract_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEditContract_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnInfoClient_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
