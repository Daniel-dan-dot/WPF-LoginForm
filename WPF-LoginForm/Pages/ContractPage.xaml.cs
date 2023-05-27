using HandyControl.Controls;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        //List<Contract> dataGridList = new List<Contract>();
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
            //LoadContract();
            
            //TODO ВКЛАДЫ
            LoadDepositContract();
            
            //TODO КРЕДИТЫ
            LoadCreditContract();
            
            //TODO ИВЕСТИЦИИ
            LoadInvestmentContract();
            
            //TODO СТРАХОВАНИЕ
            LoadInsuranceContract();
        }

        private void LoadInsuranceContract()
        {
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
        private void LoadInvestmentContract()
        {
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
        }
        private void LoadCreditContract()
        {
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
        }
        //private void LoadContract()
        //{
        //    dataGridList = DB_BANK4Entities1.GetContext().Contracts.ToList();
        //    ContractList = dataGridList.Select(s => new ContractShort()
        //    {
        //        id = s.Id,
        //        numberContract = s.NumberContract,
        //        FIOClient = $"{s.Client.LastName} {s.Client.FirstName[0]}.{s.Client.Patronymic[0]}.",
        //        date = s.Date.ToString("D"),
        //        city = s.City,
        //        score = s.Score.NumberScore,
        //    }).OrderByDescending(s => s.id).ToList();

        //    DGcontract.ItemsSource = ContractList.Take(6).ToList();
        //    pagGrid.MaxPageCount = (int)Math.Ceiling(ContractList.Count / 6.0);

        //    txtCount.Text = "Найдено записей: ";
        //    txtCount.Text += ContractList.Count().ToString();
        //}

        private void LoadDepositContract()
        {
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
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {

        }



        //private void btnInfoScore_Click(object sender, RoutedEventArgs e)
        //{
        //    var _db = DB_BANK4Entities1.GetContext();

        //    InfoScoreWindow infoScoreWindow = new InfoScoreWindow();
        //    Contract contract = new Contract();


        //    infoScoreWindow.Show();
        //    int id = (DGcontract.SelectedItem as ContractShort).id;
        //    contract = _db.Contracts.Find(id);

        //    _db.SaveChanges();
        //    LoadDepositContract();


        //    infoScoreWindow.txtNumberScore.Text = contract.Score.NumberScore;
        //    infoScoreWindow.txtBIC.Text = contract.Score.BIC;
        //    infoScoreWindow.txtTRCC.Text = contract.Score.TRRC;
        //    infoScoreWindow.txtTypeScore.Text = contract.Score.TypeScore.Name;

        //}

        //private void btnInfoContractDeposit_Click(object sender, RoutedEventArgs e)
        //{
        //    var _db = DB_BANK4Entities1.GetContext();

        //    InfoScoreWindow infoScoreWindow = new InfoScoreWindow();
        //    DepositContract contract = new DepositContract();


        //    infoScoreWindow.Show();
        //    int id = (DGcontractDeposit.SelectedItem as ContractShort).id;
        //    contract = _db.DepositContracts.Find(id);

        //    _db.SaveChanges();
        //    LoadDepositContract();


        //    infoScoreWindow.txtNumberScore.Text = contract.Contract.Score.NumberScore;
        //    infoScoreWindow.txtBIC.Text = contract.Contract.Score.BIC;
        //    infoScoreWindow.txtTRCC.Text = contract.Contract.Score.TRRC;
        //    infoScoreWindow.txtTypeScore.Text = contract.Contract.Score.TypeScore.Name;
        //}



        private void btnDeleteContractDeposit_Click(object sender, RoutedEventArgs e)
        {
            var _db = DB_BANK4Entities1.GetContext();
            var dialog = new NotificationWindow();
            if (dialog.ShowDialog() == true)
            {
                int id = (DGcontractDeposit.SelectedItem as DepositContractShort).id;
                DepositContract depositContract = _db.DepositContracts.Find(id);
                _db.DepositContracts.Remove(depositContract); _db.SaveChanges();
                LoadDepositContract();
                Growl.Success("Договор успешно удален!");
            }
        }



        private void btnDeleteContractCredit_Click(object sender, RoutedEventArgs e)
        {
            var _db = DB_BANK4Entities1.GetContext();
            var dialog = new NotificationWindow();
            if (dialog.ShowDialog() == true)
            {
                int id = (DGcontractCredit.SelectedItem as CreditContractShort).id;
                CreditContract creditContract = _db.CreditContracts.Find(id);
                _db.CreditContracts.Remove(creditContract); _db.SaveChanges();
                LoadCreditContract();
                Growl.Success("Договор успешно удален!");
            }
        }

        private void btnEditContractInvestment_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDeleteContractInvestment_Click(object sender, RoutedEventArgs e)
        {
            var _db = DB_BANK4Entities1.GetContext();
            var dialog = new NotificationWindow();
            if (dialog.ShowDialog() == true)
            {
                int id = (DGcontractInvestment.SelectedItem as InvestmentContractShort).id;
                InvestmentContract investmentContract = _db.InvestmentContracts.Find(id);
                _db.InvestmentContracts.Remove(investmentContract); _db.SaveChanges();
                LoadInvestmentContract();
                Growl.Success("Договор успешно удален!");
            }
        }

        private void btnDeleteContractInsurance_Click(object sender, RoutedEventArgs e)
        {
            var _db = DB_BANK4Entities1.GetContext();
            var dialog = new NotificationWindow();
            if (dialog.ShowDialog() == true)
            {
                int id = (DGcontractInsurance.SelectedItem as InsuranceContractShort).id;
                InsuranceContract insuranceContract = _db.InsuranceContracts.Find(id);

                _db.InsuranceContracts.Remove(insuranceContract);
                _db.SaveChanges();
                LoadInsuranceContract();
                Growl.Success("Договор успешно удален!");
            }
        }



        private void AddButtonCredit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddButtonDeposit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DepositPage()); 

        }

        private void btnInfoDepositScore_Click(object sender, RoutedEventArgs e)
        {
            var _db = DB_BANK4Entities1.GetContext();

            InfoScoreWindow infoScoreWindow = new InfoScoreWindow();
            DepositContract contract = new DepositContract();


            infoScoreWindow.Show();
            int id = (DGcontractDeposit.SelectedItem as DepositContractShort).id;
            contract = _db.DepositContracts.Find(id);

            _db.SaveChanges();
            LoadDepositContract();


            infoScoreWindow.txtNumberScore.Text = contract.Contract.Score.NumberScore;
            infoScoreWindow.txtBIC.Text = contract.Contract.Score.BIC;
            infoScoreWindow.txtTRCC.Text = contract.Contract.Score.TRRC;
            infoScoreWindow.txtTypeScore.Text = contract.Contract.Score.TypeScore.Name;
        }

        private void btnInfoClientDeposit_Click(object sender, RoutedEventArgs e)
        {
            var _db = DB_BANK4Entities1.GetContext();

            ClientInfoWindow clientInfoWindow = new ClientInfoWindow();
            DepositContract contract = new DepositContract();


            clientInfoWindow.Show();
            int id = (DGcontractDeposit.SelectedItem as DepositContractShort).id;
            contract = _db.DepositContracts.Find(id);

            _db.SaveChanges();
            LoadDepositContract();


            clientInfoWindow.txtLastName.Text = contract.Contract.Client.LastName;
            clientInfoWindow.txtFirstName.Text = contract.Contract.Client.FirstName;
            clientInfoWindow.txtPatronymic.Text = contract.Contract.Client.Patronymic;
            clientInfoWindow.txtDateOfBirth.Text = contract.Contract.Client.DateOfBirth.ToString("D");
            clientInfoWindow.txtAddress.AppendText(contract.Contract.Client.Address);
            clientInfoWindow.txtPhone.Text = contract.Contract.Client.Telephone;
            clientInfoWindow.txtTypeClient.Text = contract.Contract.Client.TypeClient.Name;
            clientInfoWindow.txtSerialPassport.Text = contract.Contract.Client.ClientInfo.SerialPassport;
            clientInfoWindow.txtNumberPassport.Text = contract.Contract.Client.ClientInfo.NumberPassport;
            clientInfoWindow.txtIssuedBy.AppendText(contract.Contract.Client.ClientInfo.IssuedBy);
            clientInfoWindow.txtDateIssued.Text = contract.Contract.Client.ClientInfo.DateOfIssue.ToString("D");
            clientInfoWindow.txtINN.Text = contract.Contract.Client.ClientInfo.INN;
            clientInfoWindow.txtSNILS.Text = contract.Contract.Client.ClientInfo.SNILS;
        }

        private void btnInfoClientCredit_Click(object sender, RoutedEventArgs e)
        {
            var _db = DB_BANK4Entities1.GetContext();

            ClientInfoWindow clientInfoWindow = new ClientInfoWindow();
            CreditContract contract = new CreditContract();


            clientInfoWindow.Show();
            int id = (DGcontractCredit.SelectedItem as CreditContractShort).id;
            contract = _db.CreditContracts.Find(id);

            _db.SaveChanges();
            LoadCreditContract();


            clientInfoWindow.txtLastName.Text = contract.Contract.Client.LastName;
            clientInfoWindow.txtFirstName.Text = contract.Contract.Client.FirstName;
            clientInfoWindow.txtPatronymic.Text = contract.Contract.Client.Patronymic;
            clientInfoWindow.txtDateOfBirth.Text = contract.Contract.Client.DateOfBirth.ToString("D");
            clientInfoWindow.txtAddress.AppendText(contract.Contract.Client.Address);
            clientInfoWindow.txtPhone.Text = contract.Contract.Client.Telephone;
            clientInfoWindow.txtTypeClient.Text = contract.Contract.Client.TypeClient.Name;
            clientInfoWindow.txtSerialPassport.Text = contract.Contract.Client.ClientInfo.SerialPassport;
            clientInfoWindow.txtNumberPassport.Text = contract.Contract.Client.ClientInfo.NumberPassport;
            clientInfoWindow.txtIssuedBy.AppendText(contract.Contract.Client.ClientInfo.IssuedBy);
            clientInfoWindow.txtDateIssued.Text = contract.Contract.Client.ClientInfo.DateOfIssue.ToString("D");
            clientInfoWindow.txtINN.Text = contract.Contract.Client.ClientInfo.INN;
            clientInfoWindow.txtSNILS.Text = contract.Contract.Client.ClientInfo.SNILS;
        }

        private void btnInfoScoreCredit_Click(object sender, RoutedEventArgs e)
        {
            var _db = DB_BANK4Entities1.GetContext();

            InfoScoreWindow infoScoreWindow = new InfoScoreWindow();
            CreditContract contract = new CreditContract();


            infoScoreWindow.Show();
            int id = (DGcontractCredit.SelectedItem as CreditContractShort).id;
            contract = _db.CreditContracts.Find(id);

            _db.SaveChanges();
            LoadCreditContract();


            infoScoreWindow.txtNumberScore.Text = contract.Contract.Score.NumberScore;
            infoScoreWindow.txtBIC.Text = contract.Contract.Score.BIC;
            infoScoreWindow.txtTRCC.Text = contract.Contract.Score.TRRC;
            infoScoreWindow.txtTypeScore.Text = contract.Contract.Score.TypeScore.Name;
        }

        private void btnInfoClientInvestment_Click(object sender, RoutedEventArgs e)
        {
            var _db = DB_BANK4Entities1.GetContext();

            ClientInfoWindow clientInfoWindow = new ClientInfoWindow();
            InvestmentContract contract = new InvestmentContract();


            clientInfoWindow.Show();
            int id = (DGcontractInvestment.SelectedItem as InvestmentContractShort).id;
            contract = _db.InvestmentContracts.Find(id);

            _db.SaveChanges();
            LoadInvestmentContract();


            clientInfoWindow.txtLastName.Text = contract.Contract.Client.LastName;
            clientInfoWindow.txtFirstName.Text = contract.Contract.Client.FirstName;
            clientInfoWindow.txtPatronymic.Text = contract.Contract.Client.Patronymic;
            clientInfoWindow.txtDateOfBirth.Text = contract.Contract.Client.DateOfBirth.ToString("D");
            clientInfoWindow.txtAddress.AppendText(contract.Contract.Client.Address);
            clientInfoWindow.txtPhone.Text = contract.Contract.Client.Telephone;
            clientInfoWindow.txtTypeClient.Text = contract.Contract.Client.TypeClient.Name;
            clientInfoWindow.txtSerialPassport.Text = contract.Contract.Client.ClientInfo.SerialPassport;
            clientInfoWindow.txtNumberPassport.Text = contract.Contract.Client.ClientInfo.NumberPassport;
            clientInfoWindow.txtIssuedBy.AppendText(contract.Contract.Client.ClientInfo.IssuedBy);
            clientInfoWindow.txtDateIssued.Text = contract.Contract.Client.ClientInfo.DateOfIssue.ToString("D");
            clientInfoWindow.txtINN.Text = contract.Contract.Client.ClientInfo.INN;
            clientInfoWindow.txtSNILS.Text = contract.Contract.Client.ClientInfo.SNILS;
        }

        private void AddButtonInvestment_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnInfoClientInsurance_Click(object sender, RoutedEventArgs e)
        {
            var _db = DB_BANK4Entities1.GetContext();

            ClientInfoWindow clientInfoWindow = new ClientInfoWindow();
            InsuranceContract contract = new InsuranceContract();


            clientInfoWindow.Show();
            int id = (DGcontractInsurance.SelectedItem as InsuranceContractShort).id;
            contract = _db.InsuranceContracts.Find(id);

            _db.SaveChanges();
            LoadInsuranceContract();


            clientInfoWindow.txtLastName.Text = contract.Contract.Client.LastName;
            clientInfoWindow.txtFirstName.Text = contract.Contract.Client.FirstName;
            clientInfoWindow.txtPatronymic.Text = contract.Contract.Client.Patronymic;
            clientInfoWindow.txtDateOfBirth.Text = contract.Contract.Client.DateOfBirth.ToString("D");
            clientInfoWindow.txtAddress.AppendText(contract.Contract.Client.Address);
            clientInfoWindow.txtPhone.Text = contract.Contract.Client.Telephone;
            clientInfoWindow.txtTypeClient.Text = contract.Contract.Client.TypeClient.Name;
            clientInfoWindow.txtSerialPassport.Text = contract.Contract.Client.ClientInfo.SerialPassport;
            clientInfoWindow.txtNumberPassport.Text = contract.Contract.Client.ClientInfo.NumberPassport;
            clientInfoWindow.txtIssuedBy.AppendText(contract.Contract.Client.ClientInfo.IssuedBy);
            clientInfoWindow.txtDateIssued.Text = contract.Contract.Client.ClientInfo.DateOfIssue.ToString("D");
            clientInfoWindow.txtINN.Text = contract.Contract.Client.ClientInfo.INN;
            clientInfoWindow.txtSNILS.Text = contract.Contract.Client.ClientInfo.SNILS;
        }

        private void btnInfoScoreInsurance_Click(object sender, RoutedEventArgs e)
        {
            var _db = DB_BANK4Entities1.GetContext();

            InfoScoreWindow infoScoreWindow = new InfoScoreWindow();
            InsuranceContract contract = new InsuranceContract();


            infoScoreWindow.Show();
            int id = (DGcontractInsurance.SelectedItem as InsuranceContractShort).id;
            contract = _db.InsuranceContracts.Find(id);

            _db.SaveChanges();
            LoadInsuranceContract();


            infoScoreWindow.txtNumberScore.Text = contract.Contract.Score.NumberScore;
            infoScoreWindow.txtBIC.Text = contract.Contract.Score.BIC;
            infoScoreWindow.txtTRCC.Text = contract.Contract.Score.TRRC;
            infoScoreWindow.txtTypeScore.Text = contract.Contract.Score.TypeScore.Name;
        }

        private void AddButtonInsurance_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnInfoScoreInvestment_Click(object sender, RoutedEventArgs e)
        {
            var _db = DB_BANK4Entities1.GetContext();

            InfoScoreWindow infoScoreWindow = new InfoScoreWindow();
            InvestmentContract contract = new InvestmentContract();


            infoScoreWindow.Show();
            int id = (DGcontractInvestment.SelectedItem as InvestmentContractShort).id;
            contract = _db.InvestmentContracts.Find(id);

            _db.SaveChanges();
            LoadInvestmentContract();


            infoScoreWindow.txtNumberScore.Text = contract.Contract.Score.NumberScore;
            infoScoreWindow.txtBIC.Text = contract.Contract.Score.BIC;
            infoScoreWindow.txtTRCC.Text = contract.Contract.Score.TRRC;
            infoScoreWindow.txtTypeScore.Text = contract.Contract.Score.TypeScore.Name;
        }

        private void pagGridDeposit_PageUpdated(object sender, HandyControl.Data.FunctionEventArgs<int> e)
        {
            DGcontractDeposit.ItemsSource = ContractListDeposit.Skip((e.Info - 1) * 6).Take(6).ToList();

        }

        private void pagGridCredit_PageUpdated(object sender, HandyControl.Data.FunctionEventArgs<int> e)
        {
            DGcontractCredit.ItemsSource = ContractListCredit.Skip((e.Info - 1) * 6).Take(6).ToList();

        }

        private void pagGridInvestment_PageUpdated(object sender, HandyControl.Data.FunctionEventArgs<int> e)
        {
            DGcontractInvestment.ItemsSource = ContractListInvestment.Skip((e.Info - 1) * 6).Take(6).ToList();

        }

        private void pagGridInsurance_PageUpdated(object sender, HandyControl.Data.FunctionEventArgs<int> e)
        {
            DGcontractInsurance.ItemsSource = ContractListInsurance.Skip((e.Info - 1) * 6).Take(6).ToList();

        }
    }
}
