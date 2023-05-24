using HandyControl.Tools;
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

namespace WPF_LoginForm.Pages
{
    /// <summary>
    /// Логика взаимодействия для HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        List<Contract> dataGridList = new List<Contract>();
        List<ContractSuperShort> ContractList = new List<ContractSuperShort>();
        List<Client> dataGridListClient = new List<Client>();
        List<Employee> dataGridListEmployee = new List<Employee>();


        public HomePage()
        {
            InitializeComponent();
            ConfigHelper.Instance.SetLang("ru");

            dataGridList = DB_BANK4Entities1.GetContext().Contracts.ToList();
            ContractList = dataGridList.Select(s => new ContractSuperShort()
            {
                id = s.Id,
                numberContract = s.NumberContract,
                FIOClient = $"{s.Client.LastName} {s.Client.FirstName[0]}.{s.Client.Patronymic[0]}.",
            }).ToList();

            FIO1.Text += ContractList[ContractList.Count-1].FIOClient.ToString();
            contract1.Text+= ContractList[ContractList.Count - 1].numberContract.ToString();
            FIO2.Text += ContractList[ContractList.Count - 2].FIOClient.ToString();
            contract2.Text += ContractList[ContractList.Count - 2].numberContract.ToString();
            FIO3.Text += ContractList[ContractList.Count - 3].FIOClient.ToString();
            contract3.Text += ContractList[ContractList.Count - 3].numberContract.ToString();
            FIO4.Text += ContractList[ContractList.Count - 4].FIOClient.ToString();
            contract4.Text += ContractList[ContractList.Count-4].numberContract.ToString();
            FIO5.Text += ContractList[ContractList.Count - 5].FIOClient.ToString();
            contract5.Text += ContractList[ContractList.Count - 5].numberContract.ToString();
            //DGcontract.ItemsSource = ContractList.Take(4).ToList();

            dataGridListClient = DB_BANK4Entities1.GetContext().Clients.ToList();
            dataGridListEmployee = DB_BANK4Entities1.GetContext().Employees.ToList();

            countContracts.Text += dataGridList.Count().ToString();
            countClients.Text += dataGridListClient.Count().ToString();
            countEmployees.Text += dataGridListEmployee.Count().ToString();



        }
    }
}

