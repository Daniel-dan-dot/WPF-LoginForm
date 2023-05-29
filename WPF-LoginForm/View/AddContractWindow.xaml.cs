using HandyControl.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPF_LoginForm.Model;
using WPF_LoginForm.Short;

namespace WPF_LoginForm.View
{
    /// <summary>
    /// Логика взаимодействия для AddContractWindow.xaml
    /// </summary>
    public partial class AddContractWindow : System.Windows.Window
    {
        List<Employee> dataEmployeeList = new List<Employee>();
        List<ShortEmployeeShort> employeeShort = new List<ShortEmployeeShort>();
        List<Client> dataClientList = new List<Client>();
        List<ShortClientShort> clientShort = new List<ShortClientShort>();
        public AddContractWindow()
        {
            InitializeComponent();
            dataEmployeeList = DB_BANK4Entities1.GetContext().Employees.ToList();
            employeeShort = dataEmployeeList.Select(s => new ShortEmployeeShort()
            {
                Id = s.Id,
                FIO = $"{s.LastName} {s.FirstName} {s.Patronymic}",
            }).ToList();

            dataClientList = DB_BANK4Entities1.GetContext().Clients.ToList();
            clientShort = dataClientList.Select(s => new ShortClientShort()
            {
                Id = s.Id,
                FIO = $"{s.LastName} {s.FirstName} {s.Patronymic}",
            }).ToList();

            cbEmployee.ItemsSource = employeeShort.ToList();
            cbEmployee.SelectedValuePath = "Id";
            cbEmployee.DisplayMemberPath = "FIO";

            cbClient.ItemsSource = clientShort.ToList();
            cbClient.SelectedValuePath = "Id";
            cbClient.DisplayMemberPath = "FIO";
        }

        private void CLoseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var _db = DB_BANK4Entities1.GetContext();
            Random r = new Random();
            Contract contract = new Contract();
            contract.NumberContract = $"N{r.Next(1,9)}{r.Next(1, 9)}{r.Next(1, 9)}{r.Next(1, 9)}/{r.Next(1, 9)}{r.Next(1, 9)}{r.Next(1, 9)}{r.Next(1, 9)}{r.Next(1, 9)}/{r.Next(1, 9)}{r.Next(1, 9)}/{r.Next(1, 9)}{r.Next(1, 9)}{r.Next(1, 9)}{r.Next(1, 9)}{r.Next(1, 9)}";
            contract.IdEmployee = (int)cbEmployee.SelectedValue;
            contract.IdClient = (int)cbClient.SelectedValue;
            contract.IdScore = r.Next(1,999);
            contract.City= txtCity.Text;
            contract.Date = (DateTime)dpDate.SelectedDate;

            _db.Contracts.Add(contract);
            _db.SaveChanges();
            this.Close();

            Growl.SuccessGlobal("Данные успешно добавлены");
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left) this.DragMove();

        }
    }
}
